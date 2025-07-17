using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

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
        public string gift;

        public ClientLine(string text, string tone, string mood, string type, string gift)
        {
            this.text = text;
            this.type = type;
            this.tone = tone;
            this.mood = mood;
            this.gift = gift;
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
    [SerializeField] public GameObject dialoguePanelOther;
    [SerializeField] public GameObject detectivePanel;
    [SerializeField] public GameObject bAndWShader;
    [SerializeField] public GameObject areYouSurePanel;
    [SerializeField] public TMP_Text traductorText;
    [SerializeField] public TMP_Text NombreText;

    [SerializeField] public GameObject uITrophies;
    [SerializeField] public GameObject gnomeMinigameCanvas;
    [SerializeField] public bool theGnomeIsFree;

    [Header("RELATED TO THE DROPDOWN MENU WITH THE LIST OF ITEMS")]

    [SerializeField] public ProductsType allProducts;

    [Header("NORMATIVAS")]

    public bool regulationsAdded;
    public int currentRegulationsNumber;
    public List<string> currentRegulations;

    [SerializeField]
    public List<RegulationInfo> regulationsData = new List<RegulationInfo>();

    public string[] razasNormas;
    public int razaSeleccionada;
    [SerializeField] public TextMeshProUGUI textoRaza;
    [SerializeField] public GameObject panelMagos;
    [SerializeField] public GameObject panelHibridos;
    [SerializeField] public GameObject panelElementales;
    [SerializeField] public GameObject panelLimbasticos;
    [SerializeField] public GameObject panelTecnopedos;

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
    [SerializeField] public GameObject couponPlace;
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
            lastSceneWithDialogues = "";
        }

        else
        {
            Debug.Log("Acabo de empezar el juego");
            LaVoluntad(50);
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

        #region PARTE DEL DESPLEGABLE DE LAS NORMATIVAS QUE SE CAMBIARÁ
        razasNormas = new string[5];
        razasNormas[0] = "Magos Oscuros";
        razasNormas[1] = "Híbridos";
        razasNormas[2] = "Tecno P2";
        razasNormas[3] = "Limbásticos";
        razasNormas[4] = "Elementales";

        razaSeleccionada = 0;
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
                string gift = GetGift(key);
                client.tickResponse.Add(new ClientLine(text, tone, mood, type, gift));
            }

            else if (type == "cross")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string gift = GetGift(key);
                client.crossResponse.Add(new ClientLine(text, tone, mood, type, gift));
            }

            else if (type == "mgOUTGood")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string gift = GetGift(key);
                client.mgGoodResponse.Add(new ClientLine(text, tone, mood, type, gift));
            }

            else if (type == "mgOUTBad")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string gift = GetGift(key);
                client.mgBadResponse.Add(new ClientLine(text, tone, mood, type, gift));
            }

            else if (type == "init" || type.StartsWith("dialogue") || type == "end" || type == "break" || type == "mgIN" || type == "gnome")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                string gift = GetGift(key);
                client.dialogueLines.Add(new ClientLine(text, tone, mood, type, gift));

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

    public string GetGift(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].GIFT;
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
        if (currentDay == "01")
            dialoguePanelFirst.gameObject.SetActive(false);

        else
            dialoguePanelOther.gameObject.SetActive(false);
    }

    public void SetSceneReferences(GameObject mC, GameObject cM, GameObject phoneObj, GameObject complainObj, GameObject dPanelFirst, GameObject dPanelOther, GameObject sospechosoPanel, GameObject seguroPanel, GameObject bAndWPanel, GameObject gnomeCanvas,
                                   GameObject trophyCanvas, GameObject regMagosOscurosPanel, GameObject regHibridosPanel, GameObject regElementalesPanel, GameObject regLimbasticosPanel, GameObject regTecnopedosPanel,
                                   GameObject moneySack, TMP_Text moneySackText, GameObject moneySackSymbol, GameObject cachinkThing, GameObject chargeButton, GameObject byeButton,
                                   GameObject cenProd, GameObject derProd, GameObject izqProd, GameObject cupPlace, GameObject tipJar, TMP_Text tipJarText)
    {
        mainCam = mC;
        clientManager = cM;
        phone = phoneObj;
        jefePanel = complainObj;
        dialoguePanelFirst = dPanelFirst;
        dialoguePanelOther = dPanelOther;
        detectivePanel = sospechosoPanel;
        areYouSurePanel = seguroPanel;
        areYouSurePanel = seguroPanel;
        bAndWShader = bAndWPanel;

        gnomeMinigameCanvas = gnomeCanvas;
        uITrophies = trophyCanvas;

        panelMagos = regMagosOscurosPanel;
        panelHibridos = regHibridosPanel;
        panelElementales = regElementalesPanel;
        panelLimbasticos = regLimbasticosPanel;
        panelTecnopedos = regTecnopedosPanel;

        leDinero = moneySack;
        leDineroText = moneySackText;
        leDineroSymbol = moneySackSymbol;
        leCajaRegistradora = cachinkThing;
        buttonCobrar = chargeButton;
        buttonNoCobrar = byeButton;
        centralProduct = cenProd;
        rightProduct = derProd;
        leftProduct = izqProd;
        couponPlace = cupPlace;
        lesPropinas = tipJar;
        lePropinasText = tipJarText;



        if (jefePanel != null)
            textoJefe = jefePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void LaVoluntad(float cantidad)
    {
        propinasNumber += cantidad;

        // Limita el valor entre 0 y 100
        propinasNumber = Mathf.Clamp(DialogueManager.Instance.propinasNumber, 0, 100);

        // Redondea al múltiplo de 10 inferior
        int nivel = ((int)propinasNumber / 10) * 10;

        // ESTO HAY QUE USARLO CUANDO VÍCTOR HAGA LOS MODELOS DE LAS PROPINAS
        // lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{nivel}");

        // Actualiza el texto
        lePropinasText.text = DialogueManager.Instance.propinasNumber.ToString();
    }
}
