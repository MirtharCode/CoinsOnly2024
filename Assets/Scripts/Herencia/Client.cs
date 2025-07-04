using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Client : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject uIManager;
    [SerializeField] public GameObject data;
    [SerializeField] public TMP_Text dialogueUIText;
    [SerializeField] public GameObject dialogueUIPanel;
    [SerializeField] public List<string> dialogue;
    [SerializeField] public Scene currentScene;
    [SerializeField] public Transform oneProduct;
    [SerializeField] public Transform twoProducts1;
    [SerializeField] public Transform twoProducts2;

    [SerializeField] public int lineIndex = 0;
    [SerializeField] public float typingTime;

    public string raza;
    public string nombre;
    public AudioSource talkingSound;
    public AudioClip lastPlayerSound;
    public AudioClip[] sounds = new AudioClip[5];

    public GameObject ftBObject;

    public bool repetirunavez = false;

    protected virtual void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        uIManager = GameObject.FindGameObjectWithTag("UI");
        data = GameObject.FindGameObjectWithTag("Data");
        ftBObject = GameObject.FindGameObjectWithTag("FadeBlack");

        currentScene = SceneManager.GetActiveScene();
        talkingSound = GetComponent<AudioSource>();
        gameManager.GetComponent<GameManager>().trampilla.SetActive(true);
        oneProduct = gameManager.GetComponent<GameManager>().oneProduct.transform;
        twoProducts1 = gameManager.GetComponent<GameManager>().twoProducts1.transform;
        twoProducts2 = gameManager.GetComponent<GameManager>().twoProducts2.transform;

        uIManager.GetComponent<UIManager>().currentCustomer = gameObject;
        if (!uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("MagoHielo"))
            data.GetComponent<Data>().SettingDialogues();

        dialogue = data.GetComponent<Data>().cCDialogue;
    }
    protected abstract void OnCollisionEnter2D(Collision2D collision);

    public abstract void ShowProductsAndMoney();
    public abstract void ByeBye();

    protected void OnDestroy()
    {
        List<GameObject> list = gameManager.GetComponent<GameManager>().dailyCustomers;

        if (list.Count > 1)
        {
            list.Remove(list[gameManager.GetComponent<GameManager>().customerNumber]);
            //Debug.Log("Yo " + this.name + "Mando a  " + list[gameManager.GetComponent<GameManager>().customerNumber].name);
            gameManager.GetComponent<GameManager>().CharacterShowUp(list[gameManager.GetComponent<GameManager>().customerNumber]);
        }

        else
        {
            list.Remove(list[gameManager.GetComponent<GameManager>().customerNumber]);

            if (uIManager.GetComponent<UIManager>().propinasNumber >= 50 && currentScene.name != "Day2_1" && currentScene.name != "Day3_1")
                data.GetComponent<Data>().tipsPoints++;

            ftBObject.GetComponent<FadeToBlack>().FadeToBlackAnywhere();
        }

        if (gameObject.name != "MagoHielo") uIManager.GetComponent<UIManager>().jefePanel.SetActive(false);
    }

    public IEnumerator WaitingForMyDestruction()
    {
        //Debug.Log("Antes de esperar");
        yield return new WaitForSeconds(3f);
        //Debug.Log("Despues de esperar");
    }

    public void Speaking()
    {
        char[] arrChar = gameManager.GetComponent<GameManager>().chars;

        for (int j = 0; j < arrChar.Length; j++)
        {
            if (arrChar[j] != '�' || arrChar[j] != '�')
            {
                int rdm = Random.Range(0, 3);

                //Debug.Log(rdm);
                AudioClip nextSound = GetRandomSound();

                talkingSound.clip = nextSound;
                talkingSound.Play();
                lastPlayerSound = nextSound;
                break;
            }

            else if (arrChar[j] == '�')
            {
                talkingSound.clip = sounds[3];
                talkingSound.Play();
                break;
            }

            else if (arrChar[j] == '�')
            {
                talkingSound.clip = sounds[4];
                talkingSound.Play();
                break;
            }
        }

        AudioClip GetRandomSound()
        {
            AudioClip randomSound = null;

            // Evita que se reproduzca el mismo sonido dos veces seguidas
            do
            {
                randomSound = sounds[Random.Range(0, 3)];
            } while (randomSound == lastPlayerSound);

            return randomSound;
        }
    }
}

