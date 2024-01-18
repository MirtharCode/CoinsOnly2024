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
                dialogue.Add("Parece que estás empezando a acostumbrarte al trabajo.");
                dialogue.Add("Estás durando más que el antiguo empleado.");
                dialogue.Add("No sé cómo sigues vivo siquiera.");
                dialogue.Add("Pero bueno, tengo malas noticias.");
                dialogue.Add("Parece que quieren acabar con el mercado de las pociones.");
                dialogue.Add("Muchos magos y limbásticos abusaban de sus efectos.");
                dialogue.Add("Y encerraron a una secta de elementales que usaban magia negra.");
                dialogue.Add("Tienen a todas esas razas fichadas.");
                dialogue.Add("Además de que por culpa de un híbrido borracho, que vomitó al Rey Mago.");
                dialogue.Add("Los híbridos no pueden beber más alcohol, menudo día.");
                dialogue.Add("Mirate las nuevas normas.");
                dialogue.Add("Suerte chico no tan nuevo.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Hola chico nuevo, veo que te estás acostumbrando al trabajo en mi tienda.");
                dialogue.Add("Que raro que ningún mago te la haya arrancado la cabeza por negarte a cobrarle, al anterior dependiente le pasó eso.");
                dialogue.Add("Aunque gracias a ese mago, no tuve que pagarle ese mes.");
                dialogue.Add("Así acabé comprando el carruaje más rápido del reino, aunque se quedó obsoleto por culpa de los coches.");
                dialogue.Add("Por culpa de esas estúpidas máquinas de 4 ruedas, los tecnópedos no podrán comprar pilas y bebida energética junta, por una reacción que los hace más rápidos.");
                dialogue.Add("Se lo tienen merecido por hacerme gastar mis preciosas monedas en un carruaje que quedó obsoleto.");
                dialogue.Add("Y también me enteré hace poco que hay una secta convirtiendo híbridos en limbásticos.");
                dialogue.Add("Por lo que los híbridos no podrán comprar nada de magia negra, esa secta solo me ha hecho perder dinero.");
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
