using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Giovanni : Limbasticos
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

            if (currentScene.name == "Day1")
            {
                dialogue.Add("�Ahoy, amigo m�o! Soy Giovanni.");
                dialogue.Add("No sabes lo que me encontr� hoy.");
                dialogue.Add("�EL N-E-C-R-O-N-O-M-I-C-�-N!");
                dialogue.Add("Es el libro de cocina definitivo, o eso creo�");
                dialogue.Add("Bueno, solo con decirte la primera receta te va a encantar.");
                dialogue.Add("�C�mo invocar a Azathoth�");
                dialogue.Add("Suena incre�ble este plato, pille algunos ingredientes para hacer el plato.");
                dialogue.Add("�Primer paso: rociar vino hecho de sangre de virgen�");
                dialogue.Add("Cambiar� el vino por una buena cerveza, le dar� m�s sabor.");
                dialogue.Add("�Segundo paso: cortar el mu�eco voodoo por la mitad junto con la persona sacrificada�");
                dialogue.Add("No s� qu� es eso de la persona sacrificada, pero el mu�eco tiene buena pinta.");
                dialogue.Add("�Y tercer paso: beber el veneno para que el Dios se adue�e de tu cuerpo�");
                dialogue.Add("No suelo beber veneno, pero creo que se lo echar� al mu�eco para darle el toque picante.");
                dialogue.Add("Tiene buena pinta �verdad? Para eso necesito estos ingredientes, as� que si puedes cobrarme.");
                dialogue.Add("Gracias, la pr�xima vez que vuelva te dejar� probar el plato para que me des tu opini�n.");
                dialogue.Add("Madre m�a, ahora te perder�s el mejor plato del mundo, pillar� las cosas en otro sitio.");


                gameManager.GetComponent<GameManager>().ShowText();
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
            gameManager.GetComponent<GameManager>().leDineroText.text = "22";
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
