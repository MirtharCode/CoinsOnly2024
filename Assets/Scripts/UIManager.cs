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
    [SerializeField] public bool listOpenPrecios = false;
    [SerializeField] public GameObject dropDownPanelPrecios;
    [SerializeField] public GameObject botonPlegadoPrecios;
    [SerializeField] public GameObject botonDesplegadoPrecios;
    [SerializeField] public GameObject position1Precios;
    [SerializeField] public GameObject position2Precios;
    [SerializeField] public GameObject preciosButton;

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
    [SerializeField] public TMP_Text NombreText;
    [SerializeField] public int dialogueSize;

    [Header("MINIIMAGES")]
    [SerializeField] public Image clientImage;
    [SerializeField] public Sprite evilWizardGerard;
    [SerializeField] public Sprite hybridElvog;
    [SerializeField] public Sprite limbasticAntonio;
    [SerializeField] public Sprite elementalTapicio;
    [SerializeField] public Sprite electropedDenjirenji;
    [SerializeField] public Sprite hybridMara;
    [SerializeField] public Sprite limbasticGiovanni;
    [SerializeField] public Sprite elementalRockon;
    [SerializeField] public Sprite hybridLepion;
    [SerializeField] public Sprite evilWizardManolo;
    [SerializeField] public Sprite limbasticCululu;
    [SerializeField] public Sprite elementalHandy;
    [SerializeField] public Sprite hybridPetra;
    [SerializeField] public Sprite electropedMasermati;
    [SerializeField] public Sprite evilWizardPijus;
    [SerializeField] public Sprite limbasticSergio;
    [SerializeField] public Sprite hybridSaltaralisis;
    [SerializeField] public Sprite evilWizardManoloMano;
    [SerializeField] public Sprite electropedRaven;
    [SerializeField] public Sprite elementalHueso;
    [SerializeField] public Sprite limbasticPatxi;
    [SerializeField] public Sprite electropedRustica;
    [SerializeField] public Sprite elementalJissy;
    [SerializeField] public Sprite evilWizardElidora;
    [SerializeField] public Sprite electropedMagmaDora;
    [SerializeField] public Sprite elJefe;
    [SerializeField] public Sprite elDetective;

    [Header("BOSS' THINGS")]
    public GameObject phone;
    public GameObject phoneBW;
    public GameObject jefePanel;
    [SerializeField] public TMP_Text textoJefe;
    public bool broncaFin = true;
    public bool mostrarJefe = false;
    [SerializeField] public List<string> quejas;

    [Header("NORMATIVAS")]
    public string[] razasNormas;
    [SerializeField] public TextMeshProUGUI textoRaza;
    [SerializeField] public GameObject panelMagos;
    [SerializeField] public GameObject panelHibridos;
    [SerializeField] public GameObject panelElementales;
    [SerializeField] public GameObject panelLimbasticos;
    [SerializeField] public GameObject panelTecnopedos;
    [SerializeField] public GameObject normativasButton;

    [Header("DETECTIVE")]
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

    [Header("GiftImages")]

    [SerializeField] public Animator showTrophyAnim;    // Si nerviosusPagaLoQueDebe es falso, Geerard te dará la foto firmada

    [SerializeField] public Sprite giftImageGeeraard;    // Si nerviosusPagaLoQueDebe es falso, Geerard te dará la foto firmada
    [SerializeField] public Sprite giftImageEnano;       // Te da un Enano. Si en el día 2 o 3 encuentras al enano zumbón.
    [SerializeField] public Sprite giftImageMano;        // Te da un anillo.
    [SerializeField] public Sprite giftImageElidora;     // Si completas su minijuego te pasa un moco.
    //[SerializeField] public Sprite giftImagePijus;
    [SerializeField] public Sprite giftImageElvog;       // Te da una botella con flores.
    //[SerializeField] public Sprite giftImageLepion;
    [SerializeField] public Sprite giftImageMara;        // Te da la pierna de su marido.
    [SerializeField] public Sprite giftImagePetra;       // Te da un mapa.
    //[SerializeField] public Sprite giftImageSaltaralis;
    [SerializeField] public Sprite giftImageAntonio;     // Te da sus gafas.
    [SerializeField] public Sprite giftImageGiovanni;    // Te da su "libro de cocina".
    [SerializeField] public Sprite giftImageCululu;      // Te da la foto de Mara.
    [SerializeField] public Sprite giftImageSergio;      // Si nerviosusPagaLoQueDebe es verdadero, te da su Globo-Espada.
    //[SerializeField] public Sprite giftImagePatxi;
    [SerializeField] public Sprite giftImageTapicio;     // Te da el puto GOTY.
    //[SerializeField] public Sprite giftImageRockon;
    [SerializeField] public Sprite giftImageHandy;       // Te da un disfraz de payaso.
    //[SerializeField] public Sprite giftImageJissy;
    //[SerializeField] public Sprite giftImageHueso;
    [SerializeField] public Sprite giftImageDenjirenji;  // Si completas su minijuego te da su espada.
    //[SerializeField] public Sprite giftImageMagmadora;
    //[SerializeField] public Sprite giftImageMasermati;
    [SerializeField] public Sprite giftImageRaven;       // Si completas su minijuego te da un disco.
    //[SerializeField] public Sprite giftImageRustica; 

    [Header("Sprites alternativos")]
    [SerializeField] Sprite sergioSpriteAlt;
    [SerializeField] Sprite antonioSpriteAlt;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        canvasPausa = gameObject.transform.GetChild(13).gameObject;
        canvasVictory = gameObject.transform.GetChild(12).gameObject;
        currentScene = SceneManager.GetActiveScene();
        buttonCobrar.SetActive(false);
        buttonNoCobrar.SetActive(false);
        botonPlegadoPrecios.SetActive(false);
        botonPlegadoNormativas.SetActive(false);
        estaToPagao = false;
        showTrophyAnim = gameObject.transform.GetChild(14).GetComponent<Animator>();

        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! CHICO NUEVO, MENOS SUELDO…");                  // Si no le has cobrado y sí deberias haberle cobrado.
        quejas.Add("¡Tendrías que haberle echado a patadas, no tenía el dinero suficiente!");                   // Si sí le has cobrado y no deberías haberle cobrado.
        quejas.Add("¡Aquí tenemos unas normas! ¡¿Las recuerdas?!");                                             // Cuando no has cumplido las normativas.
        quejas.Add("¡¿Cómo que no le has cobrado a ese cliente?! ¡Tenía dinero y no rompía ninguna norma!");    // Si no le has cobrado y sí deberias haberle cobrado (A partir del día 2).
        quejas.Add("Ese cupón es más falso que el amor que siento por mi madre");    // Cuando la cagas con el boleto

        razasNormas = new string[5];
        razasNormas[0] = "Magos Oscuros";
        razasNormas[1] = "Híbridos";
        razasNormas[2] = "Tecno P2";
        razasNormas[3] = "Limbásticos";
        razasNormas[4] = "Elementales";

        razaSeleccionada = 0;

        Data.instance.uIManager = gameObject;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Holi");
            TrophyAchieved();
        }

        if (currentCustomer != null && currentCustomer.name.Contains("Detective"))
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
        if (asegurarseQuitar) Data.instance.detectivePoints++;

        panelSospechoso.SetActive(false);

        UltimaFraseDetective();
    }

    public void ShowText()
    {
        conversationOn = true;
        dialoguePanel.gameObject.SetActive(true);

        traductorText.text = currentCustomer.GetComponent<Client>().raza;
        NombreText.text = currentCustomer.GetComponent<Client>().nombre;
        dialogueSize = currentCustomer.GetComponent<Client>().dialogue.Count;

        if (!(currentCustomer.name.Contains("Cululu") && currentScene.name == "Day5") && !(currentCustomer.name.Contains("Raven") && currentScene.name == "Day5")
            && !(currentCustomer.name.Contains("Sergio") && currentScene.name == "Day4") && !(currentCustomer.name.Contains("Geraaaard") && currentScene.name == "Day4")
            && !(currentCustomer.name.Contains("Mara") && currentScene.name == "Day4") && !(currentCustomer.name.Contains("Handy") && currentScene.name == "Day4"))
        {
            if (((currentCustomer.name.Contains("Jefe") || currentCustomer.name.Contains("Jefazo")) && internalCount < dialogueSize)
               || (currentCustomer.name.Contains("Detective") && internalCount < dialogueSize - 1)
               || (currentCustomer.name.Contains("Mano") && internalCount < dialogueSize && currentScene.name == "Day4")        // Es necesario que esté
               || (currentCustomer.name.Contains("Sapopotamo") && internalCount < dialogueSize && currentScene.name == "Day5")  // Es necesario que esté
               || (internalCount < dialogueSize - 2 && !currentCustomer.name.Contains("Jefe") && !currentCustomer.name.Contains("Jefazo"))
               || (currentCustomer.name.Contains("Denji") && internalCount < dialogueSize && (currentScene.name == "Day2_1" || currentScene.name == "Day2_2"
               || currentScene.name == "Day3_1" || currentScene.name == "Day3_2")
               || currentCustomer.name.Contains("Enano") && internalCount < dialogueSize && currentScene.name == "Day2_1")
               || currentCustomer.name.Contains("Petra") && internalCount < dialogueSize && currentScene.name == "Day5"
               || currentCustomer.name.Contains("Antonio") && internalCount < dialogueSize && currentScene.name == "Day5"
               || currentCustomer.name.Contains("Geraaaard") && internalCount < dialogueSize && currentScene.name == "Day4" && Data.instance.vecesCobradoGeerald == 0)
            {
                dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
                gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
                currentCustomer.GetComponent<Client>().Speaking();
                internalCount++;

                //if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count)
                //    currentCustomer.GetComponent<Client>().ByeBye();
                //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
            }

            else
                HideText();
        }

        else if(currentCustomer.name.Contains("Cululu") && internalCount < dialogueSize - 3 && currentScene.name == "Day5")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
            internalCount++;
        }

        else if (currentCustomer.name.Contains("Raven") && internalCount < dialogueSize - 3 && currentScene.name == "Day5")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
            internalCount++;
        }

        else if (currentCustomer.name.Contains("Sergio") && internalCount < dialogueSize - 3 && currentScene.name == "Day4")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
            internalCount++;
        }

        else if (currentCustomer.name.Contains("Geraaaard") && internalCount < dialogueSize - 3 && currentScene.name == "Day4" && Data.instance.vecesCobradoGeerald != 0)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
            internalCount++;
        }

        else if (currentCustomer.name.Contains("Geraaaard") && currentScene.name == "Day4" && Data.instance.vecesCobradoGeerald == 0 && !(internalCount == dialogueSize))
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
            internalCount++;
        }

        else if(currentCustomer.name.Contains("Mara") && currentScene.name == "Day4" && internalCount < dialogueSize - 3)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
            internalCount++;
        }

        else if (currentCustomer.name.Contains("Handy") && currentScene.name == "Day4" && internalCount < dialogueSize - 3)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
            internalCount++;
        }

        else
            HideText();
    }

    public void HideText()
    {
        //gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = false;
        dialoguePanel.gameObject.SetActive(false);
        dialoguePanel.gameObject.SetActive(false);
        dropDownPanelPrecios.gameObject.SetActive(true);
        dropDownPanelNormativas.gameObject.SetActive(true);
        dialogueSize = currentCustomer.GetComponent<Client>().dialogue.Count;

        if (currentScene.name == "Day1")
            preciosButton.gameObject.GetComponent<Animator>().SetBool("BigButton", true);

        if (currentScene.name == "Day2_1")
            normativasButton.gameObject.GetComponent<Animator>().SetBool("BigButton", true);

        if (internalCount == dialogueSize && (currentCustomer.name.Contains("Jefe") || currentCustomer.name.Contains("Jefazo")))
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

        else if (internalCount == dialogueSize &&
            ((currentCustomer.name.Contains("Mano") && currentScene.name == "Day4")
            || (currentCustomer.name.Contains("Sapopotamo") && currentScene.name == "Day5")
            || (currentCustomer.name.Contains("Denji") && currentScene.name == "Day2_1")
            || (currentCustomer.name.Contains("Denji") && currentScene.name == "Day2_2")
            || (currentCustomer.name.Contains("Denji") && currentScene.name == "Day3_1")
            || (currentCustomer.name.Contains("Denji") && currentScene.name == "Day3_2")
            || (currentCustomer.name.Contains("Enano") && currentScene.name == "Day2_1")
            || (currentCustomer.name.Contains("Petra") && currentScene.name == "Day5")
            || (currentCustomer.name.Contains("Antonio") && currentScene.name == "Day5")
            || (currentCustomer.name.Contains("Geraaaard") && currentScene.name == "Day4" && Data.instance.vecesCobradoGeerald == 0)))
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

            else if (currentScene.name == "Day2_1")
            {
                if (currentCustomer.name.Contains("Lepion"))
                    currentCustomer.GetComponent<H_Lepion>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Giovanni"))
                    currentCustomer.GetComponent<L_Giovanni>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Enano"))
                //    currentCustomer.GetComponent<MO_ManoloCabezaPico>().ShowProductsAndMoney(); //Solo muestra texto, no trae productos

                else if (currentCustomer.name.Contains("Cululu"))
                    currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Handy"))
                //    currentCustomer.GetComponent<E_Handy>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Petra"))
                //    currentCustomer.GetComponent<H_Petra>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Tapiz"))
                //    currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Masermati"))
                //    currentCustomer.GetComponent<T_Masermati>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Pijus"))
                //    currentCustomer.GetComponent<MO_PijusMagnus>().ShowProductsAndMoney();
            }

            else if (currentScene.name == "Day2_2")
            {
                if (currentCustomer.name.Contains("Handy"))
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

            else if (currentScene.name == "Day3_1")
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

                //else if (currentCustomer.name.Contains("Rustica"))
                //    currentCustomer.GetComponent<T_Rustica>().ShowProductsAndMoney();
            }

            else if (currentScene.name == "Day3_2")
            {
                //if (currentCustomer.name.Contains("Sergio"))
                //    currentCustomer.GetComponent<L_Sergio>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Saltaralisis"))
                //    currentCustomer.GetComponent<H_Saltaralisis>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Mano"))
                //    currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Raven"))
                //    currentCustomer.GetComponent<T_Raven>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Hueso"))
                //    currentCustomer.GetComponent<E_ElementalHueso>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Patxi"))
                //    currentCustomer.GetComponent<L_Patxi>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Sapopotamo"))
                //    currentCustomer.GetComponent<H_Elvog>().ShowProductsAndMoney();

                //else if (currentCustomer.name.Contains("Enano"))
                //    currentCustomer.GetComponent<MO_ManoloCabezaPico>().ShowProductsAndMoney();

                if (currentCustomer.name.Contains("Rustica"))
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

                else if (currentCustomer.name.Contains("Sergio"))
                    currentCustomer.GetComponent<L_Sergio>().ShowProductsAndMoney();

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

                else if (currentCustomer.name.Contains("Petra"))
                    currentCustomer.GetComponent<H_Petra>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Cululu"))
                    currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Masermati"))
                    currentCustomer.GetComponent<T_Masermati>().ShowProductsAndMoney();

                else if (currentCustomer.name.Contains("Mano"))
                    currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();

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
        //gameManager.GetComponent<GameManager>().FindTheCustomer();
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
        //gameManager.GetComponent<GameManager>().FindTheCustomer();
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
        //gameManager.GetComponent<GameManager>().FindTheCustomer();
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

        Color phoneColor = phone.GetComponent<Image>().color;
        Color candleColor = candle.GetComponent<Image>().color;
        float fadeAmount, negFadeAmount;
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

        if (propinasNumber < 0) propinasNumber = 0;

        else if (propinasNumber > 100) propinasNumber = 100;

        lesPropinas.GetComponent<Image>().fillAmount = (propinasNumber) / 100;
        lePropinasText.text = "" + propinasNumber;

    }

    public string MoneyText()
    {
        if (currentCustomer.name.Contains("Cululu") && Data.instance.vecesCobradoCululu >= 2 && currentScene.name == "Day5")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 3];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
        }

        else if (currentCustomer.name.Contains("Raven") && Data.instance.vecesCobradoRaven >= 1 && currentScene.name == "Day5")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 3];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
        }

        else if (currentCustomer.name.Contains("Geraaaard") && Data.instance.vecesCobradoGeerald != 0 && currentScene.name == "Day4" && giftImageGeeraard == true)
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 3];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
        }

        else if (currentCustomer.name.Contains("Mara") && Data.instance.vecesCobradaMara >= 1 && currentScene.name == "Day4")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 3];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
        }

        else if (currentCustomer.name.Contains("Handy") && Data.instance.vecesCobradaHandy >= 1 && currentScene.name == "Day4")
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 3];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
        }

        else
        {
            dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 2];
            gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            currentCustomer.GetComponent<Client>().Speaking();
        }

        if (currentScene.name == "Day1")
        {
            if (currentCustomer.name.Contains("Geraaaard") || currentCustomer.name.Contains("Sapopotamo") || currentCustomer.name.Contains("Tapiz"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Giovanni"))
            {
                mostrarJefe = false;
                LaVoluntad(10);

                Data.instance.vecesCobradoGiovanni++;
            }

            else if (currentCustomer.name.Contains("Mara"))
            {
                mostrarJefe = false;
                LaVoluntad(10);

                Data.instance.vecesCobradaMara++;
            }

            else if (currentCustomer.name.Contains("Antonio"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[1];
                LaVoluntad(-10);

                Data.instance.programadorBuscaEsposo = true;
            }

            else if (currentCustomer.name.Contains("Rockon"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[1];
                LaVoluntad(-10);
            }

            else if (currentCustomer.name.Contains("Denjirenji"))
            {
                Data.instance.samuraiPagaMal = true;
                mostrarJefe = true;
                textoJefe.text = quejas[1];
                LaVoluntad(-10);
            }

            return dialogueText.text;
        }

        else if (currentScene.name == "Day2_1" || currentScene.name == "Day2_2")
        {
            if (currentCustomer.name.Contains("Pijus"))
            {
                //Mostrar queja de que no tiene suficiente dinero
                mostrarJefe = true;
                textoJefe.text = quejas[1];
                LaVoluntad(-15);
            }

            else if (currentCustomer.name.Contains("Giovanni") || currentCustomer.name.Contains("Handy"))
            {
                //Mostrar queja de que no cumplen normas
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
            }

            else if (currentCustomer.name.Contains("Enano") || currentCustomer.name.Contains("Petra") || currentCustomer.name.Contains("Masermati")
                || currentCustomer.name.Contains("Tapiz") || currentCustomer.name.Contains("Lepion"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
                Data.instance.propinaDay2_1 = propinasNumber;
            }

            else if (currentCustomer.name.Contains("Cululu"))
            {
                Data.instance.vecesCobradoCululu++;
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
                Data.instance.propinaDay2_1 = propinasNumber;
            }

            return dialogueText.text;
        }

        else if (currentScene.name == "Day3_1" || currentScene.name == "Day3_2")
        {
            if (currentCustomer.name.Contains("Saltaralisis") || currentCustomer.name.Contains("Mano") || currentCustomer.name.Contains("Enano"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Patxi"))
            {
                Data.instance.vecesCobradoAntonio++;

                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Raven"))
            {
                mostrarJefe = false;
                LaVoluntad(10);

                Data.instance.vecesCobradoRaven++;
            }

            else if (currentCustomer.name.Contains("Sapopotamo"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(5);
            }

            else if (currentCustomer.name.Contains("Sergio") || currentCustomer.name.Contains("Hueso") || currentCustomer.name.Contains("Rustica"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
            }

            return dialogueText.text;
        }

        else if (currentScene.name == "Day4")
        {
            if (currentCustomer.name.Contains("Enano"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Handy"))
            {
                mostrarJefe = false;
                LaVoluntad(10);

                Data.instance.vecesCobradaHandy++;

                if (Data.instance.vecesCobradaHandy >= 2) Data.instance.giftHandy = true;
            }

            else if (currentCustomer.name.Contains("Cululu"))
            {
                mostrarJefe = false;
                LaVoluntad(10);

                Data.instance.vecesCobradoCululu++;
            }

            else if (currentCustomer.name.Contains("Antonio"))
            {
                Data.instance.vecesCobradoAntonio++;
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Geraaaard"))
            {
                Data.instance.vecesCobradoGeerald++;

                if (Data.instance.vecesCobradoGeerald >= 2) Data.instance.giftGeeraard = true;

                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);

            }

            else if (currentCustomer.name.Contains("Jissy") || currentCustomer.name.Contains("Elidora")
                || currentCustomer.name.Contains("Magma") || currentCustomer.name.Contains("Geraaaard"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
            }

            else if (currentCustomer.name.Contains("Mara"))
            {
                Data.instance.vecesCobradaMara++;

                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);

                if (Data.instance.vecesCobradaMara >= 2) Data.instance.giftMara = true;
            }

            else if (currentCustomer.name.Contains("Sergio"))
            {
                currentCustomer.GetComponent<SpriteRenderer>().sprite = sergioSpriteAlt;
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);

                Data.instance.giftSergio = true;

                if (Data.instance.giftSergio == true && Data.instance.giftSergioYaConseguido == false)
                {
                    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 3];
                    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
                    currentCustomer.GetComponent<Client>().Speaking();
                    Data.instance.giftSergioYaConseguido = true;
                }

                else
                {
                    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 2];
                    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
                    currentCustomer.GetComponent<Client>().Speaking();
                }
            }

            return dialogueText.text;
        }

        else if (currentScene.name == "Day5")
        {
            if (currentCustomer.name.Contains("Elidora") || currentCustomer.name.Contains("Mano")
                || currentCustomer.name.Contains("Tapiz"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Rockon") || currentCustomer.name.Contains("Masermati") || currentCustomer.name.Contains("Saltarisis"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);
            }

            else if (currentCustomer.name.Contains("Cululu"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[2];
                LaVoluntad(-15);

                Data.instance.vecesCobradoCululu++;

                if (Data.instance.vecesCobradoCululu >= 3) Data.instance.giftCululu = true;
            }

            else if (currentCustomer.name.Contains("Raven"))
            {
                mostrarJefe = false;
                LaVoluntad(10);

                Data.instance.vecesCobradoRaven++;

                if (Data.instance.vecesCobradoRaven >= 2) Data.instance.giftRaven = true;
            }

            return dialogueText.text;
        }

        return null;
    }

    public string IDontBelieveText()
    {
        dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[currentCustomer.GetComponent<Client>().dialogue.Count - 1];
        gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        currentCustomer.GetComponent<Client>().Speaking();
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
            }

            else if (currentCustomer.name.Contains("Antonio") || currentCustomer.name.Contains("Rockon") || currentCustomer.name.Contains("Denjirenji"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            return dialogueText.text;
        }

        else if (currentScene.name == "Day2_1" || currentScene.name == "Day2_2")
        {
            if (currentCustomer.name.Contains("Enano") || currentCustomer.name.Contains("Cululu")
                || currentCustomer.name.Contains("Petra") || currentCustomer.name.Contains("Masermati")
                || currentCustomer.name.Contains("Tapiz") || currentCustomer.name.Contains("Lepion"))
            {
                //Queja de que si que tenía el dinero suficiente
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
            }

            else if (currentCustomer.name.Contains("Giovanni"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Handy"))
            {
                mostrarJefe = false;
                LaVoluntad(10);

                Data.instance.vecesCobradaHandy++;
            }

            else if (currentCustomer.name.Contains("Pijus"))
            {
                mostrarJefe = false;
                LaVoluntad(-1);
            }

            return dialogueText.text;
        }

        else if (currentScene.name == "Day3_1" || currentScene.name == "Day3_2")
        {
            if (currentCustomer.name.Contains("Sergio") || currentCustomer.name.Contains("Hueso") || currentCustomer.name.Contains("Rustica"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Sapopotamo"))
            {
                Data.instance.borrachoTriste = true;
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Saltaralisis") || currentCustomer.name.Contains("Mano")
                || currentCustomer.name.Contains("Raven") || currentCustomer.name.Contains("Patxi") || currentCustomer.name.Contains("Enano"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
            }

            return dialogueText.text;
        }

        else if (currentScene.name == "Day4")
        {
            if (currentCustomer.name.Contains("Mara") || currentCustomer.name.Contains("Jissy") || currentCustomer.name.Contains("Elidora")
                || currentCustomer.name.Contains("Geraaaard") || currentCustomer.name.Contains("Magma"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Cululu") || currentCustomer.name.Contains("Enano") || currentCustomer.name.Contains("Antonio")
                || currentCustomer.name.Contains("Handy"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
            }

            else if (currentCustomer.name.Contains("Sergio"))
            {
                Data.instance.vecesCobradoGeerald++;

                //if(Data.instance.vecesCobradoGeerald >= 2) Data.instance.giftGeeraard = true;

                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
            }

            return dialogueText.text;
        }

        else if (currentScene.name == "Day5")
        {
            if (currentCustomer.name.Contains("Rockon") || currentCustomer.name.Contains("Masermati")
                || currentCustomer.name.Contains("Saltarisis") || currentCustomer.name.Contains("Magma"))
            {
                mostrarJefe = false;
                LaVoluntad(10);
            }

            else if (currentCustomer.name.Contains("Elidora") || currentCustomer.name.Contains("Mano")
                || currentCustomer.name.Contains("Raven") || currentCustomer.name.Contains("Tapiz") || currentCustomer.name.Contains("Cululu"))
            {
                mostrarJefe = true;
                textoJefe.text = quejas[3];
                LaVoluntad(-15);
            }

            return dialogueText.text;
        }

        return null;
    }

    public void RetrocederRaza()
    {
        razaSeleccionada = (razaSeleccionada - 1 + razasNormas.Length) % razasNormas.Length;

        textoRaza.text = razasNormas[razaSeleccionada];

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

        textoRaza.text = razasNormas[razaSeleccionada];

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

    public void TrophyAchieved()
    {
        if (Data.instance.giftAntonio)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageAntonio;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Gafas Otaku \nDesbloqueadas!";
        }

        else if (Data.instance.giftCululu)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageCululu;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Foto Tinder \nDesbloqueada!";
        }

        else if (Data.instance.giftDenjirenji)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageDenjirenji;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Katana \nLáser \nDesbloqueada!";
        }

        else if (Data.instance.giftElidora)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageElidora;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Mc Moco \nDesbloqueado!";
        }

        else if (Data.instance.giftElvog)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageElvog;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Flores \nen Vodka \nDesbloqueadas!";
        }

        else if (Data.instance.giftEnano)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageEnano;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Elena Nito \nDesbloqueado!";
        }

        else if (Data.instance.giftGeeraard)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageGeeraard;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Foto to wapa \nDesbloqueada!";
        }

        else if (Data.instance.giftGiovanni)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageGiovanni;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Libro Gordo \nDesbloqueado!";
        }

        else if (Data.instance.giftHandy)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageHandy;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Traje \nde los \nDomingos \nDesbloqueado!";
        }

        else if (Data.instance.giftMano)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageMano;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡El sellaso \nDesbloqueado!";
        }

        else if (Data.instance.giftMara)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageMara;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Trozo de \nex-marido \nDesbloqueado!";
        }

        else if (Data.instance.giftPetra)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImagePetra;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Mapa de \nAlbacete \nDesbloqueado!";
        }

        else if (Data.instance.giftGeeraard)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageAntonio;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Foto to wapa \nDesbloqueada!";
        }

        else if (Data.instance.giftRaven)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageRaven;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡Disco de \nlos Mojinos \nDesbloqueado!";
        }

        else if (Data.instance.giftSergio)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageSergio;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡La \nGloboespada \nDesbloqueada!";
        }

        else if (Data.instance.giftTapicio)
        {
            gameObject.transform.GetChild(14).GetChild(0).GetComponent<Image>().sprite = giftImageTapicio;
            gameObject.transform.GetChild(14).GetChild(1).GetComponent<TMP_Text>().text = "¡El GOTY \nDesbloqueado!";
        }

        //StartCoroutine(TrophyShower());
        showTrophyAnim.SetTrigger("TrophyShow");
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
            Data.instance.day0Check = false;
            Data.instance.day1Check = true;
        }

        else if (currentScene.name == "Day2_2")
        {
            Data.instance.day1Check = false;
            Data.instance.day2Check = true;
        }

        else if (currentScene.name == "Day3_2")
        {
            Data.instance.day2Check = false;
            Data.instance.day3Check = true;
        }

        else if (currentScene.name == "Day4")
        {
            Data.instance.day3Check = false;
            Data.instance.day4Check = true;
        }

        else if (currentScene.name == "Day5")
        {
            Data.instance.day4Check = false;
            Data.instance.day5Check = true;
        }

        SceneManager.LoadScene(12);
    }

    public void NextDenji()
    {
        if (currentScene.name == "Day2_1")
        {
            Data.instance.propinaDay2_1 = propinasNumber;
            SceneManager.LoadScene("Pila_Nivel1");
        }

        else if (currentScene.name == "Day3_1")
        {
            Data.instance.propinaDay3_1 = propinasNumber;
            SceneManager.LoadScene("Pila_Nivel2");
        }
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
