using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GiovanniElCocinero : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject product1;
    [SerializeField] public GameObject product2;
    [SerializeField] public GameObject product3;
    [SerializeField] public List<string> dialogue;

    bool repetirunavez = false;

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

        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            if (currentScene.name == "Day1")
            {
                dialogue.Add("�Ahoy, amigo m�o! No sabes lo que me encontr� hoy.");
                dialogue.Add("�EL N-E-C-R-O-N-O-M-I-C-�-N!");
                dialogue.Add("Es el libro de cocina definitivo... o eso creo�");
                dialogue.Add("Bueno, solo con decirte la primera receta... te va a encantar.");
                dialogue.Add("\"C�mo invocar a un Dios Antiguo de la Destrucci�n\" �Suena incre�ble no?");
                dialogue.Add("Bueno sigo, \"Primer paso: rociar vino hecho de sangre de virgen\" (Bueno... creo que cerveza tambi�n servir�a...)");
                dialogue.Add("\"Segundo paso: cortar el mu�eco voodoo por la mitad junto con el humano sacrificado\" (Ni idea de qu� es un humano sacrificada, pero lo del mu�eco tiene buena pinta...)");
                dialogue.Add("\"Y tercer paso: beber el veneno para que el Dios se adue�e de tu cuerpo\" (Mmm el veneno siempre da un toque picante al plato, se lo echar� al mu�eco seguro...)");
                dialogue.Add("Tiene buena pinta �verdad? Para eso necesito estos ingredientes, as� que si puedes cobrarme, que me muero por cocinarlo.");
                dialogue.Add("Gracias, la pr�xima vez que vuelva te dejar� probar el plato para que me des tu opini�n.");
                dialogue.Add("Mamma m�a, ahora no podr� hacer la mayor delicatessen del mundo por tu culpa.");

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
            product1 = Instantiate(gameManager.GetComponent<GameManager>().beer, product1Place.position, product1Place.rotation);
            product1.transform.SetParent(product1Place);
            product2 = Instantiate(gameManager.GetComponent<GameManager>().voodooDoll, product2Place.position, product1Place.rotation);
            product2.transform.SetParent(product2Place);
            product3 = Instantiate(gameManager.GetComponent<GameManager>().energeticDrink, product3Place.position, product3Place.rotation);
            product3.transform.SetParent(product3Place);
            gameManager.GetComponent<GameManager>().leDineroText.text = "8";
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
            Debug.Log("Se acab� el d�a guachines.");
        }
    }
}
