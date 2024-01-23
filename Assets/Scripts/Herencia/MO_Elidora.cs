using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MO_Elidora : MagosOscuros
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    bool repetirunavez = false;

    protected override void Start()
    {
        base.Start();
        nombre = "Elidora";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().evilWizardElidora;

            if (currentScene.name == "Day4")
            {
                dialogue.Add("Hola s�bdito, �No crees que deber�as de dejar de atender en este s�tano?");
                dialogue.Add("Casi uno de mis fieles slimes se deshace por culpa de la ca�da.");
                dialogue.Add("Y no sabes el precio que hubieras tenido que pagar por mi slime.");
                dialogue.Add("Podr�a haberte nombrado mi nueva silla oficial� La �nica silla del Reino Slime.");
                dialogue.Add("Mi gran y poderoso reino de 4 habitantes slimes, donde yo soy la reina.");
                dialogue.Add("LA PODEROSA REINA MAGA ELIDORA LIMALIGNA.");
                dialogue.Add("La reina m�s poderosa de todos los reinos.");
                dialogue.Add("Aunque a�n estoy con los papeles para volver mi reino oficial.");
                dialogue.Add("Creo que te dejar� unirte a mi reino si me muestras tu gran habilidad atendiendo clientes.");
                dialogue.Add("�Qu� me dices?");
                dialogue.Add("...");
                dialogue.Add("Ya veo que te he sorprendido tanto que te he dejado sin habla.");
                dialogue.Add("Venga muestrame tus habilidades cobrando.");

                dialogue.Add("Te har� el dependiente oficial� Nada m�s terminar con el papeleo, adi�s humilde s�bdito");
                dialogue.Add("En Reino Slime no tenemos estas est�pidas normativas, aunque ya nunca lo sabr�s, adi�s humano.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Hola humano, vengo defraudada de lo mal hecho que est� este reino.");
                dialogue.Add("Fu� al famoso restaurante de �Tips�, y no dejaron pasar a mis humildes ciudadanos esclavos de slime.");
                dialogue.Add("Alguna h�brido debi� hacer esas normas tan tontas, �C�mo no van a permitir criaturas m�gicas?");
                dialogue.Add("Y lo peor es la DECADENCIA del lugar, me obligaron a sentarme en una silla en vez de en mi slimes.");
                dialogue.Add("Y porqu� no hablar del servicio, casi tuve que cazar a los camareros, c�mo un os�guila a un salm�n.");
                dialogue.Add("Le voy a poner una estrella en TripKingdom a ese maldito sitio.");
                dialogue.Add("Seguro no me atend�an como deb�an por ser la reina del reino slime, esos h�bridos magof�bicos.");
                dialogue.Add("Menos mal que en mi reino no excluimos a nadie, excepto a los h�bridos a partir de este mal servicio.");
                dialogue.Add("Har� un restaurante llevado por slimes que lo har�n mejor que esos in�tiles.");
                dialogue.Add("Bueno, humano c�brame que tengo que empezar con la edificaci�n de mi reino.");

                dialogue.Add("Bien hecho humano, si se te da tan bien cobrar, seguro tambi�n se te da bien ayudarme con las obras de mi reino.");
                dialogue.Add("Est�pido humano, menos mal que mis dependientes slimes ser�n m�s listos que t�.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "16";
        }

        else if (currentScene.name == "Day5")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "8";
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
