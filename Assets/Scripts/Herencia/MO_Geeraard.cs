using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MO_Geeraard : MagosOscuros
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
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().evilWizardGerard;
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

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();


                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Hola humano, espero que en estos días te hayas leído una de miles historias.");
                dialogue.Add("...");
                dialogue.Add("Tu mirada me dice que no es así, ¿Es que no tienes tiempo para leer en casa?");
                dialogue.Add("Eres de los peores fans que he tenido en mi vida.");
                dialogue.Add("Espero que leas al menos una antes de que escriban mi nueva historia: La caza del collar de Sin Cuello.");
                dialogue.Add("Mañana mismo partiré camino del reino junto con mi nuevo compañero.");
                dialogue.Add("Es un limbástico que reviví con ayuda de un mago mano un poco extraño.");
                dialogue.Add("Al parecer es el único tipo del reino que sabe hacer limbásticos, y yo que pensaba que revivían solos");
                dialogue.Add("Bueno, como decía de mi compañero, dicen que cuando estaba vivo tenía unos nervios de acero.");
                dialogue.Add("Así que por eso solo revivimos su sistema nervioso y su cerebro.");
                dialogue.Add("Espero que sea tan capaz como yo, aunque se le ve un poco tirillas.");
                dialogue.Add("En fin, necesitaré algunos materiales para el viaje, y esta tienda tiene suerte de ser mi proveedora no oficial.");
                dialogue.Add("Por lo que tendrás el honor de cobrarme.");

                dialogue.Add("Deséame suerte en mi aventura, aunque no la necesite.");
                dialogue.Add("Por todo lo que he hecho por el reino, y me lo pagan así.");

                uIManager.GetComponent<UIManager>().ShowText();

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            uIManager.GetComponent<UIManager>().leDineroText.text = "6";
        }

        else if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().crystallBall, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);

            uIManager.GetComponent<UIManager>().leDineroText.text = "17";
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
