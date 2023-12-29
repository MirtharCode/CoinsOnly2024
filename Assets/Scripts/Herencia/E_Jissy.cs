using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class E_Jissy : Elementales
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
                dialogue.Add("¿Qué pasa tío? ¿Cómo estamos?");
                dialogue.Add("Espera, tú… Tú no eres el del otro día... ¿No?");
                dialogue.Add("Yo soy Jissy, Jissy Blueman, mi nombre de las calles tío.");
                dialogue.Add("Perdona tronco pero, ¿Seguro que no eres el de siempre?");
                dialogue.Add("Nunca se me ha dado bien lo de reconocer a la gente, ¿Sabes?");
                dialogue.Add("Aunque creo que el anterior no era humano, era... un raza superior ¿Sabes?");
                dialogue.Add("Espero que no te afecte mi comentario, tampoco se me da bien socializar.");
                dialogue.Add("En fin, que te vaya bien...");
                dialogue.Add("¡Ah, sí!, antes de irme cóbrame esto, que me iba sin pagar ¿sabes?");

                dialogue.Add("Gracias colega, deberíamos quedar algún día para hablar de... la vida ¿Sabes?");
                dialogue.Add("Bueno tronco… lo entiendo… ¿Sabes? Me alegra saber que al menos no romperé las normas.");

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
            product2 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            uIManager.GetComponent<UIManager>().leDineroText.text = "10";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
