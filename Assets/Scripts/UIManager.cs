using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject canvasPausa;
    [SerializeField] public GameObject canvasVictory;

    [SerializeField] public Scene currentScene;
    [SerializeField] GameObject normativas;
    [SerializeField] GameObject precios;

    [Header("RELATED TO THE DROPDOWN MENU WITH THE LIST OF ITEMS")]
    [SerializeField] public bool listOpen = false;
    [SerializeField] public GameObject dropDownPanel;
    [SerializeField] public GameObject botonPlegado;
    [SerializeField] public GameObject botonDesplegado;
    [SerializeField] public GameObject position1;
    [SerializeField] public GameObject position2;

    [Header("ITS ALL ABOUT THE MONEY MONEY MONEY")]
    [SerializeField] public GameObject leDinero;
    [SerializeField] public GameObject leCajaRegistradora;
    [SerializeField] public GameObject lesPropinas;
    [SerializeField] public TMP_Text leDineroText;
    [SerializeField] public TMP_Text lePropinasText;
    [SerializeField] public float propinasNumber = 0;
    [SerializeField] public bool estaToPagao = false;

    [SerializeField] public List<string> quejas;

    void Start()
    {
        canvasPausa = gameObject.transform.GetChild(7).gameObject;
        canvasVictory = gameObject.transform.GetChild(8).gameObject;
        currentScene = SceneManager.GetActiveScene();
        botonPlegado.SetActive(false);
        estaToPagao = false;

        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! CHICO NUEVO, MENOS SUELDO…");                  // Si no le has cobrado y sí deberias haberle cobrado.
        quejas.Add("¡Tendrías que haberle echado a patadas, no tenía el dinero suficiente!");                   // Si sí le has cobrado y no deberías haberle cobrado.
        quejas.Add("¡Aquí tenemos unas normas! ¡¿Las recuerdas?!");                                             // Cuando no has cumplido las normativas.
        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! ¡Tenía dinero y no rompía ninguna norma!");    // Si no le has cobrado y sí deberias haberle cobrado (A partir del día 2).
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasPausa.activeSelf)
            {
                canvasPausa.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                canvasPausa.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void OpenList()
    {
        if (listOpen)
        {
            leDinero.gameObject.GetComponent<Button>().enabled = true;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = true;
            dropDownPanel.transform.position = position2.transform.position;
            botonDesplegado.SetActive(true);
            botonPlegado.SetActive(false);
            listOpen = false;
        }

        else
        {
            leDinero.gameObject.GetComponent<Button>().enabled = false;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = false;
            dropDownPanel.transform.position = position1.transform.position;
            botonDesplegado.SetActive(false);
            botonPlegado.SetActive(true);
            listOpen = true;
        }

    }

    public void Resume()
    {
        canvasPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void TitleScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void NextDay()
    {
        for (int i = 0; i < 6; i++)
        {
            if (currentScene.name == "Day" + i)
            {
                SceneManager.LoadScene(1 + i);
            }
        }
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void ShowNormativa()
    {
        normativas.SetActive(true);
        precios.SetActive(false);
    }

    public void ShowPrecios()
    {
        precios.SetActive(true);
        normativas.SetActive(false);
    }
}
