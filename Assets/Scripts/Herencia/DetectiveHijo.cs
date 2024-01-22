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
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().elDetective;

            if (currentScene.name == "Day2")
            {
                dialogue.Add("Hola dependiente, soy del departamento de investigación de sucesos paranormales, es decir, soy detective.");
                dialogue.Add("Y tenía una pregunta respecto a un caso sobre homicidio, alguien ha vuelto un híbrido a un limbástico.");
                dialogue.Add("Un poco pesado el fiambre diciendo que tenía una cita, pero me da a mi que va a tener que esperar.");
                dialogue.Add("Creemos que ha podido ser un artefacto mágico el culpable, en concreto un libro de magia.");
                dialogue.Add("¿Sabes de algún clientes pueda tener un libro mágico?");
                dialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");

                uIManager.GetComponent<UIManager>().ShowText();

                //GetComponent<GrayscaleScript>().StartGrayscaleRoutine();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day3")
            {
                dialogue.Add("Buenos días dependiente, veo que ha sido un día ajetreado.");
                dialogue.Add("Ayer mandamos al Detective León a investigar a los sospechosos de ayer, al parecer Giovanni sabe cosas.");
                dialogue.Add("Tuvo en posesión un libro de magia ancestral, que fue prohibida hace siglos aunque se desconoce que hace.");
                dialogue.Add("Nos comentó que se le encontró de camino de la gasolinera donde trabaja el fiambre la misma noche.");
                dialogue.Add("Tras varias comprobaciones supimos que era cierto y que no puede ser el culpable.");
                dialogue.Add("Aunque ahora tenemos alguna pista más, un cliente de esta tienda usó una bola de cristal en el ritual.");
                dialogue.Add("Y que la compró bajo el nombre de “Manolo”, según un ticket tirado por la escena del crimen.");
                dialogue.Add("¿Sabes si alguno de los siguientes sospechosos pueda tener relación con la descripción que te dí?");
                dialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Buenos días humano, la investigación se está alargando bastante.");
                dialogue.Add("Puede que no lo sepas, pero este caso se empezó porque estamos buscando a quién está creando limbásticos.");
                dialogue.Add("Los limbásticos son incapaces de recordar dónde les crearon, pero con algo de investigación encontramos algo.");
                dialogue.Add("Un sospechoso de ayer parece formar parte de una religión de la que desconocemos.");
                dialogue.Add("Y creemos que pueden estar relacionados con la creación de limbásticos.");
                dialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                dialogue.Add("Creemos que el sospechoso se reunió con otro cliente de esta tienda para hacer un limbástico.");
                dialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                dialogue.Add("Creemos que el sospechoso se reunió con otro cliente de esta tienda para hacer un limbástico.");
                dialogue.Add("¿Sabes si alguno de los siguientes sospechosos se relacionó con la iglesia?");
                dialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Traigo muy buenas noticias humano, estamos a nada de cerrar el caso.");
                dialogue.Add("Uno de los sospechosos de ayer confesó que la iglesia le ayudó a revivir a un tal Sergio Nerviosaus.");
                dialogue.Add("Esta noche, haremos una redada en la iglesia para encerrar a los miembros.");
                dialogue.Add("Así que puede que en nada vayamos a cerrar el caso, aunque aún nos queda una cosa por resolver.");
                dialogue.Add("Quién fue la persona que le dió con el orbe al fiambre.");
                dialogue.Add("Tenemos algunos sospechosos, pero no estamos del todo seguros.");
                dialogue.Add("Hasta el detective Black no sabe quién arrestar.");
                dialogue.Add("Dime humano, ¿quién crees que fue quién lo mató?");
                dialogue.Add("Muchas gracias por ayudar en el caso, espero que nos volvamos a ver.");

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
