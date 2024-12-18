using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    [SerializeField] public GameObject pilaManager;
    public Transform posicionObjetoVacio;
    public bool pilaOut = false;
    public GameObject cargador1;
    public GameObject cargador2;
    public GameObject ultimoCargador;
    AudioSource audioSource;
    public AudioClip explosionSound;

    void Start()
    {
        pilaManager = GameObject.FindGameObjectWithTag("PM");
        audioSource = pilaManager.GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Pila>().cargado == true)
        {
            if (!cargador1.activeSelf)
            {
                cargador1.SetActive(true);
                cargador1.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                ultimoCargador = cargador1;
            }

            else if (!cargador2.activeSelf)
            {
                cargador2.SetActive(true);
                cargador2.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                ultimoCargador = cargador2;
            }

            audioSource.PlayOneShot(explosionSound);
            Vector3 posicionPila = other.transform.position;

            other.transform.position = posicionObjetoVacio.position;
            other.gameObject.GetComponent<Pila>().cargado = false;

            Sprite nuevoSprite = other.gameObject.GetComponent<Pila>().spriteNoCargada;
            other.gameObject.GetComponent<SpriteRenderer>().sprite = nuevoSprite;

            GameObject clon = Instantiate(other.gameObject.GetComponent<Pila>().explosion);
            clon.transform.position = posicionPila;
        }
    }
}