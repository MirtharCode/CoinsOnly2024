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
        ProcesarMovimiento();
    }

    void ProcesarMovimiento()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb2d.velocity = new Vector2(moveHorizontal * velocidad, moveVertical * velocidad);
    }

    public void ReproducirSonido()
    {
        audioSource.PlayOneShot(sonidoColision);
    }
}