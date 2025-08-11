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
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        float rotationSpeed = 100f;
        transform.Rotate(Vector3.forward * -rotationInput * rotationSpeed * Time.fixedDeltaTime);

        rb2d.AddForce(transform.up * moveInput * velocidad);

        if (Mathf.Abs(moveInput) < 0.1f)
        {
            rb2d.velocity *= 0.9f; 
        }
    }
}