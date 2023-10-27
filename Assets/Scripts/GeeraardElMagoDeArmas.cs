using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeeraardElMagoDeArmas : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject product;
    [SerializeField] public List<string> dialogue;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        gameManager.GetComponent<GameManager>().toyGrandote = true;
        gameManager.GetComponent<GameManager>().stopGrangran.gameObject.SetActive(true);

        gameManager.GetComponent<GameManager>().toyChiquito = false;
        gameManager.GetComponent<GameManager>().stopPetit.gameObject.SetActive(false);

        dialogue = new List<string>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (collision.transform.tag == "Trampilla")
        {
            if (currentScene.name == "Day1")
            {
                dialogue.Add("Buenas ciudadano, ya llegó aquí, el inigualable Geeraard, gracias, gracias…");
                dialogue.Add("…");
                dialogue.Add("¿Por qué no has empezado a llorar de la alegría y a pedirme un autógrafo mientras estás de rodillas?");
                dialogue.Add("¡Cómo no me conoces! Todos aquí me conocen, el héroe de héroes. \n¡Yo fui quien derrotó al Rey Demonio con una sola daga y los ojos vendados!");
                dialogue.Add("Vamos… Todos mis admiradores, es decir, todo el reino, saben que soy el mejor héroe que ha existido nunca.");
                dialogue.Add("…");
                dialogue.Add("Bueno, creo que perdonaré tu desconocimiento y el silencio incómodo que haces cuando te dejo hablar.");
                dialogue.Add("Cóbrame esto, así al menos esta charla dejará de ser tan incómoda.");
                dialogue.Add("Humano... deberías de leer alguna de mis grandes historias, así te firmaré el pecho la próxima vez que te vea por aquí. Ciao!");
                dialogue.Add("¡PERO QUÉ INSOLENCIA ES ESTA! Con lo importante que soy para este reino... Espero que cuando vuelvas hayas aprendido a contar monedas al menos.");

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
            product = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            gameManager.GetComponent<GameManager>().leDineroText.text = "6";
        }
    }

    public void ByeBye()
    {
        Destroy(product);
        gameManager.GetComponent<GameManager>().customerNumber++;
        gameManager.GetComponent<GameManager>().estaToPagao = false;
        gameManager.GetComponent<GameManager>().internalCount = 0;
        gameManager.GetComponent<GameManager>().leDinero.gameObject.GetComponent<Button>().enabled = false;
        gameManager.GetComponent<GameManager>().leCajaRegistradora.gameObject.GetComponent<Button>().enabled = false;
        Destroy(gameObject, 2);
    }

    private void OnDestroy()
    {
        gameManager.GetComponent<GameManager>().CharacterShowUp(gameManager.GetComponent<GameManager>().dailyCustomers[gameManager.GetComponent<GameManager>().customerNumber]);
    }
}
