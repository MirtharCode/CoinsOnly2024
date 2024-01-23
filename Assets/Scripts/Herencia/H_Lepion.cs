using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Lepion : Hibridos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
    bool repetirunavez = false;

    protected override void Start()
    {
        base.Start();
        nombre = "Lepión";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().hybridLepion;

            if (currentScene.name == "Day2")
            {
                dialogue.Add("Hola humano.");
                dialogue.Add("Espera, tu eres el tonto que no sabía contar.");
                dialogue.Add("Ayer vino aquí ese microondas");
                dialogue.Add("Y ese cacharro debió darte una moneda más");
                dialogue.Add("Al menos ahora puedo justificar su despido");
                dialogue.Add("Aunque el bobo se puso a decir cosas de hacer el harakiri o cosas así.");
                dialogue.Add("En fin, malditas máquinas japonesas.");
                dialogue.Add("Ya que estás, cobrame esto, que debo seguir con mi trabajo de blanqueamiento de dinero.");

                dialogue.Add("Adiós");
                dialogue.Add("Ni contar sabes, ¿de verdad? Acabas de perder todos los clientes chinos por la zona, \n y espero que pronto pierdas tú el trabajo.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "13";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
