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
                dialogue.Add("Hola cielo, se te vé algo cansado, ¿estás bien?");
                dialogue.Add("Seguro que estás así por el trabajo, llevo años viniendo aquí y sé bien cómo os trata el jefe.");
                dialogue.Add("Igual es un chico bueno aunque sea un poco avaricioso, egocéntrico, egoísta y explotador laboral.");
                dialogue.Add("Todo el mundo tiene el lado bueno, lo sé bien con todos los años que he pasado viva. ");
                dialogue.Add("Fuí de los primeros técnopedos, de ahí mi nombre, Rústica.");
                dialogue.Add("Trabaje en varios sitios, uno de mis favoritos fue de camarera.");
                dialogue.Add("En un bar muy elegante, creo que se llamaba Hell Fire Bar.");
                dialogue.Add("Siempre había alguna que otra pelea entre amigos, o pequeñas peleas de bandas.");
                dialogue.Add("Alguna vez nos pintaban las paredes con latas de spray, eran buenos chicos en el fondo.");
                dialogue.Add("Fue una buena época… Disculpa cielo que me voy por las nubes.");
                dialogue.Add("Cobrame esto, así voy tirando a la chatarrería a echar unas cartas con mis amigas.");

                dialogue.Add("Gracias cariño, espero no llegar tarde a la chatarrería.");
                dialogue.Add("¿Puede que me haya dejado algo de dinero, cielo? Creo que será la edad.");

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
