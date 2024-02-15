using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class E_Jissy : Elementales
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    protected override void Start()
    {
        base.Start();
        nombre = "Jissy";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            base.OnCollisionEnter2D(collision);
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().elementalJissy;
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "10";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
