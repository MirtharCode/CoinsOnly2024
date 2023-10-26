using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapicioElEmo : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
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
                dialogue.Add("Saludos desde mi solitaria existencia. *Suspira*");
                dialogue.Add("¿Qué pasa? ¿Nunca has visto alguien tan animado verdad? *Suspira*");
                dialogue.Add("Que quieres que te diga, soy prisionero de mi propio destino, fui creado solo para trabajar, mis cadenas nunca se romperán.");
                dialogue.Add("A veces deseo seguir siendo ser ese pequeño tapiz colgado en el cementerio de limbásticos, pero por desgracia, mi vida es como una canción emo.");
                dialogue.Add("Larga, triste y que nunca termina.");
                dialogue.Add("Al igual que esta conversación, perdón por hacerte perder el tiempo. *Suspira*");
                dialogue.Add("Deberías de cobrarme ya, o si no, llegaré tarde a mi torneo de \"Lanzamiento de miradas melancólicas\". *Suspira*");
                dialogue.Add("Gracias, espero que no quedar en primer lugar, como siempre.");
                dialogue.Add("Gra-gracias, aunque ahora que lo pienso no sé si era todo el dinero.");
                dialogue.Add("Otra desgracia más para mi vida, ahora seguro gano el torneo por tu culpa.");

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
            GameObject clon1 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, twoProducts1.position, twoProducts1.rotation);
            GameObject clon2 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, twoProducts2.position, twoProducts2.rotation);
            gameManager.GetComponent<GameManager>().leDinero.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().leDineroText.text = "22";
        }
    }
}
