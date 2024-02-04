using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Giovanni : Limbasticos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
    bool repetirunavez = false;

    protected override void Start()
    {
        base.Start();
        nombre = "Giovanni";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().limbasticGiovanni;

            if (currentScene.name == "Day1")
            {
                dialogue.Add("¡Ahoy, amigo mío! Soy Giovanni.");
                dialogue.Add("No sabes lo que me encontré hoy.");
                dialogue.Add("¡EL N-E-C-R-O-N-O-M-I-C-Ó-N!");
                dialogue.Add("Es el libro de cocina definitivo, o eso creo…");
                dialogue.Add("Bueno, solo con decirte la primera receta te va a encantar.");
                dialogue.Add("“Cómo invocar a Azathoth”");
                dialogue.Add("Suena increíble este plato, pillaré algunos ingredientes para hacer el plato.");
                dialogue.Add("“Primer paso: rociar vino hecho de sangre de virgen”");
                dialogue.Add("Cambiaré el vino por una buena cerveza, le dará más sabor.");
                dialogue.Add("“Segundo paso: cortar el muñeco voodoo por la mitad junto con la persona sacrificada”");
                dialogue.Add("No sé qué es eso de la persona sacrificada, pero el muñeco tiene buena pinta.");
                dialogue.Add("“Y tercer paso: beber el veneno para que el Dios se adueñe de tu cuerpo”");
                dialogue.Add("No suelo beber veneno, pero creo que se lo echaré al muñeco para darle el toque picante.");
                dialogue.Add("Tiene buena pinta ¿verdad? Para eso necesito estos ingredientes, así que si puedes cobrarme.");

                dialogue.Add("Gracias, la próxima vez que vuelva te dejaré probar el plato para que me des tu opinión.");
                dialogue.Add("Madre mía, ahora te perderás el mejor plato del mundo, pillaré las cosas en otro sitio.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day2")
            {

                dialogue.Add("Bon día amigo mío, espero que te esté yendo bien estos días.");
                dialogue.Add("A mí el último plato del otro día no salió como me esperaba la verdad… Me salió... ¡PERFECTO! ");
                dialogue.Add("Me salió... ¡PERFECTO! ");
                dialogue.Add("Hice todos los pasos a la perfección, aunque el veneno le dió un toque picante un poco raro.");
                dialogue.Add("Y fue un poco extraño cuando el plato empezó a hablarme en una lengua antigua, pero peores cosas he probado.");
                dialogue.Add("Aún recuerdo cuando fui a un restaurante de elementales de roca, aunque obviamente el local era de un mago.");
                dialogue.Add("El plato estrella era la gravilla, ese plato tenía una textura asquerosa.");
                dialogue.Add("Era como comerte un castillo de arena derretido.");
                dialogue.Add("Pero bueno, ahora preparé un plato mucho mejor, así que necesitaré estos ingredientes amigo mío.");

                dialogue.Add("Gracias, te dejaré probarlo como quede bueno my besto frendo");
                dialogue.Add("¿Tengo prohibidos estos deliciosos ingredientes? El reino cada vez acaba con la libertad de la comida.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "22";
        }

        else if (currentScene.name == "Day2")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "20";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        Destroy(product3);
        base.ByeBye();
    }
}
