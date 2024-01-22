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
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().evilWizardManoloMano;

            if (currentScene.name == "Day3")
            {
                dialogue.Add("Hola mortal, ¿No habrás visto un libro mágico alguno de estos días?");
                dialogue.Add("...");
                dialogue.Add("Llevo días buscando un libro que se me fue robado, es importante ¿sabes?");
                dialogue.Add("...");
                dialogue.Add("El habla no parece ser tu punto fuerte mortal.");
                dialogue.Add("Pero bueno, haré que ese ladrón recuerde mi nombre, Manolo Mago Manitas.");
                dialogue.Add("Por su culpa y la del otro calamar no se pudo terminar el ritu…");
                dialogue.Add("Si ves a alguien con libro mágico, avisame mortal.");
                dialogue.Add("Puede que vuelva en algún otro momento, pero primero debo atender a mi deber.");
                dialogue.Add("Tengo que volver a mi iglesia, hay que dar la misa para nuestro dios, Azathoth.");
                dialogue.Add("Por lo que ve cobrandome mortal.");

                dialogue.Add("Buen chico, nos vemos mortal.");
                dialogue.Add("Parece que eres otro sacrificio más, Azathoth te maldecirá por tu incompetencia.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            if (currentScene.name == "Day4")
            {
                dialogue.Add("Hola humano, hoy no vengo como cliente, sino como testigo de Azathoth.");
                dialogue.Add("¿Has reconsiderado acercarte a mi iglesia?");
                dialogue.Add("Últimamente aceptamos a varios humanos para que se unan a rezar con nosotros, siempre vienen nuevos.");
                dialogue.Add("Aunque hace poco comprobamos que los híbridos también son “bienvenidos” a nuestra religión.");
                dialogue.Add("Transformamos a uno de ellos en uno de los nuestros... Fue simplemente arte.");
                dialogue.Add("Pero bueno, solo me acercaba por aquí para que reconsideraras la oferta, siempre te daremos una mano.");
                dialogue.Add("Suerte en la tienda, humano.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Buenos días próximo creyente, veo que sigues encadenado a esta tienda.");
                dialogue.Add("Podrías intentar ser más libre si vinieras alguna vez a una de las misas de mi iglesia.");
                dialogue.Add("Además te beneficiaría venir, con cierta información que te voy a contar ahora.");
                dialogue.Add("Vamos a hacer que vuelvan antiguos héroes a la vida, el primero fue el gran Sergio Nerviosaus.");
                dialogue.Add("Pero dentro de poco, no será el único que volverá a la vida y nos ayudará.");
                dialogue.Add("Así que creo que te beneficiaría estar de nuestra parte, y no de la del detective que lleva unos días viéndote.");
                dialogue.Add("¿Crees que no lo sabía? Ese detective lleva algunos días indagando en nuestra sagrada iglesia.");
                dialogue.Add("Además de que siempre viene a esta tienda al final del día, así que espero que hoy le mientas un poquito.");
                dialogue.Add("Pero bueno, hoy vine como cliente, por lo que cóbrame humano.");

                dialogue.Add("Te espero pronto en mi iglesia, humano.");
                dialogue.Add("Cuando revivamos a los héroes, espero que no sepas contar mejor.");

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

        else if (currentScene.name == "Day5")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
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
