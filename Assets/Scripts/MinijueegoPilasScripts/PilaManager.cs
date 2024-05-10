using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PilaManager : MonoBehaviour
{
    [SerializeField] public GameObject pila1;
    [SerializeField] public GameObject pila2;
    [SerializeField] public GameObject Agua;
    [SerializeField] public GameObject victoriaPanel;
    [SerializeField] public GameObject derrotaPanel;
    [SerializeField] public GameObject tutorialPanel;
    [SerializeField] public float tiempoMaximo;
    [SerializeField] public TextMeshProUGUI tempo;
    public float tiempoActual;
    public bool tiempoActivado = false;
    public Scene currentScene;
    [SerializeField] public GameObject cursor;

    void Start()
    {
        pila1 = GameObject.FindGameObjectWithTag("Player");

        if (!tutorialPanel.activeInHierarchy) ActivarTemporizador();

        cursor = GameObject.FindGameObjectWithTag("Cursor");
        cursor.SetActive(false);

        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (tiempoActivado) CambiarContador();
    }

    public void Victoria()
    {
        cursor.SetActive(true);

        if (currentScene.name == "Pila_Nivel1")
        {
            Data.instance.vecesSamuraiAyudado++;
            Data.instance.samuraiAyudado1 = true;
        }

        else if (currentScene.name == "Pila_Nivel2")
        {
            Data.instance.vecesSamuraiAyudado++;
            Data.instance.samuraiAyudado2 = true;
        }

        victoriaPanel.GetComponent<FadeToBlack>().FadeToBlackAnywhere();
    }

    public void VictoryButton()
    {
        if(currentScene.name == "Pila_Nivel1")
            SceneManager.LoadScene("Day2_2");

        else if (currentScene.name == "Pila_Nivel2")
            SceneManager.LoadScene("Day3_2");
    }

    public void LoseButton()
    {
        if (currentScene.name == "Pila_Nivel1")
            SceneManager.LoadScene("Day2_2");

        else if (currentScene.name == "Pila_Nivel2")
            SceneManager.LoadScene("Day3_2");
    }

    public void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual >= 0)
        {
            tempo.text = "" + tiempoActual.ToString("f0");
        }

        if (tiempoActual <= 0)
        {
            Debug.Log("Derrota");
            victoriaPanel.GetComponent<FadeToBlack>().FadeToBlackAnywhere();
            Destroy(pila1);
            Destroy(pila2);
            tiempoActivado = false;
            cursor.SetActive(true);
        }

        if (tiempoActual <= 10)
        {
            tempo.color = Color.red;
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
        tempo.text = "" + tiempoMaximo.ToString("f0");
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}
