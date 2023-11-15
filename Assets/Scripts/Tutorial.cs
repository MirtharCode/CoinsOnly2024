using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] int contador;
    [SerializeField] public GameObject[] paneles;
    [SerializeField] public GameObject previousButton, nextButton;

    void Start()
    {
        contador = 1;
        MostrarPanelActual();
    }

    public void siguiente()
    {
        contador++;
        MostrarPanelActual();

        if (contador < 6)
            previousButton.SetActive(true);

        else
            nextButton.SetActive(false);
    }

    public void anterior()
    {
        contador--;
        MostrarPanelActual();

        if (contador > 1)
            nextButton.SetActive(true);

        else
            previousButton.SetActive(false);
    }

    void MostrarPanelActual()
    {
        foreach (GameObject panel in paneles)
        {
            panel.SetActive(false);
        }

        if (contador <= paneles.Length && contador >= 1)
            paneles[contador - 1].SetActive(true);
    }

    public void volverMenu()
    {
        SceneManager.LoadScene(0);
    }
}
