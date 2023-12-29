using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject currentCustomer;
    [SerializeField] GameObject canvasPausa;
    [SerializeField] public GameObject canvasVictory;
    public Scene currentScene;


    [Header("RELATED TO THE DROPDOWN MENU WITH THE LIST OF ITEMS")]
    [SerializeField] public bool listOpen = false;
    [SerializeField] public GameObject dropDownPanel;
    [SerializeField] public GameObject botonPlegado;
    [SerializeField] public GameObject botonDesplegado;
    [SerializeField] public GameObject position1;
    [SerializeField] public GameObject position2;
    [SerializeField] GameObject normativas;
    [SerializeField] GameObject precios;

    [Header("ITS ALL ABOUT THE MONEY MONEY MONEY")]
    [SerializeField] public GameObject leDinero;
    [SerializeField] public GameObject leCajaRegistradora;
    [SerializeField] public GameObject lesPropinas;
    [SerializeField] public TMP_Text leDineroText;
    [SerializeField] public TMP_Text lePropinasText;
    [SerializeField] public float propinasNumber = 0;
    [SerializeField] public bool estaToPagao = false;

    [Header("DIALOGUE")]
    [SerializeField] public bool conversationOn;
    [SerializeField] public bool optionsSet;
    [SerializeField] public TMP_Text dialogueText;
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public int internalCount = 0;
    [SerializeField] public TMP_Text traductorText;

    [Header("BOSS' THINGS")]
    public GameObject phone;
    public GameObject jefePanel;
    [SerializeField] public TMP_Text textoJefe;
    public bool broncaFin = true;
    public bool mostrarJefe = false;
    [SerializeField] public List<string> quejas;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        canvasPausa = gameObject.transform.GetChild(7).gameObject;
        canvasVictory = gameObject.transform.GetChild(8).gameObject;
        currentScene = SceneManager.GetActiveScene();
        botonPlegado.SetActive(false);
        estaToPagao = false;

        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! CHICO NUEVO, MENOS SUELDO…");                  // Si no le has cobrado y sí deberias haberle cobrado.
        quejas.Add("¡Tendrías que haberle echado a patadas, no tenía el dinero suficiente!");                   // Si sí le has cobrado y no deberías haberle cobrado.
        quejas.Add("¡Aquí tenemos unas normas! ¡¿Las recuerdas?!");                                             // Cuando no has cumplido las normativas.
        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! ¡Tenía dinero y no rompía ninguna norma!");    // Si no le has cobrado y sí deberias haberle cobrado (A partir del día 2).
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasPausa.activeSelf)
            {
                canvasPausa.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                canvasPausa.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void OpenList()
    {
        if (listOpen)
        {
            leDinero.gameObject.GetComponent<Button>().enabled = true;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = true;
            dropDownPanel.transform.position = position2.transform.position;
            botonDesplegado.SetActive(true);
            botonPlegado.SetActive(false);
            listOpen = false;
        }

        else
        {
            leDinero.gameObject.GetComponent<Button>().enabled = false;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = false;
            dropDownPanel.transform.position = position1.transform.position;
            botonDesplegado.SetActive(false);
            botonPlegado.SetActive(true);
            listOpen = true;
        }

    }

    public IEnumerator BossCalling()
    {
        phone.gameObject.GetComponent<Animator>().SetBool("LlamaJefe", true);

        yield return new WaitForSeconds(1);

        phone.gameObject.GetComponent<Animator>().SetBool("LlamaJefe", false);

        jefePanel.SetActive(true);
    }

    public void SaltarJefe()
    {
        broncaFin = true;
        mostrarJefe = false;
        jefePanel.SetActive(false);
    }

    public void ShowText()
    {
        gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = true;
        dialoguePanel.gameObject.SetActive(true);

        traductorText.text = currentCustomer.GetComponent<Client>().raza;

        // Si el actual cliente tiene como nombre "qhsjdjkqshdkq"
        // Llamo al método DialogueTexts al que le paso la cantidad de líneas que tiene su diálogo y que el diálogo en cuestión.


        if (currentCustomer.name.Contains("Jefe")  && internalCount < currentCustomer.GetComponent<Client>().dialogue.Count)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            internalCount++;

            //if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count)
            //    currentCustomer.GetComponent<Client>().ByeBye();
            //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        }

        else if (currentCustomer.name.Contains("Mano") && internalCount < currentCustomer.GetComponent<Client>().dialogue.Count && currentScene.name == "Day4")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            internalCount++;

            //if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count)
            //    currentCustomer.GetComponent<Client>().ByeBye();
            //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        }

        else if (internalCount < currentCustomer.GetComponent<Client>().dialogue.Count - 2 && !currentCustomer.name.Contains("Jefe"))
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            //SoundCreator(dialogueText.text);
            internalCount++;
            //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        }

        else
            HideText();
    }

    public void HideText()
    {
        gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = false;
        dialoguePanel.gameObject.SetActive(false);
        dialoguePanel.gameObject.SetActive(false);
        dropDownPanel.gameObject.SetActive(true);

        if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count && currentCustomer.name.Contains("Jefe"))
        {
            estaToPagao = true;
            currentCustomer.GetComponent<Client>().ByeBye();
            gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        }

        else if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count && currentCustomer.name.Contains("Mano") && currentScene.name == "Day4")
        {
            mostrarJefe = false;
            estaToPagao = true;
            currentCustomer.GetComponent<Client>().ByeBye();
            gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        }

        else if (!estaToPagao)
        {
            leDinero.gameObject.SetActive(true);
            leDinero.gameObject.GetComponent<Button>().enabled = true;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = true;
            botonDesplegado.SetActive(true);

            if (currentScene.name == "Day1")
            {
                if (currentCustomer.name.Contains("Geraaaard"))
                    currentCustomer.GetComponent<MO_Geeraard>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Sapopotamo"))
                    currentCustomer.GetComponent<H_Elvog>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Antonio"))
                    currentCustomer.GetComponent<L_Antonio>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Tapiz"))
                    currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Denjirenji"))
                    currentCustomer.GetComponent<T_Denjirenji>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Mara"))
                    currentCustomer.GetComponent<H_Mara>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Giovanni"))
                    currentCustomer.GetComponent<L_Giovanni>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Rockon"))
                    currentCustomer.GetComponent<E_Rockon>().ShowProductsAndMoney();

            }

            else if (currentScene.name == "Day2")
            {
                //if (currentCustomer.name.Contains(""))
                //    currentCustomer.GetComponent<>().ShowProductsAndMoney();  Aquí va Lepión, todavía no introducido por la transferencia de datos

                if (currentCustomer.name.Contains("Giovanni"))
                    currentCustomer.GetComponent<L_Giovanni>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Enano"))
                    currentCustomer.GetComponent<MO_ManoloCabezaPico>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Cululu"))
                    currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Handy"))
                    currentCustomer.GetComponent<E_Handy>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Petra"))
                    currentCustomer.GetComponent<H_Petra>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Tapiz"))
                    currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Masermati"))
                    currentCustomer.GetComponent<T_Masermati>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Pijus"))
                    currentCustomer.GetComponent<MO_PijusMagnus>().ShowProductsAndMoney();
            }

            else if (currentScene.name == "Day3")
            {
                if (currentCustomer.name.Contains("Sergio"))
                    currentCustomer.GetComponent<L_Sergio>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Saltaralisis"))
                    currentCustomer.GetComponent<H_Saltaralisis>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Mano"))
                    currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Raven"))
                    currentCustomer.GetComponent<T_Raven>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Hueso"))
                    currentCustomer.GetComponent<E_ElementalHueso>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Patxi"))
                    currentCustomer.GetComponent<L_Patxi>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Sapopotamo"))
                    currentCustomer.GetComponent<H_Elvog>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Enano"))
                    currentCustomer.GetComponent<MO_ManoloCabezaPico>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Rustica"))
                    currentCustomer.GetComponent<T_Rustica>().ShowProductsAndMoney();
            }

            else if (currentScene.name == "Day4")
            {
                if (currentCustomer.name.Contains("Jissy"))
                    currentCustomer.GetComponent<E_Jissy>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Mara"))
                    currentCustomer.GetComponent<H_Mara>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Cululu"))
                    currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Elidora"))
                    currentCustomer.GetComponent<MO_Elidora>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Geraaaard"))
                    currentCustomer.GetComponent<MO_Geeraard>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Magma"))
                    currentCustomer.GetComponent<T_MagmaDora>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Handy"))
                    currentCustomer.GetComponent<E_Handy>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Antonio"))
                    currentCustomer.GetComponent<L_Antonio>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Mano"))
                    currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();
            }

            internalCount++;
        }

        else
        {
            currentCustomer.GetComponent<Client>().ByeBye();
            gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        }
    }

    public void CollectMoney()
    {
        botonDesplegado.SetActive(false);
        gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);
        MoneyText();
    }

    public void IDontBelieveIt()
    {
        botonDesplegado.SetActive(false);
        gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);
        IDontBelieveText();

    }

    public void LaVoluntad(float cantidad)
    {
        propinasNumber += cantidad;
        lesPropinas.GetComponent<Image>().fillAmount = (propinasNumber) / 100;
        lePropinasText.text = "" + propinasNumber;
    }

    public string MoneyText()
    {
        dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 2];
        //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());

        if (currentScene.name == "Day1")
        {
            if (currentCustomer.name.Contains("Geraaaard") || currentCustomer.name.Contains("Sapopotamo") || currentCustomer.name.Contains("Tapiz") ||
                currentCustomer.name.Contains("Mara") || currentCustomer.name.Contains("Giovanni"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Antonio") || currentCustomer.name.Contains("Denjirenji") || currentCustomer.name.Contains("Rockon"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[1];
                LaVoluntad(-10);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day2")
        {
            if (currentCustomer.name.Contains("Pijus"))
            {
                //Mostrar queja de que no tiene suficiente dinero
                mostrarJefe = true;
                textoJefe.text = quejas[1];
                LaVoluntad(-15);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Giovanni") || currentCustomer.name.Contains("Handy"))
            {
                //Mostrar queja de que no cumplen normas
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Enano") || currentCustomer.name.Contains("Cululu") ||
                currentCustomer.name.Contains("Petra") || currentCustomer.name.Contains("Masermati") || currentCustomer.name.Contains("Tapiz"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day3")
        {
            if (currentCustomer.name.Contains("Saltaralisis") || currentCustomer.name.Contains("Mano") || currentCustomer.name.Contains("Raven")
                || currentCustomer.name.Contains("Patxi") || currentCustomer.name.Contains("Rustica") || currentCustomer.name.Contains("Enano"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Sapopotamo"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(5);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Sergio") || currentCustomer.name.Contains("Hueso"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day4")
        {
            if (currentCustomer.name.Contains("Cululu") || currentCustomer.name.Contains("Enano") || currentCustomer.name.Contains("Handy")
                || currentCustomer.name.Contains("Antonio"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Mara") || currentCustomer.name.Contains("Jissy") || currentCustomer.name.Contains("Elidora") 
                || currentCustomer.name.Contains("Geraaaard") || currentCustomer.name.Contains("Magma"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
                return dialogueText.text;
            }
        }



        return null;
    }

    public string IDontBelieveText()
    {
        dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 1];
        //currentCustomer.GetComponent<Client>().lineIndex += 1;
        //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());


        if (currentScene.name == "Day1")
        {
            if (currentCustomer.name.Contains("Geraaaard") || currentCustomer.name.Contains("Sapopotamo") || currentCustomer.name.Contains("Tapiz")
                || currentCustomer.name.Contains("Mara") || currentCustomer.name.Contains("Giovanni"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[0];
                LaVoluntad(-10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Antonio") || currentCustomer.name.Contains("Denjirenji") || currentCustomer.name.Contains("Rockon"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day2")
        {
            if (currentCustomer.name.Contains("Manolo") || currentCustomer.name.Contains("Cululu")
                || currentCustomer.name.Contains("Petra") || currentCustomer.name.Contains("Masermati") || currentCustomer.name.Contains("Tapiz"))
            {
                //Queja de que si que tenía el dinero suficiente
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Giovanni") || currentCustomer.name.Contains("Handy"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Pijus"))
            {
                mostrarJefe = false;
                LaVoluntad(-1);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day3")
        {
            if (currentCustomer.name.Contains("Sergio") || currentCustomer.name.Contains("Hueso") ||
                currentCustomer.name.Contains("Sapopotamo"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Saltaralisis") || currentCustomer.name.Contains("Mano") || currentCustomer.name.Contains("Raven")
                || currentCustomer.name.Contains("Patxi") || currentCustomer.name.Contains("Rustica") || currentCustomer.name.Contains("Enano"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day4")
        {
            if (currentCustomer.name.Contains("Mara") || currentCustomer.name.Contains("Jissy") || currentCustomer.name.Contains("Elidora")
                || currentCustomer.name.Contains("Geraaaard") || currentCustomer.name.Contains("Magma"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Cululu") || currentCustomer.name.Contains("Enano") || currentCustomer.name.Contains("Handy") 
                || currentCustomer.name.Contains("Antonio"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
                return dialogueText.text;
            }
        }

        return null;
    }

    public void Resume()
    {
        canvasPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void TitleScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void NextDay()
    {
        for (int i = 0; i < 6; i++)
        {
            if (currentScene.name == "Day" + i)
            {
                SceneManager.LoadScene(1 + i);
            }
        }
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void ShowNormativa()
    {
        normativas.SetActive(true);
        precios.SetActive(false);
    }

    public void ShowPrecios()
    {
        precios.SetActive(true);
        normativas.SetActive(false);
    }
}
