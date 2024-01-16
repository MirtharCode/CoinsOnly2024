using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Elementales : Client
{
    protected override void Start()
    {
        base.Start();
        raza = "Elemental";
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(2).GetComponent<AudioSource>().mute = true;
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(3).GetComponent<AudioSource>().mute = true;
        gameManager.GetComponent<GameManager>().musicBox.transform.GetChild(4).GetComponent<AudioSource>().mute = false;
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);
    public override void ShowProductsAndMoney()
    {
        //Relleno

    }

    public override void ByeBye()
    {
        uIManager.GetComponent<UIManager>().estaToPagao = false;
        gameManager.GetComponent<GameManager>().trampilla.SetActive(false);
        uIManager.GetComponent<UIManager>().internalCount = 0;
        uIManager.GetComponent<UIManager>().leDinero.gameObject.GetComponent<Button>().enabled = false;
        uIManager.GetComponent<UIManager>().leCajaRegistradora.gameObject.GetComponent<Button>().enabled = false;
        uIManager.GetComponent<UIManager>().dropDownPanelPrecios.SetActive(false);
        uIManager.GetComponent<UIManager>().dropDownPanelNormativas.SetActive(false);

        if (uIManager.GetComponent<UIManager>().mostrarJefe)
        {
            StartCoroutine(uIManager.GetComponent<UIManager>().BossCalling());

            StartCoroutine(WaitingForMyDestruction());

            Destroy(gameObject, 4);

        }

        else
        {
            Destroy(gameObject, 2);
        }
    }
}
