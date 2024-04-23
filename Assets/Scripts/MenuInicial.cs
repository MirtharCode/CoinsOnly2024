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
        if (data.GetComponent<Data>().day0Check)
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
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void Creditos()
    {
        SceneManager.LoadScene(11);
    }

  
}
