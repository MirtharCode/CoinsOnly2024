using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_Masermati : Tecnopedos
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
                dialogue.Add("Hola cocherrumín, estoy preparándome para la carrera del siglo.");
                dialogue.Add("No me presenté, soy el famoso FMS, Faster More Serious.");
                dialogue.Add("O como me llamo mi robo-madre, Masermati.");
                dialogue.Add("Y voy a hacer la primera carrera de mi vida.");
                dialogue.Add("Aunque espero que no sea la última, no sabes la pasta que cuestan estas mejoras.");
                dialogue.Add("Los tubos de escape costaron solo 100 monedas.");
                dialogue.Add("No sabes todos los platos que limpié para tener esa cantidad de monedas.");
                dialogue.Add("Pero todo este trabajo fue necesario para el día de hoy, para ganar a…");
                dialogue.Add("¡FLECHA RÁPIDA! El tecnópedo más rápido del reino.");
                dialogue.Add("Es el coche oficial de Pijus Magnus, el 2º mago más poderoso del reino.");
                dialogue.Add("O eso dice él, aunque solo lo dice por ser hijo del Rey Mago.");
                dialogue.Add("Realmente es un tirillas enano, espero que tengas suerte de no encontrarlo.");
                dialogue.Add("Bueno, cobrame humano, que tengo que estar listo para la carrera.");

                dialogue.Add("Gracias cocherrumín, voy a prepararme para la carrera.");
                dialogue.Add("¡Pero si tengo suficiente! Da igual, tengo algo de prisa.");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day2")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts2.position, twoProducts2.rotation);
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
