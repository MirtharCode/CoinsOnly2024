using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class T_MagmaDora : Tecnopedos
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

            if (currentScene.name == "Day4")
            {
                dialogue.Add("Buenas ma�anas persona fr�a, soy Magmadora.");
                dialogue.Add("Fr�o de personalidad o fr�o de carne, t� dir�s, solo tienes que mirarme.");
                dialogue.Add("Veo que no eres el mismo trozo de carne fr�a que hab�a antes en este lugar.");
                dialogue.Add("Haber si llega ya el maldito verano que yo soy de los que prefiere el calor, sino mira como estoy que ardo.");
                dialogue.Add("De verdad que la gente que prefiere el fr�o no la entiendo.");
                dialogue.Add("Si no estuvieras hecho de carne, tambi�n preferir�as el calor.");
                dialogue.Add("Ventajas de no poder sudar.");
                dialogue.Add("En fin, �Te importar�a cobrarme esto? Que me estoy quedando sin llama y tengo que avivarme un poco.");

                dialogue.Add("Gracias, espero que cuando termine de trabajar no se enfr�e de camino a casa.");
                dialogue.Add("�C�mo que han prohibido comprar pociones? �AHORA C�MO PODR� COMPRAR MI POCI�N DE LAVA!");


                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day4")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().manaPotion, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "16";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}