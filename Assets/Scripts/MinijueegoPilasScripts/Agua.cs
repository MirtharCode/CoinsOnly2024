using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    [SerializeField] public GameObject pilaManager;

    void Start()
    {
        pilaManager = GameObject.FindGameObjectWithTag("PM");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Pila>().cargado == true)
        {
            Destroy(gameObject);

        }
    }
}
