using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargadores : MonoBehaviour
{
    [SerializeField] public GameObject pilaManager;

    void Start()
    {
        pilaManager = GameObject.FindGameObjectWithTag("PM");
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Pila>().cargado == false)
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Pila>().cargado = true;
        }
    }
}
