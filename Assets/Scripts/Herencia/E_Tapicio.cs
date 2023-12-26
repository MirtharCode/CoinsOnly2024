using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class E_Tapicio : Elementales
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    bool repetirunavez = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            if (currentScene.name == "Day1")
            {
                dialogue.Add("Saludos desde mi solitaria existencia, soy Tapicio.");
                dialogue.Add("¿Qué pasa? ¿Nunca has visto alguien tan animado verdad?");
                dialogue.Add("Qué quieres que te diga... soy prisionero de mi propio destino.");
                dialogue.Add("Fui creado para solo trabajar, mis cadenas nunca se romperán.");
                dialogue.Add("A veces deseo seguir siendo ser ese pequeño tapiz colgado en el cementerio de limbásticos.");
                dialogue.Add("Pero por desgracia, mi vida es como una canción emo: Larga, triste y nunca termina.");
                dialogue.Add("Al igual que esta conversación... perdona por hacerte perder el tiempo.");
                dialogue.Add("Deberías de cobrarme ya, o si no llegaré tarde a mi torneo de Lanzamiento de miradas melancólicas.");

                dialogue.Add("Gracias, espero que no quedar en primer lugar, como siempre.");
                dialogue.Add("Otra desgracia más para mi vida, ahora seguro gano el torneo por tu culpa.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "22";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
