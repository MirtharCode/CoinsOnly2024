using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Elvog : Hibridos
{
    [SerializeField] public GameObject product;
    bool repetirunavez = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            if (currentScene.name == "Day1")
            {
                dialogue.Add("Buennnasss *hip* Eeeehhhhh… tuuu no eres el de sieeeembrree…*hip*)");
                dialogue.Add(" Bueno, el otro erra un ######");
                dialogue.Add("Ahorra a quién le direee sobre niii despidoooo… Encimaaa eres humanooo…*");
                dialogue.Add("Ne tocarra contarrrrte a tuuu…*hip * ");
                dialogue.Add(" Soy Elvog, er ex ex explorador");
                dialogue.Add("Mooo te looo vasss a creer… el ###### de mi jefeee me despidió *hip*");
                dialogue.Add("Me dijooo que bebía mushoo alcohooool y que estoy viejo, ¿perro quee dise eseee? *hip*");
                dialogue.Add("Siii solo temgo 22 añitos, estoooy em la fror de la hueventud *hip*");
                dialogue.Add("Buemo, che me olvidó *hip*, puedess cobrarme estooo…");

                dialogue.Add("Gracias mushacho *hip* Ahorra serás ni depemdiete favorito *hip*");
                dialogue.Add("Perro mushacho *hip* el otroo depemdiete erra mejor *hip*");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day1")
        {
            product = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product.transform.SetParent(oneProduct);
            gameManager.GetComponent<GameManager>().leDineroText.text = "10";
        }
    }

    public override void ByeBye()
    {
        Destroy(product);
        base.ByeBye();
    }
}
