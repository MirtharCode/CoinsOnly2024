using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetectiveHijo : DetectivePadre
{
    bool repetirunavez = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            if (currentScene.name == "Day2")
            {
                dialogue.Add("Hola cara huevo.");
                dialogue.Add("Dime el sospechoso");
                dialogue.Add("Como tan muchacho, me voy, adio");

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

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Hola chico nuevo, veo que te est�s acostumbrando al trabajo en mi tienda.");
                dialogue.Add("Que raro que ning�n mago te la haya arrancado la cabeza por negarte a cobrarle, al anterior dependiente le pas� eso.");
                dialogue.Add("Aunque gracias a ese mago, no tuve que pagarle ese mes.");
                dialogue.Add("As� acab� comprando el carruaje m�s r�pido del reino, aunque se qued� obsoleto por culpa de los coches.");
                dialogue.Add("Por culpa de esas est�pidas m�quinas de 4 ruedas, los tecn�pedos no podr�n comprar pilas y bebida energ�tica junta, por una reacci�n que los hace m�s r�pidos.");
                dialogue.Add("Se lo tienen merecido por hacerme gastar mis preciosas monedas en un carruaje que qued� obsoleto.");
                dialogue.Add("Y tambi�n me enter� hace poco que hay una secta convirtiendo h�bridos en limb�sticos.");
                dialogue.Add("Por lo que los h�bridos no podr�n comprar nada de magia negra, esa secta solo me ha hecho perder dinero.");
                dialogue.Add("Bueno, es hora de que empiece tu turno, recuerda mirar las nuevas normas.");
                dialogue.Add("Suerte humano.");

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
