using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                dialogue.Add("�Qu� pasa? �Nunca has visto alguien tan animado verdad?");
                dialogue.Add("Que quieres que te diga, soy prisionero de mi propio destino.");
                dialogue.Add("Fui creado para solo trabajar, mis cadenas nunca se romper�n.");
                dialogue.Add("A veces deseo seguir siendo ser ese peque�o tapiz colgado en el cementerio de limb�sticos.");
                dialogue.Add("Pero por desgracia, mi vida es como una canci�n emo; Larga, triste y nunca termina.");
                dialogue.Add("Al igual que esta conversaci�n, perd�n por hacerte perder el tiempo.");
                dialogue.Add("Deber�as de cobrarme ya, o si no llegar� tarde a mi torneo de Lanzamiento de miradas melanc�licas.");

                dialogue.Add("Gracias, espero que no quedar en primer lugar, como siempre.");
                dialogue.Add("Otra desgracia m�s para mi vida, ahora seguro gano el torneo por tu culpa.");


                gameManager.GetComponent<GameManager>().ShowText();
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
            gameManager.GetComponent<GameManager>().leDineroText.text = "22";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
