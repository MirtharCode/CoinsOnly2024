using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaCargada : MonoBehaviour
{
    [SerializeField] public int numPilasHechas = 0;
    [SerializeField] public GameObject pilaManager;
    [SerializeField] GameObject pilaHueco1;
    [SerializeField] GameObject pilaHueco2;

    void Start()
    {
        pilaManager = GameObject.FindGameObjectWithTag("PM");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            numPilasHechas++;
            Destroy(collision.gameObject);

            if (numPilasHechas == 1)
            {
                pilaHueco1.GetComponent<SpriteRenderer>().enabled = true;
                pilaManager.GetComponent<PilaManager>().pila2.SetActive(true);
                pilaManager.GetComponent<PilaManager>().pila2.tag = "Player";
            }

            else if(numPilasHechas == 2)
            {
                pilaHueco2.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}