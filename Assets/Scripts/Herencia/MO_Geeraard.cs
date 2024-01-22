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

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();


                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Hola humano, espero que en estos d�as te hayas le�do una de miles historias.");
                dialogue.Add("...");
                dialogue.Add("Tu mirada me dice que no es as�, �Es que no tienes tiempo para leer en casa?");
                dialogue.Add("Eres de los peores fans que he tenido en mi vida.");
                dialogue.Add("Espero que leas al menos una antes de que escriban mi nueva historia: La caza del collar de Sin Cuello.");
                dialogue.Add("Ma�ana mismo partir� camino del reino junto con mi nuevo compa�ero.");
                dialogue.Add("Es un limb�stico que reviv� con ayuda de un mago mano un poco extra�o.");
                dialogue.Add("Al parecer es el �nico tipo del reino que sabe hacer limb�sticos, y yo que pensaba que reviv�an solos");
                dialogue.Add("Bueno, como dec�a de mi compa�ero, dicen que cuando estaba vivo ten�a unos nervios de acero.");
                dialogue.Add("As� que por eso solo revivimos su sistema nervioso y su cerebro.");
                dialogue.Add("Espero que sea tan capaz como yo, aunque se le ve un poco tirillas.");
                dialogue.Add("En fin, necesitar� algunos materiales para el viaje, y esta tienda tiene suerte de ser mi proveedora no oficial.");
                dialogue.Add("Por lo que tendr�s el honor de cobrarme.");

                dialogue.Add("Des�ame suerte en mi aventura, aunque no la necesite.");
                dialogue.Add("Por todo lo que he hecho por el reino, y me lo pagan as�.");

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
