using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class E_Handy : Elementales
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
                dialogue.Add("¡Hola colega! ¿Cómo te encuentras? ¿Bien? ¿Mal?");
                dialogue.Add("¡YO ESTOY FENOMENAL!");
                dialogue.Add("Soy Handy, el elemental más fiestero, que ama cualquier celebración.");
                dialogue.Add("Cumpleaños, bodas, despedidas de solteros y… ¡FUNERALES!");
                dialogue.Add("Aunque del último funeral me echaron por alguna extraña razón...");
                dialogue.Add("Estoy tan emocionado amigo mío, tengo una nueva compañera.");
                dialogue.Add("Se llama Rave-n, incluso estudió fiestología.");
                dialogue.Add("Aunque me expulsaron del grado de fiestología por mi TFG sobre… ¡ALEGRAR FUNERALES!");
                dialogue.Add("Se debieron morir de la risa con mi TFG.");
                dialogue.Add("Bueno colega, sé que estás pasando un buen rato conmigo.");
                dialogue.Add("Pero tengo una despedida de soltero y tengo que aguantar toda la noche despierto.");
                dialogue.Add("Y necesito estos utensilios para sobrevivir a los solteros desesperados.");
                dialogue.Add("Aunque no sé para qué será la bola, me la pidieron los solteros");
                dialogue.Add("Bueno, cóbrame porfi porfita.");

                dialogue.Add("Voy a hacer una despedida de soltero !INCREÍBLE! Nos vemos colega.");
                dialogue.Add("Me has borrado la sonrisa tío, pero entiendo que no puedas romper la normativa");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            if (currentScene.name == "Day4")
            {
                dialogue.Add("Dependiente... Hoy no podría ser... ¡LA MEJOR SEMANA DE MI VIDA!");
                dialogue.Add("El trabajo del otro día fue genial, los solteros fueron encantadores.");
                dialogue.Add("Les encantó cuando me puse a hacer mi monólogo.");
                dialogue.Add("Y mi compañera es una DJ genial, en el momento de las copas salió a hacer su parte.");
                dialogue.Add("Baile con el novio un rato, pero no paraba de tocar mi bocina, era un tipo raro.");
                dialogue.Add("Pero bueno, ahora tenemos un nuevo trabajo para hoy, una gatoteca.");
                dialogue.Add("Hemos pensado en animar haciendo un musical con los gatos, pero son unos bichos muy ariscos y arrítmicos.");
                dialogue.Add("Así que hemos pensado en otra cosa, vamos a bollos con forma de gatito.");
                dialogue.Add("En fin, sabes que me encanta estar contigo, pero se me está haciendo tarde amigo.");
                dialogue.Add("Por lo que cóbrame que tengo que alegrar esa gatoteca.");

                dialogue.Add("Deséame la mayor de las suerte en mi nuevo trabajo.");
                dialogue.Add("Espero que el trabajo me vaya bien igualmente");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day2")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().crystallBall, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "20";
        }

        else if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "12";
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
