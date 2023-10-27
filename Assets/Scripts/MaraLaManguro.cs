using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaraLaManguro : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
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
                dialogue.Add("¡Buenos días querido!");
                dialogue.Add("¿Podrías luego ayudarme a cargar esto hasta fuera?");
                dialogue.Add("Uy uy, qué digo... Creo que no puedes abandonar tu puesto ¿no?");
                dialogue.Add("Desde que no está mi marido me cuesta más cargar la compra...");
                dialogue.Add("Pero claro... no sé como quiero que esté mi marido si... me lo comí.");
                dialogue.Add("Qué raro que estés inexpresivo, siempre que cuento esto se asustan... No sé porque no se normaliza que los manguros nos comamos a nuestra pareja.");
                dialogue.Add("Pero sólo para reproducirnos, no somos unos monstruos");
                dialogue.Add("Bueno... que nos liamos hablando y tienes que cobrarme, que en breve voy a tener que recoger a mi niño del Zoo.");
                dialogue.Add("Pues muchas gracias joven, espero que tu pareja te coma pronto también ji ji ji.");
                dialogue.Add("¿Perdona? Ahora por tu culpa mi hijo no tendrá su gato muerto ¡Él solo quería una mascota!");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().deadCat, twoProducts1.position, twoProducts1.rotation);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, twoProducts2.position, twoProducts2.rotation);
            gameManager.GetComponent<GameManager>().leDineroText.text = "18";
        }
    }

    public void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);

        gameManager.GetComponent<GameManager>().estaToPagao = false;
        gameManager.GetComponent<GameManager>().internalCount = 0;
        gameManager.GetComponent<GameManager>().leDinero.gameObject.GetComponent<Button>().enabled = false;
        gameManager.GetComponent<GameManager>().leCajaRegistradora.gameObject.GetComponent<Button>().enabled = false;
        Destroy(gameObject, 2);
    }

    private void OnDestroy()
    {
        List<GameObject> list = gameManager.GetComponent<GameManager>().dailyCustomers;

        if (list.Count > 1)
        {
            gameManager.GetComponent<GameManager>().CharacterShowUp(list[gameManager.GetComponent<GameManager>().customerNumber + 1]);
            list.Remove(list[gameManager.GetComponent<GameManager>().customerNumber]);
        }
        else
        {
            list.Remove(list[gameManager.GetComponent<GameManager>().customerNumber]);
            Debug.Log("Se acabó el día guachines.");
        }
    }
}
