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
                dialogue.Add("�Buenos d�as querido!");
                dialogue.Add("�Podr�as luego ayudarme a cargar esto hasta fuera?");
                dialogue.Add("Uy uy, qu� digo... Creo que no puedes abandonar tu puesto �no?");
                dialogue.Add("Desde que no est� mi marido me cuesta m�s cargar la compra...");
                dialogue.Add("Pero claro... no s� como quiero que est� mi marido si... me lo com�.");
                dialogue.Add("Qu� raro que est�s inexpresivo, siempre que cuento esto se asustan... No s� porque no se normaliza que los manguros nos comamos a nuestra pareja.");
                dialogue.Add("Pero s�lo para reproducirnos, no somos unos monstruos");
                dialogue.Add("Bueno... que nos liamos hablando y tienes que cobrarme, que en breve voy a tener que recoger a mi ni�o del Zoo.");
                dialogue.Add("Pues muchas gracias joven, espero que tu pareja te coma pronto tambi�n ji ji ji.");
                dialogue.Add("�Perdona? Ahora por tu culpa mi hijo no tendr� su gato muerto ��l solo quer�a una mascota!");

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
            Debug.Log("Se acab� el d�a guachines.");
        }
    }
}
