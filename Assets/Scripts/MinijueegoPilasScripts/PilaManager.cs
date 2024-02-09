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
    [SerializeField] public GameObject tutorialPanel;
    [SerializeField] public float tiempoMaximo;
    [SerializeField] public Slider slider;
    public float tiempoActual;
    public bool tiempoActivado = false;

    void Start()
    {
        pila1 = GameObject.FindGameObjectWithTag("Player");

        if (!tutorialPanel.activeInHierarchy) ActivarTemporizador();
    }

    void Update()
    {
        if (tiempoActivado) CambiarContador();
    }

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

        if (tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }

        if (tiempoActual <= 0)
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
        pila1.GetComponent<Pila>().enabled = true;
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}
