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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().crystallBall, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            gameManager.GetComponent<GameManager>().leDineroText.text = "13";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
