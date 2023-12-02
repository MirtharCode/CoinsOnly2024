using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Saltaralisis : Hibridos
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
                dialogue.Add("Hola… Hola… Humano .");
                dialogue.Add("Maldito cacharro, no ir como yo querer.");
                dialogue.Add("Llevo desde ser zanahorio con esta silla, y aún fallar.");
                dialogue.Add("Yo ser Saltaralisis y querer cambiar runas de una vez.");
                dialogue.Add("Sí no cambiar runas, no hablar bien y crear mal entendidos.");
                dialogue.Add("Ya pasar otro día en banco, y cuando yo decir nombre, romper runa.");
                dialogue.Add("Así que repetir palabra ASALTAR todo rato.");
                dialogue.Add(" Ellos llamar guardia y yo acabar en cárcel 3 días.");
                dialogue.Add("Duros días, pero conocer gente maja en cárcel.");
                dialogue.Add("Yo conocer…Yo conocer…Yo conocer… Sapótamo borracho.");
                dialogue.Add("Vuelve a fallar, mejor cobrar para cambiar runas.");

                dialogue.Add("Gra… Gra… cías, cambiar runas ahora.");
                dialogue.Add("No…No…. Poder cambiar, crear más mal entendidos.");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day3")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            gameManager.GetComponent<GameManager>().leDineroText.text = "12";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
