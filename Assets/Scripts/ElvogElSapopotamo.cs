using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElvogElSapopotamo : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject product;
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
                dialogue.Add("Buennnasss *hip* eeeehhhhh… tuuu no eress el de sieeeembrree…*hip* puenoooo, el otroo eraaa un ######");
                dialogue.Add("Ahorra a quieen le direee sobre niii despidoooo…Encimaaa eress umanooo…Ne tocarra contarrrrte a tuuu…*hip*");
                dialogue.Add("Mooo te looo vasss a creer… el ###### de mi jefeee me despidió *hip* me dijooo que pebía mushoo alcohooool y queeee estoooy viejo, ¿perro quee dise eseee? *hip*");
                dialogue.Add("Siii solo temgooo 22 añiitoss, estoooy em la fror de la hueventud *hip*, soy el mejorr exxxxplorador");
                dialogue.Add("Buemo, che me olvidó *hip*, puedess cobrarme estooo…");
                dialogue.Add("Graciasss mushacho *hip* ahorra serás ni depemdiete favorito *hip*");
                dialogue.Add("Perro mushacho *hip* el otroo depemdiete erra mejor *hip*");

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
            product = Instantiate(gameManager.GetComponent<GameManager>().beer, oneProduct.position, oneProduct.rotation);
            gameManager.GetComponent<GameManager>().leDineroText.text = "10";
        }
    }

    public void ByeBye()
    {
        Destroy(product);

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
