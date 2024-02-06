using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaCargada : MonoBehaviour
{
    [SerializeField] public int numPilasHechas = 0;
    [SerializeField] public bool hueco1 = false;
    [SerializeField] GameObject pilaHueco;

    void Start()
    {

    }

    void Update()
    {
        if (numPilasHechas == 1)
        {
            pilaHueco.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            numPilasHechas++;
            Destroy(collision.gameObject);
        }
    }
}