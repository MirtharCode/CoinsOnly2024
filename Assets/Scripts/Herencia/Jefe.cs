using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Jefe : RazaJefe
{
    bool repetirunavez = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            if (currentScene.name == "Day1")
            {
                dialogue.Add("Hola chico nuevo, soy tu jefe.");
                dialogue.Add("Y c�mo s� que es tu primer d�a, te estar� observando.");
                dialogue.Add("Porque s� que no ser�s capaz de atender a los clientes bien.");
                dialogue.Add("Ya sabes que todos los humanos sois in�tiles.");
                dialogue.Add("No lo digo yo, lo dice vuestro cerebro enano.");
                dialogue.Add("Pero bueno, como iba diciendo� �ATIENDE BIEN!");
                dialogue.Add("No quiero perder dinero contigo.");
                dialogue.Add("Para cobrar dale a LA BOLSA DE DINERO");
                dialogue.Add("Y para no cobrar, dale a la CAJA REGISTRADORA");
                dialogue.Add("Y como cobres mal, te quitar� dinero de tu querido tarro.");
                dialogue.Add("Tienes el cat�logo de la tienda para saber si el cliente tiene dinero suficiente.");
                dialogue.Add("Adem�s tendr�s una ayuda, la cabeza del antiguo empleado.");
                dialogue.Add("Se la arranc� un cliente al que no le vendi� su alcohol.");
                dialogue.Add("Menos mal que su sistema de traducci�n sigue funcionando.");
                dialogue.Add("No iba a comprarte otro traductor como ese no fuera.");
                dialogue.Add("Suerte en tu primer d�a, chico nuevo.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day2")
            {
                dialogue.Add("Buenos d�as chico nuevo, soy el jefe.");
                dialogue.Add("�Qu� tal tu primer d�a?");
                dialogue.Add("Nah, es broma, realmente me da igual como te fuera tu primer d�a.");
                dialogue.Add("Seguro te lo dije en el tutorial, pero seguro no te acuerdas por tu cerebro enano.");
                dialogue.Add("Tenemos unas normas que seguir en la tienda.");
                dialogue.Add("Y hoy es �Magic Friday�, aunque lo seguir� siendo el resto del a�o, como todos los a�os...");
                dialogue.Add("As� que los magos tienen rebajas, y el resto de razas trabajan m�s a cambio.");
                dialogue.Add("Tambi�n han prohibido varias bebidas a algunas razas.");
                dialogue.Add("Parece que sus cuerpos no soportan los ingredientes ilegales que llevan.");
                dialogue.Add("Eso es menos dinero para mi por desgracia.");
                dialogue.Add("Pero la multa ser� peor si me pillan.");
                dialogue.Add("Recuerda revisar las normas, estar�n debajo del cat�logo.");
                dialogue.Add("Buena suerte chico nuevo");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day3")
            {
                dialogue.Add("Buenas chico nuevo, soy el jefe.");
                dialogue.Add("Parece que est�s empezando a acostumbrarte al trabajo.");
                dialogue.Add("Est�s durando m�s que el antiguo empleado.");
                dialogue.Add("No s� c�mo sigues vivo siquiera.");
                dialogue.Add("Pero bueno, tengo malas noticias.");
                dialogue.Add("Parece que quieren acabar con el mercado de las pociones.");
                dialogue.Add("Muchos magos y limb�sticos abusaban de sus efectos.");
                dialogue.Add("Y encerraron a una secta de elementales que usaban magia negra.");
                dialogue.Add("Tienen a todas esas razas fichadas.");
                dialogue.Add("Adem�s de que por culpa de un h�brido borracho, que vomit� al Rey Mago.");
                dialogue.Add("Los h�bridos no pueden beber m�s alcohol, menudo d�a.");
                dialogue.Add("Mirate las nuevas normas.");
                dialogue.Add("Suerte chico no tan nuevo.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }
        }
    }

    public override void ByeBye()
    {
        base.ByeBye();
    }
}
