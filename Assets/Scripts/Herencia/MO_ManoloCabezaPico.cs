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

    protected override void Start()
    {
        base.Start();
        nombre = "Manolo Cabeza Pico";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().evilWizardManolo;
            data.GetComponent<Data>().SettingDialogues();

            uIManager.GetComponent<UIManager>().ShowText();

            dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
            dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

            //StartCoroutine(ShowLine());


            if (currentScene.name == "Day3")
            {
                dialogue.Add("Hola humano, que dura es mi vida. ");
                dialogue.Add("Finalmente mi mayor enemigo ha llegado, Hacienda.");
                dialogue.Add("Siempre a final de mes necesitan saber los gastos que he hecho para luego quitarme dinero.");
                dialogue.Add("Por ello tomé una decisión, he creado al grupo: ANTI-HACIENDA.");
                dialogue.Add("Por ahora estoy solo yo, pero con esto que voy comprar, empezaré con la revolución.");
                dialogue.Add("Acabaré con Hacienda, recuperaré mi mansión embargada y me repartiré el dinero para mi solo.");
                dialogue.Add("Creo que lo último se me escapó, no hagas caso cuando deliro.");
                dialogue.Add("Pero bueno, será mejor que me vaya para… ¡EMPEZAR LA REVOLUCIÓN!");
                dialogue.Add("Así que bueno, cóbrame y esas cosas humano.");

                dialogue.Add("Gracias a tu dedicación, te nombró primer miembro del grupo ANTI-HACIENDA. ¡Viva la Revolución!");
                dialogue.Add(" No puede ser, ahora no podré ayudar a pobres magos como yo.");

                uIManager.GetComponent<UIManager>().ShowText();

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().crystallBall, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "4";
        }

        else if (currentScene.name == "Day3")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().beer, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
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
