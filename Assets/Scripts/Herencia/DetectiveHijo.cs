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
                dialogue.Add("Hola dependiente, soy del departamento de investigaci�n de sucesos paranormales, es decir, soy detective.");
                dialogue.Add("Y ten�a una pregunta respecto a un caso sobre homicidio, alguien ha vuelto un h�brido a un limb�stico.");
                dialogue.Add("Un poco pesado el fiambre diciendo que ten�a una cita, pero me da a mi que va a tener que esperar.");
                dialogue.Add("Creemos que ha podido ser un artefacto m�gico el culpable, en concreto un libro de magia.");
                dialogue.Add("�Sabes de alg�n clientes pueda tener un libro m�gico?");
                dialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");

                uIManager.GetComponent<UIManager>().ShowText();

                //GetComponent<GrayscaleScript>().StartGrayscaleRoutine();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day3")
            {
                dialogue.Add("Buenos d�as dependiente, veo que ha sido un d�a ajetreado.");
                dialogue.Add("Ayer mandamos al Detective Le�n a investigar a los sospechosos de ayer, al parecer Giovanni sabe cosas.");
                dialogue.Add("Tuvo en posesi�n un libro de magia ancestral, que fue prohibida hace siglos aunque se desconoce que hace.");
                dialogue.Add("Nos coment� que se le encontr� de camino de la gasolinera donde trabaja el fiambre la misma noche.");
                dialogue.Add("Tras varias comprobaciones supimos que era cierto y que no puede ser el culpable.");
                dialogue.Add("Aunque ahora tenemos alguna pista m�s, un cliente de esta tienda us� una bola de cristal en el ritual.");
                dialogue.Add("Y que la compr� bajo el nombre de �Manolo�, seg�n un ticket tirado por la escena del crimen.");
                dialogue.Add("�Sabes si alguno de los siguientes sospechosos pueda tener relaci�n con la descripci�n que te d�?");
                dialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day4")
            {
                dialogue.Add("Buenos d�as humano, la investigaci�n se est� alargando bastante.");
                dialogue.Add("Puede que no lo sepas, pero este caso se empez� porque estamos buscando a qui�n est� creando limb�sticos.");
                dialogue.Add("Los limb�sticos son incapaces de recordar d�nde les crearon, pero con algo de investigaci�n encontramos algo.");
                dialogue.Add("Un sospechoso de ayer parece formar parte de una religi�n de la que desconocemos.");
                dialogue.Add("Y creemos que pueden estar relacionados con la creaci�n de limb�sticos.");
                dialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                dialogue.Add("Creemos que el sospechoso se reuni� con otro cliente de esta tienda para hacer un limb�stico.");
                dialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                dialogue.Add("Creemos que el sospechoso se reuni� con otro cliente de esta tienda para hacer un limb�stico.");
                dialogue.Add("�Sabes si alguno de los siguientes sospechosos se relacion� con la iglesia?");
                dialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Traigo muy buenas noticias humano, estamos a nada de cerrar el caso.");
                dialogue.Add("Uno de los sospechosos de ayer confes� que la iglesia le ayud� a revivir a un tal Sergio Nerviosaus.");
                dialogue.Add("Esta noche, haremos una redada en la iglesia para encerrar a los miembros.");
                dialogue.Add("As� que puede que en nada vayamos a cerrar el caso, aunque a�n nos queda una cosa por resolver.");
                dialogue.Add("Qui�n fue la persona que le di� con el orbe al fiambre.");
                dialogue.Add("Tenemos algunos sospechosos, pero no estamos del todo seguros.");
                dialogue.Add("Hasta el detective Black no sabe qui�n arrestar.");
                dialogue.Add("Dime humano, �qui�n crees que fue qui�n lo mat�?");
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
