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
    [SerializeField] public GameObject data;
    [SerializeField] public GameObject currentCustomer;
    [SerializeField] GameObject canvasPausa;
    [SerializeField] public GameObject canvasVictory;
    public Scene currentScene;


    [Header("RELATED TO THE DROPDOWN MENU WITH THE LIST OF ITEMS")]
    [SerializeField] public bool listOpenPrecios = false;
    [SerializeField] public GameObject dropDownPanelPrecios;
    [SerializeField] public GameObject botonPlegadoPrecios;
    [SerializeField] public GameObject botonDesplegadoPrecios;
    [SerializeField] public GameObject position1Precios;
    [SerializeField] public GameObject position2Precios;

    [SerializeField] public bool listOpenNormativas = false;
    [SerializeField] public GameObject dropDownPanelNormativas;
    [SerializeField] public GameObject botonPlegadoNormativas;
    [SerializeField] public GameObject botonDesplegadoNormativas;
    [SerializeField] public GameObject position1Normativas;
    [SerializeField] public GameObject position2Normativas;

    [Header("ITS ALL ABOUT THE MONEY MONEY MONEY")]
    [SerializeField] public GameObject leDinero;
    [SerializeField] public GameObject leCajaRegistradora;
    [SerializeField] public GameObject buttonCobrar;
    [SerializeField] public GameObject buttonNoCobrar;
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
    public GameObject phoneBW;
    public GameObject jefePanel;
    [SerializeField] public TMP_Text textoJefe;
    public bool broncaFin = true;
    public bool mostrarJefe = false;
    [SerializeField] public List<string> quejas;

    public string[] razasNormas;
    [SerializeField] public TextMeshProUGUI textoRaza;

    [SerializeField] public GameObject panelMagos;
    [SerializeField] public GameObject panelHibridos;
    [SerializeField] public GameObject panelElementales;
    [SerializeField] public GameObject panelLimbasticos;
    [SerializeField] public GameObject panelTecnopedos;

    [Header("Detective")]

    [SerializeField] public GameObject panelSospechoso;
    [SerializeField] public GameObject panelSeguro;
    [SerializeField] int variableDetective;
    bool asegurarseQuitar = false;
    bool SospechosoTerminado = false;
    public GameObject backgroundBAndW;
    public GameObject tableBAndW;
    public GameObject candle;
    public GameObject candleBAndW;
    public GameObject extPropinasBAndW;
    public GameObject intPropinasBAndW;

    [Header("Razas")]

    int razaSeleccionada;

    [Header("BWThings")]

    [SerializeField] public Sprite upperBoxBW;
    [SerializeField] public Sprite downerBoxBW;
    [SerializeField] public Sprite buttonBW;

    void Start()
    {

        gameManager = GameObject.FindGameObjectWithTag("GM");
        data = GameObject.FindGameObjectWithTag("Data");
        canvasPausa = gameObject.transform.GetChild(11).gameObject;
        canvasVictory = gameObject.transform.GetChild(12).gameObject;
        currentScene = SceneManager.GetActiveScene();
        buttonCobrar.SetActive(false);
        buttonNoCobrar.SetActive(false);
        botonPlegadoPrecios.SetActive(false);
        botonPlegadoNormativas.SetActive(false);
        estaToPagao = false;

        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! CHICO NUEVO, MENOS SUELDO…");                  // Si no le has cobrado y sí deberias haberle cobrado.
        quejas.Add("¡Tendrías que haberle echado a patadas, no tenía el dinero suficiente!");                   // Si sí le has cobrado y no deberías haberle cobrado.
        quejas.Add("¡Aquí tenemos unas normas! ¡¿Las recuerdas?!");                                             // Cuando no has cumplido las normativas.
        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! ¡Tenía dinero y no rompía ninguna norma!");    // Si no le has cobrado y sí deberias haberle cobrado (A partir del día 2).

        razasNormas = new string[5];
        razasNormas[0] = "Magos Oscuros";
        razasNormas[1] = "Híbridos";
        razasNormas[2] = "Elementales";
        razasNormas[3] = "Limbásticos";
        razasNormas[4] = "Tecno P2";

        razaSeleccionada = 0;
    }

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

        if (gameManager.GetComponent<GameManager>().dailyCustomers.Count == 1)
        {
            StartCoroutine(FadeToBAndW());
        }
    }

    public void OpenListPrecios()
    {
        if (listOpenPrecios)
        {
            buttonCobrar.SetActive(true);
            buttonNoCobrar.SetActive(true);
            dropDownPanelPrecios.transform.position = position2Precios.transform.position;
            botonDesplegadoPrecios.SetActive(true);
            botonPlegadoPrecios.SetActive(false);
            listOpenPrecios = false;
        }

        else
        {
            buttonCobrar.SetActive(false);
            buttonNoCobrar.SetActive(false);
            dropDownPanelPrecios.transform.position = position1Precios.transform.position;
            botonDesplegadoPrecios.SetActive(false);
            botonPlegadoPrecios.SetActive(true);
            listOpenPrecios = true;
        }
    }

    public void OpenListNormativas()
    {
        if (listOpenNormativas)
        {
            buttonCobrar.SetActive(true);
            buttonNoCobrar.SetActive(true);
            dropDownPanelNormativas.transform.position = position2Normativas.transform.position;
            botonDesplegadoNormativas.SetActive(true);
            botonPlegadoNormativas.SetActive(false);
            listOpenNormativas = false;
        }

        else
        {
            buttonCobrar.SetActive(false);
            buttonNoCobrar.SetActive(false);
            dropDownPanelNormativas.transform.position = position1Normativas.transform.position;
            botonDesplegadoNormativas.SetActive(false);
            botonPlegadoNormativas.SetActive(true);
            listOpenNormativas = true;
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

    public void SospechosoCorrecto()
    {
        panelSeguro.SetActive(true);
        asegurarseQuitar = true;
    }

    public void SospechosoIncorrecto()
    {
        panelSeguro.SetActive(true);
    }

    public void VolverSeleccionSospechoso() //Al clicar para volver
    {
        asegurarseQuitar = false;
        panelSeguro.SetActive(false);
    }

    public void ConfirmarSospechoso() //Al clicar en confirmar
    {
        if (asegurarseQuitar) data.GetComponent<Data>().detectivePoints++;

        panelSospechoso.SetActive(false);

        UltimaFraseDetective();
    }

    public void ShowText()
    {
        gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = true;
        dialoguePanel.gameObject.SetActive(true);

        traductorText.text = currentCustomer.GetComponent<Client>().raza;

        // Si el actual cliente tiene como nombre "qhsjdjkqshdkq"
        // Llamo al método DialogueTexts al que le paso la cantidad de líneas que tiene su diálogo y que el diálogo en cuestión.


        if (currentCustomer.name.Contains("Jefe") && internalCount < currentCustomer.GetComponent<Client>().dialogue.Count)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            internalCount++;

            //if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count)
            //    currentCustomer.GetComponent<Client>().ByeBye();
            //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        }

        else if (currentCustomer.name.Contains("Jefazo") && internalCount < currentCustomer.GetComponent<Client>().dialogue.Count)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            internalCount++;

            //if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count)
            //    currentCustomer.GetComponent<Client>().ByeBye();
            //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        }

        else if (currentCustomer.name.Contains("Detective") && internalCount < currentCustomer.GetComponent<Client>().dialogue.Count - 1)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            internalCount++;
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

        else if (currentCustomer.name.Contains("Sapopotamo") && internalCount < currentCustomer.GetComponent<Client>().dialogue.Count && currentScene.name == "Day5")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            internalCount++;

            //if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count)
            //    currentCustomer.GetComponent<Client>().ByeBye();
            //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        }


        else if (internalCount < currentCustomer.GetComponent<Client>().dialogue.Count - 2 && !currentCustomer.name.Contains("Jefe") && !currentCustomer.name.Contains("Jefazo"))
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
        dropDownPanelPrecios.gameObject.SetActive(true);
        dropDownPanelNormativas.gameObject.SetActive(true);

        if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count && currentCustomer.name.Contains("Jefe"))
        {
            estaToPagao = true;
            currentCustomer.GetComponent<Client>().ByeBye();
            gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        }

        else if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count && currentCustomer.name.Contains("Jefazo"))
        {
            estaToPagao = true;
            currentCustomer.GetComponent<Client>().ByeBye();
            gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        }

        else if (currentCustomer.name.Contains("Detective") && !estaToPagao)
        {
            dropDownPanelNormativas.SetActive(false);
            dropDownPanelPrecios.SetActive(false);
            dialoguePanel.SetActive(false);
            panelSospechoso.SetActive(true);
        }

        else if (SospechosoTerminado)
        {
            currentCustomer.GetComponent<DetectiveHijo>().ShowProductsAndMoney();
        }

        else if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count && currentCustomer.name.Contains("Mano") && currentScene.name == "Day4")
        {
            mostrarJefe = false;
            estaToPagao = true;
            currentCustomer.GetComponent<Client>().ByeBye();
            gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        }

        else if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count && currentCustomer.name.Contains("Sapopotamo") && currentScene.name == "Day5")
        {
            mostrarJefe = false;
            estaToPagao = true;
            currentCustomer.GetComponent<Client>().ByeBye();
            gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        }

        else if (!estaToPagao)
        {
            leDinero.gameObject.SetActive(true);
            buttonCobrar.SetActive(true);
            buttonNoCobrar.SetActive(true);
            botonDesplegadoPrecios.SetActive(true);
            botonDesplegadoNormativas.SetActive(true);

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
                if (currentCustomer.name.Contains("Lepion"))
                    currentCustomer.GetComponent<H_Lepion>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Giovanni"))
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

            else if (currentScene.name == "Day5")
            {
                if (currentCustomer.name.Contains("Elidora"))
                    currentCustomer.GetComponent<MO_Elidora>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Rockon"))
                    currentCustomer.GetComponent<E_Rockon>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Cululu"))
                    currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Masermati"))
                    currentCustomer.GetComponent<T_Masermati>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Enano"))
                    currentCustomer.GetComponent<MO_ManoloCabezaPico>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Saltaralisis"))
                    currentCustomer.GetComponent<H_Saltaralisis>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Raven"))
                    currentCustomer.GetComponent<T_Raven>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Tapiz"))
                    currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();
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
        botonDesplegadoPrecios.SetActive(false);
        botonDesplegadoNormativas.SetActive(false);
        gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);
        MoneyText();
    }

    public void IDontBelieveIt()
    {
        botonDesplegadoPrecios.SetActive(false);
        botonDesplegadoNormativas.SetActive(false);
        gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);
        IDontBelieveText();
    }

    public void UltimaFraseDetective()
    {
        botonDesplegadoPrecios.SetActive(false);
        botonDesplegadoNormativas.SetActive(false);
        gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);
        dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 1];
    }

    public IEnumerator FadeToBAndW(float fadeSpeed = 0.75f)
    {
        phoneBW.GetComponent<Image>().enabled = true;
        dialoguePanel.GetComponent<Image>().sprite = downerBoxBW;
        dialoguePanel.transform.GetChild(0).GetComponent<Image>().sprite = upperBoxBW;
        dialoguePanel.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = buttonBW;

        Color phoneColor = phone.GetComponent<Image>().color;
        Color candleColor = candle.GetComponent<Image>().color;
        float fadeAmount, negFadeAmount;

        print(phoneColor);
        while (tableBAndW.GetComponent<Image>().color.a > 0 && backgroundBAndW.GetComponent<SpriteRenderer>().color.a > 0
            && candleBAndW.GetComponent<Image>().color.a > 0 && extPropinasBAndW.GetComponent<Image>().color.a > 0
            && intPropinasBAndW.GetComponent<Image>().color.a > 0 && phone.GetComponent<Image>().color.a > 0
            && leCajaRegistradora.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = phoneColor.a - (fadeSpeed * Time.deltaTime);
            negFadeAmount = candleColor.a + (fadeSpeed * Time.deltaTime);
            phoneColor = new Color(phoneColor.r, phoneColor.g, phoneColor.b, fadeAmount);
            candleColor = new Color(candleColor.r, candleColor.g, candleColor.b, negFadeAmount);
            phone.GetComponent<Image>().color = phoneColor;
            tableBAndW.GetComponent<Image>().color = phoneColor;
            candleBAndW.GetComponent<Image>().color = phoneColor;
            backgroundBAndW.GetComponent<SpriteRenderer>().color = phoneColor;
            extPropinasBAndW.GetComponent<Image>().color = phoneColor;
            intPropinasBAndW.GetComponent<Image>().color = phoneColor;
            leCajaRegistradora.GetComponent<Image>().color = phoneColor;
            candle.GetComponent<Image>().color = candleColor;
            yield return null;
        }
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
                currentCustomer.name.Contains("Petra") || currentCustomer.name.Contains("Masermati") || currentCustomer.name.Contains("Tapiz") || currentCustomer.name.Contains("Lepion"))
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

        else if (currentScene.name == "Day5")
        {
            if (currentCustomer.name.Contains("Elidora") || currentCustomer.name.Contains("Enano") || currentCustomer.name.Contains("Raven")
                || currentCustomer.name.Contains("Tapiz"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Rockon") || currentCustomer.name.Contains("Cululu") || currentCustomer.name.Contains("Masermati")
                || currentCustomer.name.Contains("Saltarisis"))
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

            else if (currentCustomer.name.Contains("Antonio") || currentCustomer.name.Contains("Rockon"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Denjirenji"))
            {
                data.GetComponent<Data>().samuraiPagaMal = true;
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }
        }

        else if (currentScene.name == "Day2")
        {
            if (currentCustomer.name.Contains("Manolo") || currentCustomer.name.Contains("Cululu")
                || currentCustomer.name.Contains("Petra") || currentCustomer.name.Contains("Masermati") || currentCustomer.name.Contains("Tapiz") || currentCustomer.name.Contains("Lepion"))
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
            if (currentCustomer.name.Contains("Sergio") || currentCustomer.name.Contains("Hueso"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Sapopotamo"))
            {
                data.GetComponent<Data>().borrachoTriste = true;
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

        else if (currentScene.name == "Day5")
        {
            if (currentCustomer.name.Contains("Rockon") || currentCustomer.name.Contains("Cululu") || currentCustomer.name.Contains("Masermati")
                || currentCustomer.name.Contains("Saltarisis") || currentCustomer.name.Contains("Magma"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                return dialogueText.text;
            }

            else if (currentCustomer.name.Contains("Elidora") || currentCustomer.name.Contains("Enano") || currentCustomer.name.Contains("Raven")
                || currentCustomer.name.Contains("Tapiz"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
                return dialogueText.text;
            }
        }

        return null;
    }

    void MostrarRazaActual()
    {
        textoRaza.text = razasNormas[razaSeleccionada];
    }

    public void RetrocederRaza()
    {
        razaSeleccionada = (razaSeleccionada - 1 + razasNormas.Length) % razasNormas.Length;

        MostrarRazaActual();

        if (textoRaza.text == "Magos Oscuros")
        {
            panelMagos.SetActive(true);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Elementales")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(true);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Híbridos")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(true);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Limbásticos")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(true);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Tecno P2")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(true);
        }
    }

    public void AvanzarRaza()
    {
        razaSeleccionada = (razaSeleccionada + 1) % razasNormas.Length;

        MostrarRazaActual();

        if (textoRaza.text == "Magos Oscuros")
        {
            panelMagos.SetActive(true);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Elementales")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(true);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Híbridos")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(true);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Limbásticos")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(true);
            panelTecnopedos.SetActive(false);
        }

        else if (textoRaza.text == "Tecno P2")
        {
            panelMagos.SetActive(false);
            panelElementales.SetActive(false);
            panelHibridos.SetActive(false);
            panelLimbasticos.SetActive(false);
            panelTecnopedos.SetActive(true);
        }
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
        if (currentScene.name == "Day1")
        {
            data.GetComponent<Data>().day0Check = false;
            data.GetComponent<Data>().day1Check = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (currentScene.name == "Day2")
        {
            data.GetComponent<Data>().day1Check = false;
            data.GetComponent<Data>().day2Check = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (currentScene.name == "Day3")
        {
            data.GetComponent<Data>().day2Check = false;
            data.GetComponent<Data>().day3Check = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (currentScene.name == "Day4")
        {
            data.GetComponent<Data>().day3Check = false;
            data.GetComponent<Data>().day4Check = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else if (currentScene.name == "Day5")
        {
            data.GetComponent<Data>().day4Check = false;
            data.GetComponent<Data>().day5Check = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
