using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Cululu : Limbasticos
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

            if (currentScene.name == "Day2")
            {
                dialogue.Add("¿Buenos días? ¿O noches? Ya no sé la verdad.");
                dialogue.Add("Perdón, te habré confundido un poco, soy el del orbe el que habla.");
                dialogue.Add("Por este maldito orbe solo puedo ver morado, no distingo si es de día o no.");
                dialogue.Add("Me llamo Cululú, y hasta hace poco era un híbrido.");
                dialogue.Add("Pero ahora soy un limbástico, me morí ayer mientras estaba en la gasolinera.");
                dialogue.Add("Vi a un tío con un libro rarísimo que parecía hacer un ritual, y al verme, me dió un golpe con este orbe.");
                dialogue.Add("Y al despertar, pues me quedé encerrado aquí, aunque supongo que esto no sea un problema para mi cita.");
                dialogue.Add("El detective de mi caso me dijo que no fuera por ahora hasta que me acostumbrara a mi nuevo yo.");
                dialogue.Add("Pero la vida es una, y esa manguro es mi tipo ideal.");
                dialogue.Add("Pero bueno, espero que encuentren al culpable pronto para que no me atosigue el detective.");
                dialogue.Add("Ve cobrando estas pociones, que en unos minutos tengo la cita.");

                dialogue.Add("Muchas gracias hermano, deseame suerte en la cita.");
                dialogue.Add("Tío, de verdad que no te entiendo, si tengo toda la pasta.");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day2")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            gameManager.GetComponent<GameManager>().leDineroText.text = "16";
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
