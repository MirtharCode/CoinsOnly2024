using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MO_Geeraard : MagosOscuros
{
    [SerializeField] public GameObject product;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Trampilla")
        {
            if (currentScene.name == "Day1")
            {
                dialogue.Add("Buenas ciudadano, ya lleg� aqu�, el inigualable Geeraard, gracias, gracias�");
                dialogue.Add("�");
                dialogue.Add("�Por qu� no has empezado a llorar de la alegr�a y a pedirme un aut�grafo mientras est�s de rodillas?");
                dialogue.Add("�C�mo no me conoces! Todos aqu� me conocen, el h�roe de h�roes. \n�Yo fui quien derrot� al Rey Demonio con una sola daga y los ojos vendados!");
                dialogue.Add("Vamos� Todos mis admiradores, es decir, todo el reino, saben que soy el mejor h�roe que ha existido nunca.");
                dialogue.Add("�");
                dialogue.Add("Bueno, creo que perdonar� tu desconocimiento y el silencio inc�modo que haces cuando te dejo hablar.");
                dialogue.Add("C�brame esto, as� al menos esta charla dejar� de ser tan inc�moda.");

                dialogue.Add("Humano... deber�as de leer alguna de mis grandes historias, as� te firmar� el pecho la pr�xima vez que te vea por aqu�. Ciao!");
                dialogue.Add("�PERO QU� INSOLENCIA ES ESTA! Con lo importante que soy para este reino... Espero que cuando vuelvas hayas aprendido a contar monedas al menos.");

                gameManager.GetComponent<GameManager>().ShowText();
            }
        }
    }
    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day1")
        {
            product = Instantiate(gameManager.GetComponent<GameManager>().
                manaPotion, oneProduct.position, oneProduct.rotation);
            product.transform.SetParent(oneProduct);
            gameManager.GetComponent<GameManager>().leDineroText.text = "6";
        }
    }
}
