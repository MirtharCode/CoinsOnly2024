using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class E_ElementalHueso : Elementales
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
    bool repetirunavez = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            if (currentScene.name == "Day3")
            {
                dialogue.Add("Oye chaval, casi me hago polvo arriba esperando, ati�ndeme que tengo prisa.");
                dialogue.Add("Es que estoy en la nueva exposici�n de dinosaurios de la ciudad.");
                dialogue.Add("Y cuando digo que estoy, es que li-te-ral-men-te estoy.");
                dialogue.Add("Aunque no lo aparente, tengo millones de a�os.");
                dialogue.Add("Un mago me cre� a imagen y semejanza de una diosa de la belleza.");
                dialogue.Add("Soy \"Elemental de huesos\", y soy, e-vi-den-te-men-te un elemental de huesos.");
                dialogue.Add("Osea, soy �nica �Sabes?, y por eso tengo el mejor trabajo de la ciudad.");
                dialogue.Add("Soy LA estrella del museo, todo el mundo hace colas interminables para verme...");
                dialogue.Add("Pero bueno... deja de comerme con la mirada y c�brame, que me est�n esperando.");

                dialogue.Add("Un poco caro, pero bueno hace a�os este mu�eco eran 3 esclavos elementales, gracias.");
                dialogue.Add("Pero si las pociones las beb�an hasta los dinosaurios, est�pidas normativas.");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day3")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            gameManager.GetComponent<GameManager>().leDineroText.text = "26";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
