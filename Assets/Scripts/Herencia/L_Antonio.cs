using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Antonio : Limbasticos
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
                dialogue.Add("Ey…Hola amigo, soy Antonio…¿Qué tal tu día?");
                dialogue.Add("...");
                dialogue.Add("Ya veo…No eres muy hablador eh.");
                dialogue.Add("Te entiendo tio, yo también estoy tan cansado cuando curro en programación.");
                dialogue.Add(" No se como sobreviví a esta jornada laboral, puede que porque esté muerto.");
                dialogue.Add(" Ja ja ja ja ja… Perdón, los chistes no son lo mío, mi cabeza no funciona tras un día de trabajo tan duro.");
                dialogue.Add("Hace que mi cerebro no funciona, porque estoy muerto.");
                dialogue.Add("Ja ja ja ja ja… Perdón ya paro.");
                dialogue.Add("Cobrame y dejaré de incomodarte.");

                dialogue.Add("Gra-gracias, aunque ahora que lo pienso no sé si era todo el dinero…");
                dialogue.Add(" Uy, me faltan monedas, siempre se cometen estos errores cuando pierdes la cabeza… Ya paro, nos vemos.");

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day1")
        {
            product = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, oneProduct.position, oneProduct.rotation);
            product.transform.SetParent(oneProduct);
            gameManager.GetComponent<GameManager>().leDineroText.text = "8";
        }
    }

    public override void ByeBye()
    {
        Destroy(product);
        base.ByeBye();
    }
}
