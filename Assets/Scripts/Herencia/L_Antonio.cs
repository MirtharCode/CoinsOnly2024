using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Antonio : Limbasticos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
    [SerializeField] public Sprite spriteAlt;

    protected override void Start()
    {
        base.Start();
        nombre = "Antonio";

        if (data.GetComponent<Data>().giftAntonio)
            GetComponent<SpriteRenderer>().sprite = spriteAlt;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            base.OnCollisionEnter2D(collision);
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().limbasticAntonio;
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day1")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            uIManager.GetComponent<UIManager>().leDineroText.text = "8";
        }

        if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);

            uIManager.GetComponent<UIManager>().leDineroText.text = "24";
        }
    }

    public override void ByeBye()
    {
        if (currentScene.name == "Day5" || data.GetComponent<Data>().giftAntonio)
        {
            GetComponent<SpriteRenderer>().sprite = spriteAlt;

            if (!data.GetComponent<Data>().giftAntonio)
            {
                data.GetComponent<Data>().giftAntonio = true;
                uIManager.GetComponent<UIManager>().TrophyAchieved("Antonio");
            }
        }

        Destroy(product1);
        Destroy(product2);
        Destroy(product3);
        base.ByeBye();
    }
}
