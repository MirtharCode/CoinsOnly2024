using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeeraardElMagoDeArmas : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public List<string> dialogueGeeraard;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        gameManager.GetComponent<GameManager>().toyGrandote = true;
        gameManager.GetComponent<GameManager>().stopGrangran.gameObject.SetActive(true);

        gameManager.GetComponent<GameManager>().toyChiquito = false;
        gameManager.GetComponent<GameManager>().stopPetit.gameObject.SetActive(false);

        dialogueGeeraard = new List<string>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (collision.transform.tag == "Trampilla")
        {
            if (currentScene.name == "Day1")
            {
                dialogueGeeraard.Add("Buenas ciudadano, ya lleg� aqu�, el inigualable Geeraard, gracias, gracias�");
                dialogueGeeraard.Add("�");
                dialogueGeeraard.Add("�Por qu� no has empezado a llorar de la alegr�a y a pedirme un aut�grafo mientras est�s de rodillas?");
                dialogueGeeraard.Add("�C�mo no me conoces! Todos aqu� me conocen, el h�roe de h�roes, quien derrot� al Rey Demonio con una sola daga y los ojos vendados.");
                dialogueGeeraard.Add("Vamos� Todos mis admiradores, es decir, todo el reino, saben que soy el mejor h�roe que ha existido en la historia.");
                dialogueGeeraard.Add("�");
                dialogueGeeraard.Add("Bueno, me imagino que perdonar� tu desconocimiento y ese silencio inc�modo que haces cuando te dejo hablar.");
                dialogueGeeraard.Add("C�brame esto, as� al menos esta charla dejar� de ser tan inc�moda.");
                dialogueGeeraard.Add("Humano... deber�as de leer alguna de mis grandes historias, as� te firmar� el pecho la pr�xima vez que te vea por aqu�. Ciao!");
                dialogueGeeraard.Add("�PERO QU� INSOLENCIA ES ESTA! Con lo importante que soy para este reino... Espero que cuando vuelvas hayas aprendido a contar monedas al menos.");

                gameManager.GetComponent<GameManager>().ShowText();
            }
        }
    }

    public void ShowProductsAndMoney()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        Transform oneProduct = gameManager.GetComponent<GameManager>().oneProduct.transform;
        Transform twoProducts1 = gameManager.GetComponent<GameManager>().twoProducts1.transform;
        Transform twoProducts2 = gameManager.GetComponent<GameManager>().twoProducts2.transform;

        if (currentScene.name == "Day1")
        {
            GameObject clon = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            gameManager.GetComponent<GameManager>().leDinero.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().leDineroText.text = "6";
        }
    }
}
