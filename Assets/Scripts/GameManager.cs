using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("CHARACTER SIZES")]
    [SerializeField] public bool toyChiquito;
    [SerializeField] public GameObject stopPetit;
    [SerializeField] public bool toyGrandote;
    [SerializeField] public GameObject stopGrangran;

    [Header("CHARACTERS THAT CAN APPEAR")]
    [SerializeField] public GameObject currentCustomer;
    [SerializeField] public int customerNumber = 0;
    [SerializeField] public List<GameObject> dailyCustomers;
    [SerializeField] public GameObject evilWizardGerard;
    [SerializeField] public GameObject hybridElvog;
    [SerializeField] public GameObject limbasticAntonio;
    [SerializeField] public GameObject elementalTapicio;
    [SerializeField] public GameObject electropedDenjirenji;
    [SerializeField] public GameObject hybridMara;
    [SerializeField] public GameObject limbasticGiovanni;

    [Header("RELATED TO THE DROPDOWN MENU WITH THE LIST OF ITEMS")]
    [SerializeField] public bool listOpen;
    [SerializeField] public GameObject dropDownPanel;
    [SerializeField] public TMP_Text dropDownButtonText;
    [SerializeField] public GameObject position1;
    [SerializeField] public GameObject position2;

    [Header("ITS ALL ABOUT THE MONEY MONEY MONEY")]
    [SerializeField] public GameObject leDinero;
    [SerializeField] public GameObject leCajaRegistradora;
    [SerializeField] public GameObject lesPropinas;
    [SerializeField] public TMP_Text leDineroText;
    [SerializeField] public TMP_Text lePropinasText;
    [SerializeField] public float propinasNumber = 0;
    [SerializeField] public bool estaToPagao = false;

    [Header("PRODUCTS PLACES")]
    [SerializeField] public Transform oneProduct;
    [SerializeField] public Transform twoProducts1;
    [SerializeField] public Transform twoProducts2;

    [Header("PRODUCTS LIST")]
    [SerializeField] public GameObject energeticDrink;
    [SerializeField] public GameObject beer;
    [SerializeField] public GameObject deadCat;
    [SerializeField] public GameObject voodooDoll;
    [SerializeField] public GameObject manaPotion;
    [SerializeField] public GameObject magicBattery;
    [SerializeField] public GameObject magicRamen;
    [SerializeField] public GameObject magicRune;
    [SerializeField] public GameObject venomPotion;

    [Header("CHARACTERS ENTRY/EXIT")]
    [SerializeField] public Transform showUpPoint;
    [SerializeField] public Transform exitPoint;

    [Header("DIALOGUE")]
    [SerializeField] public bool conversationOn;
    [SerializeField] public bool optionsSet;
    [SerializeField] public TMP_Text dialogueText;
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public int internalCount = 0;

    #region Código Antiguo
    //[SerializeField] public bool luffyOn, doraOn, terryOn, franceOn, duolingOn;
    //[SerializeField] public GameObject[] products, boughtProducts, soldPlaces;
    //[SerializeField] public TMP_Text initialConversationText;
    //[SerializeField] public char[] chars;
    //[SerializeField] public string[] words;
    //[SerializeField] public int[] wordsDuration;
    //[SerializeField] public AudioSource conversationSound;
    //[SerializeField] public AudioClip[] marianoSounds;
    #endregion

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        estaToPagao = false;
        if (currentScene.name == "Day1")
            Day1();
    }

    void Update()
    {
    }

    public void OpenList()
    {
        if (listOpen)
        {
            dropDownPanel.transform.position = position2.transform.position;
            dropDownButtonText.text = "<";
            listOpen = false;
        }
        else
        {
            dropDownPanel.transform.position = position1.transform.position;
            dropDownButtonText.text = ">";
            listOpen = true;
        }

    }

    public void CharacterShowUp(GameObject character)
    {
        GameObject clon = Instantiate(character, showUpPoint);
    }

    public void Day1()
    {
        LaVoluntad(50);

        dailyCustomers.Clear();
        dailyCustomers.Add(evilWizardGerard);
        dailyCustomers.Add(hybridElvog);
        dailyCustomers.Add(limbasticAntonio);
        dailyCustomers.Add(elementalTapicio);
        dailyCustomers.Add(electropedDenjirenji);

        CharacterShowUp(dailyCustomers[customerNumber]);
    }

    public void ShowText()
    {
        currentCustomer = GameObject.FindGameObjectWithTag("CurrentCustomer");

        if (currentCustomer.name.Contains("Geraaaard"))
            DialogueTexts(currentCustomer.GetComponent<GeeraardElMagoDeArmas>().dialogue.Count, currentCustomer.GetComponent<GeeraardElMagoDeArmas>().dialogue);

        else if (currentCustomer.name.Contains("Sapopotamo"))
            DialogueTexts(currentCustomer.GetComponent<ElvogElSapopotamo>().dialogue.Count, currentCustomer.GetComponent<ElvogElSapopotamo>().dialogue);

        else if (currentCustomer.name.Contains("Antonio"))
            DialogueTexts(currentCustomer.GetComponent<AntonioElProgramador>().dialogue.Count, currentCustomer.GetComponent<AntonioElProgramador>().dialogue);

        else if (currentCustomer.name.Contains("Tapiz"))
            DialogueTexts(currentCustomer.GetComponent<TapicioElEmo>().dialogue.Count, currentCustomer.GetComponent<TapicioElEmo>().dialogue);

        else if (currentCustomer.name.Contains("Denjirenji"))
            DialogueTexts(currentCustomer.GetComponent<DenjirenjiElSamurai>().dialogue.Count, currentCustomer.GetComponent<DenjirenjiElSamurai>().dialogue);

        else if (currentCustomer.name.Contains("Mara"))
            DialogueTexts(currentCustomer.GetComponent<MaraLaManguro>().dialogue.Count, currentCustomer.GetComponent<MaraLaManguro>().dialogue);

        else if (currentCustomer.name.Contains("Giovanni"))
            DialogueTexts(currentCustomer.GetComponent<GiovanniElCocinero>().dialogue.Count, currentCustomer.GetComponent<GiovanniElCocinero>().dialogue);

    }

    public void DialogueTexts(int dialogueExtension, List<string> dialogueList)
    {
        if (internalCount < dialogueExtension - 2)
        {
            conversationOn = true;
            dialoguePanel.gameObject.SetActive(true);

            dialogueText.text = dialogueList[internalCount];
            internalCount++;
        }

        else
        {
            conversationOn = false;
            HideText();
        }
    }

    public void HideText()
    {
        currentCustomer = GameObject.FindGameObjectWithTag("CurrentCustomer");

        conversationOn = false;
        dialoguePanel.gameObject.SetActive(false);

        if (!estaToPagao)
        {
            leDinero.gameObject.SetActive(true);
            leDinero.gameObject.GetComponent<Button>().enabled = true;
            leCajaRegistradora.gameObject.GetComponent<Button>().enabled = true;

            if (currentCustomer.name.Contains("Geraaaard"))
            {
                currentCustomer.GetComponent<GeeraardElMagoDeArmas>().ShowProductsAndMoney();
                internalCount++;
            }

            else if (currentCustomer.name.Contains("Sapopotamo"))
            {
                currentCustomer.GetComponent<ElvogElSapopotamo>().ShowProductsAndMoney();
                internalCount++;
            }

            else if (currentCustomer.name.Contains("Antonio"))
            {
                currentCustomer.GetComponent<AntonioElProgramador>().ShowProductsAndMoney();
                internalCount++;
            }

            else if (currentCustomer.name.Contains("Tapiz"))
            {
                currentCustomer.GetComponent<TapicioElEmo>().ShowProductsAndMoney();
                internalCount++;
            }

            else if (currentCustomer.name.Contains("Denjirenji"))
            {
                currentCustomer.GetComponent<DenjirenjiElSamurai>().ShowProductsAndMoney();
                internalCount++;
            }

            else if (currentCustomer.name.Contains("Mara"))
            {
                currentCustomer.GetComponent<MaraLaManguro>().ShowProductsAndMoney();
                internalCount++;
            }

            else if (currentCustomer.name.Contains("Giovanni"))
            {
                currentCustomer.GetComponent<GiovanniElCocinero>().ShowProductsAndMoney();
                internalCount++;
            }

        }

        else
        {
            if (currentCustomer.name.Contains("Geraaaard"))
            {
                stopGrangran.gameObject.SetActive(false); // El cliente se pira.
                currentCustomer.GetComponent<GeeraardElMagoDeArmas>().ByeBye();
            }

            else if (currentCustomer.name.Contains("Sapopotamo"))
            {
                stopGrangran.gameObject.SetActive(false); // El cliente se pira.
                currentCustomer.GetComponent<ElvogElSapopotamo>().ByeBye();
            }

            else if (currentCustomer.name.Contains("Antonio"))
            {
                stopGrangran.gameObject.SetActive(false); // El cliente se pira.
                currentCustomer.GetComponent<AntonioElProgramador>().ByeBye();
            }

            else if (currentCustomer.name.Contains("Tapiz"))
            {
                stopGrangran.gameObject.SetActive(false); // El cliente se pira.
                currentCustomer.GetComponent<TapicioElEmo>().ByeBye();
            }

            else if (currentCustomer.name.Contains("Denjirenji"))
            {
                stopGrangran.gameObject.SetActive(false); // El cliente se pira.
                currentCustomer.GetComponent<DenjirenjiElSamurai>().ByeBye();
            }

            else if (currentCustomer.name.Contains("Mara"))
            {
                stopGrangran.gameObject.SetActive(false); // El cliente se pira.
                currentCustomer.GetComponent<MaraLaManguro>().ByeBye();
            }

            else if (currentCustomer.name.Contains("Giovanni"))
            {
                stopGrangran.gameObject.SetActive(false); // El cliente se pira.
                currentCustomer.GetComponent<GiovanniElCocinero>().ByeBye();
            }
        }

    }

    public void CollectMoney()
    {
        currentCustomer = GameObject.FindGameObjectWithTag("CurrentCustomer");

        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);

        if (currentCustomer.name.Contains("Geraaaard"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<GeeraardElMagoDeArmas>().dialogue[currentCustomer.GetComponent<GeeraardElMagoDeArmas>().dialogue.Count - 2];
            LaVoluntad(10);
        }

        else if (currentCustomer.name.Contains("Sapopotamo"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<ElvogElSapopotamo>().dialogue[currentCustomer.GetComponent<ElvogElSapopotamo>().dialogue.Count - 2];
            LaVoluntad(10);
        }

        else if (currentCustomer.name.Contains("Antonio"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<AntonioElProgramador>().dialogue[currentCustomer.GetComponent<AntonioElProgramador>().dialogue.Count - 2];
            LaVoluntad(-10);
        }

        else if (currentCustomer.name.Contains("Tapiz"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<TapicioElEmo>().dialogue[currentCustomer.GetComponent<TapicioElEmo>().dialogue.Count - 2];
            LaVoluntad(10);
        }

        else if (currentCustomer.name.Contains("Denjirenji"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<DenjirenjiElSamurai>().dialogue[currentCustomer.GetComponent<DenjirenjiElSamurai>().dialogue.Count - 2];
            LaVoluntad(-10);
        }

        else if (currentCustomer.name.Contains("Mara"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<MaraLaManguro>().dialogue[currentCustomer.GetComponent<MaraLaManguro>().dialogue.Count - 2];
            LaVoluntad(10);
        }

        else if (currentCustomer.name.Contains("Giovanni"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<GiovanniElCocinero>().dialogue[currentCustomer.GetComponent<GiovanniElCocinero>().dialogue.Count - 2];
            LaVoluntad(10);
        }

    }

    public void IDontBelieveIt()
    {
        currentCustomer = GameObject.FindGameObjectWithTag("CurrentCustomer");

        conversationOn = true;
        estaToPagao = true;
        dialoguePanel.gameObject.SetActive(true);
        leDinero.gameObject.SetActive(false);

        if (currentCustomer.name.Contains("Geraaaard"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<GeeraardElMagoDeArmas>().dialogue[currentCustomer.GetComponent<GeeraardElMagoDeArmas>().dialogue.Count - 1];
            LaVoluntad(-10);
        }

        else if (currentCustomer.name.Contains("Sapopotamo"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<ElvogElSapopotamo>().dialogue[currentCustomer.GetComponent<ElvogElSapopotamo>().dialogue.Count - 1];
            LaVoluntad(-10);
        }

        else if (currentCustomer.name.Contains("Antonio"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<AntonioElProgramador>().dialogue[currentCustomer.GetComponent<AntonioElProgramador>().dialogue.Count - 1];
            LaVoluntad(10);
        }

        else if (currentCustomer.name.Contains("Tapiz"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<TapicioElEmo>().dialogue[currentCustomer.GetComponent<TapicioElEmo>().dialogue.Count - 1];
            LaVoluntad(-10);
        }

        else if (currentCustomer.name.Contains("Denjirenji"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<DenjirenjiElSamurai>().dialogue[currentCustomer.GetComponent<DenjirenjiElSamurai>().dialogue.Count - 1];
            LaVoluntad(10);
        }

        else if (currentCustomer.name.Contains("Mara"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<MaraLaManguro>().dialogue[currentCustomer.GetComponent<MaraLaManguro>().dialogue.Count - 1];
            LaVoluntad(-10);
        }

        else if (currentCustomer.name.Contains("Giovanni"))
        {
            dialogueText.text =
                currentCustomer.GetComponent<GiovanniElCocinero>().dialogue[currentCustomer.GetComponent<GiovanniElCocinero>().dialogue.Count - 1];
            LaVoluntad(-10);
        }
    }

    public void LaVoluntad(float cantidad)
    {
        propinasNumber += cantidad;
        lesPropinas.GetComponent<Image>().fillAmount = (propinasNumber) / 100;
        lePropinasText.text = "" + propinasNumber;
    }

    #region Código Antiguo
    //void firstEntrance(int random)
    //{
    //    if (random == 1)
    //    {
    //        luffyOn = true;
    //        luffy.SetActive(true);
    //        initialConversationText.text = "Hola, vengo a comprar el One Piece, pero como no se que es, espero que tú sepas separ lo que sepo no saber, porque sabiendo lo\n" +
    //            " que es el ser, será mucho más para ti con tu beneficio, bueno, vamos a la mandanga, que es very difficult todo esto, sabes...\n" +
    //            " ¡¡Algún día seré el rey de las patatas!!";


    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }

    //    }
    //    else if (random == 2)
    //    {
    //        doraOn = true;
    //        dora.SetActive(true);
    //        initialConversationText.text = "Hola, hola! Soy Dora la Explotadora Hi, hi! I`m Dora and you are my bitch! ¿Donde hay bananas? \n" +
    //            " Dime donde hay bananas sucio e indigno ser WHERE ARE THE BANANAS? También si tienes ideas para juegos me las debes dar\n" +
    //            " ¡Me encanta el talento de los jóvenes! I love easy money!!";

    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }
    //    }
    //    else if (random == 3)
    //    {
    //        terryOn = true;
    //        terry.SetActive(true);
    //        initialConversationText.text = "Making my way downtown, Walking fast, faces pass and I'm homebound,\n" +
    //            " Staring blankly ahead, Just making my way, Making a way through the crowd. \n" +
    //            "And I need you (chururu churururú) And I miss you (chururu churururú) And now I wonder...\n";

    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }
    //    }
    //    else if (random == 4)
    //    {
    //        franceOn = true;
    //        france.SetActive(true);
    //        initialConversationText.text = "Hola queguido comegciante, me podgría cobgag estos gagos gábanos silvegtges y estas vegdugas de tempogada\n" +
    //            " Me lamo Gigobegto Gampagdez, me encanta gapeag y ggapag ggupos de folios con mi ggapadoga. \n" +
    //            "Viva le Fgance!\n";

    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }
    //    }
    //    else if (random == 5)
    //    {
    //        duolingOn = true;
    //        duoling.SetActive(true);
    //        initialConversationText.text = "Espero que hayas hecho hoy tu lección de Quichua, porque si no te lo recordaré con el cuchill...\n" +
    //            "Oh perdona... la costumbre jeje Bueno, cóbrame estos productos y aprende otro idioma exclusivamente con mi app jijiji\n" +
    //            "¿Me cobras o te enseño una lección?\n";

    //        for (int i = 0; i < boughtProducts.Length; i++)
    //        {
    //            int randomProduct = Random.Range(0, 6);
    //            boughtProducts[i] = products[randomProduct];

    //            if (i == 0 || i == 2 || i == 4)
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], new Vector3(soldPlaces[i].transform.position.x, soldPlaces[i].transform.position.y, -9), soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //            else
    //            {
    //                GameObject clon = Instantiate(boughtProducts[i], soldPlaces[i].transform.position, soldPlaces[i].transform.rotation);
    //                clon.transform.parent = soldPlaces[i].transform;
    //            }
    //        }
    //    }
    //}

    //public void SoundCreator(string texto)
    //{
    //    chars = new char[texto.Length];
    //    string[] provisionalWords = new string[texto.Length];
    //    int pauses = 0;
    //    int huecoPalabra = 0;


    //    for (int i = 0; i < texto.Length; i++)
    //    {
    //        if (texto[i] == ' ')
    //        {
    //            pauses++;
    //            huecoPalabra++;
    //        }

    //        else if (texto[i] != ' ')
    //            provisionalWords[huecoPalabra] += texto[i];

    //        chars[i] = texto[i];
    //    }

    //    int palabrasTotales = huecoPalabra + 1;
    //    print(palabrasTotales);
    //    words = new string[palabrasTotales];

    //    for (int i = 0; i < palabrasTotales; i++)
    //    {
    //        words[i] = provisionalWords[i];
    //    }

    //    wordsDuration = new int[words.Length];

    //    for (int i = 0; i < wordsDuration.Length; i++)
    //    {
    //        for (int j = 0; j < words[i].Length; j++)
    //        {
    //            wordsDuration[i]++;
    //        }
    //    }

    //    StartCoroutine(SoundMaker());
    //}

    //IEnumerator SoundMaker()
    //{

    //    for (int i = 0; i < wordsDuration.Length; i++)
    //    {
    //        if (wordsDuration[i] < 3)
    //        {
    //            conversationSound.clip = marianoSounds[1];

    //            float duration = conversationSound.clip.length / 2f;
    //            float randomPitch = Random.Range(0.9f, 1.1f);

    //            conversationSound.pitch = randomPitch;
    //            conversationSound.Play();

    //            yield return new WaitWhile(() => conversationSound.isPlaying);
    //        }

    //        else if (wordsDuration[i] < 7)
    //        {
    //            conversationSound.clip = marianoSounds[4];

    //            float duration = conversationSound.clip.length / 2f;
    //            float randomPitch = Random.Range(0.9f, 1.1f);

    //            conversationSound.pitch = randomPitch;
    //            conversationSound.Play();

    //            yield return new WaitWhile(() => conversationSound.isPlaying);
    //        }

    //        else
    //        {
    //            conversationSound.clip = marianoSounds[7];

    //            float duration = conversationSound.clip.length / 32;
    //            float randomPitch = Random.Range(0.9f, 1.1f);

    //            conversationSound.pitch = randomPitch;
    //            conversationSound.Play();

    //            yield return new WaitWhile(() => conversationSound.isPlaying);
    //        }
    //    }
    //}

    #endregion
}
