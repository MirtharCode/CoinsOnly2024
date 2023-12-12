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

            if (currentScene.name == "Day2")
            {
                dialogue.Add("¿Qué pasa tío?¿Cómo estamos?");
                dialogue.Add("Espera, tu… Tu no eres el de el otro día ¿no..?");
                dialogue.Add("Yo soy Jissy, Jissy Blueman, mi nombre de las calles tío.");
                dialogue.Add("Perdona tronco pero, ¿Seguro que no eres el dependiente de siempre?");
                dialogue.Add("Nunca se me ha dado bien esto de reconocer a la gente, ¿sabes?");
                dialogue.Add("Pero tienes un parecido al anterior dependiente.");
                dialogue.Add("Aunque creo que el anterior no era humano, era un raza superior ¿sabes?");
                dialogue.Add("Espero que no te afectará el comentario, tampoco se me da bien socializar.");
                dialogue.Add("En fín, espero que te vaya bien.");
                dialogue.Add("Ah, sí, pero antes de irme, cobrame esto.");
                dialogue.Add("Que me iba sin pagar ¿sabes?");

                dialogue.Add("Gracias colega, deberíamos quedar algún día para hablar de la vida ¿sabes?");
                dialogue.Add("Bueno tronco… lo entiendo… ¿Sabes? Me alegra saber que al menos no romperé las normas.");

                gameManager.GetComponent<GameManager>().ShowText();

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().beer, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            gameManager.GetComponent<GameManager>().leDineroText.text = "20";
        }
    }

    public override void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        base.ByeBye();
    }
}
