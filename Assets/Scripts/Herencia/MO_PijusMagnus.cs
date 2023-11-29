using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MO_PijusMagnus : Hibridos
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
                dialogue.Add("T� ve cobrando esto que tengo prisa.");
                dialogue.Add("Espera-");
                dialogue.Add("��Eres humano?! �No te da verg�enza respirar el mismo aire que yo?");
                dialogue.Add("No se ni como pagaste lo suficiente para entrar al reino.");
                dialogue.Add("Y m�s te vale que me cobres bien, he le�do lo del 50%.");
                dialogue.Add("As� que quiero que me lo rebajes T-O-D-O.");
                dialogue.Add("Y como me cobres mal tendr� que usar mis poderosa habilidad�");
                dialogue.Add("El n�mero de mi papi.");
                dialogue.Add("Espero que me cobres bien, venga.");

                dialogue.Add("As� me gusta humano, no sab�a qu� os hab�an ense�ado a contar all�.");
                dialogue.Add("�C�mo que no sirve la oferta! Pues... Pues� Bonita moneda, me la quedo.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().beer, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            gameManager.GetComponent<GameManager>().leDineroText.text = "10";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
