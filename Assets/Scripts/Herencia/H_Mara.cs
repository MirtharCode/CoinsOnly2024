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
                //dialogue.Add("Buenos d�as querido, soy Mara.");
                //dialogue.Add("�Pod�as luego ayudarme a cargar esto hasta fuera?");
                //dialogue.Add("Uy uy, que digo, me imagino que no puedes abandonar tu puesto.");
                //dialogue.Add("Desde que no est� mi marido, me cuesta m�s cargar la compra.");
                //dialogue.Add("Pero bueno, como quiero que est� mi marido si me lo com�.");
                //dialogue.Add("...");
                //dialogue.Add("Que raro que est�s inexpresivo, siempre que cuento eso se asustan.");
                //dialogue.Add("No s� porque no se normaliza que los manguros nos comamos a nuestra pareja.");
                //dialogue.Add("Pero s�lo para reproducirnos, no somos unos monstruos.");
                //dialogue.Add("Bueno, deber�as cobrarme, que tengo que recoger a mi ni�o del zoo.");

                //dialogue.Add("Muchas gracias joven, espero que tu pareja te coma pronto tambi�n ji ji ji.");
                //dialogue.Add("�Perdona? Ahora por tu culpa mi hijo no tendr� su gato muerto, �l solo quer�a una mascota");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Uy, buenos d�as cielo, se nota que eres un buen trabajador.");
                dialogue.Add("Deber�a de tomar ejemplo de ti, que me hubiera venido mejor trabajar en vez de ir a la horrible cita del otro d�a.");
                dialogue.Add("Para una vez que decido volver a darle a un intento al amor, y con el tiempo que le dediqu� a mi cuenta de Hybrinder.");
                dialogue.Add("Llegu� al peque�o local limb�sticos, con mis patas raptoriales reci�n afiladas, y el tipo result� no ser un h�brido.");
                dialogue.Add("Ni siquiera su cabeza se ve�a apetitosa, ten�a una pedazo de esfera en su cabeza.");
                dialogue.Add("Y lo m�s raro es que el que hablaba era el esp�ritu de la esfera.");
                dialogue.Add("Igualmente acced� a cenar con �l, aunque me hubiera enga�ado de esta manera.");
                dialogue.Add("Nada m�s me separ� de �l, le bloque� de todos lados, espero no verlo m�s en mi vida.");
                dialogue.Add("Perdona si te aburriste con mi historia querido, c�brame que tengo que ir a m�s tiendas querido.");

                dialogue.Add("Gracias cielo, espero nunca que no tengas citas como la m�a.");
                dialogue.Add("�Est� prohibido esto? Bueno, ayer vi varias personas compr�ndolo, que raro.");

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
