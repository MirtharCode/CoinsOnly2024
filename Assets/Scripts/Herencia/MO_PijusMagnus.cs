using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MO_PijusMagnus : MagosOscuros
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    protected override void Start()
    {
        base.Start();
        nombre = "Pijus Magnus";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().evilWizardPijus;
            data.GetComponent<Data>().SettingDialogues();

            if (currentScene.name == "Day2")
            {
                dialogue.Add("Tú ve cobrando esto que tengo prisa.");
                dialogue.Add("Espera-");
                dialogue.Add("¡¿Eres humano?! ¿No te da vergüenza respirar el mismo aire que yo?");
                dialogue.Add("No se ni como pagaste lo suficiente para entrar al reino.");
                dialogue.Add("Y más te vale que me cobres bien, he leído lo del 50%.");
                dialogue.Add("Así que quiero que me lo rebajes T-O-D-O.");
                dialogue.Add("Y como me cobres mal tendré que usar mis poderosa habilidad…");
                dialogue.Add("El número de mi papi.");
                dialogue.Add("Espero que me cobres bien, venga.");

                dialogue.Add("Así me gusta humano, no sabía qué os habían enseñado a contar allí.");
                dialogue.Add("¡Cómo que no sirve la oferta! Pues... Pues… Bonita moneda, me la quedo.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().beer, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "10";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
