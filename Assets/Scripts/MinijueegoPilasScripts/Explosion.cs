using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //[SerializeField] int cuentaAtras = 500;
    [SerializeField] float tiempoDesaparecer = 5;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sr.color -= new Color(0, 0, 0, (1 / tiempoDesaparecer) * Time.deltaTime);

        if (sr.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}