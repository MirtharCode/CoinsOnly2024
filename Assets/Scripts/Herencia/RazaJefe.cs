using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class RazaJefe : Client
{
    protected override void Start()
    {
        base.Start();
        raza = "El Jefe";
    }

    protected abstract void OnCollisionEnter2D(Collision2D collision);
    public override void ShowProductsAndMoney()
    {
        //Relleno

    }

    public override void ByeBye()
    {
        gameManager.GetComponent<GameManager>().estaToPagao = false;
        gameManager.GetComponent<GameManager>().trampilla.SetActive(false);
        gameManager.GetComponent<GameManager>().internalCount = 0;
        gameManager.GetComponent<GameManager>().leDinero.gameObject.GetComponent<Button>().enabled = false;
        gameManager.GetComponent<GameManager>().leCajaRegistradora.gameObject.GetComponent<Button>().enabled = false;
        gameManager.GetComponent<GameManager>().dropDownButton.SetActive(false);

        if (gameManager.GetComponent<GameManager>().mostrarJefe)
        {
            StartCoroutine(gameManager.GetComponent<GameManager>().BossCalling());

            StartCoroutine(WaitingForMyDestruction());

            Destroy(gameObject, 4);

        }

        else
        {
            Destroy(gameObject, 2);
        }
    }
}