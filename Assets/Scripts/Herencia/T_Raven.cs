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
                dialogue.Add("¡Hola amigo mío! ¿No es un día maravilloso?");
                dialogue.Add("Aunque ni he dormido, pero trabajar como DJ Rave-n siempre me llena de energía.");
                dialogue.Add("Tuve que trabajar en una despedido de soltero, los chicos fueron muy majos.");
                dialogue.Add("Pero mi compañero Handy lo pasó un poco mal la verdad.");
                dialogue.Add("El soltero se encariñó con el pobre Handy, era un limbástico muy cariñoso.");
                dialogue.Add("Pero bueno, me alegró de que al menos haya podido poner mi música.");
                dialogue.Add("Porque la música de hoy en día es digamos… Demasiado triste y oscura.");
                dialogue.Add("El grupo Tears of Limbastics es super triste, malditas canciones emos.");
                dialogue.Add("¡Sí lo mejor es el grupo Magicians of Power, tiene canciones super divertidas! ");
                dialogue.Add("Pero parece que la sociedad se está deprimiendo cada vez más.");
                dialogue.Add("Aún así, intentaré alegrar al mundo con mis canciones.");
                dialogue.Add("Pero para ello, necesito recargar pilas colega, que quiero recargar.");
                dialogue.Add("Cobrame esto si puedes porfi.");

                dialogue.Add("Gracias compi, ahora iré a descansar para deslumbrar esta noche más.");
                dialogue.Add("No podré recargar pilas colega… Este será un día con más canciones emos por tí.");

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
