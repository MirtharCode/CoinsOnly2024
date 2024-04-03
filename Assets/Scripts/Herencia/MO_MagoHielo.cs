using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MO_MagoHielo : MagosOscuros
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    [SerializeField] AudioClip risa;

    protected override void Start()
    {
        base.Start();
        nombre = "MagoHielo";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public override void ShowProductsAndMoney()
    {

    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        Destroy(product3);
        base.ByeBye();
    }

    public void PianoSoundMagoHielo()
    {
        GetComponent<AudioSource>().Play();
    }

    public void MagoHieloRisa()
    {
        GetComponent<AudioSource>().clip = risa;
        GetComponent<AudioSource>().Play();
    }
}