using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class E_Rockon : Elementales
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

            if (currentScene.name == "Day1")
            {
                dialogue.Add("�Ho-hola que tal?");
                dialogue.Add("Espero no molestar, y perdona mi tar-tartamudez.");
                dialogue.Add("En fin, perdona otra vez. No me disculpar� m�s, per-per-perdona.");
                dialogue.Add("Estoy intentando me-mejorar, como buen Rockon que soy.");
                dialogue.Add("Debo mejorar, como pap� que es muy fuerte.");
                dialogue.Add("Siempre me ha querido mu-mu-mucho.");
                dialogue.Add("Mi co-comida favorita es la gravilla que me hac�a.");
                dialogue.Add("Adem�s si le echabas cemento por encima, ya quedaba buen�iiiiisimo.");
                dialogue.Add("Bu-bu-bueno en fin� �Me puedes cobrar esto?");
                dialogue.Add("Es que le quiero dar una sorpresa a papi, seguro que este gato mu-muerto le hace mucha ilusi�n.");

                dialogue.Add("Gra-gra-gracias seguro que mi papaito se pone feliz");
                dialogue.Add("Jopetas� Con la ilusi�n que me hac�a regalarles esto a mis papis�");

                gameManager.GetComponent<GameManager>().ShowText();

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            gameManager.GetComponent<GameManager>().leDineroText.text = "12";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        base.ByeBye();
    }
}
