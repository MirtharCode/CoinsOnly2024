using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pila : MonoBehaviour
{
    public float velocidad = 2f;
    [SerializeField] public bool cargado;
    [SerializeField] public Sprite spriteCargada;

    void Start()
    {
        cargado = false;
    }

    void Update()
    {
        ProcesarMovimiento();
    }

    void ProcesarMovimiento()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(velocidad, 0f, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-velocidad, 0f, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0f, velocidad, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0f, -velocidad, 0) * Time.deltaTime;
    }
}