using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MO_ManoloCabezaPico : MagosOscuros
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
                dialogue.Add("�Hola peque��n! No te hab�a visto desde ah� abajo.");
                dialogue.Add("Soy el grandioso Manolo Cabeza de Pico, el mago m�s rico�Del barrio m�s alto del reino.");
                dialogue.Add("Me sobra el dinero, para nada entr� aqu� por el 50% de descuento en magos.");
                dialogue.Add("O incluso podr�a ser un 70% ahora que somos amigos.");
                dialogue.Add(" Vale vale, no me mires con esa cara impasible, pero venga�");
                dialogue.Add("Te prometo que te devolver� ese 20%, siempre pago mis deudas.");
                dialogue.Add("Por ejemplo, mi vecino a�n me dice que le debo 2000 monedas y que deje de evitarlo.");
                dialogue.Add("Pero, por favor, yo no lo evito por la deuda, lo evito para ahorrarme esas 2000 monedas.");
                dialogue.Add("Creo que no deb� decir eso�Bueno, mejor ve cobrando antes de que la li� m�s.");

                dialogue.Add("Menos mal me he ahorrado esas monedas, as� podr� mantener mi enorme mansi�n durante 1 hora m�s.");
                dialogue.Add("�No tengo dinero ni con el 50% de rebaja? Me va a tocar embargar la casa.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().crystallBall, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            gameManager.GetComponent<GameManager>().leDineroText.text = "9";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
