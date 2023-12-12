using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MO_Geeraard : MagosOscuros
{
    [SerializeField] public GameObject product;
    bool repetirunavez = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            if (currentScene.name == "Day1")
            {
                dialogue.Add("Buenas ciudadano, ya lleg� aqu�, el inigualable Geeraard, gracias, gracias�");
                dialogue.Add("�");
                dialogue.Add("�Por qu� no has empezado a llorar de la alegr�a y a pedirme un aut�grafo mientras est�s de rodillas?");
                dialogue.Add("�C�mo que no me conoces! Todos aqu� me conocen.");
                dialogue.Add("El h�roe de h�roes, quien derrot� al Rey Demonio con una sola daga y los ojos vendados.");
                dialogue.Add("Vamos� Todos mis admiradores, es decir, todo el reino, saben que soy el mejor h�roe de la historia.");
                dialogue.Add("...");
                dialogue.Add("Bueno, me imagino que perdonar� tu desconocimiento y ese silencio inc�modo que provocas.");
                dialogue.Add("C�brame esto al menos, as� esta charla dejar� de ser tan inc�moda.");

                dialogue.Add("Deber�as de leer alguna de mis grandes historias humano, adi�s.");
                dialogue.Add("Pero, �QU� INSOLENCIA ES ESTA! Espero que cuando vuelva aprendas a contar monedas humano.");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();


                //StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day1")
        {
            product = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product.transform.SetParent(oneProduct);
            gameManager.GetComponent<GameManager>().leDineroText.text = "6";
        }
    }

    public override void ByeBye()
    {
        Destroy(product);
        base.ByeBye();
    }
}
