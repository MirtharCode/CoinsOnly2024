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

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Hola humano, ¿no tienes días libres o que? ");
                dialogue.Add("Eres parecido en ese aspecto a los elementales, nosotros tampoco paramos de trabajar, es lo que tiene ser creaciones de los magos. ");
                dialogue.Add("Espera, ¿no lo sabías? La mayoría de las razas actuales fueron creadas por ellos. ");
                dialogue.Add("Que triste es la ignorancia de los humanos. ");
                dialogue.Add("Los elementales fueron creados para hacer el trabajo de esclavos. ");
                dialogue.Add("Los tecnópedos fueron creados por accidente cuando metieron una varita en un microondas. ");
                dialogue.Add("Y los limbásticos no se sabe cómo se crearon, solo se sabe que fueron los magos. ");
                dialogue.Add("Leí en algunos foros de ocultismo que fueron creados por una iglesia que lleva años oculta entre nosotros.");
                dialogue.Add("Tampoco pude leer mucho, es lo que tiene tener 23 horas de jornada laboral.");
                dialogue.Add("Hablando de ello, en nada tengo que volver a trabajar como tapiz en un museo de la zona.");
                dialogue.Add("Y encima tengo que explicar, de nuevo, al nuevo saco de huesos como va el trabajo allí.");
                dialogue.Add("Le fue horrible en su primer día, aunque ya es horrible ser parte de nuestra raza.");
                dialogue.Add("Por lo que ve cobrándome esto antes de que caiga en el olvido.");

                dialogue.Add("Espero que acabe pronto mi jornada, aunque vaya a comenzar.");
                dialogue.Add("Ni en mi descanso puedo conseguir un mínimo de felicidad.");

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

        else if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "32";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
