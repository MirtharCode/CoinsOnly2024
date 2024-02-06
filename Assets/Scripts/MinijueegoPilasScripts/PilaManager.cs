using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilaManager : MonoBehaviour
{
    [SerializeField] public GameObject pila1;
    [SerializeField] public GameObject pila2;

    void Start()
    {
        pila1 = GameObject.FindGameObjectWithTag("Player");
        pila2 = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }
}
