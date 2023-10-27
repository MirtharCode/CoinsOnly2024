using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DenjirenjiElSamurai : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
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
                dialogue.Add("Buenas joven, no me creo que mi jefe me vaya a usar así.");
                dialogue.Add("Perdón, el jefe me está poniendo la cabeza como un horno.");
                dialogue.Add("He estado 10 años aprendiendo técnicas samurai infalibles, he sido el mejor de la promoción, incluso salvé el mundo junto a cuatro tortugas ninja, y ahora…");
                dialogue.Add("Solo sirvo para calentar su maldita comida, y encima la tengo que comprar yo");
                dialogue.Add("He perdido todo honor como samurai...");
                dialogue.Add("Al final acabaré haciéndome un harakiri con cucharas.");
                dialogue.Add("Disculpa que te haya robado un poco de tu tiempo, cóbrame esto antes de que mi jefe se planteé hacerme el harakiri él mismo");
                dialogue.Add("Menos mal que tenía el dinero justo, o... eso creo.");
                dialogue.Add("¡Por una moneda! Discúlpame, espero que el jefe no me mate...");

                gameManager.GetComponent<GameManager>().ShowText();
            }
        }
    }

    public void ShowProductsAndMoney()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        Transform product1Place = gameManager.GetComponent<GameManager>().oneProduct.transform;
        Transform product2Place = gameManager.GetComponent<GameManager>().twoProducts1.transform;
        Transform product3Place = gameManager.GetComponent<GameManager>().twoProducts2.transform;

        if (currentScene.name == "Day1")
        {
            product1 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, product1Place.position, product1Place.rotation);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, product2Place.position, product1Place.rotation);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, product3Place.position, product3Place.rotation);
            gameManager.GetComponent<GameManager>().leDineroText.text = "9";
        }
    }

    public void ByeBye()
    {
        Destroy(product1);
        Destroy(product2);
        Destroy(product3);

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
