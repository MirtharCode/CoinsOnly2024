using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Saltaralisis : Hibridos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    protected override void Start()
    {
        base.Start();
        nombre = "Saltarisis";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().hybridSaltaralisis;
            data.GetComponent<Data>().SettingDialogues();

            if (currentScene.name == "Day3")
            {
                dialogue.Add("Hola… Hola… Humano .");
                dialogue.Add("Maldito cacharro, no ir como yo querer.");
                dialogue.Add("Llevo desde ser zanahorio con esta silla, y aún fallar.");
                dialogue.Add("Yo ser Saltaralisis y querer cambiar runas de una vez.");
                dialogue.Add("Sí no cambiar runas, no hablar bien y crear mal entendidos.");
                dialogue.Add("Ya pasar otro día en banco, y cuando yo decir nombre, romper runa.");
                dialogue.Add("Así que repetir palabra ASALTAR todo rato.");
                dialogue.Add(" Ellos llamar guardia y yo acabar en cárcel 3 días.");
                dialogue.Add("Duros días, pero conocer gente maja en cárcel.");
                dialogue.Add("Yo conocer…Yo conocer…Yo conocer… Sapótamo borracho.");
                dialogue.Add("Vuelve a fallar, mejor cobrar para cambiar runas.");

                dialogue.Add("Gra… Gra… cías, cambiar runas ahora.");
                dialogue.Add("No…No…. Poder cambiar, crear más mal entendidos.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Hola humano, ¿cómo estar día?");
                dialogue.Add("Como tu ver ver ver ver ver romper runas de nuevo.");
                dialogue.Add("Yo estar en bar anoche con mi querida familia, hasta que un borracho echarme toda su bebida encima.");
                dialogue.Add("El tipo no quiso reparar mis runas y romperlas toda la noche.");
                dialogue.Add("Ahora necesitar cambiar runas de nuevo, la gente no comprender a mí.");
                dialogue.Add("No entender que yo no nacer con mitad animal, si no con vegetal.");
                dialogue.Add("Deber cambiar alguna cosa para hacer mejor trato a los híbridos mitad vegetal.");
                dialogue.Add("O al menos hacer algo para que los híbridos vegetarianos no babear babear babear con nosotros.");
                dialogue.Add("Ya volver a funcionar mal, cóbrame que querer cambiar runas.");

                dialogue.Add("Gracias humano, cambiar en nada runas.");
                dialogue.Add("Yo solo querer cerveza para papá, pero bueno, dar solo runas mejor.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day3")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "12";
        }

        else if (currentScene.name == "Day5")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "14";
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
