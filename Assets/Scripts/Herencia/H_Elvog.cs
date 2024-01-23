using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Elvog : Hibridos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    bool repetirunavez = false;

    protected override void Start()
    {
        base.Start();
        nombre = "Elvog";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().hybridElvog;

            if (currentScene.name == "Day1")
            {
                dialogue.Add("Buennnasss *hip* Eeeehhhhh… tuuu no eres el de sieeeembrree…*hip*");
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

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day3")
            {
                dialogue.Add("¡COLEGA, TE NECESITO DE VERDAD!");
                dialogue.Add("¡HAN PROHIBIDO LAS CERVEZAS A LOS HÍBRIDOS!");
                dialogue.Add("¡EMPECÉ A HABLAR BIEN DE NUEVO!");
                dialogue.Add("¡HASTA ME LLEGÓ UNA SOLICITUD DE EMPLEO!");
                dialogue.Add("¡NO QUIERO VOLVER A TRABAJAR!");
                dialogue.Add("¡Y MENOS CON ESA TAL PETRA QUE ME QUITÓ EL TRABAJO!");
                dialogue.Add("¡ME NIEGO!");
                dialogue.Add("¡TE DARÉ EL DINERO QUE NECESITES!");
                dialogue.Add("¡PERO NE-CE-SI-TO CERVEZA! ");

                dialogue.Add("¡TE QUIERO MUCHO COLEGA! ");
                dialogue.Add("Hasta mi dependiente favorito… Adiós a Elvog Borracho");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Buennnasss *hip* Tú…Tú…  Ahí está miii dependiente favorito.");
                dialogue.Add("Erres el mejor, tíoooo, gracias a tí no tengo trabajarrr más, er jefe me ha visto borracho, de nuevo.");
                dialogue.Add("Ahorra seguirré con mi increíble vida jubeniiiil, eres er único capaz de entenderme*hip*");
                dialogue.Add("Te invitarría a una birra, pero no sé que bebeís los hurmanos, tenéis pinta de beberrrr Carrimocho.");
                dialogue.Add("No parreceis bebedores fuertes como yo, mi hígado y yo segurro somos los combatientes más fuertes del reino*hip*");
                dialogue.Add("Te estoy robando muuuuucho tiempo, solo quiero decirte que esperro que podamos ser amigos, y que nos vayamos de copas al terminaaaar el turno.");
                dialogue.Add("Nos vemos besto amigo.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            uIManager.GetComponent<UIManager>().leDineroText.text = "10";
        }

        else if (currentScene.name == "Day3")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().beer, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "50";
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
