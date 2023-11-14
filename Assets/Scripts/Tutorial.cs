using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    int contador;
    public GameObject[] paneles;

    void Start()
    {
        contador = 1;
        MostrarPanelActual();
    }

    void Update()
    {

    }

    public void siguiente()
    {
        contador++;

        if (contador >= 7)
        {
            SceneManager.LoadScene(0);
        }

        MostrarPanelActual();

    }

    public void anterior()
    {
        contador--;

        if (contador <= 1)
        {
            SceneManager.LoadScene(0);
        }

        MostrarPanelActual();
    }

    void MostrarPanelActual()
    {
        foreach (GameObject panel in paneles)
        {
            panel.SetActive(false);
        }

        if (contador <= paneles.Length && contador >= 1)
        {
            paneles[contador - 1].SetActive(true);
        }
    }

    public void volverMenu()
    {
        SceneManager.LoadScene(0);
    }
}
