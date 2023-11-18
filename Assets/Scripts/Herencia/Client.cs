using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Client : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public List<string> dialogue;
    [SerializeField] public Scene currentScene;
    [SerializeField] public Transform oneProduct;
    [SerializeField] public Transform twoProducts1;
    [SerializeField] public Transform twoProducts2;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        currentScene = SceneManager.GetActiveScene();
        dialogue = new List<string>();
        oneProduct = gameManager.GetComponent<GameManager>().oneProduct.transform;
        twoProducts1 = gameManager.GetComponent<GameManager>().twoProducts1.transform;
        twoProducts2 = gameManager.GetComponent<GameManager>().twoProducts2.transform;
    }

    public abstract void ShowProductsAndMoney();
    public void ByeBye()
    {
        gameManager.GetComponent<GameManager>().estaToPagao = false;
        gameManager.GetComponent<GameManager>().internalCount = 0;
        gameManager.GetComponent<GameManager>().leDinero.gameObject.GetComponent<Button>().enabled = false;
        gameManager.GetComponent<GameManager>().leCajaRegistradora.gameObject.GetComponent<Button>().enabled = false;
        gameManager.GetComponent<GameManager>().dropDownButton.SetActive(false);
        Destroy(gameObject, 2);
    }
    protected void OnDestroy()
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
            gameManager.GetComponent<GameManager>().victoryPanel.SetActive(true);
            Debug.Log("Se acabó el día guachines.");
        }
    }
}
