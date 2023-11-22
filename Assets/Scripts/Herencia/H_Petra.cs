using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class H_Petra : Hibridos
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

            if (currentScene.name == "Day2")
            {
                dialogue.Add("Hola dependiente, de verdad que no puedo aguantar m�s mis ganas de empezar a trabajar.");
                dialogue.Add("Necesito cont�rselo a alguien, �Por fin puedo ser una exploradora!");
                dialogue.Add("Necesitaba soltarlo, no sabes lo emocionada que estoy con este nuevo trabajo.");
                dialogue.Add("Por cierto, no me present�, me llamo Petra.");
                dialogue.Add("He estado 12 a�os en paro desde que no llegu� a tiempo a una misi�n.");
                dialogue.Add("Pero es lo que pasa cuando eres mitad tortuga y mitad liebre, que mi velocidad siempre ser� normal.");
                dialogue.Add("Tambi�n mi jefe me coment� que esperaba que lo hiciera mejor que el �ltimo empleado.");
                dialogue.Add("Era un sap�tamo que se la pasaba bebiendo en el trabajo.");
                dialogue.Add("Menos mal que no bebo nada de alcohol en mi vida.");
                dialogue.Add("Uy, perdona, te estoy quitando tiempo.");
                dialogue.Add("Cobrame esto qu� lo necesito para el trabajo.");

                dialogue.Add("Deseame suerte en mi primer d�a de curro, �Nos vemos!");
                dialogue.Add("Necesitaba esto de verdad para el trabajo, el jefe me va a despedir y ni empec�.");


                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day2")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
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
