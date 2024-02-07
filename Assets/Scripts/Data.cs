using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Data : MonoBehaviour
{
    [SerializeField] public bool spaSpain;
    [SerializeField] public bool engAmerican;
    [SerializeField] public bool spaColombian;

    [SerializeField] public GameObject gameManager;

    [SerializeField] public int numEvilWizard;
    //[SerializeField] public int numEvilWizardGerard;
    //[SerializeField] public int numEvilWizardManolo;
    //[SerializeField] public int numEvilWizardManoloMano;
    //[SerializeField] public int numEvilWizardElidora;
    //[SerializeField] public int numEvilWizardPijus;

    [SerializeField] public int numHybrid;
    //[SerializeField] public int numHybridElvog;
    //[SerializeField] public int numHybridLepion;
    //[SerializeField] public int numHybridMara;
    //[SerializeField] public int numHybridPetra;
    //[SerializeField] public int numHybridSaltaralisis;

    [SerializeField] public int numLimbastic;
    //[SerializeField] public int numLimbasticAntonio;
    //[SerializeField] public int numLimbasticGiovanni;
    //[SerializeField] public int numLimbasticCululu;
    //[SerializeField] public int numLimbasticSergio;
    //[SerializeField] public int numLimbasticPatxi;

    [SerializeField] public int numElemental;
    //[SerializeField] public int numElementalTapicio;
    //[SerializeField] public int numElementalRockon;
    //[SerializeField] public int numElementalHandy;
    //[SerializeField] public int numElementalJissy;
    //[SerializeField] public int numElementalHueso;

    [SerializeField] public int numElectroped;
    //[SerializeField] public int numElectropedDenjirenji;
    //[SerializeField] public int numElectropedMagmaDora;
    //[SerializeField] public int numElectropedMasermati;
    //[SerializeField] public int numElectropedRaven;
    //[SerializeField] public int numElectropedRustica;

    [SerializeField] public bool samuraiPagaMal = true;
    [SerializeField] public bool borrachoTriste = false;
    [SerializeField] public bool day0Check = false;
    [SerializeField] public bool day1Check = false;
    [SerializeField] public bool day2Check = false;
    [SerializeField] public bool day3Check = false;
    [SerializeField] public bool day4Check = false;
    [SerializeField] public bool day5Check = false;
    [SerializeField] public bool finalMuyMaloConseguido = false;
    [SerializeField] public bool finalMaloConseguido = false;
    [SerializeField] public bool finalBuenoConseguido = false;
    [SerializeField] public bool finalMuyBuenoConseguido = false;
    [SerializeField] public bool finalSecretoConseguido = false;
    [SerializeField] public int tipsPoints;
    [SerializeField] public int detectivePoints;

    [SerializeField] public bool giftGeeraard = false;      // La foto firmada
    [SerializeField] public bool giftEnano = false;         // Te da un Enano.
    [SerializeField] public bool giftMano = false;          // Te da un anillo.
    [SerializeField] public bool giftElidora = false;       // Te pasa un moco.
    //[SerializeField] public bool giftPijus = false;
    [SerializeField] public bool giftElvog = false;         // Te da una botella con flores.
    //[SerializeField] public bool giftLepion = false;
    [SerializeField] public bool giftMara = false;          // Te da la pierna de su marido.
    [SerializeField] public bool giftPetra = false;         // Te da un mapa.
    //[SerializeField] public bool giftSaltaralisis = false;
    [SerializeField] public bool giftAntonio = false;       // Te da sus gafas.
    [SerializeField] public bool giftGiovanni = false;      // Te da su "libro de cocina".
    [SerializeField] public bool giftCululu = false;        // Te da la foto de Mara.
    [SerializeField] public bool giftSergio = false;        // Te da su Globo-Espada.
    //[SerializeField] public bool giftPatxi = false;         
    [SerializeField] public bool giftTapicio = false;       // Te da el puto GOTY.
    //[SerializeField] public bool giftRockon = false;
    [SerializeField] public bool giftHandy = false;         // Te da un disfraz de payaso.
    //[SerializeField] public bool giftJissy = false;
    //[SerializeField] public bool giftHueso = false;
    [SerializeField] public bool giftDenjirenji = false;    // Te da su espada.
    //[SerializeField] public bool giftMagmadora = false;
    //[SerializeField] public bool giftMasermati = false;
    [SerializeField] public bool giftRaven = false;         // Te da un disco.
    //[SerializeField] public bool giftRustica = false;

    [SerializeField] public List<string> dialogue;


    public static Data instance;

    void Start()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
        DontDestroyOnLoad(gameObject);


    }

    #region Todos los diálogos de Coins Only

    public void SettingDialogues()
    {
        Scene currentScene;
        currentScene = SceneManager.GetActiveScene();

        List<GameObject> _dC;
        gameManager = GameObject.FindGameObjectWithTag("GM");

        if (spaSpain)
        {
            if (currentScene.name == "Day1")
            {
                _dC = gameManager.GetComponent<GameManager>().dailyCustomers;
                List<string> _dC1 = _dC[0].GetComponent<Client>().dialogue;
                List<string> _dC2 = _dC[1].GetComponent<Client>().dialogue;
                List<string> _dC3 = _dC[2].GetComponent<Client>().dialogue;
                List<string> _dC4 = _dC[3].GetComponent<Client>().dialogue;
                List<string> _dC5 = _dC[4].GetComponent<Client>().dialogue;
                List<string> _dC6 = _dC[5].GetComponent<Client>().dialogue;
                List<string> _dC7 = _dC[6].GetComponent<Client>().dialogue;
                List<string> _dC8 = _dC[7].GetComponent<Client>().dialogue;
                List<string> _dC9 = _dC[8].GetComponent<Client>().dialogue;

                _dC1.Add("Buenas ciudadano, ya llegó aquí, el inigualable Geeraard, gracias, gracias…");
                _dC1.Add("…");
                _dC1.Add("¿Por qué no has empezado a llorar de la alegría y a pedirme un autógrafo mientras estás de rodillas?");
                _dC1.Add("¡Cómo que no me conoces! Todos aquí me conocen.");
                _dC1.Add("El héroe de héroes, quien derrotó al Rey Demonio con una sola daga y los ojos vendados.");
                _dC1.Add("Vamos… Todos mis admiradores, es decir, todo el reino, saben que soy el mejor héroe de la historia.");
                _dC1.Add("...");
                _dC1.Add("Bueno, me imagino que perdonaré tu desconocimiento y ese silencio incómodo que provocas.");
                _dC1.Add("Cóbrame esto al menos, así esta charla dejará de ser tan incómoda.");

                _dC1.Add("Deberías de leer alguna de mis grandes historias humano, adiós.");
                _dC1.Add("Pero, ¡QUÉ INSOLENCIA ES ESTA! Espero que cuando vuelva aprendas a contar monedas humano.");
            }
        }
    }

    #endregion
}
