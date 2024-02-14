using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Antonio : Limbasticos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    protected override void Start()
    {
        base.Start();
        nombre = "Antonio";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().limbasticAntonio;

            if (currentScene.name == "Day1")
            {
                //dialogue.Add("Ey�Hola amigo, soy Antonio��Qu� tal tu d�a?");
                //dialogue.Add("...");
                //dialogue.Add("Ya veo�No eres muy hablador eh.");
                //dialogue.Add("Te entiendo tio, yo tambi�n estoy tan cansado cuando curro en programaci�n.");
                //dialogue.Add(" No se como sobreviv� a esta jornada laboral, puede que porque est� muerto.");
                //dialogue.Add(" Ja ja ja ja ja� Perd�n, los chistes no son lo m�o, mi cabeza no funciona tras un d�a de trabajo tan duro.");
                //dialogue.Add("Hace que mi cerebro no funciona, porque estoy muerto.");
                //dialogue.Add("Ja ja ja ja ja� Perd�n ya paro.");
                //dialogue.Add("Cobrame y dejar� de incomodarte.");

                //dialogue.Add("Gra-gracias, aunque ahora que lo pienso no s� si era todo el dinero�");
                //dialogue.Add(" Uy, me faltan monedas, siempre se cometen estos errores cuando pierdes la cabeza� Ya paro, nos vemos.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            if (currentScene.name == "Day4")
            {
                dialogue.Add("Buenos d�as chico� Eres el del otro d�a �no?");
                dialogue.Add("Tengo mala memoria, debe ser porque siempre pierdo la cabeza, ja ja ja...");
                dialogue.Add("Sab�a que eras t�, a�n recuerdo el vac�o que dejabas cada vez que contaba mi mejor chiste.");
                dialogue.Add("Entonces tengo la confianza de decirte que me gustar�a hacer un regalo a mi novio Patxi.");
                dialogue.Add("Ayer me hizo una cita y quiero hacer algo a cambio, pens� en proponerle hacer senderismo.");
                dialogue.Add("Pero con lo lento que voy y lo r�pido que va �l, seguro no lo disfrutamos igual, por eso me decant� por la opci�n del regalo.");
                dialogue.Add("Espero que le guste este gato muerto, seguro que le recuerda a Mistafurri�o.");
                dialogue.Add("Era su gato cuando estaba vivo, y puede que quiera algo que le recuerde a �l.");
                dialogue.Add("C�brame por favor que tengo que envolver el regalo.");

                dialogue.Add("Espero que le guste este regalo.");
                dialogue.Add("Ahora que le regalo yo a mi Patxi.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            uIManager.GetComponent<UIManager>().leDineroText.text = "8";
        }

        if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);

            uIManager.GetComponent<UIManager>().leDineroText.text = "18";
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
