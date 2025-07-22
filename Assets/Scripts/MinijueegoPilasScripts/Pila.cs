using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pila : MonoBehaviour
{
    public float velocidad = 2f;
    [SerializeField] public bool cargado;
    [SerializeField] public Sprite spriteCargada;
    [SerializeField] public Sprite spriteNoCargada;
    [SerializeField] public GameObject explosion;
    private Rigidbody2D rb2d;
    [SerializeField] public AudioClip sonidoColision;
    private AudioSource audioSource;

    void Start()
    {
        cargado = false;
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void ReproducirSonido()
    {
        audioSource.PlayOneShot(sonidoColision);
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb2d.AddForce(input * velocidad);
    }
}