using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Jefe : RazaJefe
{
    protected override void Start()
    {
        base.Start();
        nombre = "El Jefe";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().elJefe;
            //data.GetComponent<Data>().SettingDialogues();

            uIManager.GetComponent<UIManager>().ShowText();

            dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
            dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

            //StartCoroutine(ShowLine());


            if (currentScene.name == "Day3")
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

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Hola humano, ¿Sabes que hoy es un día especial?");
                dialogue.Add("Es el primer día del año que no tenemos nuevas normas, ¡ASÍ PODRÉ TENER MÁS DINERO!");
                dialogue.Add("Y al ser un día tan especial, te daré un trato especial.");
                dialogue.Add("Revisaré cómo trabajaste por mis cámaras… Digo con mis poderosas habilidades mentales.");
                dialogue.Add("Y si lo has hecho muy bien, seguirás trabajando aquí, o al menos espero que puedas pagarte la maldita documentación.");
                dialogue.Add("Como no hayas ganado suficiente dinero, ¡TE QUEDAS SIN LA DOCUMENTACIÓN!");
                dialogue.Add("Pero bueno, confío que hayas sido un buen trabajador.");
                dialogue.Add("Suerte en el que espero que no sea tu último día.");

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

    // El jefe tenía 150 líneas de código.
}
