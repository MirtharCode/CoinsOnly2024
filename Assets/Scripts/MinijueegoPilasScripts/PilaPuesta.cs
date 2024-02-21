using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilaPuesta : MonoBehaviour
{
    [SerializeField] public int numPilasHechas = 0;
    [SerializeField] public GameObject pilaManager;
    [SerializeField] public GameObject pilaHueco1;
    [SerializeField] public GameObject pilaHueco2;
    [SerializeField] public GameObject pila;

    void Start()
    {
        pilaManager = GameObject.FindGameObjectWithTag("PM");
        pila = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && pila.GetComponent<Pila>().cargado == true)
        {
            numPilasHechas++;
            Destroy(collision.gameObject);

            if (numPilasHechas == 1)
            {
                pilaHueco1.GetComponent<SpriteRenderer>().enabled = true;
                pilaManager.GetComponent<PilaManager>().pila2.SetActive(true);
                pilaManager.GetComponent<PilaManager>().pila2.tag = "Player";
                pila = GameObject.Find("Pila2");
            }

            else if(numPilasHechas == 2)
            {
                pilaHueco2.GetComponent<SpriteRenderer>().enabled = true;
                pilaManager.GetComponent<PilaManager>().Victoria();
                pilaManager.GetComponent<PilaManager>().CambiarTemporizador(false);
            }
        }
    }
}