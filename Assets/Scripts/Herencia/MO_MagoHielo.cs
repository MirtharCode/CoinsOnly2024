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
    [SerializeField] public GameObject perberto2;

    [SerializeField] AudioClip risa;
    [SerializeField] AudioClip grito;

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

    public void MagoHieloGrito()
    {
        GetComponent<AudioSource>().clip = grito;
        GetComponent<AudioSource>().Play();
    }

    public void CallingForPerverto()
    {
        perberto2.SetActive(true);
        perberto2.GetComponent<Animator>().Play("PervertoJumpScare");
    }

    public void PosMeMato()
    {
        Destroy(gameObject);
    }
}