using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class T_Denjirenji : Tecnopedos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
    [SerializeField] public GameObject trampilla;

    protected override void Start()
    {
        base.Start();
        nombre = "Denjirenji";

        trampilla = GameObject.FindGameObjectWithTag("Trampilla");
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            base.OnCollisionEnter2D(collision);
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().electropedDenjirenji;
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day1")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "9";
        }
    }

    public override void ByeBye()
    {
        if (currentScene.name == "Day2_1")
        {
            uIManager.GetComponent<UIManager>().canvasVictory.SetActive(true);
            trampilla.GetComponent<Animator>().enabled = false;
        }

        else if (currentScene.name == "Day3_1")
        {
            uIManager.GetComponent<UIManager>().canvasVictory.SetActive(true);
            trampilla.GetComponent<Animator>().enabled = false;
        }

        else
        {
            Destroy(product1);
            Destroy(product2);
            Destroy(product3);
            base.ByeBye();
        }
    }
}
