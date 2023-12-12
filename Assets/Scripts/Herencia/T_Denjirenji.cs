using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_Denjirenji : Tecnopedos
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
                dialogue.Add("Buenas joven, no me creo que ahora solo sea un recadero�");
                dialogue.Add("Perd�n, el jefe me est� poniendo la cabeza como un horno.");
                dialogue.Add("Soy Denjirenji.");
                dialogue.Add("He estado 10 a�os aprendiendo t�cnicas samurai infalibles y fu� el mejor de la promoci�n.");
                dialogue.Add("Incluso salv� el mundo junto a cuatro tortugas, y ahora�");
                dialogue.Add("Solo sirvo para calentar su maldita comida, y encima la tengo que comprar yo.");
                dialogue.Add("Perd� todo honor como samurai.");
                dialogue.Add("Al final, acabar� haci�ndome el harakiri con cucharas.");
                dialogue.Add("Disculpa que te haya robado un poco de tu tiempo, c�brame esto por favor.");

                dialogue.Add("Menos mal que ten�a el dinero justo... o eso creo.");
                dialogue.Add("�Por una moneda! Disc�lpame... espero que el jefe no me mate.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            gameManager.GetComponent<GameManager>().leDineroText.text = "9";
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
