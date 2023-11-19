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
        gameManager.GetComponent<GameManager>().trampilla.SetActive(true);
        oneProduct = gameManager.GetComponent<GameManager>().oneProduct.transform;
        twoProducts1 = gameManager.GetComponent<GameManager>().twoProducts1.transform;
        twoProducts2 = gameManager.GetComponent<GameManager>().twoProducts2.transform;
    }

    public abstract void ShowProductsAndMoney();
    public abstract void ByeBye();

    protected void OnDestroy()
    {
        List<GameObject> list = gameManager.GetComponent<GameManager>().dailyCustomers;

        if (list.Count > 1)
        {
            list.Remove(list[gameManager.GetComponent<GameManager>().customerNumber]);
            Debug.Log("Yo " + this.name + "Mando a  " + list[gameManager.GetComponent<GameManager>().customerNumber].name);
            gameManager.GetComponent<GameManager>().CharacterShowUp(list[gameManager.GetComponent<GameManager>().customerNumber]);
        }
        else
        {
            list.Remove(list[gameManager.GetComponent<GameManager>().customerNumber]);
            gameManager.GetComponent<GameManager>().victoryPanel.SetActive(true);
            Debug.Log("Se acabó el día guachines.");
        }
    }
}
