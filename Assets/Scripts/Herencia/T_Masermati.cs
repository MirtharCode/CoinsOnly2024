using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_Masermati : Tecnopedos
{
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;

    protected override void Start()
    {
        base.Start();
        nombre = "Masermati";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().electropedMasermati;
            data.GetComponent<Data>().SettingDialogues();

            if (currentScene.name == "Day2")
            {
                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }

            else if (currentScene.name == "Day5")
            {
                dialogue.Add("Hola cocherrumín, ¿adivina quién participó en la carrera del otro día y quedó en 1º lugar?");
                dialogue.Add("Pues yo no porque quedé en 8º lugar, pero lo importante fue participar.");
                dialogue.Add("Si sigo entrenando, puede que para la próxima quede en 1º lugar.");
                dialogue.Add("Si no fuera porque Flecha Rápida hiciera trampa, ese trasto de 4 ruedas lanzó clavos por el camino.");
                dialogue.Add("Es igual de miserable que su dueño Pijus Magnus, la próxima vez no se repetirá.");
                dialogue.Add("Menos mal que mi familia se quedó apoyándome hasta el final.");
                dialogue.Add("Seguro que en cuanto me ponga la luces traseras y el cambio de marchas mejoraré mucho más.");
                dialogue.Add("Pero como siempre dan citas para dentro de 3 meses en reparación pública.");
                dialogue.Add("Esperaré hasta la cita y la operación para ser mejor coche en mi siguiente carrera.");
                dialogue.Add("Bueno cocherrumín, creo que debería ir corriendo hasta casa que se me hace tarde.");

                dialogue.Add("Ahora voy acelerando a casa para no llegar tarde, chao. ");
                dialogue.Add("Con las prisas se me olvidó revisar las normas");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().magicRune, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "10";
        }

        else if (currentScene.name == "Day5")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicBattery, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            uIManager.GetComponent<UIManager>().leDineroText.text = "22";
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
