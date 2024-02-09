using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PilaManager : MonoBehaviour
{
    [SerializeField] public GameObject pila1;
    [SerializeField] public GameObject pila2;
    [SerializeField] public GameObject victoriaPanel;
    [SerializeField] public GameObject derrotaPanel;
    [SerializeField] public float tiempoMaximo;
    [SerializeField] public Slider slider;
    public float tiempoActual;
    public bool tiempoActivado = false;
    public Animation anim;

    void Start()
    {
        pila1 = GameObject.FindGameObjectWithTag("Player");
        ActivarTemporizador();
        //anim = GetComponent<Animation>();
        //StartCoroutine(EsperarAnimacion());
    }

    void Update()
    {
        if (tiempoActivado)
        {
            CambiarContador();
        }
    }

    //IEnumerator EsperarAnimacion()
    //{
    //    anim.Play();

    //    yield return new WaitForSeconds(anim.clip.length);
    //}


    public void Victoria()
    {
        victoriaPanel.SetActive(true);
    }

    public void VolverButton()
    {
        SceneManager.LoadScene(0);
    }

    public void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if(tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }

        if(tiempoActual <= 0)
        {
            Debug.Log("Derrota");
            derrotaPanel.SetActive(true);
            Destroy(pila1);
            Destroy(pila2);
            tiempoActivado = false;
        }
    }

    public void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}
