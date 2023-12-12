using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_Rustica : Limbasticos
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

            if (currentScene.name == "Day3")
            {
                dialogue.Add("Hola cielo, se te v� algo cansado, �est�s bien?");
                dialogue.Add("Seguro que est�s as� por el trabajo, llevo a�os viniendo aqu� y s� bien c�mo os trata el jefe.");
                dialogue.Add("Igual es un chico bueno aunque sea un poco avaricioso, egoc�ntrico, ego�sta y explotador laboral.");
                dialogue.Add("Todo el mundo tiene el lado bueno, lo s� bien con todos los a�os que he pasado viva. ");
                dialogue.Add("Fu� de los primeros t�cnopedos, de ah� mi nombre, R�stica.");
                dialogue.Add("Trabaje en varios sitios, uno de mis favoritos fue de camarera.");
                dialogue.Add("En un bar muy elegante, creo que se llamaba Hell Fire Bar.");
                dialogue.Add("Siempre hab�a alguna que otra pelea entre amigos, o peque�as peleas de bandas.");
                dialogue.Add("Alguna vez nos pintaban las paredes con latas de spray, eran buenos chicos en el fondo.");
                dialogue.Add("Fue una buena �poca� Disculpa cielo que me voy por las nubes.");
                dialogue.Add("Cobrame esto, as� voy tirando a la chatarrer�a a echar unas cartas con mis amigas.");

                dialogue.Add("Gracias cari�o, espero no llegar tarde a la chatarrer�a.");
                dialogue.Add("�Puede que me haya dejado algo de dinero, cielo? Creo que ser� la edad.");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day3")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            gameManager.GetComponent<GameManager>().leDineroText.text = "6";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
