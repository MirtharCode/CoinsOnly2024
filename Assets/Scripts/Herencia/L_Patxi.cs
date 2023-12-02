using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L_Patxi : Limbasticos
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

            if (currentScene.name == "Day3")
            {
                dialogue.Add("No s� c�mo mi hombre est� tan ocupado, maldita programaci�n. ");
                dialogue.Add("Y siempre tan apagado, le est�n chupando el alma a mi Antonio. ");
                dialogue.Add("Ay ay ay, Antonio m�o deja la programa...");
                dialogue.Add("��Usted qui�n es?!  Espera que ya es mi turno.");
                dialogue.Add("Me hab�a olvidado que estaba en la cola mientras deliraba con mi Antonio.");
                dialogue.Add("Es mi querido noviecito, curra m�s que un elemental en las minas.");
                dialogue.Add("Y yo soy el mejor novio que se ha tenido, Patxi.");
                dialogue.Add("El pobre trabaja de programador, mientras que yo soy corredor de bolsa.");
                dialogue.Add("Solo tengo que correr con unas bolsas, es un buen trabajo para un limb�stico.");
                dialogue.Add("Y ya que su trabajo es tan complicado quiero hacerle algo especial�");
                dialogue.Add("Quer�a prepararle una cena rom�ntica esta noche, as� que si puedes cobrarme esto.");

                dialogue.Add("Mi Antonio va a perder la cabeza con esta cena, perdona, se me pegaron sus chistes.");
                dialogue.Add("Enemigo del romanticismo, mi Antonio no va a disfrutar mi cena para relajarse.");

                gameManager.GetComponent<GameManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                StartCoroutine(ShowLine());
            }
        }
    }

    public override void ShowProductsAndMoney()
    {
        if (currentScene.name == "Day3")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, oneProduct.position, oneProduct.rotation);
            product1.transform.SetParent(oneProduct);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().magicRamen, twoProducts1.position, twoProducts1.rotation);
            product2.transform.SetParent(twoProducts1);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().venomPotion, twoProducts2.position, twoProducts2.rotation);
            product3.transform.SetParent(twoProducts2);
            gameManager.GetComponent<GameManager>().leDineroText.text = "16";
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
