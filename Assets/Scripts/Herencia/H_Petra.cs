using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Petra : Hibridos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
    [SerializeField] public Sprite spriteAlt;

    protected override void Start()
    {
        base.Start();
        nombre = "Petra";

        if (data.GetComponent<Data>().giftPetra)
            GetComponent<SpriteRenderer>().sprite = spriteAlt;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            base.OnCollisionEnter2D(collision);
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().hybridPetra;
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day2_2")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "18";
        }
    }

    public override void ByeBye()
    {
        if (currentScene.name == "Day5" || data.GetComponent<Data>().giftPetra)
        {
            GetComponent<SpriteRenderer>().sprite = spriteAlt;

            if (!data.GetComponent<Data>().giftPetra)
            {
                data.GetComponent<Data>().giftPetra = true;
                uIManager.GetComponent<UIManager>().TrophyAchieved("Petra");
            }
        }

        Destroy(product1);
        Destroy(product2);
        Destroy(product3);
        base.ByeBye();
    }
}
