using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_Raven : Tecnopedos
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

            if (currentScene.name == "Day3")
            {
                dialogue.Add("�Hola amigo m�o! �No es un d�a maravilloso?");
                dialogue.Add("Aunque ni he dormido, pero trabajar como DJ Rave-n siempre me llena de energ�a.");
                dialogue.Add("Tuve que trabajar en una despedido de soltero, los chicos fueron muy majos.");
                dialogue.Add("Pero mi compa�ero Handy lo pas� un poco mal la verdad.");
                dialogue.Add("El soltero se encari�� con el pobre Handy, era un limb�stico muy cari�oso.");
                dialogue.Add("Pero bueno, me alegr� de que al menos haya podido poner mi m�sica.");
                dialogue.Add("Porque la m�sica de hoy en d�a es digamos� Demasiado triste y oscura.");
                dialogue.Add("El grupo Tears of Limbastics es super triste, malditas canciones emos.");
                dialogue.Add("�S� lo mejor es el grupo Magicians of Power, tiene canciones super divertidas! ");
                dialogue.Add("Pero parece que la sociedad se est� deprimiendo cada vez m�s.");
                dialogue.Add("A�n as�, intentar� alegrar al mundo con mis canciones.");
                dialogue.Add("Pero para ello, necesito recargar pilas colega, que quiero recargar.");
                dialogue.Add("Cobrame esto si puedes porfi.");

                dialogue.Add("Gracias compi, ahora ir� a descansar para deslumbrar esta noche m�s.");
                dialogue.Add("No podr� recargar pilas colega� Este ser� un d�a con m�s canciones emos por t�.");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day3")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            gameManager.GetComponent<GameManager>().leDineroText.text = "8";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
