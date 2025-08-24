using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public enum Language
{
    ES,
    EN
}

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private Dictionary<string, DialogueEntry> dialogueLookup;

    [System.Serializable]
    public class ClientLine
    {
        public string text;
        public string type;
        public string tone;
        public string mood;
        public string extra;

        public ClientLine(string text, string tone, string mood, string type, string extra)
        {
            this.text = text;
            this.type = type;
            this.tone = tone;
            this.mood = mood;
            this.extra = extra;
        }
    }

    [System.Serializable]
    public class DailyClientInfo
    {
        public string clientID;
        public string name;
        public string firstKey;
        public string endKey;
        public string race;
        public List<ClientLine> dialogueLines = new List<ClientLine>();
        public List<ClientLine> tickResponse = new List<ClientLine>();
        public List<ClientLine> crossResponse = new List<ClientLine>();
        public List<ClientLine> mgGoodResponse = new List<ClientLine>();
        public List<ClientLine> mgBadResponse = new List<ClientLine>();


        //Solo si hay que cobrarle
        public int numberOfProducts;
        public List<string> productTypes; // Type1, Type2, Type3
        public float clientMoney;
        public float toBeCharged;
        public string correctChoice; // "TICK" o "CROSS"
        public int tipsIfCheck;
        public int tipsIfBye;
        public string bossComplainsCheckWrong;
        public string bossComplainsByeWrong;

        //Solo si tiene cupones
        public bool hasCoupon;
        public string couponRace;
        public string couponType;

        //Solo si es el detective
        public List<string> suspects; // suspects1, suspects2, suspects3
        public string correctAnswer;

        public DailyClientInfo(string clientID, string name, string firstKey, string lastKey, string race)
        {
            this.clientID = clientID;
            this.name = name;
            this.firstKey = firstKey;
            this.endKey = lastKey;
            this.race = race;
        }
    }

    [System.Serializable]
    public class ProductCategoryEntry
    {
        public string categoryName;
        public List<string> products;
    }
    [System.Serializable]
    public class ProductsType
    {
        public List<ProductCategoryEntry> categories = new List<ProductCategoryEntry>();
    }

    [System.Serializable]
    public class RegulationInfo
    {
        public string regulationName;
        public string regulationType;
        public string discountedProduct;
        public string newPrice;
        public string mix1Forbidden;
        public string mix2Forbidden;
        public string raceAffected;

        public RegulationInfo(string regulationName, string regulationType, string raceAffected)
        {
            this.regulationName = regulationName;
            this.regulationType = regulationType;
            this.raceAffected = raceAffected;
        }
    }

    public List<string> GetAllKeys()
    {
        return new List<string>(dialogueLookup.Keys);
    }

    [Header("IDIOMA ACTUAL")]
    public Language currentLanguage = Language.ES; //XIXO

    [Header("REFERENCIAS MENÚ")]
    public GameObject playButton;
    public GameObject minigamesButton;
    public GameObject optionsButton;
    public GameObject creditsButton;
    public GameObject exitButton;
    public GameObject languageButton;
    public GameObject musicTextContainer;
    public GameObject muteTextContainer;

    public bool IsReady { get; private set; } = false;

    public string currentDay;
    public string lastSceneWithDialogues;
    public GameObject csvImporter;
    public GameObject mainCam;
    public GameObject clientManager;
    public GameObject clientPrefab;
    public List<DailyClientInfo> dailyCustomers = new List<DailyClientInfo>();
    public List<String> chosenChecks = new List<String>();

    [SerializeField] public bool conversationOn;
    [SerializeField] public GameObject dialoguePanelFirst;
    [SerializeField] public GameObject dialoguePanelFirstCollider;
    [SerializeField] public GameObject dialoguePanelFirstNameText;
    [SerializeField] public GameObject dialoguePanelFirstRaceText;
    [SerializeField] public GameObject dialoguePanelFirstDialogueText;
    [SerializeField] public GameObject dialoguePanelOther;
    [SerializeField] public GameObject dialoguePanelOtherCollider;
    [SerializeField] public GameObject dialoguePanelOtherNameText;
    [SerializeField] public GameObject dialoguePanelOtherRaceText;
    [SerializeField] public GameObject dialoguePanelOtherDialogueText;
    [SerializeField] public GameObject detectivePanel;
    [SerializeField] public Volume postPro;
    [SerializeField] public VolumeProfile postPro_Profile;
    [SerializeField] public GameObject areYouSurePanel;
    [SerializeField] public GameObject racePanel;
    [SerializeField] public TMP_Text traductorText;
    [SerializeField] public TMP_Text NombreText;

    [SerializeField] public GameObject uITrophies;
    [SerializeField] public GameObject gnomeMinigameCanvas;
    [SerializeField] public bool theGnomeIsFree;
    [SerializeField] public GameObject gnomeFog1;
    [SerializeField] public GameObject gnomeFog2;

    [Header("RELATED TO THE DROPDOWN MENU WITH THE LIST OF ITEMS")]

    [SerializeField] public ProductsType allProducts;

    public TextMeshProUGUI beerText;
    public TextMeshProUGUI magicRamenText;
    public TextMeshProUGUI energyDrinkText;
    public TextMeshProUGUI manaPotionText;
    public TextMeshProUGUI venomPotionText;
    public TextMeshProUGUI deadCatText;
    public TextMeshProUGUI vodooDollText;
    public TextMeshProUGUI crystallBallText;
    public TextMeshProUGUI magicBatteriesText;
    public TextMeshProUGUI magicRunesText;

    [Header("NORMATIVAS")]

    public bool regulationsAdded;
    public int currentRegulationsNumber;
    public List<string> currentRegulations;
    public GameObject currentRegulationsBook;

    [SerializeField]
    public List<RegulationInfo> regulationsData = new List<RegulationInfo>();

    [Header("NORMATIVAS PRIMER DÍA")]
    public TextMeshProUGUI reg01DWTitle;
    public TextMeshProUGUI reg01DWNoRegText;
    public TextMeshProUGUI reg01HybTitle;
    public TextMeshProUGUI reg01HybNoRegText;
    public TextMeshProUGUI reg01EleTitle;
    public TextMeshProUGUI reg01EleNoRegText;
    public TextMeshProUGUI reg01LimTitle;
    public TextMeshProUGUI reg01LimNoRegText;
    public TextMeshProUGUI reg01TP2Title;
    public TextMeshProUGUI reg01TP2NoRegText;


    [Header("NORMATIVAS SEGUNDO DÍA")]
    public TextMeshProUGUI reg02DWTitle;
    public TextMeshProUGUI reg02DWNoRegText;
    public TextMeshProUGUI reg02HybTitle;
    public TextMeshProUGUI reg02HybNoRegText;
    public TextMeshProUGUI reg02EleTitle;
    public TextMeshProUGUI reg02EleReg1Text;
    public TextMeshProUGUI reg02LimTitle;
    public TextMeshProUGUI reg02LimReg1Text;
    public TextMeshProUGUI reg02TP2Title;
    public TextMeshProUGUI reg02TP2NoRegText;


    [Header("NORMATIVAS TERCER DÍA")]
    public TextMeshProUGUI reg03DWTitle;
    public TextMeshProUGUI reg03DWReg1Text;
    public TextMeshProUGUI reg03HybTitle;
    public TextMeshProUGUI reg03HybNoRegText;
    public TextMeshProUGUI reg03EleTitle;
    public TextMeshProUGUI reg03EleReg1Text;
    public TextMeshProUGUI reg03LimTitle;
    public TextMeshProUGUI reg03LimReg1Text;
    public TextMeshProUGUI reg03TP2Title;
    public TextMeshProUGUI reg03TP2Reg1Text;


    [Header("NORMATIVAS CUARTO DÍA")]
    public TextMeshProUGUI reg04DWTitle;
    public TextMeshProUGUI reg04DWReg1Text;
    public TextMeshProUGUI reg04DWReg2Text;
    public TextMeshProUGUI reg04HybTitle;
    public TextMeshProUGUI reg04HybReg1Text;
    public TextMeshProUGUI reg04EleTitle;
    public TextMeshProUGUI reg04EleReg1Text;
    public TextMeshProUGUI reg04EleReg2Text;
    public TextMeshProUGUI reg04LimTitle;
    public TextMeshProUGUI reg04LimReg1Text;
    public TextMeshProUGUI reg04TP2Title;
    public TextMeshProUGUI reg04TP2Reg1Text;


    [Header("NORMATIVAS QUINTO DÍA")]
    public TextMeshProUGUI reg05DWTitle;
    public TextMeshProUGUI reg05DWReg1Text;
    public TextMeshProUGUI reg05DWReg2Text;
    public TextMeshProUGUI reg05HybTitle;
    public TextMeshProUGUI reg05HybReg1Text;
    public TextMeshProUGUI reg05HybReg2Text;
    public TextMeshProUGUI reg05EleTitle;
    public TextMeshProUGUI reg05EleReg1Text;
    public TextMeshProUGUI reg05EleReg2Text;
    public TextMeshProUGUI reg05LimTitle;
    public TextMeshProUGUI reg05LimReg1Text;
    public TextMeshProUGUI reg05TP2Title;
    public TextMeshProUGUI reg05TP2Reg1Text;


    [Header("NORMATIVAS SEXTO DÍA")]
    public TextMeshProUGUI reg06DWTitle;
    public TextMeshProUGUI reg06DWReg1Text;
    public TextMeshProUGUI reg06DWReg2Text;
    public TextMeshProUGUI reg06HybTitle;
    public TextMeshProUGUI reg06HybReg1Text;
    public TextMeshProUGUI reg06HybReg2Text;
    public TextMeshProUGUI reg06EleTitle;
    public TextMeshProUGUI reg06EleReg1Text;
    public TextMeshProUGUI reg06EleReg2Text;
    public TextMeshProUGUI reg06LimTitle;
    public TextMeshProUGUI reg06LimReg1Text;
    public TextMeshProUGUI reg06LimReg2Text;
    public TextMeshProUGUI reg06TP2Title;
    public TextMeshProUGUI reg06TP2Reg1Text;
    public TextMeshProUGUI reg06TP2Reg2Text;


    [Header("NORMATIVAS SÉPTIMO DÍA")]
    public TextMeshProUGUI reg07DWTitle;
    public TextMeshProUGUI reg07DWReg1Text;
    public TextMeshProUGUI reg07DWReg2Text;
    public TextMeshProUGUI reg07HybTitle;
    public TextMeshProUGUI reg07HybReg1Text;
    public TextMeshProUGUI reg07HybReg2Text;
    public TextMeshProUGUI reg07EleTitle;
    public TextMeshProUGUI reg07EleReg1Text;
    public TextMeshProUGUI reg07EleReg2Text;
    public TextMeshProUGUI reg07LimTitle;
    public TextMeshProUGUI reg07LimReg1Text;
    public TextMeshProUGUI reg07LimReg2Text;
    public TextMeshProUGUI reg07TP2Title;
    public TextMeshProUGUI reg07TP2Reg1Text;
    public TextMeshProUGUI reg07TP2Reg2Text;

    public string darkWizardsTitleText;
    public string limbasticsTitleText;
    public string hybridsTitleText;
    public string tecnoP2TitleText;
    public string elementalsTitleText;

    List<TextMeshProUGUI> darkWizardsTitles = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> limbasticsTitles = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> hybridsTitles = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> tecnoP2Titles = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> elementalsTitles = new List<TextMeshProUGUI>();

    public string noRegText;
    public string noBuyPotionText;
    public string noBuyCaffeineText;
    public string magicItems2coinsText;
    public string darkmagicItems10coinsText;
    public string noBuyAtTheSameTimeText;
    public string noBuyAlcoholText;
    public string noBuyDarkMagicText;

    List<TextMeshProUGUI> noRegContainer = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> noBuyPotionContainer = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> noBuyCaffeineContainer = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> magicItems2coinsContainer = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> darkmagicItems10coinsContainer = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> noBuyAtTheSameTimeContainer = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> noBuyAlcoholContainer = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> noBuyDarkMagicContainer = new List<TextMeshProUGUI>();

    [Header("ITS ALL ABOUT THE MONEY MONEY MONEY")]
    [SerializeField] public GameObject leDinero;
    [SerializeField] public TMP_Text leDineroText;
    [SerializeField] public GameObject leDineroSymbol;
    [SerializeField] public GameObject leCajaRegistradora;
    [SerializeField] public GameObject buttonCobrar;
    [SerializeField] public GameObject buttonNoCobrar;
    [SerializeField] public GameObject centralProduct;
    [SerializeField] public GameObject rightProduct;
    [SerializeField] public GameObject leftProduct;

    [SerializeField] public bool tutorialZoomIn;
    [SerializeField] public GameObject zoomTargetPrices;
    [SerializeField] public GameObject zoomTargetRegulations;
    [SerializeField] public GameObject zoomTargetCoupon;

    [SerializeField] public GameObject couponPlace;
    [SerializeField] public GameObject couponInfoContainer;

    [SerializeField] public GameObject lesPropinas;
    [SerializeField] public TMP_Text lePropinasText;
    [SerializeField] public float propinasNumber;


    [SerializeField] public float puntosElidora;

    [Header("BOSS' THINGS")]
    public GameObject phone;
    public GameObject jefePanel;
    [SerializeField] public TMP_Text textoJefe;
    //public bool broncaFin = true;

    // Creación del singleton del DialogueManager para que solo haya uno en escena
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Inicializa el diccionario
        dialogueLookup = new Dictionary<string, DialogueEntry>();
    }

    private void Start()
    {
        if (currentDay == "")
            currentDay = "01";

        postPro_Profile = postPro.profile;

        if (lastSceneWithDialogues == currentDay)
        {
            Debug.Log("He vuelto del minijuego y actualizo las propinas");
            // Limita el valor entre 0 y 100
            propinasNumber = Mathf.Clamp(propinasNumber, 0, 100);

            // Redondea hacia abajo al múltiplo de 10 más cercano (0, 10, 20, ..., 100)
            int nivel = ((int)propinasNumber / 10) * 10;

            // Carga el sprite correspondiente
            //lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{nivel}");

            // Actualiza el texto
            lePropinasText.text = propinasNumber.ToString();
        }


        #region CREANDO EL DICCIONARIO DE TIPOS DE PRODUCTOS
        allProducts = new ProductsType();

        allProducts.categories.Add(new ProductCategoryEntry
        {
            categoryName = "NONE",
            products = new List<string> { "magicBatteries", "magicRamen" }
        });

        allProducts.categories.Add(new ProductCategoryEntry
        {
            categoryName = "alcohol",
            products = new List<string> { "beer" }
        });

        allProducts.categories.Add(new ProductCategoryEntry
        {
            categoryName = "caffeinated",
            products = new List<string> { "energyDrink" }
        });

        allProducts.categories.Add(new ProductCategoryEntry
        {
            categoryName = "darkMagic",
            products = new List<string> { "deadCat", "voodooDoll" }
        });

        allProducts.categories.Add(new ProductCategoryEntry
        {
            categoryName = "magic",
            products = new List<string> { "crystalBall", "runes" }
        });

        allProducts.categories.Add(new ProductCategoryEntry
        {
            categoryName = "potion",
            products = new List<string> { "manaPotion", "venomPotion" }
        });

        #endregion
    }

    public void LoadFromDatabase(DialogueDatabase db, string dayPrefix)
    {
        // Limpia el diccionario para que solo tenga los datos de dicho día
        dialogueLookup.Clear();

        foreach (var entry in db.entries)
        {
            if (string.IsNullOrEmpty(entry.ID))
                continue;

            //  Filtrar por día (#01, #02, etc.)
            if (!entry.ID.StartsWith($"#{dayPrefix}"))
                continue;

            if (!dialogueLookup.ContainsKey(entry.ID))
                dialogueLookup[entry.ID] = entry;

            else
                Debug.LogWarning($" Clave duplicada: {entry.ID}");
        }

        IsReady = true;
        Debug.Log($" Base de datos cargada solo para el día: {dayPrefix}");
    }

    public void GenerateDailyClients()
    {
        dailyCustomers.Clear();
        HashSet<string> seenClients = new HashSet<string>();

        List<string> allKeys = GetAllKeys();
        allKeys.Sort(); // orden cronológico

        Dictionary<string, DailyClientInfo> tempClients = new Dictionary<string, DailyClientInfo>();


        foreach (string key in allKeys)
        {
            string clientID = GetClientNumber(key);
            if (string.IsNullOrEmpty(clientID)) continue;

            string type = GetType(key);

            if (!tempClients.ContainsKey(clientID))
            {
                // Primer contacto con el cliente para inicializarlo
                string name = GetSpeaker(key);
                string race = GetRace(key);
                string lastKey = GetLastKey(key);
                tempClients[clientID] = new DailyClientInfo(clientID, name, key, lastKey, race);
                dailyCustomers.Add(tempClients[clientID]);
            }

            DailyClientInfo client = tempClients[clientID];

            if (type == "tick")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string extra = GetExtra(key);
                client.tickResponse.Add(new ClientLine(text, tone, mood, type, extra));
            }

            else if (type == "cross")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string extra = GetExtra(key);
                client.crossResponse.Add(new ClientLine(text, tone, mood, type, extra));
            }

            else if (type == "mgOUTGood")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string extra = GetExtra(key);
                client.mgGoodResponse.Add(new ClientLine(text, tone, mood, type, extra));
            }

            else if (type == "mgOUTBad")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string extra = GetExtra(key);
                client.mgBadResponse.Add(new ClientLine(text, tone, mood, type, extra));
            }

            else if (type == "init" || type.StartsWith("dialogue") || type == "end" || type == "break" || type == "mgIN" || type == "gnome")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string extra = GetExtra(key);
                client.dialogueLines.Add(new ClientLine(text, tone, mood, type, extra));

                // Si llegó al final, no hace falta seguir registrando más líneas
                if (type == "end" || type == "break")
                {
                    client.endKey = key;
                    continue;
                }
            }

            if (client.name == "Detective")
            {
                client.suspects = GetSuspectsList(key);
                client.correctAnswer = GetCorrectAnswer(key);
            }
        }

        Debug.Log($"Clientes procesados: {dailyCustomers.Count}");

        dailyCustomers = dailyCustomers.OrderBy(client => client.clientID == "clientFINAL" ? int.MaxValue : GetClientIndex(client.clientID)).ToList();
    }

    public void AssignProductDataToClients(ProductsDatabase productsDb)
    {
        foreach (DailyClientInfo client in dailyCustomers)
        {
            ProductsEntry matchingProduct = productsDb.entries
                .Find(entry =>
                entry.CLIENT.Equals(client.name, StringComparison.OrdinalIgnoreCase) &&
                entry.DAY.Equals(currentDay, StringComparison.OrdinalIgnoreCase) && entry.CLIENTID.Equals(client.endKey));

            if (matchingProduct == null)
            {
                Debug.LogWarning($"No se encontró entrada de producto para el {client.clientID}, de nombre: {client.name}");
                continue;
            }

            if (int.TryParse(matchingProduct.NUMBEROF, out int numProducts))
            {
                client.numberOfProducts = numProducts;
            }

            client.productTypes = new List<string>();
            if (!string.IsNullOrEmpty(matchingProduct.TYPE1)) client.productTypes.Add(matchingProduct.TYPE1);
            if (!string.IsNullOrEmpty(matchingProduct.TYPE2)) client.productTypes.Add(matchingProduct.TYPE2);
            if (!string.IsNullOrEmpty(matchingProduct.TYPE3)) client.productTypes.Add(matchingProduct.TYPE3);

            if (float.TryParse(matchingProduct.CLIENTMONEY, out float money))
            {
                client.clientMoney = money;
            }

            if (float.TryParse(matchingProduct.TOBECHARGED, out float charge))
            {
                client.toBeCharged = charge;
            }

            client.correctChoice = matchingProduct.CORRECTCHOICE;

            if (int.TryParse(matchingProduct.TIPSIFCHECK, out int tipsCheck))
            {
                client.tipsIfCheck = tipsCheck;
            }

            if (int.TryParse(matchingProduct.TIPSIFBYE, out int tipsBye))
            {
                client.tipsIfBye = tipsBye;
            }

            client.bossComplainsCheckWrong = matchingProduct.BOSSCOMPLAINSCHECKWRONG;
            client.bossComplainsByeWrong = matchingProduct.BOSSCOMPLAINSBYEWRONG;

            if (matchingProduct.HASCOUPON == "YES")
            {
                client.hasCoupon = true;
                client.couponRace = matchingProduct.COUPONRACE;
                client.couponType = matchingProduct.COUPONTYPE;
            }

            #region PARTE DE LAS NORMATIVAS (AUNQUE AÚN NO SE CONTEMPLA QUE HAYA DOS POR RAZA ACTIVAS) ELIMINADO PARA LA DEMO PORQUE NO FUNCIONABA

            //if (!regulationsAdded && currentRegulationsNumber ==0) // PARCHE HORRIBLE PARA QUE NO PETE LA DEMO
            //{
            //    regulationsAdded = true;

            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_01);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_02);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_03);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_04);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_05);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_06);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_07);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_08);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_09);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_10);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_11);
            //    currentRegulations.Add(matchingProduct.CURRENTREGULATION_12);

            //    #region CREAR LISTA CURRENTREGULATIONS
            //    // Añadir objetos RegulationInfo
            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_01, matchingProduct.WHICHTYPE_01, matchingProduct.FORWHO_01)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_01,
            //        newPrice = matchingProduct.NEWPRICE_01,
            //        mix1Forbidden = matchingProduct.MIX1_01,
            //        mix2Forbidden = matchingProduct.MIX2_01
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_02, matchingProduct.WHICHTYPE_02, matchingProduct.FORWHO_02)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_02,
            //        newPrice = matchingProduct.NEWPRICE_02,
            //        mix1Forbidden = matchingProduct.MIX1_02,
            //        mix2Forbidden = matchingProduct.MIX2_02
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_03, matchingProduct.WHICHTYPE_03, matchingProduct.FORWHO_03)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_03,
            //        newPrice = matchingProduct.NEWPRICE_03,
            //        mix1Forbidden = matchingProduct.MIX1_03,
            //        mix2Forbidden = matchingProduct.MIX2_03
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_04, matchingProduct.WHICHTYPE_04, matchingProduct.FORWHO_04)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_04,
            //        newPrice = matchingProduct.NEWPRICE_04,
            //        mix1Forbidden = matchingProduct.MIX1_04,
            //        mix2Forbidden = matchingProduct.MIX2_04
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_05, matchingProduct.WHICHTYPE_05, matchingProduct.FORWHO_05)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_05,
            //        newPrice = matchingProduct.NEWPRICE_05,
            //        mix1Forbidden = matchingProduct.MIX1_05,
            //        mix2Forbidden = matchingProduct.MIX2_05
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_06, matchingProduct.WHICHTYPE_06, matchingProduct.FORWHO_06)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_06,
            //        newPrice = matchingProduct.NEWPRICE_06,
            //        mix1Forbidden = matchingProduct.MIX1_06,
            //        mix2Forbidden = matchingProduct.MIX2_06
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_07, matchingProduct.WHICHTYPE_07, matchingProduct.FORWHO_07)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_07,
            //        newPrice = matchingProduct.NEWPRICE_07,
            //        mix1Forbidden = matchingProduct.MIX1_07,
            //        mix2Forbidden = matchingProduct.MIX2_07
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_08, matchingProduct.WHICHTYPE_08, matchingProduct.FORWHO_08)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_08,
            //        newPrice = matchingProduct.NEWPRICE_08,
            //        mix1Forbidden = matchingProduct.MIX1_08,
            //        mix2Forbidden = matchingProduct.MIX2_08
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_09, matchingProduct.WHICHTYPE_09, matchingProduct.FORWHO_09)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_09,
            //        newPrice = matchingProduct.NEWPRICE_09,
            //        mix1Forbidden = matchingProduct.MIX1_09,
            //        mix2Forbidden = matchingProduct.MIX2_09
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_10, matchingProduct.WHICHTYPE_10, matchingProduct.FORWHO_10)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_10,
            //        newPrice = matchingProduct.NEWPRICE_10,
            //        mix1Forbidden = matchingProduct.MIX1_10,
            //        mix2Forbidden = matchingProduct.MIX2_10
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_11, matchingProduct.WHICHTYPE_11, matchingProduct.FORWHO_11)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_11,
            //        newPrice = matchingProduct.NEWPRICE_11,
            //        mix1Forbidden = matchingProduct.MIX1_11,
            //        mix2Forbidden = matchingProduct.MIX2_11
            //    });

            //    regulationsData.Add(new RegulationInfo(matchingProduct.CURRENTREGULATION_12, matchingProduct.WHICHTYPE_12, matchingProduct.FORWHO_12)
            //    {
            //        discountedProduct = matchingProduct.WHICHPRODUCT_12,
            //        newPrice = matchingProduct.NEWPRICE_12,
            //        mix1Forbidden = matchingProduct.MIX1_12,
            //        mix2Forbidden = matchingProduct.MIX2_12
            //    });

            //    #endregion

            //    for (int i = 0; i < regulationsData.Count; i++)
            //    {
            //        if (regulationsData[i].regulationName != "")
            //        {
            //            currentRegulationsNumber++;

            //            if (regulationsData[i].regulationName == "forbiddenType_For_")
            //                ForbiddenType_For(dropDownPanelNormativas.transform, regulationsData[i].raceAffected, regulationsData[i].regulationType);

            //            else if (regulationsData[i].regulationName == "changingPriceTo_For_")
            //                ChangingPriceTo_For_(dropDownPanelNormativas.transform, regulationsData[i].raceAffected, regulationsData[i].newPrice, regulationsData[i].discountedProduct);

            //            else if (regulationsData[i].regulationName == "forbiddenMixof_For_")
            //                ForbiddenMixOf_For_(dropDownPanelNormativas.transform, regulationsData[i].raceAffected, regulationsData[i].mix1Forbidden, regulationsData[i].mix2Forbidden);

            //        }

            //    }
            //}

            #endregion
        }
    }

    #region FUNCIONES PARA LAS NORMATIVAS
    public void ForbiddenType_For(Transform razasPanelNormativas, string affectedRace, string typeOfProduct)
    {
        // Buscar el panel correspondiente a la raza
        Transform razaPanel = razasPanelNormativas.Cast<Transform>()
            .FirstOrDefault(child => child.name == affectedRace);

        if (razaPanel == null) return;

        razaPanel.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        razaPanel.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hoy tienen prohibido comprar:";
        // Obtener productos de la categoría deseada
        List<string> productsList = allProducts.categories
            .FirstOrDefault(c => c.categoryName == typeOfProduct)?.products;

        if (productsList == null || productsList.Count == 0) return;

        // Mostrar hasta 3 imágenes (index 1, 2, 3 del hijo del panel)
        for (int k = 0; k < Mathf.Min(productsList.Count, 3); k++)
        {
            Transform imageTransform = razaPanel.GetChild(k + 1);
            Image img = imageTransform.GetComponent<Image>();

            img.enabled = true;
            img.sprite = Resources.Load<Sprite>($"Sprites/Products/{productsList[k]}");
        }
    }

    public void ChangingPriceTo_For_(Transform razasPanelNormativas, string affectedRace, string newPrice, string product)
    {
        // Buscar el panel correspondiente a la raza
        Transform razaPanel = razasPanelNormativas.Cast<Transform>()
            .FirstOrDefault(child => child.name == affectedRace);

        if (razaPanel == null) return;

        razaPanel.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        razaPanel.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Hoy valen " + newPrice + " monedas:";
        razaPanel.GetChild(2).GetComponent<Image>().enabled = true;
        razaPanel.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Products/{product}");
    }

    public void ForbiddenMixOf_For_(Transform razasPanelNormativas, string affectedRace, string product1, string product2)
    {
        // Buscar el panel correspondiente a la raza
        Transform razaPanel = razasPanelNormativas.Cast<Transform>()
            .FirstOrDefault(child => child.name == affectedRace);

        if (razaPanel == null) return;

        razaPanel.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        razaPanel.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "No pueden comprar juntos:";
        razaPanel.GetChild(2).GetComponent<Image>().enabled = true;
        razaPanel.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Products/{product1}");
        razaPanel.GetChild(3).GetComponent<Image>().enabled = true;
        razaPanel.GetChild(3).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Products/{product2}");
    }

    #endregion

    #region GET DATA OF THE CLIENT
    private int GetClientIndex(string clientID)
    {
        switch (clientID)
        {
            case "clientZERO":
            case "clientZEROalt": return 0;

            case "clientONE":
            case "clientONEalt": return 1;

            case "clientTWO":
            case "clientTWOalt": return 2;

            case "clientTHREE":
            case "clientTHREEalt": return 3;

            case "clientFOUR":
            case "clientFOURalt": return 4;

            case "clientFIVE":
            case "clientFIVEalt": return 5;

            case "clientSIX":
            case "clientSIXalt": return 6;

            case "clientSEVEN":
            case "clientSEVENalt": return 7;

            case "clientEIGHT":
            case "clientEIGHTalt": return 8;

            case "clientNINE":
            case "clientNINEalt": return 9;

            case "clientTEN":
            case "clientTENalt": return 10;

            case "clientELEVEN":
            case "clientELEVENalt": return 11;

            case "clientTWELVE":
            case "clientTWELVEalt": return 12;

            case "clientTHIRTEEN":
            case "clientTHIRTEENalt": return 13;

            case "clientFOURTEEN":
            case "clientFOURTEENalt": return 14;

            case "clientFIFTEEN":
            case "clientFIFTEENalt": return 15;

            default: return 999;
        }
    }

    public string GetLastKey(string key)
    {
        if (dialogueLookup[key].TYPE == "end" || dialogueLookup[key].TYPE == "break")
            return dialogueLookup[key].ID;
        return "";
    }

    public string GetSpeaker(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].ACTOR;
        return "";
    }

    public string GetRace(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].RACE;
        return "";
    }

    public string GetText(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].TEXT;
        return $"[{key}]";
    }

    public string GetType(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].TYPE;
        return $"[{key}]";
    }

    public string GetTone(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].TONE;
        return $"[{key}]";
    }

    public string GetMood(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].MOOD;
        return $"[{key}]";
    }

    public string GetExtra(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].EXTRA;
        return $"[{key}]";
    }

    public string GetClientNumber(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].CLIENT;
        return $"[{key}]";
    }

    public List<string> GetSuspectsList(string key)
    {
        if (dialogueLookup.ContainsKey(key))
        {
            List<string> sospechosos = new List<string>
            {
                dialogueLookup[key].SUSPECT1,
                dialogueLookup[key].SUSPECT2,
                dialogueLookup[key].SUSPECT3
            };
            return sospechosos;
        }
        return new List<string>();
    }

    public string GetCorrectAnswer(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].CORRECTANSWER;
        return $"[{key}]";
    }

    #endregion

    public void ShowText()
    {
        conversationOn = true;

        if (currentDay == "01")
            dialoguePanelFirst.gameObject.SetActive(true);

        else
            dialoguePanelOther.gameObject.SetActive(true);
    }

    public void HideText()
    {
        conversationOn = false;
        //if (currentDay == "01")
        //    dialoguePanelFirst.gameObject.SetActive(false);

        //else
        //    dialoguePanelOther.gameObject.SetActive(false);
    }

    public void SetSceneRefs(GameObject mC, GameObject cM, GameObject phoneObj, GameObject complainObj,
                             GameObject dPanelFirst, GameObject dPanelFirstCollider, GameObject dPanelFirstNameText, GameObject dPanelFirstRaceText, GameObject dPanelFirstDialogueText,
                             GameObject dPanelOther, GameObject dPanelOtherCollider, GameObject dPanelOtherNameText, GameObject dPanelOtherRaceText, GameObject dPanelOtherDialogueText,
                             GameObject _racePanel, GameObject susPanel, GameObject secPanel, GameObject gnomeCanvas, GameObject gnomiebla1, GameObject gnomiebla2, GameObject trophyCanvas,
                             GameObject regBook, GameObject moneySack, TMP_Text moneySackText, GameObject moneySackSymbol, GameObject cachinkThing, GameObject chargeButton, GameObject byeButton,
                             GameObject cenProd, GameObject derProd, GameObject izqProd, GameObject zoomPricesObject, GameObject zoomRegulationsObject, GameObject zoomCouponObject,
                             GameObject coupPlace, GameObject coupInfoContainer, GameObject tipJar, TMP_Text tipJarText,
                             TextMeshProUGUI BE, TextMeshProUGUI MR, TextMeshProUGUI ED, TextMeshProUGUI MP, TextMeshProUGUI VP, TextMeshProUGUI DC, TextMeshProUGUI VD, TextMeshProUGUI CB, TextMeshProUGUI MB, TextMeshProUGUI RU,

                             TextMeshProUGUI r01DWTitle, TextMeshProUGUI r01DWNoRegText,
                             TextMeshProUGUI r01HybTitle, TextMeshProUGUI r01HybNoRegText,
                             TextMeshProUGUI r01EleTitle, TextMeshProUGUI r01EleNoRegText,
                             TextMeshProUGUI r01LimbTitle, TextMeshProUGUI r01LimbNoRegText,
                             TextMeshProUGUI r01TP2Title, TextMeshProUGUI r01TP2NoRegText,

                             TextMeshProUGUI r02DWTitle, TextMeshProUGUI r02DWNoRegText,
                             TextMeshProUGUI r02HybTitle, TextMeshProUGUI r02HybNoRegText,
                             TextMeshProUGUI r02EleTitle, TextMeshProUGUI r02EleReg1Text,
                             TextMeshProUGUI r02LimTitle, TextMeshProUGUI r02LimReg1Text,
                             TextMeshProUGUI r02TP2Title, TextMeshProUGUI r02TP2NoRegText,

                             TextMeshProUGUI r03DWTitle, TextMeshProUGUI r03DWReg1Text,
                             TextMeshProUGUI r03HybTitle, TextMeshProUGUI r03HybNoRegText,
                             TextMeshProUGUI r03EleTitle, TextMeshProUGUI r03EleReg1Text,
                             TextMeshProUGUI r03LimTitle, TextMeshProUGUI r03LimReg1Text,
                             TextMeshProUGUI r03TP2Title, TextMeshProUGUI r03TP2Reg1Text,

                             TextMeshProUGUI r04DWTitle, TextMeshProUGUI r04DWReg1Text, TextMeshProUGUI r04DWReg2Text,
                             TextMeshProUGUI r04HybTitle, TextMeshProUGUI r04HybReg1Text,
                             TextMeshProUGUI r04EleTitle, TextMeshProUGUI r04EleReg1Text, TextMeshProUGUI r04EleReg2Text,
                             TextMeshProUGUI r04LimTitle, TextMeshProUGUI r04LimReg1Text,
                             TextMeshProUGUI r04TP2Title, TextMeshProUGUI r04TP2Reg1Text,

                             TextMeshProUGUI r05DWTitle, TextMeshProUGUI r05DWReg1Text, TextMeshProUGUI r05DWReg2Text,
                             TextMeshProUGUI r05HybTitle, TextMeshProUGUI r05HybReg1Text, TextMeshProUGUI r05HybReg2Text,
                             TextMeshProUGUI r05EleTitle, TextMeshProUGUI r05EleReg1Text, TextMeshProUGUI r05EleReg2Text,
                             TextMeshProUGUI r05LimTitle, TextMeshProUGUI r05LimReg1Text,
                             TextMeshProUGUI r05TP2Title, TextMeshProUGUI r05TP2Reg1Text,

                             TextMeshProUGUI r06DWTitle, TextMeshProUGUI r06DWReg1Text, TextMeshProUGUI r06DWReg2Text,
                             TextMeshProUGUI r06HybTitle, TextMeshProUGUI r06HybReg1Text, TextMeshProUGUI r06HybReg2Text,
                             TextMeshProUGUI r06EleTitle, TextMeshProUGUI r06EleReg1Text, TextMeshProUGUI r06EleReg2Text,
                             TextMeshProUGUI r06LimTitle, TextMeshProUGUI r06LimReg1Text, TextMeshProUGUI r06LimReg2Text,
                             TextMeshProUGUI r06TP2Title, TextMeshProUGUI r06TP2Reg1Text, TextMeshProUGUI r06TP2Reg2Text,

                             TextMeshProUGUI r07DWTitle, TextMeshProUGUI r07DWReg1Text, TextMeshProUGUI r07DWReg2Text,
                             TextMeshProUGUI r07HybTitle, TextMeshProUGUI r07HybReg1Text, TextMeshProUGUI r07HybReg2Text,
                             TextMeshProUGUI r07EleTitle, TextMeshProUGUI r07EleReg1Text, TextMeshProUGUI r07EleReg2Text,
                             TextMeshProUGUI r07LimTitle, TextMeshProUGUI r07LimReg1Text, TextMeshProUGUI r07LimReg2Text,
                             TextMeshProUGUI r07TP2Title, TextMeshProUGUI r07TP2Reg1Text, TextMeshProUGUI r07TP2Reg2Text)
    {
        mainCam = mC;
        clientManager = cM;
        phone = phoneObj;
        jefePanel = complainObj;
        dialoguePanelFirst = dPanelFirst;
        dialoguePanelFirstCollider = dPanelFirstCollider;
        dialoguePanelFirstNameText = dPanelFirstNameText;
        dialoguePanelFirstRaceText = dPanelFirstRaceText;
        dialoguePanelFirstDialogueText = dPanelFirstDialogueText;
        dialoguePanelOther = dPanelOther;
        dialoguePanelOtherCollider = dPanelOtherCollider;
        dialoguePanelOtherNameText = dPanelOtherNameText;
        dialoguePanelOtherRaceText = dPanelOtherRaceText;
        dialoguePanelOtherDialogueText = dPanelOtherDialogueText;
        racePanel = _racePanel;
        detectivePanel = susPanel;
        areYouSurePanel = secPanel;
        areYouSurePanel = secPanel;

        gnomeMinigameCanvas = gnomeCanvas;
        gnomeFog1 = gnomiebla1;
        gnomeFog2 = gnomiebla2;
        uITrophies = trophyCanvas;

        currentRegulationsBook = regBook;

        leDinero = moneySack;
        leDineroText = moneySackText;
        leDineroSymbol = moneySackSymbol;
        leCajaRegistradora = cachinkThing;
        buttonCobrar = chargeButton;
        buttonNoCobrar = byeButton;
        centralProduct = cenProd;
        rightProduct = derProd;
        leftProduct = izqProd;

        zoomTargetPrices = zoomPricesObject;
        zoomTargetRegulations = zoomRegulationsObject;
        zoomTargetCoupon = zoomCouponObject;

        couponPlace = coupPlace;
        couponInfoContainer = coupInfoContainer;

        lesPropinas = tipJar;
        lePropinasText = tipJarText;

        beerText = BE;
        magicRamenText = MR;
        energyDrinkText = ED;
        manaPotionText = MP;
        venomPotionText = VP;
        deadCatText = DC;
        vodooDollText = VD;
        crystallBallText = CB;
        magicBatteriesText = MB;
        magicRunesText = RU;

        reg01DWTitle = r01DWTitle;
        reg01DWNoRegText = r01DWNoRegText;
        reg01HybTitle = r01HybTitle;
        reg01HybNoRegText = r01HybNoRegText;
        reg01EleTitle = r01EleTitle;
        reg01EleNoRegText = r01EleNoRegText;
        reg01LimTitle = r01LimbTitle;
        reg01LimNoRegText = r01LimbNoRegText;
        reg01TP2Title = r01TP2Title;
        reg01TP2NoRegText = r01TP2NoRegText;

        reg02DWTitle = r02DWTitle;
        reg02DWNoRegText = r02DWNoRegText;
        reg02HybTitle = r02HybTitle;
        reg02HybNoRegText = r02HybNoRegText;
        reg02EleTitle = r02EleTitle;
        reg02EleReg1Text = r02EleReg1Text;
        reg02LimTitle = r02LimTitle;
        reg02LimReg1Text = r02LimReg1Text;
        reg02TP2Title = r02TP2Title;
        reg02TP2NoRegText = r02TP2NoRegText;

        reg03DWTitle = r03DWTitle;
        reg03DWReg1Text = r03DWReg1Text;
        reg03HybTitle = r03HybTitle;
        reg03HybNoRegText = r03HybNoRegText;
        reg03EleTitle = r03EleTitle;
        reg03EleReg1Text = r03EleReg1Text;
        reg03LimTitle = r03LimTitle;
        reg03LimReg1Text = r03LimReg1Text;
        reg03TP2Title = r03TP2Title;
        reg03TP2Reg1Text = r03TP2Reg1Text;

        reg04DWTitle = r04DWTitle;
        reg04DWReg1Text = r04DWReg1Text;
        reg04DWReg2Text = r04DWReg2Text;
        reg04HybTitle = r04HybTitle;
        reg04HybReg1Text = r04HybReg1Text;
        reg04EleTitle = r04EleTitle;
        reg04EleReg1Text = r04EleReg1Text;
        reg04EleReg2Text = r04EleReg2Text;
        reg04LimTitle = r04LimTitle;
        reg04LimReg1Text = r04LimReg1Text;
        reg04TP2Title = r04TP2Title;
        reg04TP2Reg1Text = r04TP2Reg1Text;

        reg05DWTitle = r05DWTitle;
        reg05DWReg1Text = r05DWReg1Text;
        reg05DWReg2Text = r05DWReg2Text;
        reg05HybTitle = r05HybTitle;
        reg05HybReg1Text = r05HybReg1Text;
        reg05HybReg2Text = r05HybReg2Text;
        reg05EleTitle = r05EleTitle;
        reg05EleReg1Text = r05EleReg1Text;
        reg05EleReg2Text = r05EleReg2Text;
        reg05LimTitle = r05LimTitle;
        reg05LimReg1Text = r05LimReg1Text;
        reg05TP2Title = r05TP2Title;
        reg05TP2Reg1Text = r05TP2Reg1Text;

        reg06DWTitle = r06DWTitle;
        reg06DWReg1Text = r06DWReg1Text;
        reg06DWReg2Text = r06DWReg2Text;
        reg06HybTitle = r06HybTitle;
        reg06HybReg1Text = r06HybReg1Text;
        reg06HybReg2Text = r06HybReg2Text;
        reg06EleTitle = r06EleTitle;
        reg06EleReg1Text = r06EleReg1Text;
        reg06EleReg2Text = r06EleReg2Text;
        reg06LimTitle = r06LimTitle;
        reg06LimReg1Text = r06LimReg1Text;
        reg06LimReg2Text = r06LimReg2Text;
        reg06TP2Title = r06TP2Title;
        reg06TP2Reg1Text = r06TP2Reg1Text;
        reg06TP2Reg2Text = r06TP2Reg2Text;

        reg07DWTitle = r07DWTitle;
        reg07DWReg1Text = r07DWReg1Text;
        reg07DWReg2Text = r07DWReg2Text;
        reg07HybTitle = r07HybTitle;
        reg07HybReg1Text = r07HybReg1Text;
        reg07HybReg2Text = r07HybReg2Text;
        reg07EleTitle = r07EleTitle;
        reg07EleReg1Text = r07EleReg1Text;
        reg07EleReg2Text = r07EleReg2Text;
        reg07LimTitle = r07LimTitle;
        reg07LimReg1Text = r07LimReg1Text;
        reg07LimReg2Text = r07LimReg2Text;
        reg07TP2Title = r07TP2Title;
        reg07TP2Reg1Text = r07TP2Reg1Text;
        reg07TP2Reg2Text = r07TP2Reg2Text;

        if (jefePanel != null)
            textoJefe = jefePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void ChangeTipsPaper()
    {
        // Limita el valor entre 0 y 100
        propinasNumber = Mathf.Clamp(DialogueManager.Instance.propinasNumber, 0, 100);

        // Redondea al múltiplo de 10 inferior
        int nivel = ((int)propinasNumber / 10) * 10;

        // ESTO HAY QUE USARLO CUANDO VÍCTOR HAGA LOS MODELOS DE LAS PROPINAS
        // lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{nivel}");

        // Actualiza el texto
        lePropinasText.text = DialogueManager.Instance.propinasNumber.ToString();
    }

    public IEnumerator ChangeSaturation()
    {
        Debug.Log("Me llamo Detective");
        float startValue = 15f;
        float endValue = -100f;
        float duration = 1.5f;

        postPro.priority = 5;

        if (postPro_Profile.TryGet(out ColorAdjustments color))
        {
            float elapsed = 0f;
            float initial = startValue;
            color.saturation.value = initial;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                color.saturation.value = Mathf.Lerp(initial, endValue, t);
                yield return null;
            }
        }

    }

    public IEnumerator ReverseSaturation()
    {
        Debug.Log("Me llamo Minixefe");
        float startValue = -100f;
        float endValue = 15f;
        float duration = 1.5f;

        postPro.priority = 5;

        if (postPro_Profile.TryGet(out ColorAdjustments color))
        {
            float elapsed = 0f;
            float initial = startValue;
            color.saturation.value = initial;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                color.saturation.value = Mathf.Lerp(initial, endValue, t);
                yield return null;
            }
        }
    }

    public void BackToTheDefaultSaturation()
    {
        Debug.Log("Entro a cambiar la saturación a 15");
        if (postPro_Profile.TryGet(out ColorAdjustments color))
            color.saturation.value = 15f;
    }

    public void SetMenuReferences(GameObject playB, GameObject minigamesB, GameObject optionsB, GameObject creditsB, GameObject exitB, GameObject languageB, GameObject musicTC, GameObject muteTC)
    {
        playButton = playB;
        minigamesButton = minigamesB;
        optionsButton = optionsB;
        creditsButton = creditsB;
        exitButton = exitB;
        languageButton = languageB;
        musicTextContainer = musicTC;
        muteTextContainer = muteTC;
    }

    public void ChangingTextsAndFlag(Language lang)
    {
        LanguageActivations(playButton, lang.ToString());
        LanguageActivations(minigamesButton, lang.ToString());
        LanguageActivations(optionsButton, lang.ToString());
        LanguageActivations(creditsButton, lang.ToString());
        LanguageActivations(exitButton, lang.ToString());
        languageButton.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Menu/Buttons/Languages/{lang}");
        LanguageActivations(musicTextContainer, lang.ToString());
        LanguageActivations(muteTextContainer, lang.ToString());
    }

    public void LanguageActivations(GameObject parent, string childName)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.name == childName)
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
        }
    }

    public void LanguagePricesText()
    {
        List<TextMeshProUGUI> productsNames = new List<TextMeshProUGUI>();
        productsNames.Add(beerText);
        productsNames.Add(magicRamenText);
        productsNames.Add(energyDrinkText);
        productsNames.Add(manaPotionText);
        productsNames.Add(venomPotionText);
        productsNames.Add(deadCatText);
        productsNames.Add(vodooDollText);
        productsNames.Add(crystallBallText);
        productsNames.Add(magicBatteriesText);
        productsNames.Add(magicRunesText);

        if (currentLanguage == Language.ES)
        {
            string[] objetosESP =
                    { "Cerveza", "Ramen\nMágico", "Bedida\nEnergética", "Poción\nManá", "Poción\nVeneno", "Gato\nMuerto","Muñeco\nVoodoo", "Bola\nCristal", "Pilas\nMágicas", "Runas\nMágicas"};

            for (int i = 0; i < productsNames.Count; i++)
            {
                productsNames[i].text = objetosESP[i];
            }
        }

        else if (currentLanguage == Language.EN)
        {
            string[] objetosENG =
                    { "Beer", "Magic\nRamen", "Energy\nDrink", "Mana\nPotion", "Poison\nPotion", "Dead\nCat","Voodoo\nDoll", "Crystall\nBall", "Magic\nBatteries", "Magic\nRunes"};

            for (int i = 0; i < productsNames.Count; i++)
            {
                productsNames[i].text = objetosENG[i];
            }
        }
    }

    public void LanguageRegulationsText()
    {
        if (currentLanguage == Language.ES)
        {
            darkWizardsTitleText = "MAGOS OSCUROS";
            elementalsTitleText = "ELEMENTALES";
            hybridsTitleText = "HÍBRIDOS";
            limbasticsTitleText = "LIMBÁSTICOS";
            tecnoP2TitleText = "TECNÓPEDOS";
            noRegText = "No hay ninguna \nnorma nueva";
            noBuyPotionText = "Tienen prohibido comprar \ncualquier poción";
            noBuyCaffeineText = "Tienen prohibido comprar \nproductos con cafeína";
            magicItems2coinsText = "Los objetos mágicos les \ncuestan 2 monedas";
            darkmagicItems10coinsText = "Los objetos de magia negra \nles cuestan 10 monedas";
            noBuyAtTheSameTimeText = "Tienen prohibido comprar \n estos productos a la vez";
            noBuyAlcoholText = "Tienen prohibido comprar \nproductos con alcohol";
            noBuyDarkMagicText = "Tienen prohibido comprar \nproductos con magia oscura";
        }

        else if (currentLanguage == Language.EN)
        {
            darkWizardsTitleText = "DARK WIZARDS";
            elementalsTitleText = "ELEMENTALS";
            hybridsTitleText = "HYBRIDS";
            limbasticsTitleText = "LIMBASTICS";
            tecnoP2TitleText = "TECNOP2";
            noRegText = "There are no \nnew regulations";
            noBuyPotionText = "Potions are \nnot allowed to purchase";
            noBuyCaffeineText = "Caffeine products are\nnot allowed to purchase";
            magicItems2coinsText = "Magic products \nnow cost 2 coins";
            darkmagicItems10coinsText = "Dark Magic products \nnow cost 10 coins";
            noBuyAtTheSameTimeText = "Mixing these products are\n not allowed";
            noBuyAlcoholText = "Alcohol products are\nnot allowed to purchase";
            noBuyDarkMagicText = "Dark Magic products are \n not allowed to purchase";
        }

        ChangingRegulationTexts(darkWizardsTitleText, darkWizardsTitles);
        ChangingRegulationTexts(elementalsTitleText, elementalsTitles);
        ChangingRegulationTexts(hybridsTitleText, hybridsTitles);
        ChangingRegulationTexts(limbasticsTitleText, limbasticsTitles);
        ChangingRegulationTexts(tecnoP2TitleText, tecnoP2Titles);
        ChangingRegulationTexts(noRegText, noRegContainer);
        ChangingRegulationTexts(noBuyPotionText, noBuyPotionContainer);
        ChangingRegulationTexts(noBuyCaffeineText, noBuyCaffeineContainer);
        ChangingRegulationTexts(magicItems2coinsText, magicItems2coinsContainer);
        ChangingRegulationTexts(darkmagicItems10coinsText, darkmagicItems10coinsContainer);
        ChangingRegulationTexts(noBuyAtTheSameTimeText, noBuyAtTheSameTimeContainer);
        ChangingRegulationTexts(noBuyAlcoholText, noBuyAlcoholContainer);
        ChangingRegulationTexts(noBuyDarkMagicText, noBuyDarkMagicContainer);
    }

    public void FillingRegulationsTextsLists()
    {
        darkWizardsTitles.Add(reg01DWTitle);
        darkWizardsTitles.Add(reg02DWTitle);
        darkWizardsTitles.Add(reg03DWTitle);
        darkWizardsTitles.Add(reg04DWTitle);
        darkWizardsTitles.Add(reg05DWTitle);
        darkWizardsTitles.Add(reg06DWTitle);
        darkWizardsTitles.Add(reg07DWTitle);

        elementalsTitles.Add(reg01EleTitle);
        elementalsTitles.Add(reg02EleTitle);
        elementalsTitles.Add(reg03EleTitle);
        elementalsTitles.Add(reg04EleTitle);
        elementalsTitles.Add(reg05EleTitle);
        elementalsTitles.Add(reg06EleTitle);
        elementalsTitles.Add(reg07EleTitle);

        hybridsTitles.Add(reg01HybTitle);
        hybridsTitles.Add(reg02HybTitle);
        hybridsTitles.Add(reg03HybTitle);
        hybridsTitles.Add(reg04HybTitle);
        hybridsTitles.Add(reg05HybTitle);
        hybridsTitles.Add(reg06HybTitle);
        hybridsTitles.Add(reg07HybTitle);

        limbasticsTitles.Add(reg01LimTitle);
        limbasticsTitles.Add(reg02LimTitle);
        limbasticsTitles.Add(reg03LimTitle);
        limbasticsTitles.Add(reg04LimTitle);
        limbasticsTitles.Add(reg05LimTitle);
        limbasticsTitles.Add(reg06LimTitle);
        limbasticsTitles.Add(reg07LimTitle);

        tecnoP2Titles.Add(reg01TP2Title);
        tecnoP2Titles.Add(reg02TP2Title);
        tecnoP2Titles.Add(reg03TP2Title);
        tecnoP2Titles.Add(reg04TP2Title);
        tecnoP2Titles.Add(reg05TP2Title);
        tecnoP2Titles.Add(reg06TP2Title);
        tecnoP2Titles.Add(reg07TP2Title);

        noRegContainer.Add(reg01DWNoRegText);
        noRegContainer.Add(reg01EleNoRegText);
        noRegContainer.Add(reg01HybNoRegText);
        noRegContainer.Add(reg01LimNoRegText);
        noRegContainer.Add(reg01TP2NoRegText);
        noRegContainer.Add(reg02DWNoRegText);
        noRegContainer.Add(reg02HybNoRegText);
        noRegContainer.Add(reg02TP2NoRegText);
        noRegContainer.Add(reg03HybNoRegText);

        noBuyPotionContainer.Add(reg02EleReg1Text);
        noBuyPotionContainer.Add(reg03EleReg1Text);
        noBuyPotionContainer.Add(reg04EleReg1Text);
        noBuyPotionContainer.Add(reg05EleReg1Text);
        noBuyPotionContainer.Add(reg06EleReg1Text);
        noBuyPotionContainer.Add(reg07EleReg1Text);
        noBuyPotionContainer.Add(reg03TP2Reg1Text);
        noBuyPotionContainer.Add(reg04TP2Reg1Text);
        noBuyPotionContainer.Add(reg05TP2Reg1Text);
        noBuyPotionContainer.Add(reg06TP2Reg1Text);
        noBuyPotionContainer.Add(reg07TP2Reg1Text);


        noBuyCaffeineContainer.Add(reg02LimReg1Text);
        noBuyCaffeineContainer.Add(reg03LimReg1Text);
        noBuyCaffeineContainer.Add(reg04LimReg1Text);
        noBuyCaffeineContainer.Add(reg05LimReg1Text);
        noBuyCaffeineContainer.Add(reg06LimReg1Text);
        noBuyCaffeineContainer.Add(reg07LimReg1Text);


        magicItems2coinsContainer.Add(reg03DWReg1Text);
        magicItems2coinsContainer.Add(reg04DWReg1Text);
        magicItems2coinsContainer.Add(reg05DWReg1Text);
        magicItems2coinsContainer.Add(reg06DWReg1Text);
        magicItems2coinsContainer.Add(reg07DWReg1Text);


        darkmagicItems10coinsContainer.Add(reg04EleReg2Text);
        darkmagicItems10coinsContainer.Add(reg05EleReg2Text);
        darkmagicItems10coinsContainer.Add(reg06EleReg2Text);
        darkmagicItems10coinsContainer.Add(reg07EleReg2Text);


        noBuyAtTheSameTimeContainer.Add(reg04DWReg2Text);
        noBuyAtTheSameTimeContainer.Add(reg05DWReg2Text);
        noBuyAtTheSameTimeContainer.Add(reg06DWReg2Text);
        noBuyAtTheSameTimeContainer.Add(reg07DWReg2Text);
        noBuyAtTheSameTimeContainer.Add(reg06TP2Reg2Text);
        noBuyAtTheSameTimeContainer.Add(reg07TP2Reg2Text);
        noBuyAtTheSameTimeContainer.Add(reg06LimReg2Text);
        noBuyAtTheSameTimeContainer.Add(reg07LimReg2Text);
        noBuyAlcoholContainer.Add(reg04HybReg1Text);
        noBuyAlcoholContainer.Add(reg05HybReg1Text);
        noBuyAlcoholContainer.Add(reg06HybReg1Text);
        noBuyAlcoholContainer.Add(reg07HybReg1Text);


        noBuyDarkMagicContainer.Add(reg05HybReg2Text);
        noBuyDarkMagicContainer.Add(reg06HybReg2Text);
        noBuyDarkMagicContainer.Add(reg07HybReg2Text);
    }

    public void ChangingRegulationTexts(string newText, List<TextMeshProUGUI> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            lista[i].text = newText;
        }
    }
}
