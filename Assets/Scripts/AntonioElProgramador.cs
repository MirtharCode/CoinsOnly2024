using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntonioElProgramador : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public List<string> dialogue;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        gameManager.GetComponent<GameManager>().toyGrandote = true;
        gameManager.GetComponent<GameManager>().stopGrangran.gameObject.SetActive(true);

        gameManager.GetComponent<GameManager>().toyChiquito = false;
        gameManager.GetComponent<GameManager>().stopPetit.gameObject.SetActive(false);

        dialogue = new List<string>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (collision.transform.tag == "Trampilla")
        {
            if (currentScene.name == "Day1")
            {
                dialogue.Add("Ey!� Hola amigo� �Qu� tal tu d�a?");
                dialogue.Add("...");
                dialogue.Add("Ya veo� ja ja ja ja �No eres muy hablador eh?");
                dialogue.Add("Te entiendo tio, yo tambi�n estoy tan cansado cuando curro, no se como sobreviv� a esta jornada laboral, puede que...porque est� muerto");
                dialogue.Add("ja ja ja ja ja� Perdona, los chistes no son lo m�o, mi... cabeza no funciona tras un d�a de trabajo tan duro");
                dialogue.Add("Estoy tan agotado del trabajo... mi cerebro ya no funciona, porque...ya sabes... estoy muerto");
                dialogue.Add("ja ja ja ja ja� perd�n ya paro");
                dialogue.Add("C�brame y dejar� de incomodarte.");
                dialogue.Add("Gra-gracias, aunque ahora que lo pienso no s� si era todo el dinero.");
                dialogue.Add("�Uy! Me faltaban 2 monedas �verdad?, Siempre se cometen estos errores cuando trabajas tanto, o cuando... pierdes la cabeza, ja ja ja ja� Perd�n, nos vemos.");

                gameManager.GetComponent<GameManager>().ShowText();
            }
        }
    }

    public void ShowProductsAndMoney()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        Transform oneProduct = gameManager.GetComponent<GameManager>().oneProduct.transform;
        Transform twoProducts1 = gameManager.GetComponent<GameManager>().twoProducts1.transform;
        Transform twoProducts2 = gameManager.GetComponent<GameManager>().twoProducts2.transform;

        if (currentScene.name == "Day1")
        {
            GameObject clon = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, oneProduct.position, oneProduct.rotation);
            gameManager.GetComponent<GameManager>().leDinero.gameObject.SetActive(true);
            gameManager.GetComponent<GameManager>().leDineroText.text = "8";
        }
    }
}
