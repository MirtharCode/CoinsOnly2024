using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    private Dictionary<string, DialogueEntry> dialogueLookup;

    [System.Serializable]
    public class ClientLine
    {
        public string text;
        public string tone;
        public string mood;

        public ClientLine(string text, string tone, string mood)
        {
            this.text = text;
            this.tone = tone;
            this.mood = mood;
        }
    }

    [System.Serializable]
    public class DailyClientInfo
    {
        public string clientID;
        public string name;
        public string firstKey;
        public string race;
        public List<ClientLine> dialogueLines = new List<ClientLine>();
        public List<ClientLine> tickResponse = new List<ClientLine>();
        public List<ClientLine> crossResponse = new List<ClientLine>();
        //public string tickResponse;
        //public string crossResponse;
        
        //Solo si hay que cobrarle
        public int numberOfProducts;
        public List<string> productTypes; // Type1, Type2, Type3
        public float clientMoney;
        public float toBeCharged;
        public string correctChoice; // "TICK" o "CROSS"

        public DailyClientInfo(string clientID, string name, string firstKey, string race)
        {
            this.clientID = clientID;
            this.name = name;
            this.firstKey = firstKey;
            this.race = race;
        }
    }

    public List<string> GetAllKeys()
    {
        return new List<string>(dialogueLookup.Keys);
    }

    public bool IsReady { get; private set; } = false;

    public GameObject clientPrefab;
    public List<DailyClientInfo> dailyCustomers = new List<DailyClientInfo>();
    [SerializeField] public bool conversationOn;
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public TMP_Text traductorText;
    [SerializeField] public TMP_Text NombreText;

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

    [Header("NORMATIVAS")]
    public string[] razasNormas;
    int razaSeleccionada;
    [SerializeField] public TextMeshProUGUI textoRaza;
    [SerializeField] public GameObject panelMagos;
    [SerializeField] public GameObject panelHibridos;
    [SerializeField] public GameObject panelElementales;
    [SerializeField] public GameObject panelLimbasticos;
    [SerializeField] public GameObject panelTecnopedos;
    [SerializeField] public GameObject normativasButton;

    [Header("ITS ALL ABOUT THE MONEY MONEY MONEY")]
    [SerializeField] public GameObject leDinero;
    [SerializeField] public TMP_Text leDineroText;
    [SerializeField] public GameObject leCajaRegistradora;
    [SerializeField] public GameObject buttonCobrar;
    [SerializeField] public GameObject buttonNoCobrar;
    [SerializeField] public GameObject centralProduct;
    [SerializeField] public GameObject rightProduct;
    [SerializeField] public GameObject leftProduct;

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

    #region CÓDIGO ANTIGUO REFERENTE A LOS DESPLEGABLES DE NORMATIVAS Y PRECIOS QUE CAMBIARÁN
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
    #endregion

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
                tempClients[clientID] = new DailyClientInfo(clientID, name, key, race);
                dailyCustomers.Add(tempClients[clientID]);
            }

            DailyClientInfo client = tempClients[clientID];

            if (type == "tick")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                client.tickResponse.Add(new ClientLine(text, tone, mood));
            }
           
            else if (type == "cross")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                client.crossResponse.Add(new ClientLine(text, tone, mood));
            }

            else if (type == "init" || type.StartsWith("dialogue") || type == "end" || type == "brake")
            {
                string text = GetText(key);
                string tone = GetTone(key);
                string mood = GetMood(key);
                client.dialogueLines.Add(new ClientLine(text, tone, mood));

                // Si llegó al final, no hace falta seguir registrando más líneas
                if (type == "end" || type == "brake")
                    continue;
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
                .Find(entry => entry.CLIENT.Equals(client.name, StringComparison.OrdinalIgnoreCase));

            if (matchingProduct == null)
            {
                Debug.LogWarning($"No se encontró entrada de producto para cliente: {client.name}");
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
        }
    }

    #region GET DATA OF THE CLIENT
    private int GetClientIndex(string clientID)
    {
        switch (clientID)
        {
            case "clientZERO": return 0;
            case "clientONE": return 1;
            case "clientTWO": return 2;
            case "clientTHREE": return 3;
            case "clientFOUR": return 4;
            case "clientFIVE": return 5;
            case "clientSIX": return 6;
            case "clientSEVEN": return 7;
            case "clientEIGHT": return 8;
            case "clientNINE": return 9;
            case "clientTEN": return 10;
            case "clientELEVEN": return 11;
            case "clientTWELVE": return 12;
            case "clientTHIRTEEN": return 13;
            case "clientFOURTEEN": return 14;
            case "clientFIFTEEN": return 15;
            default: return 999; // fallback genérico, clientFINAL usa int.MaxValue arriba
        }
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

    public string GetClientNumber(string key)
    {
        if (dialogueLookup.ContainsKey(key))
            return dialogueLookup[key].CLIENT;
        return $"[{key}]";
    }

    #endregion

    public void ShowText()
    {
        conversationOn = true;
        dialoguePanel.gameObject.SetActive(true);

        //// Si no es ninguna de las situaciones especiales
        //if (!(currentCustomer.name.Contains("Cululu") && currentScene.name == "Day5") && !(currentCustomer.name.Contains("Raven") && currentScene.name == "Day5")
        //    && !(currentCustomer.name.Contains("Sergio") && currentScene.name == "Day4") && !(currentCustomer.name.Contains("Geraaaard") && currentScene.name == "Day4")
        //    && !(currentCustomer.name.Contains("Mara") && currentScene.name == "Day4") && !(currentCustomer.name.Contains("Handy") && currentScene.name == "Day4"))
        //{

        //    if (((currentCustomer.name.Contains("Jefe") || currentCustomer.name.Contains("Jefazo")) && internalCount < dialogueSize)
        //       || (currentCustomer.name.Contains("Detective") && internalCount < dialogueSize - 1)
        //       || (currentCustomer.name.Contains("Mano") && internalCount < dialogueSize && currentScene.name == "Day4")        // Es necesario que esté
        //       || (currentCustomer.name.Contains("Sapopotamo") && internalCount < dialogueSize && currentScene.name == "Day5")  // Es necesario que esté
        //       || (internalCount < dialogueSize - 2 && !currentCustomer.name.Contains("Jefe") && !currentCustomer.name.Contains("Jefazo"))
        //       || (currentCustomer.name.Contains("Denji") && internalCount < dialogueSize && (currentScene.name == "Day2_1" || currentScene.name == "Day2_2"
        //       || currentScene.name == "Day3_1" || currentScene.name == "Day3_2")
        //       || currentCustomer.name.Contains("Enano") && internalCount < dialogueSize && currentScene.name == "Day2_1")
        //       || currentCustomer.name.Contains("Petra") && internalCount < dialogueSize && currentScene.name == "Day5"
        //       || currentCustomer.name.Contains("Antonio") && internalCount < dialogueSize && currentScene.name == "Day5"
        //       || currentCustomer.name.Contains("Geraaaard") && internalCount < dialogueSize && currentScene.name == "Day4" && Data.instance.noCobrarSergioCobrarGeeraardD4 == 0)
        //    {
        //        dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
        //        gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        //        currentCustomer.GetComponent<Client>().Speaking();
        //        internalCount++;

        //        //if (internalCount == currentCustomer.GetComponent<Client>().dialogue.Count)
        //        //    currentCustomer.GetComponent<Client>().ByeBye();
        //        //StartCoroutine(currentCustomer.GetComponent<Client>().ShowLine());
        //    }

        //    else
        //        HideText();
        //}

        //else if (currentCustomer.name.Contains("Cululu") && internalCount < dialogueSize - 3 && currentScene.name == "Day5")
        //{
        //    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
        //    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        //    currentCustomer.GetComponent<Client>().Speaking();
        //    internalCount++;
        //}

        //else if (currentCustomer.name.Contains("Raven") && internalCount < dialogueSize - 3 && currentScene.name == "Day5")
        //{
        //    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
        //    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        //    currentCustomer.GetComponent<Client>().Speaking();
        //    internalCount++;
        //}

        //else if (currentCustomer.name.Contains("Sergio") && internalCount < dialogueSize - 3 && currentScene.name == "Day4")
        //{
        //    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
        //    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        //    currentCustomer.GetComponent<Client>().Speaking();
        //    internalCount++;
        //}

        //else if (currentCustomer.name.Contains("Geraaaard") && internalCount < dialogueSize - 3 && currentScene.name == "Day4" && Data.instance.noCobrarSergioCobrarGeeraardD4 != 0)
        //{
        //    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
        //    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        //    currentCustomer.GetComponent<Client>().Speaking();
        //    internalCount++;
        //}

        //else if (currentCustomer.name.Contains("Geraaaard") && currentScene.name == "Day4" && Data.instance.noCobrarSergioCobrarGeeraardD4 == 0 && !(internalCount == dialogueSize))
        //{
        //    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
        //    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        //    currentCustomer.GetComponent<Client>().Speaking();
        //    internalCount++;
        //}

        //else if (currentCustomer.name.Contains("Mara") && currentScene.name == "Day4" && internalCount < dialogueSize - 3)
        //{
        //    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
        //    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        //    currentCustomer.GetComponent<Client>().Speaking();
        //    internalCount++;
        //}

        //else if (currentCustomer.name.Contains("Handy") && currentScene.name == "Day4" && internalCount < dialogueSize - 3)
        //{
        //    dialogueText.text = currentCustomer.GetComponent<Client>().dialogue[internalCount];
        //    gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
        //    currentCustomer.GetComponent<Client>().Speaking();
        //    internalCount++;
        //}

        //else
        //    HideText();
    }

    public void HideText()
    {
        //gameManager.GetComponent<GameManager>().FindTheCustomer();
        conversationOn = false;
        dialoguePanel.gameObject.SetActive(false);
        dropDownPanelPrecios.gameObject.SetActive(true);
        dropDownPanelNormativas.gameObject.SetActive(true);

        //if (currentScene.name == "Day1")
        //    preciosButton.gameObject.GetComponent<Animator>().SetBool("BigButton", true);

        //if (currentScene.name == "Day2_1")
        //    normativasButton.gameObject.GetComponent<Animator>().SetBool("BigButton", true);

        //if (internalCount == dialogueSize && (currentCustomer.name.Contains("Jefe") || currentCustomer.name.Contains("Jefazo")))
        //{
        //    estaToPagao = true;
        //    currentCustomer.GetComponent<Client>().ByeBye();
        //    gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        //}

        //else if (currentCustomer.name.Contains("Detective") && !estaToPagao)
        //{
        //    dropDownPanelNormativas.SetActive(false);
        //    dropDownPanelPrecios.SetActive(false);
        //    dialoguePanel.SetActive(false);
        //    panelSospechoso.SetActive(true);
        //}

        //else if (SospechosoTerminado)
        //{
        //    currentCustomer.GetComponent<DetectiveHijo>().ShowProductsAndMoney();
        //}

        //else if (internalCount == dialogueSize &&
        //    ((currentCustomer.name.Contains("Mano") && currentScene.name == "Day4")
        //    || (currentCustomer.name.Contains("Sapopotamo") && currentScene.name == "Day5")
        //    || (currentCustomer.name.Contains("Denji") && currentScene.name == "Day2_1")
        //    || (currentCustomer.name.Contains("Denji") && currentScene.name == "Day2_2")
        //    || (currentCustomer.name.Contains("Denji") && currentScene.name == "Day3_1")
        //    || (currentCustomer.name.Contains("Denji") && currentScene.name == "Day3_2")
        //    || (currentCustomer.name.Contains("Enano") && currentScene.name == "Day2_1")
        //    || (currentCustomer.name.Contains("Petra") && currentScene.name == "Day5")
        //    || (currentCustomer.name.Contains("Antonio") && currentScene.name == "Day5")
        //    || (currentCustomer.name.Contains("Geraaaard") && currentScene.name == "Day4" && Data.instance.noCobrarSergioCobrarGeeraardD4 == 0)))
        //{
        //    mostrarJefe = false;
        //    estaToPagao = true;
        //    currentCustomer.GetComponent<Client>().ByeBye();
        //    gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);

        //    if (currentCustomer.name.Contains("Enano") && currentScene.name == "Day2_1")
        //    {
        //        gnomo.GetComponent<Gnomo>().ShowUpGnomoAnim();
        //    }
        //}

        //else if (!estaToPagao)
        //{
        //    leDinero.gameObject.SetActive(true);
        //    buttonCobrar.SetActive(true);
        //    buttonNoCobrar.SetActive(true);
        //    botonDesplegadoPrecios.SetActive(true);
        //    botonDesplegadoNormativas.SetActive(true);

        //    if (currentScene.name == "Day1")
        //    {
        //        if (currentCustomer.name.Contains("Geraaaard"))
        //            currentCustomer.GetComponent<MO_Geeraard>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Sapopotamo"))
        //            currentCustomer.GetComponent<H_Elvog>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Antonio"))
        //            currentCustomer.GetComponent<L_Antonio>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Tapiz"))
        //            currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Denjirenji"))
        //            currentCustomer.GetComponent<T_Denjirenji>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Mara"))
        //            currentCustomer.GetComponent<H_Mara>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Giovanni"))
        //            currentCustomer.GetComponent<L_Giovanni>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Rockon"))
        //            currentCustomer.GetComponent<E_Rockon>().ShowProductsAndMoney();
        //    }

        //    else if (currentScene.name == "Day2_1")
        //    {
        //        if (currentCustomer.name.Contains("Lepion"))
        //            currentCustomer.GetComponent<H_Lepion>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Giovanni"))
        //            currentCustomer.GetComponent<L_Giovanni>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Cululu"))
        //            currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Handy"))
        //        //    currentCustomer.GetComponent<E_Handy>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Petra"))
        //        //    currentCustomer.GetComponent<H_Petra>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Tapiz"))
        //        //    currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Masermati"))
        //        //    currentCustomer.GetComponent<T_Masermati>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Pijus"))
        //        //    currentCustomer.GetComponent<MO_PijusMagnus>().ShowProductsAndMoney();
        //    }

        //    else if (currentScene.name == "Day2_2")
        //    {
        //        if (currentCustomer.name.Contains("Handy"))
        //            currentCustomer.GetComponent<E_Handy>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Petra"))
        //            currentCustomer.GetComponent<H_Petra>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Tapiz"))
        //            currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Masermati"))
        //            currentCustomer.GetComponent<T_Masermati>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Pijus"))
        //            currentCustomer.GetComponent<MO_PijusMagnus>().ShowProductsAndMoney();

        //    }

        //    else if (currentScene.name == "Day3_1")
        //    {
        //        if (currentCustomer.name.Contains("Sergio"))
        //            currentCustomer.GetComponent<L_Sergio>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Saltaralisis"))
        //            currentCustomer.GetComponent<H_Saltaralisis>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Mano"))
        //            currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Raven"))
        //            currentCustomer.GetComponent<T_Raven>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Hueso"))
        //            currentCustomer.GetComponent<E_ElementalHueso>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Patxi"))
        //            currentCustomer.GetComponent<L_Patxi>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Sapopotamo"))
        //            currentCustomer.GetComponent<H_Elvog>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Enano"))
        //            currentCustomer.GetComponent<MO_ManoloCabezaPico>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Rustica"))
        //        //    currentCustomer.GetComponent<T_Rustica>().ShowProductsAndMoney();
        //    }

        //    else if (currentScene.name == "Day3_2")
        //    {
        //        //if (currentCustomer.name.Contains("Sergio"))
        //        //    currentCustomer.GetComponent<L_Sergio>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Saltaralisis"))
        //        //    currentCustomer.GetComponent<H_Saltaralisis>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Mano"))
        //        //    currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Raven"))
        //        //    currentCustomer.GetComponent<T_Raven>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Hueso"))
        //        //    currentCustomer.GetComponent<E_ElementalHueso>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Patxi"))
        //        //    currentCustomer.GetComponent<L_Patxi>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Sapopotamo"))
        //        //    currentCustomer.GetComponent<H_Elvog>().ShowProductsAndMoney();

        //        //else if (currentCustomer.name.Contains("Enano"))
        //        //    currentCustomer.GetComponent<MO_ManoloCabezaPico>().ShowProductsAndMoney();

        //        if (currentCustomer.name.Contains("Rustica"))
        //            currentCustomer.GetComponent<T_Rustica>().ShowProductsAndMoney();
        //    }

        //    else if (currentScene.name == "Day4")
        //    {
        //        if (currentCustomer.name.Contains("Jissy"))
        //            currentCustomer.GetComponent<E_Jissy>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Mara"))
        //            currentCustomer.GetComponent<H_Mara>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Cululu"))
        //            currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Sergio"))
        //            currentCustomer.GetComponent<L_Sergio>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Elidora"))
        //            currentCustomer.GetComponent<MO_Elidora>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Geraaaard"))
        //            currentCustomer.GetComponent<MO_Geeraard>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Magma"))
        //            currentCustomer.GetComponent<T_MagmaDora>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Handy"))
        //            currentCustomer.GetComponent<E_Handy>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Antonio"))
        //            currentCustomer.GetComponent<L_Antonio>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Mano"))
        //            currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();
        //    }

        //    else if (currentScene.name == "Day5")
        //    {
        //        if (currentCustomer.name.Contains("Elidora"))
        //            currentCustomer.GetComponent<MO_Elidora>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Rockon"))
        //            currentCustomer.GetComponent<E_Rockon>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Petra"))
        //            currentCustomer.GetComponent<H_Petra>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Cululu"))
        //            currentCustomer.GetComponent<L_Cululu>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Masermati"))
        //            currentCustomer.GetComponent<T_Masermati>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Mano"))
        //            currentCustomer.GetComponent<MO_ManoloMano>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Saltaralisis"))
        //            currentCustomer.GetComponent<H_Saltaralisis>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Raven"))
        //            currentCustomer.GetComponent<T_Raven>().ShowProductsAndMoney();

        //        else if (currentCustomer.name.Contains("Tapiz"))
        //            currentCustomer.GetComponent<E_Tapicio>().ShowProductsAndMoney();
        //    }

        //    internalCount++;
        //}

        //else
        //{
        //    currentCustomer.GetComponent<Client>().ByeBye();
        //    gameManager.GetComponent<GameManager>().audioSource.PlayOneShot(gameManager.GetComponent<GameManager>().TrampillaSalida);
        //}
    }
}
