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
                dialogue.Add("Chaval, casi me hago polvo arriba esperando, adem�s tengo prisa.");
                dialogue.Add("Estoy en la nueva exposici�n de dinosaurios de la ciudad.");
                dialogue.Add("Y cuando digo que estoy, es que literalmente estoy.");
                dialogue.Add("Debido a que tengo huesos de hace millones de a�os.");
                dialogue.Add("Un mago arque�logo me cre� y como qued� tan raro, no se dign� ni en darme nombre.");
                dialogue.Add("Literal me llamo Elemental de Hueso el elemental de huesos.");
                dialogue.Add("Por suerte logr� valerme por mi solo, y ahora obtuve un trabajo de verdad.");
                dialogue.Add(" Ser esclavizado por un museo, muchos de mi raza desear�an este puesto en vez de la mina.");
                dialogue.Add("Pero bueno, cobrame chaval, que tienen que verme en el museo.");

                dialogue.Add("Un poco caro el mu�eco, pero hace a�os ese mu�eco antes eran 3 esclavos elementales, gracias.");
                dialogue.Add("Pero si la cerveza la beb�an hasta los dinosaurios, est�pidas norm�ticas.");

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
