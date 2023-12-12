using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Mara : Hibridos
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

            if (currentScene.name == "Day1")
            {
                dialogue.Add("Buenos días querido, soy Mara.");
                dialogue.Add("¿Podías luego ayudarme a cargar esto hasta fuera?");
                dialogue.Add("Uy uy, que digo, me imagino que no puedes abandonar tu puesto.");
                dialogue.Add("Desde que no está mi marido, me cuesta más cargar la compra.");
                dialogue.Add("Pero bueno, como quiero que esté mi marido si me lo comí.");
                dialogue.Add("...");
                dialogue.Add("Que raro que estés inexpresivo, siempre que cuento eso se asustan.");
                dialogue.Add("No sé porque no se normaliza que los manguros nos comamos a nuestra pareja.");
                dialogue.Add("Pero sólo para reproducirnos, no somos unos monstruos.");
                dialogue.Add("Bueno, deberías cobrarme, que tengo que recoger a mi niño del zoo.");

                dialogue.Add("Muchas gracias joven, espero que tu pareja te coma pronto también ji ji ji.");
                dialogue.Add("¿Perdona? Ahora por tu culpa mi hijo no tendrá su gato muerto, él solo quería una mascota");

                gameManager.GetComponent<GameManager>().ShowText();

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            gameManager.GetComponent<GameManager>().leDineroText.text = "18";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
