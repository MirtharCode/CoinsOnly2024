using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Sergio : Limbasticos
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
                dialogue.Add("Hola joven humano, disculpa la impertinencia, pero deberían de bajar el peso de esas bebidas.");
                dialogue.Add("No sabes lo que pesan esas malditas latas.");
                dialogue.Add("No tengo ya fuerza ni para levantarlas.");
                dialogue.Add("En mis tiempos, cuando era conocido como Sergio Nervisous.");
                dialogue.Add("Era capaz de levantar piedras y tenía unos nervios de acero.");
                dialogue.Add("Pero ahora suficiente que aguanto este cubo en mi cabeza.");
                dialogue.Add("Y encima me ha revivido un mago que dice que es un héroe.");
                dialogue.Add("Se hace llamar, Geeraard, que nombre más raro para un héroe.");
                dialogue.Add("Me revivió para que le ayudará en su nueva aventura.");
                dialogue.Add("¡Pero si no soy capaz ni de levantar una espada de verdad!");
                dialogue.Add("Con lo bien que estaba en mi tumba.");
                dialogue.Add("Necesito recuperar mis nervios, así que, cobrame estas bebidas.");
                dialogue.Add("Seguro revive mi fuerza.");

                dialogue.Add("Voy a intentar que esto me despierte como es debido.");
                dialogue.Add("¿Está prohibido venderme esto? En mis tiempos, bebíamos esto sin problema.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            gameManager.GetComponent<GameManager>().leDineroText.text = "20";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
