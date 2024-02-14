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

    protected override void Start()
    {
        base.Start();
        nombre = "Mara";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().hybridMara;

            if (currentScene.name == "Day1")
            {
                //dialogue.Add("Buenos días querido, soy Mara.");
                //dialogue.Add("¿Podías luego ayudarme a cargar esto hasta fuera?");
                //dialogue.Add("Uy uy, que digo, me imagino que no puedes abandonar tu puesto.");
                //dialogue.Add("Desde que no está mi marido, me cuesta más cargar la compra.");
                //dialogue.Add("Pero bueno, como quiero que esté mi marido si me lo comí.");
                //dialogue.Add("...");
                //dialogue.Add("Que raro que estés inexpresivo, siempre que cuento eso se asustan.");
                //dialogue.Add("No sé porque no se normaliza que los manguros nos comamos a nuestra pareja.");
                //dialogue.Add("Pero sólo para reproducirnos, no somos unos monstruos.");
                //dialogue.Add("Bueno, deberías cobrarme, que tengo que recoger a mi niño del zoo.");

                //dialogue.Add("Muchas gracias joven, espero que tu pareja te coma pronto también ji ji ji.");
                //dialogue.Add("¿Perdona? Ahora por tu culpa mi hijo no tendrá su gato muerto, él solo quería una mascota");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Uy, buenos días cielo, se nota que eres un buen trabajador.");
                dialogue.Add("Debería de tomar ejemplo de ti, que me hubiera venido mejor trabajar en vez de ir a la horrible cita del otro día.");
                dialogue.Add("Para una vez que decido volver a darle a un intento al amor, y con el tiempo que le dediqué a mi cuenta de Hybrinder.");
                dialogue.Add("Llegué al pequeño local limbásticos, con mis patas raptoriales recién afiladas, y el tipo resultó no ser un híbrido.");
                dialogue.Add("Ni siquiera su cabeza se veía apetitosa, tenía una pedazo de esfera en su cabeza.");
                dialogue.Add("Y lo más raro es que el que hablaba era el espíritu de la esfera.");
                dialogue.Add("Igualmente accedí a cenar con él, aunque me hubiera engañado de esta manera.");
                dialogue.Add("Nada más me separé de él, le bloqueé de todos lados, espero no verlo más en mi vida.");
                dialogue.Add("Perdona si te aburriste con mi historia querido, cóbrame que tengo que ir a más tiendas querido.");

                dialogue.Add("Gracias cielo, espero nunca que no tengas citas como la mía.");
                dialogue.Add("¿Está prohibido esto? Bueno, ayer vi varias personas comprándolo, que raro.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "12";
        }

        else if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, twoProducts1.position, twoProducts1.rotation);
            product1.transform.SetParent(twoProducts1);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts2.position, twoProducts2.rotation);
            product2.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "18";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
