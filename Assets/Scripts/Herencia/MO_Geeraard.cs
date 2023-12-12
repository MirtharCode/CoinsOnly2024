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
                dialogue.Add("Buenas ciudadano, ya llegó aquí, el inigualable Geeraard, gracias, gracias…");
                dialogue.Add("…");
                dialogue.Add("¿Por qué no has empezado a llorar de la alegría y a pedirme un autógrafo mientras estás de rodillas?");
                dialogue.Add("¡Cómo que no me conoces! Todos aquí me conocen.");
                dialogue.Add("El héroe de héroes, quien derrotó al Rey Demonio con una sola daga y los ojos vendados.");
                dialogue.Add("Vamos… Todos mis admiradores, es decir, todo el reino, saben que soy el mejor héroe de la historia.");
                dialogue.Add("...");
                dialogue.Add("Bueno, me imagino que perdonaré tu desconocimiento y ese silencio incómodo que provocas.");
                dialogue.Add("Cóbrame esto al menos, así esta charla dejará de ser tan incómoda.");

                dialogue.Add("Deberías de leer alguna de mis grandes historias humano, adiós.");
                dialogue.Add("Pero, ¡QUÉ INSOLENCIA ES ESTA! Espero que cuando vuelva aprendas a contar monedas humano.");

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
