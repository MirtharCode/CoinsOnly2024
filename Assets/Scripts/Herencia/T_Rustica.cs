using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_Rustica : Tecnopedos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    protected override void Start()
    {
        base.Start();
        nombre = "R�stica";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            base.OnCollisionEnter2D(collision);
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().electropedRustica;
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day3_2")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().badPoisonCupon2, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1); //Cupon falso de pociones
            product3 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "4";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        Destroy(product3);
        base.ByeBye();
    }
}
