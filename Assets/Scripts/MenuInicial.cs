using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] public GameObject data;
    [SerializeField] public GameObject button1, button2;

    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
        if (data.GetComponent<Data>().day00Checked)
        {
            button1.SetActive(false);
            button2.SetActive(false);
        }

        else
        {
            button1.SetActive(true);
            button2.SetActive(true);
        }

    }
    //public void Jugar()
    //{
    //    SceneManager.LoadScene("Day1");
    //}

    public void Salir()
    {
        data.GetComponent<Data>().GuardarDatos();
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
        data.GetComponent<Data>().GuardarDatos();
    }
}
