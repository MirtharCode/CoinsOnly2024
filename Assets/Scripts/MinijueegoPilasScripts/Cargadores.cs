using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargadores : MonoBehaviour
{
    [SerializeField] public GameObject pilaManager;
    [SerializeField] public Sprite pilaCargada;
    [SerializeField] public AudioClip sonidoColision;

    private AudioSource audioSource;

    void Start()
    {
        pilaManager = GameObject.FindGameObjectWithTag("PM");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Pila>().cargado == false)
        {
            collision.gameObject.GetComponent<Pila>().ReproducirSonido();
            collision.gameObject.GetComponent<Pila>().cargado = true;
            Sprite nuevoSprite = collision.gameObject.GetComponent<Pila>().spriteCargada;
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = nuevoSprite;
            gameObject.SetActive(false);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Pila>().cargado == false)
    //    {
    //        audioSource.PlayOneShot(sonidoColision);
    //        collision.gameObject.GetComponent<Pila>().cargado = true;
    //        Sprite nuevoSprite = collision.gameObject.GetComponent<Pila>().spriteCargada;
    //        collision.gameObject.GetComponent<SpriteRenderer>().sprite = nuevoSprite;
    //        Invoke(nameof(MiraMamaMeMuero), 1);
    //    }
    //}
}
