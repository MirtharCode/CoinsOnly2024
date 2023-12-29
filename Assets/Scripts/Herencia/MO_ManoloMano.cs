using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MO_ManoloMano : MagosOscuros
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
                dialogue.Add("Hola mortal, �No habr�s visto un libro m�gico alguno de estos d�as?");
                dialogue.Add("...");
                dialogue.Add("Llevo d�as buscando un libro que se me fue robado, es importante �sabes?");
                dialogue.Add("...");
                dialogue.Add("El habla no parece ser tu punto fuerte mortal.");
                dialogue.Add("Pero bueno, har� que ese ladr�n recuerde mi nombre, Manolo Mago Manitas.");
                dialogue.Add("Por su culpa y la del otro calamar no se pudo terminar el ritu�");
                dialogue.Add("Si ves a alguien con libro m�gico, avisame mortal.");
                dialogue.Add("Puede que vuelva en alg�n otro momento, pero primero debo atender a mi deber.");
                dialogue.Add("Tengo que volver a mi iglesia, hay que dar la misa para nuestro dios, Azathoth.");
                dialogue.Add("Por lo que ve cobrandome mortal.");

                dialogue.Add("Buen chico, nos vemos mortal.");
                dialogue.Add("Parece que eres otro sacrificio m�s, Azathoth te maldecir� por tu incompetencia.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            if (currentScene.name == "Day4")
            {
                dialogue.Add("Hola humano, hoy no vengo como cliente, sino como testigo de Azathoth.");
                dialogue.Add("�Has reconsiderado acercarte a mi iglesia?");
                dialogue.Add("�ltimamente aceptamos a varios humanos para que se unan a rezar con nosotros, siempre vienen nuevos.");
                dialogue.Add("Aunque hace poco comprobamos que los h�bridos tambi�n son �bienvenidos� a nuestra religi�n.");
                dialogue.Add("Transformamos a uno de ellos en uno de los nuestros... Fue simplemente arte.");
                dialogue.Add("Pero bueno, solo me acercaba por aqu� para que reconsideraras la oferta, siempre te daremos una mano.");
                dialogue.Add("Suerte en la tienda, humano.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().crystallBall, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "11";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
