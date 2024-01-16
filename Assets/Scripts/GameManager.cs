using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    [Header("CURSOR RESHULO")]
    [SerializeField] public GameObject cursor;

    [Header("TRAMPILLA")]
    [SerializeField] public GameObject trampilla;

    [Header("CHARACTERS THINGS")]
    [SerializeField] public GameObject currentCustomer;
    [SerializeField] public int customerNumber = 0;
    [SerializeField] public List<GameObject> dailyCustomers;

    [SerializeField] public GameObject jefe;
    [SerializeField] public GameObject data;

    [Header("CHARACTERS THAT CAN APPEAR")]

    [Header("Day1")]
    [SerializeField] public GameObject evilWizardGerard;
    [SerializeField] public GameObject hybridElvog;
    [SerializeField] public GameObject limbasticAntonio;
    [SerializeField] public GameObject elementalTapicio;
    [SerializeField] public GameObject electropedDenjirenji;
    [SerializeField] public GameObject hybridMara;
    [SerializeField] public GameObject limbasticGiovanni;
    [SerializeField] public GameObject elementalRockon;

    [Header("Day2")]
    [SerializeField] public GameObject electropedMagmaDora;
    [SerializeField] public GameObject evilWizardManolo;
    [SerializeField] public GameObject limbasticCululu;
    [SerializeField] public GameObject elementalHandy;
    [SerializeField] public GameObject hybridPetra;
    [SerializeField] public GameObject elementalJissy;
    [SerializeField] public GameObject electropedMasermati;
    [SerializeField] public GameObject evilWizardPijus;

    [Header("Day3")]
    [SerializeField] public GameObject limbasticSergio;
    [SerializeField] public GameObject hybridSaltaralisis;
    [SerializeField] public GameObject evilWizardManoloMano;
    [SerializeField] public GameObject electropedRaven;
    [SerializeField] public GameObject elementalHueso;
    [SerializeField] public GameObject limbasticPatxi;
    //[SerializeField] public GameObject hybridElvog; //(Aparece de nuevo en el día 3)
    [SerializeField] public GameObject evilWizardElidora;
    [SerializeField] public GameObject electropedRustica;

    [Header("PRODUCTS PLACES")]
    [SerializeField] public Transform oneProduct;
    [SerializeField] public Transform twoProducts1;
    [SerializeField] public Transform twoProducts2;

    [Header("PRODUCTS LIST")]
    [SerializeField] public GameObject energeticDrink;
    [SerializeField] public GameObject beer;
    [SerializeField] public GameObject crystallBall;
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

    [Header("AUDIO")]
    [SerializeField] public AudioClip TrampillaEntrada;
    [SerializeField] public AudioClip TrampillaSalida;
    public AudioSource audioSource;
    [SerializeField] public GameObject musicBox;

    [SerializeField] GameObject canvas;
    public Scene currentScene;



    #region Código Antiguo
    [SerializeField] public TMP_Text initialConversationText;
    [SerializeField] public char[] chars;
    [SerializeField] public string[] words;
    [SerializeField] public int[] wordsDuration;
    [SerializeField] public AudioSource conversationSound;
    [SerializeField] public AudioClip[] marianoSounds;
    #endregion

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicBox = GameObject.FindGameObjectWithTag("MusicBox");
        canvas = GameObject.FindGameObjectWithTag("UI");
        data = GameObject.FindGameObjectWithTag("Data");

        GameObject newCursor = Instantiate(cursor, canvas.transform);
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Day1") Day1();
        if (currentScene.name == "Day2") Day2();
        if (currentScene.name == "Day3") Day3();
        if (currentScene.name == "Day4") Day4();
    }

    public void CharacterShowUp(GameObject character)
    {
        audioSource.PlayOneShot(TrampillaEntrada);
        GameObject clon = Instantiate(character, showUpPoint);
    }

    public void Day1()
    {
        canvas.GetComponent<UIManager>().LaVoluntad(50);
        dailyCustomers.Clear();
        dailyCustomers.Add(jefe);
        dailyCustomers.Add(evilWizardGerard);
        dailyCustomers.Add(hybridElvog);
        dailyCustomers.Add(limbasticAntonio);
        dailyCustomers.Add(elementalTapicio);
        dailyCustomers.Add(electropedDenjirenji);
        dailyCustomers.Add(hybridMara);
        dailyCustomers.Add(limbasticGiovanni);
        dailyCustomers.Add(elementalRockon);

        CharacterShowUp(dailyCustomers[customerNumber]);
    }

    public void Day2()
    {
        canvas.GetComponent<UIManager>().LaVoluntad(50);
        dailyCustomers.Clear();
        dailyCustomers.Add(jefe);
        //dailyCustomers.Add(); aqui va Lepion, pero no está metido porque no está la transferencia de datos aún
        dailyCustomers.Add(limbasticGiovanni);
        dailyCustomers.Add(evilWizardManolo);
        dailyCustomers.Add(limbasticCululu);
        dailyCustomers.Add(elementalHandy);
        dailyCustomers.Add(hybridPetra);
        dailyCustomers.Add(elementalTapicio);
        dailyCustomers.Add(electropedMasermati);
        dailyCustomers.Add(evilWizardPijus);

        CharacterShowUp(dailyCustomers[customerNumber]);
    }

    public void Day3()
    {
        canvas.GetComponent<UIManager>().LaVoluntad(50);
        dailyCustomers.Clear();
        dailyCustomers.Add(jefe);
        dailyCustomers.Add(limbasticSergio);
        dailyCustomers.Add(hybridSaltaralisis);
        dailyCustomers.Add(evilWizardManoloMano);
        dailyCustomers.Add(electropedRaven);
        dailyCustomers.Add(elementalHueso);
        dailyCustomers.Add(limbasticPatxi);
        dailyCustomers.Add(hybridElvog);
        dailyCustomers.Add(evilWizardManolo);
        dailyCustomers.Add(electropedRustica);

        CharacterShowUp(dailyCustomers[customerNumber]);
    }

    public void Day4()
    {
        canvas.GetComponent<UIManager>().LaVoluntad(50);
        dailyCustomers.Clear();
        dailyCustomers.Add(jefe);
        dailyCustomers.Add(elementalJissy);
        dailyCustomers.Add(hybridMara);
        dailyCustomers.Add(limbasticCululu);
        dailyCustomers.Add(evilWizardElidora);
        dailyCustomers.Add(evilWizardGerard);
        dailyCustomers.Add(electropedMagmaDora);
        dailyCustomers.Add(elementalHandy);
        dailyCustomers.Add(limbasticAntonio);
        dailyCustomers.Add(evilWizardManoloMano);

        CharacterShowUp(dailyCustomers[customerNumber]);
    }


    public void FindTheCustomer()
    {
        canvas.GetComponent<UIManager>().currentCustomer = GameObject.FindGameObjectWithTag("CurrentCustomer");
    }

    //public void MoreSpeed()
    //{
    //    currentCustomer.GetComponent<Client>().typingTime = 0;
    //}
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

    //    //StartCoroutine(SoundMaker());
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