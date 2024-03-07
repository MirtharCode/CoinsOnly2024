using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Patxi : Limbasticos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    protected override void Start()
    {
        base.Start();
        nombre = "Patxi";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            base.OnCollisionEnter2D(collision);
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().limbasticPatxi;
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day3_1")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "16";
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
