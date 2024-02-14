using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class DetectivePadre : Client
{
    protected override void Start()
    {
        base.Start();
        raza = "¿?";
        gameManager.GetComponent<GameManager>().musicBox.GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(1).GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(2).GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(3).GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(4).GetComponent<AudioSource>().Stop();
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(5).GetComponent<AudioSource>().Play();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //Relleno
    }
    public override void ShowProductsAndMoney()
    {
        //Relleno
    }


    public override void ByeBye()
    {
        uIManager.GetComponent<UIManager>().estaToPagao = false;
        gameManager.GetComponent<GameManager>().trampilla.SetActive(false);
        uIManager.GetComponent<UIManager>().internalCount = 0;
        uIManager.GetComponent<UIManager>().buttonCobrar.SetActive(false);
        uIManager.GetComponent<UIManager>().buttonNoCobrar.SetActive(false);
        uIManager.GetComponent<UIManager>().dropDownPanelPrecios.SetActive(false);
        uIManager.GetComponent<UIManager>().dropDownPanelNormativas.SetActive(false);
        Destroy(gameObject, 2);
    }
}