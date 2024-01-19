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

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Ho-hola amigo, �qu� tal tu-tu-tu d�a de hoy?");
                dialogue.Add("Seguro que fue un d�a pri-pri-edr�stico, como decimos chicos piedras.");
                dialogue.Add("Tenemos muchas expresiones ra-raras gracias a mis primos roca, son de pueblo cerrado.");
                dialogue.Add("Adem�s de que son chicos fuerte como mi padre, dicen que son �Gymbros�.");
                dialogue.Add("Deber�a de ir al �Muscle Beluga� para me-mejorar mis m�sculos, es el mejor gimnasio del reino.");
                dialogue.Add("As� igualar�a la fuerza de mis primos y podr�a ayudar a mi padre en su restaurante.");
                dialogue.Add("�l est� como esclavo en el �Tips� del reino, es el mejor sitio para comer.");
                dialogue.Add("Aunque cada d�a le tocan clientes m�s desagradables, fue una ma-maga que quer�a pasar a unos slimes.");
                dialogue.Add("Se nota que no sabe lo que cuesta limpiar la baba de esas po-pobres criaturas.");
                dialogue.Add("Se-seguro que estoy haciendo mucha cola, c�brame amigo.");

                dialogue.Add("Gra-gracias, espero le gusten estos peluches con forma humana a mi padre.");
                dialogue.Add("Me falta di-dinero, jopetas, perd�n amigo.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            uIManager.GetComponent<UIManager>().leDineroText.text = "12";
        }

        else if (currentScene.name == "Day5")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "12";
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
