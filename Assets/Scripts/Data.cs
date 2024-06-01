using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Data : MonoBehaviour
{
    [SerializeField] public bool spaSpain;
    [SerializeField] public bool engAmerican;
    [SerializeField] public bool spaColombian;

    [SerializeField] public GameObject uIManager;
    [SerializeField] public HomeManager homeManager;
    [SerializeField] public Transiciones transiciones;

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

    [SerializeField] public bool samuraiPagaMal = false;
    [SerializeField] public bool borrachoTriste = false;
    [SerializeField] public bool samuraiAyudado1 = false;
    [SerializeField] public bool samuraiAyudado2 = false;
    [SerializeField] public int vecesSamuraiAyudado = 0;

    [SerializeField] public bool day0Check = false;
    [SerializeField] public bool day1Check = false;
    [SerializeField] public bool day2Check = false;
    [SerializeField] public bool day3Check = false;
    [SerializeField] public bool day4Check = false;
    [SerializeField] public bool day5Check = false;
    [SerializeField] public bool videoActivo = false;
    [SerializeField] public bool videoVisto = false;
    [SerializeField] public bool finalMuyMaloConseguido = false;
    [SerializeField] public bool finalMaloConseguido = false;
    [SerializeField] public bool finalBuenoConseguido = false;
    [SerializeField] public bool finalMuyBuenoConseguido = false;
    [SerializeField] public bool finalSecretoConseguido = false;
    [SerializeField] public int tipsPoints;
    [SerializeField] public int detectivePoints;

    [SerializeField] public bool fase1Check = false;
    [SerializeField] public bool fase2Check = false;
    [SerializeField] public bool fase3Check = false;
    [SerializeField] public bool fase4Check = false;
    [SerializeField] public bool fase5Check = false;
    [SerializeField] public bool fase6Check = false;
    [SerializeField] public bool fase7Check = false;
    [SerializeField] public bool fase8Check = false;
    [SerializeField] public bool fase9Check = false;

    [SerializeField] public bool sePueTocar = false;
    [SerializeField] public bool yaSeFueCliente = false;
    [SerializeField] public float tipsBetweenDays = 0;

    [SerializeField] public int vecesCobradoCululu = 0;                 // Si le cobras 3 veces bien (día 1, 4 y 5), te llevas la foto de la cangumantis en pose sugerente
    [SerializeField] public int vecesCobradoGiovanni = 0;               // Si le cobras 2 veces bien (día 1 y 2), te llevas un libro que es la bomba.
    [SerializeField] public int vecesCobradaMara = 0;                   // Si le cobras 2 veces bien (día 1 y 2), te llevas una pata de la suerte.
    [SerializeField] public int vecesCobradaHandy = 0;                   // Si le cobras 2 veces bien (día 2 y 4), eres un puto payaso.
    [SerializeField] public int noCobrarSergioCobrarGeeraardD4 = 0;                   // No tienes que cobrar a Sergio en el día 4 y tienes que cobrar a Geerald en el día 4
    [SerializeField] public int vecesCobradoAntonio = 0;                   // Tienes que cobrar a Antonio en el dia 4 y a Paxi en el dia 3
    [SerializeField] public int vecesCobradoRaven = 0;
    [SerializeField] public int numGnomosFinded = 0;
    [SerializeField] public bool nerviosusPagaLoQueDebe = false;        // Si le cobras (día 4) te da la globoespada.
    [SerializeField] public bool nerviosusTeDebePasta = false;          // Si no le cobras Gerardo el magias te dará su bella foto.
    [SerializeField] public bool slimeFostiados = false;                // Si le has dado hasta en el carnet de identidad a los slimes.
    [SerializeField] public bool slimeFail = false;                     // Si no llegaste a 50 puntos en el minijuego de Elidora.
    [SerializeField] public bool elidoraAcariciada = false;             // Si le metiste tremendo cebollazo al pedrolo de Elidora.

    [SerializeField] public bool giftGeeraard = false;      // Si nerviosusPagaLoQueDebe es falso, Geerard te dará la foto firmada
    [SerializeField] public bool giftEnano = false;         // Te da un Enano. Si en el día 2 o 3 encuentras al enano zumbón.
    [SerializeField] public bool giftMano = false;          // Te da un anillo.
    [SerializeField] public bool giftElidora = false;       // Si completas su minijuego te pasa un moco.
    //[SerializeField] public bool giftPijus = false;
    [SerializeField] public bool giftElvog = false;         // Te da una botella con flores.
    //[SerializeField] public bool giftLepion = false;
    [SerializeField] public bool giftMara = false;          // Te da la pierna de su marido.
    [SerializeField] public bool giftPetra = false;         // Te da un mapa.
    //[SerializeField] public bool giftSaltaralisis = false;
    [SerializeField] public bool giftAntonio = false;       // Te da sus gafas.
    [SerializeField] public bool giftGiovanni = false;      // Te da su "libro de cocina".
    [SerializeField] public bool giftCululu = false;        // Te da la foto de Mara.
    [SerializeField] public bool giftSergio = false;        // Si nerviosusPagaLoQueDebe es verdadero, te da su Globo-Espada.
    //[SerializeField] public bool giftPatxi = false;         
    [SerializeField] public bool giftTapicio = false;       // Te da el puto GOTY.
    //[SerializeField] public bool giftRockon = false;
    [SerializeField] public bool giftHandy = false;         // Te da un disfraz de payaso.
    //[SerializeField] public bool giftJissy = false;
    //[SerializeField] public bool giftHueso = false;
    [SerializeField] public bool giftDenjirenji = false;    // Si completas su minijuego te da su espada.
    //[SerializeField] public bool giftMagmadora = false;
    //[SerializeField] public bool giftMasermati = false;
    [SerializeField] public bool giftRaven = false;         // Si completas su minijuego te da un disco.
    //[SerializeField] public bool giftRustica = false;

    [SerializeField] public List<string> cCDialogue;

    public static Data instance;

    public string archivoDeGuardado;
    public SavedData datosJuego = new SavedData();

    void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";

        uIManager = null;
        homeManager = null;

        if (instance != null) Destroy(gameObject);

        else instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CargarDatos();
    }

    public void CargarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<SavedData>(contenido);

            spaSpain = datosJuego.savedspaSpain;
            engAmerican = datosJuego.savedengAmerican;
            spaColombian = datosJuego.savedspaColombian;

            numEvilWizard = datosJuego.savednumEvilWizard;

            numHybrid = datosJuego.savednumHybrid;

            numLimbastic = datosJuego.savednumLimbastic;

            numElemental = datosJuego.savednumElemental;

            numElectroped = datosJuego.SavednumElectroped;

            samuraiPagaMal = datosJuego.savedsamuraiPagaMal;
            borrachoTriste = datosJuego.savedborrachoTriste;
            samuraiAyudado1 = datosJuego.savedsamuraiAyudado1;
            samuraiAyudado2 = datosJuego.savedsamuraiAyudado2;
            vecesSamuraiAyudado = datosJuego.savedvecesSamuraiAyudado;

            day0Check = datosJuego.savedday0Check;
            day1Check = datosJuego.savedday1Check;
            day2Check = datosJuego.savedday2Check;
            day3Check = datosJuego.savedday3Check;
            day4Check = datosJuego.savedday4Check;
            day5Check = datosJuego.savedday5Check;
            videoActivo = datosJuego.savedvideoActivo;
            videoVisto = datosJuego.savedvideoVisto;
            finalMuyMaloConseguido = datosJuego.savedfinalMuyMaloConseguido;
            finalMaloConseguido = datosJuego.savedfinalMaloConseguido;
            finalBuenoConseguido = datosJuego.savedfinalBuenoConseguido;
            finalMuyBuenoConseguido = datosJuego.savedfinalMuyBuenoConseguido;
            finalSecretoConseguido = datosJuego.savedfinalSecretoConseguido;
            tipsPoints = datosJuego.savedtipsPoints;
            detectivePoints = datosJuego.saveddetectivePoints;

            fase1Check = datosJuego.savedfase1Check;
            fase2Check = datosJuego.savedfase2Check;
            fase3Check = datosJuego.savedfase3Check;
            fase4Check = datosJuego.savedfase4Check;
            fase5Check = datosJuego.savedfase5Check;
            fase6Check = datosJuego.savedfase6Check;
            fase7Check = datosJuego.savedfase7Check;
            fase8Check = datosJuego.savedfase8Check;
            fase9Check = datosJuego.savedfase9Check;

            sePueTocar = datosJuego.savedsePueTocar;
            yaSeFueCliente = datosJuego.savedyaSeFueCliente;
            tipsBetweenDays = datosJuego.savedtipsBetweenDays;

            vecesCobradoCululu = datosJuego.savedvecesCobradoCululu;
            vecesCobradoGiovanni = datosJuego.savedvecesCobradoGiovanni;
            vecesCobradaMara = datosJuego.savedvecesCobradaMara;
            vecesCobradaHandy = datosJuego.savedvecesCobradaHandy;
            noCobrarSergioCobrarGeeraardD4 = datosJuego.savednoCobrarSergioCobrarGeeraardD4;
            vecesCobradoAntonio = datosJuego.savedvecesCobradoAntonio;
            vecesCobradoRaven = datosJuego.savedvecesCobradoRaven;
            numGnomosFinded = datosJuego.savednumGnomosFinded;
            nerviosusPagaLoQueDebe = datosJuego.savednerviosusPagaLoQueDebe;
            nerviosusTeDebePasta = datosJuego.savednerviosusTeDebePasta;
            slimeFostiados = datosJuego.savedslimeFostiados;
            slimeFail = datosJuego.savedslimeFail;
            elidoraAcariciada = datosJuego.savedelidoraAcariciada;

            giftGeeraard = datosJuego.savedgiftGeeraard;
            giftEnano = datosJuego.savedgiftEnano;
            giftMano = datosJuego.savedgiftMano;
            giftElidora = datosJuego.savedgiftElidora;
            giftElvog = datosJuego.savedgiftElvog;
            giftMara = datosJuego.savedgiftMara;
            giftPetra = datosJuego.savedgiftPetra;
            giftAntonio = datosJuego.savedgiftAntonio;
            giftGiovanni = datosJuego.savedgiftGiovanni;
            giftCululu = datosJuego.savedgiftCululu;
            giftSergio = datosJuego.savedgiftSergio;
            giftTapicio = datosJuego.savedgiftTapicio;
            giftHandy = datosJuego.savedgiftHandy;
            giftDenjirenji = datosJuego.savedgiftDenjirenji;
            giftRaven = datosJuego.savedgiftRaven;

        }

        else
        {
            Debug.Log("El archivo no existe");
        }
    }

    public void GuardarDatos()
    {
        SavedData nuevosDatos = new SavedData()
        {
            savedspaSpain = spaSpain,
            savedengAmerican = engAmerican,
            savedspaColombian = spaColombian,

            savednumEvilWizard = numEvilWizard,

            savednumHybrid = numHybrid,

            savednumLimbastic = numLimbastic,

            savednumElemental = numElemental,

            SavednumElectroped = numElectroped,

            savedsamuraiPagaMal = samuraiPagaMal,
            savedborrachoTriste = borrachoTriste,
            savedsamuraiAyudado1 = samuraiAyudado1,
            savedsamuraiAyudado2 = samuraiAyudado2,
            savedvecesSamuraiAyudado = vecesSamuraiAyudado,

            savedday0Check = day0Check,
            savedday1Check = day1Check,
            savedday2Check = day2Check,
            savedday3Check = day3Check,
            savedday4Check = day4Check,
            savedday5Check = day5Check,
            savedvideoActivo = videoActivo,
            savedvideoVisto = videoVisto,
            savedfinalMuyMaloConseguido = finalMuyMaloConseguido,
            savedfinalMaloConseguido = finalMaloConseguido,
            savedfinalBuenoConseguido = finalBuenoConseguido,
            savedfinalMuyBuenoConseguido = finalMuyBuenoConseguido,
            savedfinalSecretoConseguido = finalSecretoConseguido,
            savedtipsPoints = tipsPoints,
            saveddetectivePoints = detectivePoints,

            savedfase1Check = fase1Check,
            savedfase2Check = fase2Check,
            savedfase3Check = fase3Check,
            savedfase4Check = fase4Check,
            savedfase5Check = fase5Check,
            savedfase6Check = fase6Check,
            savedfase7Check = fase7Check,
            savedfase8Check = fase8Check,
            savedfase9Check = fase9Check,

            savedsePueTocar = sePueTocar,
            savedyaSeFueCliente = yaSeFueCliente,
            savedtipsBetweenDays = tipsBetweenDays,

            savedvecesCobradoCululu = vecesCobradoCululu,
            savedvecesCobradoGiovanni = vecesCobradoGiovanni,
            savedvecesCobradaMara = vecesCobradaMara,
            savedvecesCobradaHandy = vecesCobradaHandy,
            savednoCobrarSergioCobrarGeeraardD4 = noCobrarSergioCobrarGeeraardD4,
            savedvecesCobradoAntonio = vecesCobradoAntonio,
            savedvecesCobradoRaven = vecesCobradoRaven,
            savednumGnomosFinded = numGnomosFinded,
            savednerviosusPagaLoQueDebe = nerviosusPagaLoQueDebe,
            savednerviosusTeDebePasta = nerviosusTeDebePasta,
            savedslimeFostiados = slimeFostiados,
            savedslimeFail = slimeFail,
            savedelidoraAcariciada = elidoraAcariciada,

            savedgiftGeeraard = giftGeeraard,
            savedgiftEnano = giftEnano,
            savedgiftMano = giftMano,
            savedgiftElidora = giftElidora,
            savedgiftElvog = giftElvog,
            savedgiftMara = giftMara,
            savedgiftPetra = giftPetra,
            savedgiftAntonio = giftAntonio,
            savedgiftGiovanni = giftGiovanni,
            savedgiftCululu = giftCululu,
            savedgiftSergio = giftSergio,
            savedgiftTapicio = giftTapicio,
            savedgiftHandy = giftHandy,
            savedgiftDenjirenji = giftDenjirenji,
            savedgiftRaven = giftRaven
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJSON);

        Debug.Log("Archivo Guardado");
    }

    #region Todos los diálogos de Coins Only

    public void SettingDialogues()
    {
        Scene currentScene;
        currentScene = SceneManager.GetActiveScene();
        cCDialogue.Clear();

        if (spaSpain)
        {
            if (currentScene.name == "Day1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola chico nuevo, soy tu jefe.");
                    cCDialogue.Add("Y cómo sé que es tu primer día, te estaré observando.");
                    cCDialogue.Add("Porque sé que no serás capaz de atender a los clientes bien.");
                    cCDialogue.Add("Ya sabes que todos los humanos sois inútiles.");
                    cCDialogue.Add("No lo digo yo, lo dice vuestro cerebro enano.");
                    cCDialogue.Add("Pero bueno, como iba diciendo… ¡ATIENDE BIEN!");
                    cCDialogue.Add("No quiero perder dinero contigo.");
                    cCDialogue.Add("Para cobrar usa la CAJA REGISTRADORA.");
                    cCDialogue.Add("Y como cobres mal, te quitaré dinero de tu TARRO DE PROPINAS.");
                    cCDialogue.Add("Tienes el catálogo de la tienda a la derecha para saber si el cliente tiene dinero suficiente.");
                    cCDialogue.Add(" Además tendrás una ayuda, la cabeza del antiguo empleado.");
                    cCDialogue.Add("Se la arrancó un cliente al que no le vendió su alcohol.");
                    cCDialogue.Add("Menos mal que su sistema de traducción sigue funcionando.");
                    cCDialogue.Add("No iba a comprarte otro traductor como ese no fuera.");
                    cCDialogue.Add("Suerte en tu primer día, chico nuevo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard"))
                {
                    cCDialogue.Add("Buenas ciudadano, ya llegó aquí, el inigualable Geeraard, gracias, gracias…");
                    cCDialogue.Add("…");
                    cCDialogue.Add("¿Por qué no has empezado a llorar de la alegría y a pedirme un autógrafo mientras estás de rodillas?");
                    cCDialogue.Add("¡Cómo no me conoces! Todos aquí me conocen.");
                    cCDialogue.Add("El héroe de héroes, quien derrotó al Rey Demonio con una sola daga y los ojos vendados.");
                    cCDialogue.Add("Vamos… Todos mis admiradores, es decir, todo el reino, saben que soy el mejor héroe de la historia.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Bueno, me imagino que perdonare tu desconocimiento y ese silencio incómodo que provocas.");
                    cCDialogue.Add("Cobrame esto al menos, así esta charla dejará de ser tan incómoda.");
                    cCDialogue.Add("Deberías de leer alguna de mis grandes historias humano, adiós.");
                    cCDialogue.Add("Pero, ¡QUÉ INSOLENCIA ES ESTA! Espero que cuando vuelva aprendas a contar monedas humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Buennnasss *hip* Eeeehhhhh… tuuu no eres el de sieeeembrree… *hip*");
                    cCDialogue.Add(" Bueno, el otro erra un ######");
                    cCDialogue.Add("Ahorra a quien le direee sobre niii despidoooo… Encimaaa eres humanooo…*");
                    cCDialogue.Add("Ne tocarra contarrrrte a tuuu… *hip*");
                    cCDialogue.Add(" Soy Elvog, er ex ex explorador");
                    cCDialogue.Add("Mooo te looo vasss a creer… El ###### de mi jefeee me despidió *hip*");
                    cCDialogue.Add("Me dijooo que bebía mushoo alcohooool y que estoy viejo, ¿perro quee dise eseee? *hip*");
                    cCDialogue.Add("Siii solo temgo 22 añitos, estoooy em la fror de la hueventud *hip*");
                    cCDialogue.Add("Buemo, che me olvidó *hip*, puedess cobrarme estooo…");
                    cCDialogue.Add("Gracias mushacho *hip* Ahorra serás ni depemdiete favorito *hip*");
                    cCDialogue.Add("Perro mushacho *hip* el otroo depemdiete erra mejor *hip*");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Ey… Hola amigo, soy Antonio… ¿Qué tal tu día?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Ya veo… No eres muy hablador eh.");
                    cCDialogue.Add("Te entiendo tio, yo también estoy tan cansado cuando curro en programación.");
                    cCDialogue.Add(" No se como sobreviví a esta jornada laboral, puede que porque esté muerto.");
                    cCDialogue.Add(" Ja ja ja ja ja… Perdón, los chistes no son lo mío, mi cabeza no funciona tras un día de trabajo tan duro.");
                    cCDialogue.Add("Hace que mi cerebro no funciona, porque estoy muerto.");
                    cCDialogue.Add("Ja ja ja ja ja… Perdón ya paro.");
                    cCDialogue.Add("Cobrame y dejaré de incomodarte.");
                    cCDialogue.Add("Gra-gracias, aunque ahora que lo pienso no sé si era todo el dinero…");
                    cCDialogue.Add(" Uy, me faltan monedas, siempre se cometen estos errores cuando pierdes la cabeza… Ya paro, nos vemos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Saludos desde mi solitaria existencia, soy Tapicio.");
                    cCDialogue.Add("¿Qué pasa? ¿Nunca has visto alguien tan animado verdad?");
                    cCDialogue.Add("Que quieres que te diga, soy prisionero de mi propio destino.");
                    cCDialogue.Add("Fui creado para solo trabajar, mis cadenas nunca se romperán.");
                    cCDialogue.Add("A veces deseo seguir siendo ser ese pequeño tapiz colgado en el cementerio de limbásticos.");
                    cCDialogue.Add("Pero por desgracia, mi vida es como una canción emo: Larga, triste y nunca termina.");
                    cCDialogue.Add("Al igual que esta conversación, perdón por hacerte perder el tiempo.");
                    cCDialogue.Add("Deberías de cobrarme ya, o si no llegaré tarde a mi torneo de lanzamiento de miradas melancólicas.");
                    cCDialogue.Add("Gracias, espero que no quedar en primer lugar, como siempre.");
                    cCDialogue.Add("Otra desgracia más para mi vida, ahora seguro gano el torneo por tu culpa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Buenas joven, no me creo que ahora solo sea un recadero…");
                    cCDialogue.Add("Perdón, el jefe me está poniendo la cabeza como un horno.");
                    cCDialogue.Add("Soy Denjirenji.");
                    cCDialogue.Add("He estado 10 años aprendiendo técnicas samurai infalibles y fuí el mejor de la promoción.");
                    cCDialogue.Add("Incluso salvé el mundo junto a cuatro tortugas ninja, y ahora…");
                    cCDialogue.Add("Solo sirvo para calentar su maldita comida, y encima la tengo que comprar yo.");
                    cCDialogue.Add("Perdí todo honor como samurai.");
                    cCDialogue.Add("Al final acabaré haciéndome el harakiri con cucharas.");
                    cCDialogue.Add("Disculpa que te haya robado un poco de tu tiempo, cobrame esto por favor.");
                    cCDialogue.Add("Menos mal que tenía el dinero justo, o eso creo.");
                    cCDialogue.Add("¡Por una moneda! Disculpame, espero que el jefe no me mate.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mara"))
                {
                    cCDialogue.Add("Buenos días querido, soy Mara.");
                    cCDialogue.Add("¿Podías luego ayudarme a cargar esto hasta fuera?");
                    cCDialogue.Add("Uy uy, que digo, me imagino que no puedes abandonar tu puesto.");
                    cCDialogue.Add("Desde que no está mi marido, me cuesta más cargar la compra.");
                    cCDialogue.Add("Pero bueno, como quiero que esté mi marido si me lo comí.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Que raro que estés inexpresivo, siempre que cuento eso se asustan.");
                    cCDialogue.Add("No sé porque no se normaliza que los manguros nos comamos a nuestra pareja.");
                    cCDialogue.Add("Pero sólo para reproducirnos, no somos unos monstruos.");
                    cCDialogue.Add("Bueno, deberías cobrarme, que tengo que recoger a mi niño del zoo.");
                    cCDialogue.Add("Muchas gracias joven, espero que tu pareja te coma pronto también ji ji ji.");
                    cCDialogue.Add("¿Perdona? Ahora por tu culpa mi hijo no tendrá su gato muerto, él solo quería una mascota");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("¡Ahoy, amigo mío! Soy Giovanni.");
                    cCDialogue.Add("No sabes lo que me encontré hoy.");
                    cCDialogue.Add("¡EL N-E-C-R-O-N-O-M-I-C-Ó-N!");
                    cCDialogue.Add("Es el libro de cocina definitivo, o eso creo…");
                    cCDialogue.Add("Bueno, solo con decirte la primera receta te va a encantar.");
                    cCDialogue.Add("“Cómo invocar a Azathoth”");
                    cCDialogue.Add("Suena increíble este plato, pillaré algunos ingredientes para hacer el plato.");
                    cCDialogue.Add("“Primer paso: rociar vino hecho de sangre de virgen”");
                    cCDialogue.Add("Cambiaré el vino por una buena cerveza, le dará más sabor.");
                    cCDialogue.Add("“Segundo paso: cortar el muñeco voodoo por la mitad junto con la persona sacrificada”");
                    cCDialogue.Add("No sé qué es eso de la persona sacrificada, pero el muñeco tiene buena pinta.");
                    cCDialogue.Add("“Y tercer paso: beber el veneno para que el Dios se adueñe de tu cuerpo”");
                    cCDialogue.Add("No suelo beber veneno, pero creo que se lo echaré al muñeco para darle el toque picante.");
                    cCDialogue.Add("Tiene buena pinta ¿verdad? Para eso necesito estos ingredientes, así que si puedes cobrarme.");
                    cCDialogue.Add("Gracias, la próxima vez que vuelva te dejaré probar el plato para que me des tu opinión.");
                    cCDialogue.Add("Madre mía, ahora te perderás el mejor plato del mundo, pillaré las cosas en otro sitio.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rockon"))
                {
                    cCDialogue.Add("¿Ho-hola que tal?");
                    cCDialogue.Add("Espero no molestar, y perdona mi tar-tartamudez. ");
                    cCDialogue.Add("En fin, perdona otra vez. No me disculparé más, per-per-perdona.");
                    cCDialogue.Add("Estoy intentando me-mejorar, como buen Rockon que soy.");
                    cCDialogue.Add("Debo mejorar como papá, es muy fuerte.");
                    cCDialogue.Add("Siempre me ha querido mu-mu-mucho.");
                    cCDialogue.Add("Mi co-comida favorita es la gravilla que me hacía.");
                    cCDialogue.Add("Además si le echabas cemento por encima, ya quedaba bueniiiiiisimo.");
                    cCDialogue.Add("Bu-bu-bueno en fin… ¿Me puedes cobrar esto?");
                    cCDialogue.Add("Es que le quiero dar una sorpresa a papá, seguro que este gato mu-muerto le hace mucha ilusión.");
                    cCDialogue.Add("Gra-gra-gracias seguro que papá se pone feliz");
                    cCDialogue.Add("Jopetas… Con la ilusión que me hacía regalarles esto a papá y mamá… Pero no tengo todo el dinero");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefazo"))
                {
                    cCDialogue.Add("Seguro que fue muy agotador. pero mejor me lo comentas mañana.");
                    cCDialogue.Add("Y un pajarito llamado Inspector de Empleo me ha dicho que no tienes casa.");
                    cCDialogue.Add("Menos mal que tienes un jefe tan generoso y rico, así que te prestaré una de las mejores viviendas del reino.");
                    cCDialogue.Add("Ese maravilloso lugar se llama: El sótano de la casa de mi madre.");
                    cCDialogue.Add("Espero que te guste.");
                    cCDialogue.Add("Llévate el traductor por si tengo que hablar contigo, tendrás que entender a mi madre.");
                }
            }

            else if (currentScene.name == "Day2_1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenos días chico nuevo.");
                    cCDialogue.Add("¿Qué tal tu primer día?");
                    cCDialogue.Add("Nah, es broma, realmente me da igual como te fuera tu primer día.");
                    cCDialogue.Add("Seguro te lo dije en el tutorial, pero seguro no te acuerdas por tu cerebro enano.");
                    cCDialogue.Add("Tenemos unas normas que seguir en la tienda a partir de hoy.");
                    cCDialogue.Add("Además es “Magic Friday”, aunque lo seguirá siendo el resto del año, como todos los años...");
                    cCDialogue.Add("Así que los magos tienen rebajas, y el resto de razas trabajan más a cambio.");
                    cCDialogue.Add("También han prohibido varias bebidas a algunas razas.");
                    cCDialogue.Add("Parece que sus cuerpos no soportan los ingredientes ilegales que llevan.");
                    cCDialogue.Add("Eso es menos dinero para mi por desgracia.");
                    cCDialogue.Add("Pero la multa será peor si me pillan.");
                    cCDialogue.Add("Recuerda revisar las normas, están a la izquierda de la pantalla.");
                    cCDialogue.Add("Buena suerte chico nuevo");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Lepion"))
                {
                    cCDialogue.Add("Hola humano.");
                    cCDialogue.Add("Espera, tu eres el tonto que no sabía contar.");
                    cCDialogue.Add("Ayer vino aquí ese microondas.");
                    cCDialogue.Add("Y ese cacharro debió darte una moneda más");
                    cCDialogue.Add("Al menos ahora puedo justificar su despido");
                    cCDialogue.Add("Aunque el bobo se puso a decir cosas de hacer el harakiri o cosas así.");
                    cCDialogue.Add("En fin, malditas máquinas japonesas.");
                    cCDialogue.Add("Ya que estás, cobrame esto, que debo seguir con mi trabajo de blanqueamiento de dinero.");
                    cCDialogue.Add("Adiós");
                    cCDialogue.Add("Ni contar sabes, ¿de verdad? Acabas de perder todos los clientes chinos por la zona, \n y espero que pronto pierdas tú el trabajo.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bon día amigo mío, espero que te esté yendo bien estos días.");
                    cCDialogue.Add("A mí el último plato del otro día no salió como me esperaba la verdad… Me salió... ¡PERFECTO! ");
                    cCDialogue.Add("Hice todos los pasos a la perfección, aunque el veneno le dió un toque picante un poco raro.");
                    cCDialogue.Add("Y fue un poco extraño cuando el plato empezó a hablarme en una lengua antigua, pero peores cosas he probado.");
                    cCDialogue.Add("Aún recuerdo cuando fui a un restaurante de elementales de roca, aunque obviamente el local era de un mago.");
                    cCDialogue.Add("El plato estrella era la gravilla, ese plato tenía una textura asquerosa.");
                    cCDialogue.Add("Era como comerte un castillo de arena derretido.");
                    cCDialogue.Add("Pero bueno, ahora preparé un plato mucho mejor, así que necesitaré estos ingredientes amigo mío.");
                    cCDialogue.Add("Gracias, te dejaré probarlo como quede bueno my besto frendo");
                    cCDialogue.Add("¿Tengo prohibidos estos deliciosos ingredientes? El reino cada vez acaba con la libertad de la comida.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Enano"))
                {
                    cCDialogue.Add("¡Hola pequeñín!");
                    cCDialogue.Add("Soy el grandioso Manolo Cabeza de Pico, el mago más rico… Del barrio más alto del reino.");
                    cCDialogue.Add("Creo que se me ha colado uno de mis gnomos defectuoso en la tienda.");
                    cCDialogue.Add("Se llama José Miguel Culo Escurridizo.");
                    cCDialogue.Add("El pobre no podía mantenerse quieto y se coló en la trampilla antes de turno.");
                    cCDialogue.Add("Aunque realmente me cae mal, no hace caso y no para de esconderse.");
                    cCDialogue.Add("Puede que si lo encuentras un par de veces esta semana se vaya contigo.");
                    cCDialogue.Add("Así me dejará en paz el pesado, suerte buscándolo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("¿Buenos días? ¿O noches? Ya no sé la verdad.");
                    cCDialogue.Add("Perdón, te habré confundido un poco, soy el del orbe el que habla.");
                    cCDialogue.Add("Por este maldito orbe solo puedo ver morado, no distingo si es de día o no.");
                    cCDialogue.Add("Me llamo Cululú, y hasta hace poco era un híbrido.");
                    cCDialogue.Add("Pero ahora soy un limbástico, me morí ayer mientras estaba en la gasolinera.");
                    cCDialogue.Add("Vi a un tío con un libro rarísimo que parecía hacer un ritual, y al verme, me dió un golpe con este orbe.");
                    cCDialogue.Add("Y al despertar, pues me quedé encerrado aquí, aunque supongo que esto no sea un problema para mi cita.");
                    cCDialogue.Add("El detective de mi caso me dijo que no fuera por ahora hasta que me acostumbrara a mi nuevo yo.");
                    cCDialogue.Add("Pero la vida es una, y esa manguro es mi tipo ideal.");
                    cCDialogue.Add("Pero bueno, espero que encuentren al culpable pronto para que no me atosigue el detective.");
                    cCDialogue.Add("Ve cobrando estas pociones, que en unos minutos tengo la cita.");
                    cCDialogue.Add("Muchas gracias hermano, deseame suerte en la cita.");
                    cCDialogue.Add("Tío, de verdad que no te entiendo, si tengo toda la pasta.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("¡Buen ser humano, necesito tu ayuda!.");
                    cCDialogue.Add("En mi casa se me han acabado las pilas y mi madre no estaba en casa para metermelas y darme energía.");
                    cCDialogue.Add("Por favor, necesito que me metas las pilas, ya te las pagaré luego. Recuerda meterlas en el hueco de la parte superior");
                    cCDialogue.Add("¡Y rápido!, que no quiero apagarme y convertirme en uno de esos horribles monstruos.");
                }
            }

            else if (currentScene.name == "Day2_2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Muchas gracias Ronin, que sepas que te lo recompensaré algún día, espero que mi maestro no se enfade.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("¡Hola colega! ¿Cómo te encuentras? ¿Bien? ¿Mal?");
                    cCDialogue.Add("¡YO ESTOY FENOMENAL!");
                    cCDialogue.Add("Soy Handy, el elemental más fiestero, que ama cualquier celebración.");
                    cCDialogue.Add("Cumpleaños, bodas, despedidas de solteros y… ¡FUNERALES!");
                    cCDialogue.Add("Aunque del último funeral me echaron por alguna extraña razón.");
                    cCDialogue.Add("Estoy tan emocionado amigo mío, tengo una nueva compañera.");
                    cCDialogue.Add("Se llama Rave-n, incluso estudió fiestología.");
                    cCDialogue.Add("Aunque a mí me expulsaron del grado de fiestología por mi TFG sobre… ¡ALEGRAR FUNERALES!");
                    cCDialogue.Add("Se debieron de morir de la risa con mi TFG.");
                    cCDialogue.Add("Bueno colega, sé que estás pasando un buen rato conmigo.");
                    cCDialogue.Add("Pero tengo una despedida de soltero y tengo que aguantar toda la noche despierto.");
                    cCDialogue.Add("Y necesito estos utensilios para sobrevivir a los solteros desesperados.");
                    cCDialogue.Add("Aunque no sé para qué será la bola, me la pidieron los solteros");
                    cCDialogue.Add("Bueno, cobrame porfi porfita.");
                    cCDialogue.Add("Voy a hacer una despedida de soltero !INCREÍBLE! Nos vemos colega.");
                    cCDialogue.Add("Me has borrado la sonrisa tío, pero entiendo que no puedas romper la normativa");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Petra"))
                {
                    cCDialogue.Add("Hola dependiente, de verdad que no puedo aguantar más mis ganas de empezar a trabajar.");
                    cCDialogue.Add("Necesito contárselo a alguien, ¡Por fin puedo ser una exploradora!");
                    cCDialogue.Add("Necesitaba soltarlo, no sabes lo emocionada que estoy con este nuevo trabajo.");
                    cCDialogue.Add("Por cierto, no me presenté, me llamo Petra.");
                    cCDialogue.Add("He estado 12 años en paro desde que no llegué a tiempo a una misión.");
                    cCDialogue.Add("Pero es lo que pasa cuando eres mitad tortuga y mitad liebre, que mi velocidad siempre será normal.");
                    cCDialogue.Add("También mi jefe me comentó que esperaba que lo hiciera mejor que el último empleado.");
                    cCDialogue.Add("Era un sapótamo que se la pasaba bebiendo en el trabajo.");
                    cCDialogue.Add("Menos mal que no bebo nada de alcohol en mi vida.");
                    cCDialogue.Add("Uy, perdona, te estoy quitando tiempo.");
                    cCDialogue.Add("Cobrame esto qué lo necesito para el trabajo.");
                    cCDialogue.Add("Deseame suerte en mi primer día de curro, ¡Nos vemos!");
                    cCDialogue.Add("Necesitaba esto de verdad para el trabajo, el jefe me va a despedir y ni empecé.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Hola humano, ¿no tienes días libres o que? ");
                    cCDialogue.Add("Eres parecido en ese aspecto a los elementales, nosotros tampoco paramos de trabajar, es lo que tiene ser creaciones de los magos. ");
                    cCDialogue.Add("Espera, ¿no lo sabías? La mayoría de las razas actuales fueron creadas por ellos. ");
                    cCDialogue.Add("Que triste es la ignorancia de los humanos. ");
                    cCDialogue.Add("Los elementales fueron creados para hacer el trabajo de esclavos. ");
                    cCDialogue.Add("Los tecnópedos fueron creados por accidente cuando metieron una varita en un microondas. ");
                    cCDialogue.Add("Y los limbásticos no se sabe cómo se crearon, solo se sabe que fueron los magos. ");
                    cCDialogue.Add("Leí en algunos foros de ocultismo que fueron creados por una iglesia que lleva años oculta entre nosotros.");
                    cCDialogue.Add("Tampoco pude leer mucho, es lo que tiene tener 23 horas de jornada laboral.");
                    cCDialogue.Add("Hablando de ello, en nada tengo que volver a trabajar como tapiz en un museo de la zona.");
                    cCDialogue.Add("Y encima tengo que explicar, de nuevo, al nuevo saco de huesos como va el trabajo allí.");
                    cCDialogue.Add("Le fue horrible en su primer día, aunque ya es horrible ser parte de nuestra raza.");
                    cCDialogue.Add("Por lo que ve cobrándome esto antes de que caiga en el olvido.");
                    cCDialogue.Add("Espero que acabe pronto mi jornada, aunque vaya a comenzar.");
                    cCDialogue.Add("Ni en mi descanso puedo conseguir un mínimo de felicidad.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Masermati"))
                {
                    cCDialogue.Add("Hola cocherrumín, estoy preparándome para la carrera del siglo.");
                    cCDialogue.Add("No me presenté, soy el famoso FMS, Faster More Serious.");
                    cCDialogue.Add("O como me llamo mi robo-madre, Masermati.");
                    cCDialogue.Add("Y voy a hacer la primera carrera de mi vida.");
                    cCDialogue.Add("Aunque espero que no sea la última, no sabes la pasta que cuestan estas mejoras.");
                    cCDialogue.Add("Los tubos de escape costaron solo 100 monedas.");
                    cCDialogue.Add("No sabes todos los platos que limpié para tener esa cantidad de monedas.");
                    cCDialogue.Add("Pero todo este trabajo fue necesario para el día de hoy, para ganar a…");
                    cCDialogue.Add("¡FLECHA RÁPIDA! El tecnópedo más rápido del reino.");
                    cCDialogue.Add("Es el coche oficial de Pijus Magnus, el 2º mago más poderoso del reino.");
                    cCDialogue.Add("O eso dice él, aunque solo lo dice por ser hijo del Rey Mago.");
                    cCDialogue.Add("Realmente es un tirillas enano, espero que tengas suerte de no encontrarlo.");
                    cCDialogue.Add("Bueno, cobrame humano, que tengo que estar listo para la carrera.");
                    cCDialogue.Add("Gracias cocherrumín, voy a prepararme para la carrera.");
                    cCDialogue.Add("¡Pero si tengo suficiente! Da igual, tengo algo de prisa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Pijus"))
                {
                    cCDialogue.Add("Tú ve cobrando esto que tengo prisa.");
                    cCDialogue.Add("Espera-");
                    cCDialogue.Add("¡¿Eres humano?! ¿No te da vergüenza respirar el mismo aire que yo?");
                    cCDialogue.Add("No se ni como pagaste lo suficiente para entrar al reino.");
                    cCDialogue.Add("Y más te vale que me cobres bien, he leído lo del 50%.");
                    cCDialogue.Add("Así que quiero que me lo rebajes T-O-D-O.");
                    cCDialogue.Add("Y como me cobres mal tendré que usar mis poderosa habilidad…");
                    cCDialogue.Add("El número de mi papi.");
                    cCDialogue.Add("Espero que me cobres bien, venga.");
                    cCDialogue.Add("Así me gusta humano, no sabía qué os habían enseñado a contar allí.");
                    cCDialogue.Add("¡Cómo que no sirve la oferta! Pues...Pues…Bonita moneda, me la quedo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Hola dependiente, soy del departamento de investigación de sucesos paranormales, es decir, soy detective.");
                    cCDialogue.Add("Y tenía una pregunta respecto a un caso sobre homicidio, alguien ha vuelto un híbrido a un limbástico.");
                    cCDialogue.Add("Un poco pesado el fiambre diciendo que tenía una cita, pero me da a mi que va a tener que esperar.");
                    cCDialogue.Add("Creemos que ha podido ser un artefacto mágico el culpable, en concreto un libro de magia.");
                    cCDialogue.Add("¿Sabes de algún clientes pueda tener un libro mágico?");
                    cCDialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");
                }
            }

            else if (currentScene.name == "Day3_1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenas chico nuevo.");
                    cCDialogue.Add("Parece que te estás acostumbrando a tu trabajo.");
                    cCDialogue.Add("Estás durando más que el antiguo empleado.");
                    cCDialogue.Add("No sé cómo sigues vivo siquiera.");
                    cCDialogue.Add("Pero bueno, tengo malas noticias.");
                    cCDialogue.Add("Ha empezado el mercado de una nueva raza: Los Cupones");
                    cCDialogue.Add("Son criaturas que se utilizan como trueque a cambio de objetos.");
                    cCDialogue.Add("Con los cupones podrán pillar lo que quieran, ¡LES SALDRÁ GRATIS!");
                    cCDialogue.Add("Vaya asco de bichos, al menos son muy coquettes.");
                    cCDialogue.Add("Debajo de tu pantalla tendrás una retrato de los cupones que son válidos.");
                    cCDialogue.Add("Cuidado que no te traigan ninguno falso, fijate bien el retrato.");
                    cCDialogue.Add("Y recuerda revisar las normas, no servirá su cupón si tiene prohibido algún objeto.");
                    cCDialogue.Add("Suerte humano.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sergio"))
                {
                    cCDialogue.Add("Hola joven humano, disculpa la impertinencia, pero deberían de bajar el peso de esas bebidas.");
                    cCDialogue.Add("No sabes lo que pesan esas malditas latas.");
                    cCDialogue.Add("No tengo fuerza ni para levantarlas.");
                    cCDialogue.Add("En mis tiempos, cuando era conocido como Sergio Nervisous.");
                    cCDialogue.Add("Era capaz de levantar piedras y tenía unos nervios de acero.");
                    cCDialogue.Add("Pero ahora suficiente que aguanto este cubo en mi cabeza.");
                    cCDialogue.Add("Y encima me ha revivido un mago que dice que es un héroe.");
                    cCDialogue.Add("Se hace llamar Geeraard, que nombre más raro para un héroe.");
                    cCDialogue.Add("Me revivió para que le ayudará en su nueva aventura.");
                    cCDialogue.Add("¡Pero si no soy capaz ni de levantar una espada de verdad!");
                    cCDialogue.Add("Con lo bien que estaba en mi tumba.");
                    cCDialogue.Add("Necesito recuperar mis nervios, así que, cobrame estas bebidas.");
                    cCDialogue.Add("Seguro revive mi fuerza.");
                    cCDialogue.Add("Voy a intentar que esto me despierte como es debido.");
                    cCDialogue.Add("¿Está prohibido venderme esto? En mis tiempos, bebíamos esto sin problema.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Salta"))
                {
                    cCDialogue.Add("Hola… Hola… Humano .");
                    cCDialogue.Add("Maldito cacharro, no ir como yo querer.");
                    cCDialogue.Add("Llevo desde ser zanahorio con esta silla, y aún fallar.");
                    cCDialogue.Add("Yo ser Saltaralisis y querer cambiar runas de una vez.");
                    cCDialogue.Add("Sí no cambiar runas, no hablar bien y crear malentendidos.");
                    cCDialogue.Add("Ya pasar otro día en banco, y cuando yo decir nombre, romper runa.");
                    cCDialogue.Add("Así que repetir palabra ASALTAR todo rato.");
                    cCDialogue.Add(" Ellos llamar guardia y yo acabar en cárcel 3 días.");
                    cCDialogue.Add("Duros días, pero conocer gente maja en cárcel.");
                    cCDialogue.Add("Yo conocer…Yo conocer…Yo conocer… Sapótamo borracho.");
                    cCDialogue.Add("Vuelve a fallar, mejor cobrar para cambiar runas.");
                    cCDialogue.Add("Gra… Gra… cías, cambiar runas ahora.");
                    cCDialogue.Add("No…No…. Poder cambiar, crear más mal entendidos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola mortal, ¿No habrás visto un libro mágico alguno de estos días?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Llevo días buscando un libro que se me fue robado, es importante ¿sabes?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("El habla no parece ser tu punto fuerte mortal.");
                    cCDialogue.Add("Pero bueno, haré que ese ladrón recuerde mi nombre, Manolo Mago Manitas.");
                    cCDialogue.Add("Por su culpa y la del otro calamar no se pudo terminar el ritu…");
                    cCDialogue.Add("Si ves a alguien con libro mágico, avisame mortal.");
                    cCDialogue.Add("Puede que vuelva en algún otro momento, pero primero debo atender a mi deber.");
                    cCDialogue.Add("Tengo que volver a mi iglesia, hay que dar la misa para nuestro dios, Azathoth.");
                    cCDialogue.Add("Por lo que ve cobrandome mortal.");
                    cCDialogue.Add("Buen chico, nos vemos mortal.");
                    cCDialogue.Add("Parece que eres otro sacrificio más, Azathoth te maldecirá por tu incompetencia.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Raven"))
                {
                    cCDialogue.Add("¡Hola amigo mío! ¿No es un día maravilloso?");
                    cCDialogue.Add("Aunque ni he dormido, pero trabajar como DJ Rave-n siempre me llena de energía.");
                    cCDialogue.Add("Tuve que trabajar en una despedido de soltero, los chicos fueron muy majos.");
                    cCDialogue.Add("Pero mi compañero Handy lo pasó un poco mal la verdad.");
                    cCDialogue.Add("El soltero se encariñó con el pobre Handy, era un limbástico muy cariñoso.");
                    cCDialogue.Add("Pero bueno, me alegró de que al menos haya podido poner mi música.");
                    cCDialogue.Add("Porque la música de hoy en día es digamos… Demasiado triste y oscura.");
                    cCDialogue.Add("El grupo Tears of Limbastics es super triste, malditas canciones emos.");
                    cCDialogue.Add("¡Sí lo mejor es el grupo Magicians of Power, tiene canciones super divertidas! ");
                    cCDialogue.Add("Pero parece que la sociedad se está deprimiendo cada vez más.");
                    cCDialogue.Add("Aún así, intentaré alegrar al mundo con mis canciones.");
                    cCDialogue.Add("Pero para ello, necesito recargar pilas colega, que quiero recargar.");
                    cCDialogue.Add("Cobrame esto si puedes porfi.");
                    cCDialogue.Add("Gracias compi, ahora iré a descansar para deslumbrar esta noche más.");
                    cCDialogue.Add("No podré recargar pilas colega… Este será un día con más canciones emos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Hueso"))
                {
                    cCDialogue.Add("Chaval, casi me hago polvo arriba esperando, además tengo prisa.");
                    cCDialogue.Add("Estoy en la nueva exposición de dinosaurios de la ciudad.");
                    cCDialogue.Add("Y cuando digo que estoy, es que literalmente estoy.");
                    cCDialogue.Add("Debido a que tengo huesos de hace millones de años.");
                    cCDialogue.Add("Un mago arqueólogo me creó y como quedé tan raro, no se dignó ni en darme nombre.");
                    cCDialogue.Add("Literal me llamo Elemental de Hueso el elemental de huesos.");
                    cCDialogue.Add("Por suerte logré valerme por mi solo, y ahora obtuve un trabajo de verdad.");
                    cCDialogue.Add(" Ser esclavizado por un museo, muchos de mi raza desearían este puesto en vez de la mina.");
                    cCDialogue.Add("Pero bueno, cobrame chaval, que tienen que verme en el museo.");
                    cCDialogue.Add("Un poco caro el muñeco, pero hace años ese muñeco antes eran 3 esclavos elementales, gracias.");
                    cCDialogue.Add("Pero si las pociones las bebían hasta los dinosaurios, estúpidas normátivas.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Patxi"))
                {
                    cCDialogue.Add("No sé cómo mi hombre está tan ocupado, maldita programación. ");
                    cCDialogue.Add("Y siempre tan apagado, le están chupando el alma a mi Antonio. ");
                    cCDialogue.Add("Ay ay ay, Antonio mío deja la programa...");
                    cCDialogue.Add("¡¿Usted quién es?!  Espera que ya es mi turno.");
                    cCDialogue.Add("Me había olvidado que estaba en la cola mientras deliraba con mi Antonio.");
                    cCDialogue.Add("Es mi querido noviecito, curra más que un elemental en las minas.");
                    cCDialogue.Add("Y yo soy el mejor novio que se ha tenido, Patxi.");
                    cCDialogue.Add("El pobre trabaja de programador, mientras que yo soy corredor de bolsa.");
                    cCDialogue.Add("Solo tengo que correr con unas bolsas, es un buen trabajo para un limbástico.");
                    cCDialogue.Add("Y ya que su trabajo es tan complicado quiero hacerle algo especial…");
                    cCDialogue.Add("Quería prepararle una cena romántica esta noche, así que si puedes cobrarme esto.");
                    cCDialogue.Add("Mi Antonio va a perder la cabeza con esta cena, perdona, se me pegaron sus chistes.");
                    cCDialogue.Add("Enemigo del romanticismo, mi Antonio no va a disfrutar mi cena para relajarse.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("¡COLEGA, TE NECESITO DE VERDAD!");
                    cCDialogue.Add("HAN PROHIBIDO LAS CERVEZAS A LOS HÍBRIDOS");
                    cCDialogue.Add("EMPECÉ A HABLAR BIEN DE NUEVO");
                    cCDialogue.Add("HASTA ME LLEGÓ UNA SOLICITUD DE EMPLEO");
                    cCDialogue.Add("NO QUIERO VOLVER A TRABAJAR");
                    cCDialogue.Add("Y MENOS CON ESA TAL PETRA QUE ME QUITÓ EL TRABAJO");
                    cCDialogue.Add("¡ME NIEGO!");
                    cCDialogue.Add("TE DARÉ EL DINERO QUE NECESITES");
                    cCDialogue.Add("PERO NE-CE-SI-TO CERVEZA ");
                    cCDialogue.Add("¡TE QUIERO MUCHO COLEGA! ");
                    cCDialogue.Add("Hasta mi dependiente favorito…Adiós a Elvog Borracho");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Enano"))
                {
                    cCDialogue.Add("¡Hola pequeñín! No te había visto desde ahí abajo.");
                    cCDialogue.Add("Me sobra el dinero, para nada entré aquí por el 50% de descuento en magos.");
                    cCDialogue.Add("O incluso podría ser un 70% ahora que somos amigos.");
                    cCDialogue.Add(" Vale vale, no me mires con esa cara impasible, pero venga…");
                    cCDialogue.Add("Te prometo que te devolveré el dinero si me lo rebajas más.");
                    cCDialogue.Add("Por ejemplo, mi vecino aún me dice que le debo 2000 monedas y que deje de evitarlo.");
                    cCDialogue.Add("Pero, por favor, yo no lo evito por la deuda, lo evito para ahorrarme esas 2000 monedas.");
                    cCDialogue.Add("Creo que no debí decir eso…Bueno, mejor ve cobrando antes de que la lié más.");
                    cCDialogue.Add("Menos mal me he ahorrado esas monedas, así podré mantener mi enorme mansión durante 1 hora más.");
                    cCDialogue.Add("¿No tengo dinero ni con el 50% de rebaja? Me va a tocar embargar la casa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Hola de nuevo, venía a comprar…");
                    cCDialogue.Add("¡Pero qué, otra vez no!");
                    cCDialogue.Add("Estúpida batería rota, hace 1 segundo tenía batería de sobra y ahora de un momento a otro se pone en crítico mi energía.");
                    cCDialogue.Add("¡Necesito que me metas las baterías otra vez, y está vez ten cuidado con el agua!");
                }
            }

            else if (currentScene.name == "Day3_2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji") && vecesSamuraiAyudado < 2)
                {
                    cCDialogue.Add("Ufff, por los pelos, estupida batería, creo que está algo rota por estos sustos que me da");
                    cCDialogue.Add("Espero que esta deshonra no llegue a los oídos de mi maestro, muchas gracias humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji") && vecesSamuraiAyudado >= 2)
                {
                    cCDialogue.Add("Ufff, por los pelos, estupida batería, creo que está algo rota por estos sustos que me da");
                    cCDialogue.Add("Toma, quedate con mi espada legendaria \n cómo agradecimiento. Cuidala bien, la han tocado muchos \n más seres anteriores a ti.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rustica"))
                {
                    cCDialogue.Add("Hola cielo, se te vé algo cansado, ¿estás bien?");
                    cCDialogue.Add("Seguro que estás así por el trabajo, llevo años viniendo aquí y sé bien cómo os trata el jefe.");
                    cCDialogue.Add("Igual es un chico bueno aunque sea un poco avaricioso, egocéntrico, egoísta y explotador laboral.");
                    cCDialogue.Add("Todo el mundo tiene el lado bueno, lo sé bien con todos los años que he pasado viva. ");
                    cCDialogue.Add("Fuí de los primeros técnopedos, de ahí mi nombre, Rústica.");
                    cCDialogue.Add("Trabaje en varios sitios, uno de mis favoritos fue de camarera.");
                    cCDialogue.Add("En un bar muy elegante, creo que se llamaba Hell Fire Bar.");
                    cCDialogue.Add("Siempre había alguna que otra pelea entre amigos, o pequeñas peleas de bandas.");
                    cCDialogue.Add("Alguna vez nos pintaban las paredes con latas de spray, eran buenos chicos en el fondo.");
                    cCDialogue.Add("Fue una buena época… Disculpa cielo que me voy por las nubes.");
                    cCDialogue.Add("Cobrame esto, así voy tirando a la chatarrería a echar unas cartas con mis amigas.");
                    cCDialogue.Add("Gracias cariño, espero no llegar tarde a la chatarrería.");
                    cCDialogue.Add("¿Mi cupón está roto? Perdón cariño.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Buenos días dependiente, veo que ha sido un día ajetreado.");
                    cCDialogue.Add("Ayer mandamos al Detective León a investigar a los sospechosos de ayer, al parecer Giovanni sabe cosas.");
                    cCDialogue.Add("Tuvo en posesión un libro de magia ancestral, que fue prohibida hace siglos aunque se desconoce que hace.");
                    cCDialogue.Add("Nos comentó que se le encontró de camino de la gasolinera donde trabaja el fiambre la misma noche.");
                    cCDialogue.Add("Tras varias comprobaciones supimos que era cierto y que no puede ser el culpable.");
                    cCDialogue.Add("Aunque ahora tenemos alguna pista más, un cliente de esta tienda usó una bola de cristal en el ritual.");
                    cCDialogue.Add("Y que la compró bajo el nombre de “Manolo”, según un ticket tirado por la escena del crimen.");
                    cCDialogue.Add("¿Sabes si alguno de los siguientes sospechosos pueda tener relación con la descripción que te dí?");
                    cCDialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");

                }
            }

            else if (currentScene.name == "Day4")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola chico nuevo, veo que te estás acostumbrando al trabajo en mi tienda.");
                    cCDialogue.Add("Que raro que ningún mago te la haya arrancado la cabeza por negarte a cobrarle, al anterior dependiente le pasó eso.");
                    cCDialogue.Add("Aunque gracias a ese mago, no tuve que pagarle ese mes.");
                    cCDialogue.Add("Así acabé comprando el carruaje más rápido del reino, aunque se quedó obsoleto por culpa de los coches.");
                    cCDialogue.Add("Por culpa de esas estúpidas máquinas de 4 ruedas, los tecnópedos no podrán comprar pilas y bebida energética junta, por una reacción que los hace más rápidos.");
                    cCDialogue.Add("Se lo tienen merecido por hacerme gastar mis preciosas monedas en un carruaje que quedó obsoleto.");
                    cCDialogue.Add("Y también me enteré hace poco que hay una secta convirtiendo híbridos en limbásticos.");
                    cCDialogue.Add("Por lo que los híbridos no podrán comprar nada de magia negra, esa secta solo me ha hecho perder dinero.");
                    cCDialogue.Add("Bueno, es hora de que empiece tu turno, recuerda mirar las nuevas normas.");
                    cCDialogue.Add("Suerte humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jissy"))
                {
                    cCDialogue.Add("¿Qué pasa tío?¿Cómo estamos?");
                    cCDialogue.Add("Espera, tu… Tu no eres el de el otro día ¿no..?");
                    cCDialogue.Add("Yo  soy Jeese, Jeese Chemman, mi nombre de las calles tío.");
                    cCDialogue.Add("Perdona tronco pero, ¿Seguro que no eres el dependiente de siempre?");
                    cCDialogue.Add("Nunca se me ha dado bien esto de reconocer a la gente, ¿sabes?");
                    cCDialogue.Add("Pero tienes un parecido al anterior dependiente.");
                    cCDialogue.Add("Aunque creo que el anterior no era humano, era un raza superior ¿sabes?");
                    cCDialogue.Add("Espero que no te afectará el comentario, tampoco se me da bien socializar.");
                    cCDialogue.Add("En fín, espero que te vaya bien.");
                    cCDialogue.Add("Ah, sí, pero antes de irme, cobrame esto.");
                    cCDialogue.Add("Que me iba sin pagar ¿sabes?");
                    cCDialogue.Add("Gracias colega, deberíamos quedar algún día para hablar de la vida ¿sabes?");
                    cCDialogue.Add("Bueno tronco, no sé cómo no aceptas mi dinero, deberías mejorar en el trabajo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mara"))
                {
                    cCDialogue.Add("Uy, buenos días cielo, se nota que eres un buen trabajador.");
                    cCDialogue.Add("Debería de tomar ejemplo de ti, que me hubiera venido mejor trabajar en vez de ir a la horrible cita del otro día.");
                    cCDialogue.Add("Para una vez que decido volver a darle a un intento al amor, y con el tiempo que le dediqué a mi cuenta de Hybrinder.");
                    cCDialogue.Add("Llegué al pequeño local limbásticos, con mis patas raptoriales recién afiladas, y el tipo resultó no ser un híbrido.");
                    cCDialogue.Add("Ni siquiera su cabeza se veía apetitosa, tenía una pedazo de esfera en su cabeza.");
                    cCDialogue.Add("Igualmente accedí a cenar con él, aunque me hubiera engañado de esta manera.");
                    cCDialogue.Add("Nada más me separé de él, le bloqueé de todos lados, espero no verlo más en mi vida.");
                    cCDialogue.Add("Mi pata de la suerte seguro dejó de funcionar, es la de mi ex marido.");
                    cCDialogue.Add("Siempre la llevo en mi bolso, pero dejaré de usarla");
                    cCDialogue.Add("Perdona si te aburriste con mi historia querido, cóbrame que tengo que ir a más tiendas querido.");
                    cCDialogue.Add("Gracias cielo, quédate con mi pata de la suerte, no creo que la necesite más.");
                    cCDialogue.Add("Gracias cielo, espero nunca que no tengas citas como la mía.");
                    cCDialogue.Add("¿Está prohibido esto? Bueno, ayer vi varias personas comprándolo, que raro.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("Buenos días mi dependiente favorito, ¿no es preciosa la vida?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Veo que mi pregunta te dejo mudo al igual que yo cuando veo a mi nueva diosa.");
                    cCDialogue.Add("La cita del otro día no sólo fue genial, fue perfecta.");
                    cCDialogue.Add("Cuando la ví, quedé perdido en su ojos de mantis, y no paraba de querer acariciar sus preciosas y afiladas garras.");
                    cCDialogue.Add("Obvio fuí un caballero y no me atreví a tocar sus hermosas garras.");
                    cCDialogue.Add("Además de que no quería perder mi mano.");
                    cCDialogue.Add("Pero bueno, lo mejor de la cita fue cuando nos sentamos juntos y cenamos.");
                    cCDialogue.Add("Y esa cangumantis me dijo 10 palabras, ¡10 PALABRAS!");
                    cCDialogue.Add("Solo una hembra me había dicho más palabras que esas, mi madre.");
                    cCDialogue.Add("Mis palabras favoritas fueron / ¿Pagas tu, no ? / Quiso que pagara yo, qué romántico");
                    cCDialogue.Add("Tengo pensado decirle de tener otra cita, y creo que esto de aquí será necesario para la cita, así que si pudieras cobrarme.");
                    cCDialogue.Add("Te informaré sobre mi próxima cita, mi dependiente favorito.");
                    cCDialogue.Add("Tú, enemigo del amor, gracias por arruinar mi cita.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sergio"))
                {
                    cCDialogue.Add("Hola humano, ¿podrías ayudarme?");
                    cCDialogue.Add("He decidido no ir a la misión del mago raro que me invocó.");
                    cCDialogue.Add("No sé quién se cree para ir reviviendome sin mi permiso.");
                    cCDialogue.Add("Bueno, al caso, necesito 3 bebidas energéticas para activar mi 100%");
                    cCDialogue.Add("Y así escapar del reino con mi super energía, o eso ponía en internet sobre esta bebidas.");
                    cCDialogue.Add("Que me dices, ¿me ayudas?");
                    cCDialogue.Add("Gracias por tu ayuda, tendrás una recompensa, te daré mi legendaria espada, ¡LA GLOBOSPADA!");
                    cCDialogue.Add("Sabía que me ayudarías, suerte humano.");
                    cCDialogue.Add("¿De verdad? Qué poco corazón");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Elidora"))
                {
                    cCDialogue.Add("Hola súbdito, ¿No crees que deberías de dejar de atender en este sótano?");
                    cCDialogue.Add("Casi uno de mis fieles slimes se deshace por culpa de la caída.");
                    cCDialogue.Add("Y no sabes el precio que hubieras tenido que pagar por mi slime.");
                    cCDialogue.Add("Podría haberte nombrado mi nueva silla oficial… La única silla del Reino Slime.");
                    cCDialogue.Add("Mi gran y poderoso reino de 4 habitantes slimes, donde yo soy la reina.");
                    cCDialogue.Add("LA PODEROSA REINA MAGA ELIDORA LIMALIGNA.");
                    cCDialogue.Add("La reina más poderosa de todos los reinos.");
                    cCDialogue.Add("Aunque aún estoy con los papeles para volver mi reino oficial.");
                    cCDialogue.Add("Creo que te dejaré unirte a mi reino si me muestras tu gran habilidad atendiendo clientes.");
                    cCDialogue.Add("¿Qué me dices?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Ya veo que te he sorprendido tanto que te he dejado sin habla.");
                    cCDialogue.Add("Venga muestrame tus habilidades cobrando.");
                    cCDialogue.Add("Te haré el dependiente oficial… Nada más terminar con el papeleo, adiós humilde súbdito");
                    cCDialogue.Add(" En Reino Slime sirven estos cupones, adiós humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard") && noCobrarSergioCobrarGeeraardD4 == 0)
                {
                    cCDialogue.Add("¡Humano, que le vendiste a mi limbástico!");
                    cCDialogue.Add("Con lo que me costó convencer a la iglesia para invocarlo.");
                    cCDialogue.Add("No sabes lo difícil que fue encontrar a ese mago mano.");
                    cCDialogue.Add("Y por no hablar de los ingredientes para revivirlo, fueron muy costosos.");
                    cCDialogue.Add("Serás… Claro, esto es lo que pasa por dejar a un humano trabajar.");
                    cCDialogue.Add("Has perdido un cliente, ¡PARA SIEMPRE!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard") && noCobrarSergioCobrarGeeraardD4 != 0)
                {
                    cCDialogue.Add("Hola humano, espero que en estos días te hayas leído una de miles historias.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Tu mirada me dice que no es así, ¿Es que no tienes tiempo para leer en casa?");
                    cCDialogue.Add("Eres de los peores fans que he tenido en mi vida.");
                    cCDialogue.Add("Espero que leas al menos una antes de que escriban mi nueva historia: La caza del collar de Sin Cuello.");
                    cCDialogue.Add("Mañana mismo partiré camino del reino junto con mi nuevo compañero.");
                    cCDialogue.Add("Es un limbástico que reviví con ayuda de un mago mano un poco extraño.");
                    cCDialogue.Add("Al parecer es el único tipo del reino que sabe hacer limbásticos, y yo que pensaba que revivían solos");
                    cCDialogue.Add("Bueno, como decía de mi compañero, dicen que cuando estaba vivo tenía unos nervios de acero.");
                    cCDialogue.Add("Así que por eso solo revivimos su sistema nervioso y su cerebro.");
                    cCDialogue.Add("Espero que sea tan capaz como yo, aunque se le ve un poco tirillas.");
                    cCDialogue.Add("En fin, necesitaré algunos materiales para el viaje, y esta tienda tiene suerte de ser mi proveedora no oficial.");
                    cCDialogue.Add("Por lo que tendrás el honor de cobrarme, y con suerte recibirás un autógrafo mio.");
                    cCDialogue.Add("Deséame suerte en mi aventura, te daré mi foto favorita con un autógrafo, por tu humilde servicio.");
                    cCDialogue.Add("Deséame suerte en mi aventura, aunque no la necesite.");
                    cCDialogue.Add("Por todo lo que he hecho por el reino, y me lo pagan así.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Magma"))
                {
                    cCDialogue.Add("Buenas mañanas persona fría, soy Magmadora.");
                    cCDialogue.Add("Frío de personalidad o frío de carne, tú dirás, solo tienes que mirarme.");
                    cCDialogue.Add("Veo que no eres el mismo trozo de carne fría que había antes en este lugar.");
                    cCDialogue.Add("Haber si llega ya el maldito verano que yo soy de los que prefiere el calor, sino mira como estoy que ardo.");
                    cCDialogue.Add("De verdad que la gente que prefiere el frío no la entiendo.");
                    cCDialogue.Add("Si no estuvieras hecho de carne, también preferirías el calor.");
                    cCDialogue.Add("Ventajas de no poder sudar.");
                    cCDialogue.Add("En fin, ¿Te importaría cobrarme esto? Que me estoy quedando sin llama y tengo que avivarme un poco.");
                    cCDialogue.Add("Gracias, espero que cuando termine de trabajar no se enfríe de camino a casa.");
                    cCDialogue.Add("¿Cómo que han prohibido comprar pociones? ¡AHORA CÓMO PODRÉ COMPRAR MI POCIÓN DE LAVA!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("Dependiente... Hoy no podría ser... ¡LA MEJOR SEMANA DE MI VIDA!");
                    cCDialogue.Add("El trabajo del otro día fue genial, los solteros fueron encantadores.");
                    cCDialogue.Add("Les encantó cuando me puse a hacer mi monólogo.");
                    cCDialogue.Add("Y mi compañera es una DJ genial, en el momento de las copas salió a hacer su parte.");
                    cCDialogue.Add("Baile con el novio un rato, pero no paraba de tocar mi bocina, era un tipo raro.");
                    cCDialogue.Add("Pero bueno, ahora tenemos un nuevo trabajo para hoy, una gatoteca.");
                    cCDialogue.Add("Hemos pensado en animar haciendo un musical con los gatos, pero son unos bichos muy ariscos y arrítmicos.");
                    cCDialogue.Add("Así que hemos pensado en otra cosa, vamos a bollos con forma de gatito.");
                    cCDialogue.Add("En fin, sabes que me encanta estar contigo, pero se me está haciendo tarde amigo.");
                    cCDialogue.Add("Por lo que cóbrame que tengo que alegrar esa gatoteca.");
                    cCDialogue.Add("Gracias amigo, como muestra de nuestra amistad, el traje que usé en la despedida de soltero.");
                    cCDialogue.Add("Deséame la mayor de las suerte en mi nuevo trabajo.");
                    cCDialogue.Add("Espero que el trabajo me vaya bien igualmente");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Buenos días chico… Eres el del otro día ¿no?");
                    cCDialogue.Add("Tengo mala memoria, debe ser porque siempre pierdo la cabeza, ja ja ja...");
                    cCDialogue.Add("Sabía que eras tú, aún recuerdo el vacío que dejabas cada vez que contaba mi mejor chiste.");
                    cCDialogue.Add("Entonces tengo la confianza de decirte que me gustaría hacer un regalo a mi novio Patxi.");
                    cCDialogue.Add("Ayer me hizo una cita y quiero hacer algo a cambio, pensé en proponerle hacer senderismo.");
                    cCDialogue.Add("Pero con lo lento que voy y lo rápido que va él, seguro no lo disfrutamos igual, por eso me decanté por la opción del regalo.");
                    cCDialogue.Add("Espero que le guste este gato muerto, seguro que le recuerda a Mistafurriño.");
                    cCDialogue.Add("Era su gato cuando estaba vivo, y puede que quiera algo que le recuerde a él.");
                    cCDialogue.Add("Cóbrame por favor que tengo que envolver el regalo.");
                    cCDialogue.Add("Espero que le guste este regalo.");
                    cCDialogue.Add("Ahora que le regalo yo a mi Patxi.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola humano, hoy no vengo como cliente, sino como testigo de Azathoth.");
                    cCDialogue.Add("¿Has reconsiderado acercarte a mi iglesia?");
                    cCDialogue.Add("Últimamente aceptamos a varios humanos para que se unan a rezar con nosotros, siempre vienen nuevos.");
                    cCDialogue.Add("Aunque hace poco comprobamos que los híbridos también son “bienvenidos” a nuestra religión.");
                    cCDialogue.Add("Transformamos a uno de ellos en uno de los nuestros... Fue simplemente arte.");
                    cCDialogue.Add("Pero bueno, solo me acercaba por aquí para que reconsideraras la oferta, siempre te daremos una mano.");
                    cCDialogue.Add("Suerte en la tienda, humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Buenos días humano, la investigación se está alargando bastante.");
                    cCDialogue.Add("Puede que no lo sepas, pero este caso se empezó porque estamos buscando a quién está creando limbásticos.");
                    cCDialogue.Add("Los limbásticos son incapaces de recordar dónde les crearon, pero con algo de investigación encontramos algo.");
                    cCDialogue.Add("Un sospechoso de ayer parece formar parte de una religión de la que desconocemos.");
                    cCDialogue.Add("Y creemos que pueden estar relacionados con la creación de limbásticos.");
                    cCDialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                    cCDialogue.Add("Creemos que el sospechoso se reunió con otro cliente de esta tienda para hacer un limbástico.");
                    cCDialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                    cCDialogue.Add("Creemos que el sospechoso se reunió con otro cliente de esta tienda para hacer un limbástico.");
                    cCDialogue.Add("¿Sabes si alguno de los siguientes sospechosos se relacionó con la iglesia?");
                    cCDialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");
                }
            }

            else if (currentScene.name == "Day5")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola humano, ¿Sabes que hoy es un día especial?");
                    cCDialogue.Add("Es el primer día del año que no tenemos nuevas normas, ¡ASÍ PODRÉ TENER MÁS DINERO!");
                    cCDialogue.Add("Y al ser un día tan especial, te daré un trato especial.");
                    cCDialogue.Add("Revisaré cómo trabajaste por mis cámaras… Digo con mis poderosas habilidades mentales.");
                    cCDialogue.Add("Y si lo has hecho muy bien, seguirás trabajando aquí, o al menos espero que puedas pagarte la maldita documentación.");
                    cCDialogue.Add("Como no hayas ganado suficiente dinero, ¡TE QUEDAS SIN LA DOCUMENTACIÓN!");
                    cCDialogue.Add("Pero bueno, confío que hayas sido un buen trabajador.");
                    cCDialogue.Add("Suerte en el que espero que no sea tu último día.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Elidora"))
                {
                    cCDialogue.Add("Hola humano, vengo defraudada de lo mal hecho que está este reino.");
                    cCDialogue.Add("Fuí al famoso restaurante de “Tips”, y no dejaron pasar a mis humildes ciudadanos esclavos de slime.");
                    cCDialogue.Add("Alguna híbrido debió hacer esas normas tan tontas, ¿Cómo no van a permitir criaturas mágicas?");
                    cCDialogue.Add("Y lo peor es la DECADENCIA del lugar, me obligaron a sentarme en una silla en vez de en mi slimes.");
                    cCDialogue.Add("Y porqué no hablar del servicio, casi tuve que cazar a los camareros, cómo un oságuila a un salmón.");
                    cCDialogue.Add("Le voy a poner una estrella en TripKingdom a ese maldito sitio.");
                    cCDialogue.Add("Seguro no me atendían como debían por ser la reina del reino slime, esos híbridos magofóbicos.");
                    cCDialogue.Add("Menos mal que en mi reino no excluimos a nadie, excepto a los híbridos a partir de este mal servicio.");
                    cCDialogue.Add("Haré un restaurante llevado por slimes que lo harán mejor que esos inútiles.");
                    cCDialogue.Add("Bueno, humano cóbrame que tengo que empezar con la edificación de mi reino.");
                    cCDialogue.Add("Bien hecho humano, si se te da tan bien cobrar, seguro también se te da bien ayudarme con las obras de mi reino.");
                    cCDialogue.Add("Estúpido humano, menos mal que mis dependientes slimes serán más listos que tú.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rockon"))
                {
                    cCDialogue.Add("Ho-hola amigo, ¿qué tal tu-tu-tu día de hoy?");
                    cCDialogue.Add("Seguro que fue un día pri-pri-edrástico, como decimos chicos piedras.");
                    cCDialogue.Add("Tenemos muchas expresiones ra-raras gracias a mis primos roca, son de pueblo cerrado.");
                    cCDialogue.Add("Además de que son chicos fuerte como mi padre, dicen que son “Gymbros”.");
                    cCDialogue.Add("Debería de ir al “Muscle Beluga” para me-mejorar mis músculos, es el mejor gimnasio del reino.");
                    cCDialogue.Add("Así igualaría la fuerza de mis primos y podría ayudar a mi padre en su restaurante.");
                    cCDialogue.Add("Él está como esclavo en el “Tips” del reino, es el mejor sitio para comer.");
                    cCDialogue.Add("Aunque cada día le tocan clientes más desagradables, fue una ma-maga que quería pasar a unos slimes.");
                    cCDialogue.Add("Se nota que no sabe lo que cuesta limpiar la baba de esas po-pobres criaturas.");
                    cCDialogue.Add("Se-seguro que estoy haciendo mucha cola, cóbrame amigo.");
                    cCDialogue.Add("Gra-gracias, espero le gusten estos peluches con forma humana a mi padre.");
                    cCDialogue.Add("Me falta di-dinero, jopetas, perdón por intentar engañarte con el cupón.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Buennnasss *hip* Tú…Tú…  Ahí está miii dependiente favorito.");
                    cCDialogue.Add("Erres el mejor, tíoooo, gracias a tí no tengo trabajarrr más, er jefe me ha visto borracho, de nuevo.");
                    cCDialogue.Add("Ahorra seguirré con mi increíble vida jubeniiiil, eres er único capaz de entenderme*hip*");
                    cCDialogue.Add("Te invitarría a una birra, pero no sé que bebeís los hurmanos, tenéis pinta de beberrrr Carrimocho.");
                    cCDialogue.Add("No parreceis bebedores fuertes como yo, mi hígado y yo segurro somos los combatientes más fuertes del reino*hip*");
                    cCDialogue.Add("Te estoy robando muuuuucho tiempo, solo quiero decirte que esperro que podamos ser amigos.");
                    cCDialogue.Add("Te darré esta botella, en señal de nuestra amis *hip* tad");
                    cCDialogue.Add("Nos vemos besto amigo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Petra"))
                {
                    cCDialogue.Add("Hola amigo… Al igual que tu me diste ánimos para trabajar, te tendré que contar una nueva noticia…");
                    cCDialogue.Add("Me han despedido… Es… ¡Una muy buena noticia!");
                    cCDialogue.Add("Ese tipo era un explotador de mucho cuidado, ¿quién se creía?");
                    cCDialogue.Add("Quería que le encontrará un lugar llamado Atlantis con un mapa del menú infantil del Tips.");
                    cCDialogue.Add("Ahora le tocará al nuevo hacer eso, o mejor dicho al que han recontratado");
                    cCDialogue.Add("Con la nueva prohibición del alcohol, el sapopótamo dejó el alcohol.");
                    cCDialogue.Add("Espero que le vaya bien, aunque lo dudo.");
                    cCDialogue.Add("Además, me podré librar de algunas que llevaba en la mochila, como este mapa vacío.");
                    cCDialogue.Add("Te lo puedes quedar, aunque dudo que le puedas dar mucho uso, principalmente porque no tiene nada.");
                    cCDialogue.Add("Nos vemos amigo.");
                }


                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("Hola colega, tengo una mala noticia para ti.");
                    cCDialogue.Add("La cangumantis y yo lo hemos dejado, me echó spray de pimienta en la esfera cuando la encontré.");
                    cCDialogue.Add("Es una de las maneras en la que me han dejado, la peor una de mis exs que me dejó por mi hermano.");
                    cCDialogue.Add("Pero esto ha hecho que abra los ojos y me dé cuenta que de tanto pensar en el amor, me perdí en el sendero de la vida.");
                    cCDialogue.Add("Así que tome una decisión importante y me desinstalé Hybrinder, aunque me quedara un año de premium.");
                    cCDialogue.Add("Creo que ahora voy a rehacer mi vida, ahora que soy un limbástico.");
                    cCDialogue.Add("Puedo intentar ser un monje, perdido en la montaña, para encontrar un nuevo camino.");
                    cCDialogue.Add("Pero creo que me quedaré trabajando en la gasolinera como siempre, hasta que encuentre mi camino.");
                    cCDialogue.Add("Hablando de la gasolinera, cóbrame que tengo dentro de nada el turno.");
                    cCDialogue.Add("Gracias, quédate con este cuadro de Mara, para que me olvide de ella.");
                    cCDialogue.Add("Voy a empezar con ganas mi nuevo camino, si es que me llega.");
                    cCDialogue.Add("Espero que empezar mi nuevo camino no se vea afectado por mi nulas capacidades de contar monedas.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Masermati"))
                {
                    cCDialogue.Add("Hola cocherrumín, ¿adivina quién participó en la carrera del otro día y quedó en 1º lugar?");
                    cCDialogue.Add("Pues yo no porque quedé en 8º lugar, pero lo importante fue participar.");
                    cCDialogue.Add("Si sigo entrenando, puede que para la próxima quede en 1º lugar.");
                    cCDialogue.Add("Si no fuera porque Flecha Rápida hiciera trampa, ese trasto de 4 ruedas lanzó clavos por el camino.");
                    cCDialogue.Add("Es igual de miserable que su dueño Pijus Magnus, la próxima vez no se repetirá.");
                    cCDialogue.Add("Menos mal que mi familia se quedó apoyándome hasta el final.");
                    cCDialogue.Add("Seguro que en cuanto me ponga la luces traseras y el cambio de marchas mejoraré mucho más.");
                    cCDialogue.Add("Pero como siempre dan citas para dentro de 3 meses en reparación pública.");
                    cCDialogue.Add("Esperaré hasta la cita y la operación para ser mejor coche en mi siguiente carrera.");
                    cCDialogue.Add("Bueno cocherrumín, creo que debería ir corriendo hasta casa que se me hace tarde.");
                    cCDialogue.Add("Ahora voy acelerando a casa para no llegar tarde, chao.");
                    cCDialogue.Add("Con las prisas debí romper el cupón.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Hola amigo, ¿a que me ves diferente?");
                    cCDialogue.Add("Se curó mi miopía gracias a beber tanto veneno.");
                    cCDialogue.Add("¿Quién iba a decir que el veneno era la cura?");
                    cCDialogue.Add("Me imagino que no lo ha probado nadie antes, porque se moriría sino.");
                    cCDialogue.Add("Pero como no puede morir alguien muerto, me curé.");
                    cCDialogue.Add("Gracias por vendernos el veneno a Patxi y a mí.");
                    cCDialogue.Add("Ahora no necesitaré mis gafas, puedes quedártelas.");
                }


                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Buenos días próximo creyente, veo que sigues encadenado a esta tienda.");
                    cCDialogue.Add("Podrías intentar ser más libre si vinieras alguna vez a una de las misas de mi iglesia.");
                    cCDialogue.Add("Además te beneficiaría venir, con cierta información que te voy a contar ahora.");
                    cCDialogue.Add("Vamos a hacer que vuelvan antiguos héroes a la vida, el primero fue el gran Sergio Nerviosaus.");
                    cCDialogue.Add("Pero dentro de poco, no será el único que volverá a la vida y nos ayudará.");
                    cCDialogue.Add("Así que creo que te beneficiaría estar de nuestra parte, y no de la del detective que lleva unos días viéndote.");
                    cCDialogue.Add("¿Crees que no lo sabía? Ese detective lleva algunos días indagando en nuestra sagrada iglesia.");
                    cCDialogue.Add("Además de que siempre viene a esta tienda al final del día, así que espero que hoy le mientas un poquito.");
                    cCDialogue.Add("Pero bueno, hoy vine como cliente, por lo que cóbrame humano.");
                    cCDialogue.Add("Te espero pronto en mi iglesia, humano.");
                    cCDialogue.Add("Cuando revivamos a los héroes, espero que no sepas contar mejor.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Salta"))
                {
                    cCDialogue.Add("Hola humano, ¿cómo estar día?");
                    cCDialogue.Add("Como tu ver ver ver ver ver romper runas de nuevo.");
                    cCDialogue.Add("Yo estar en bar anoche con mi querida familia, hasta que un borracho echarme toda su bebida encima.");
                    cCDialogue.Add("El tipo no quiso reparar mis runas y romperlas toda la noche.");
                    cCDialogue.Add("Ahora necesitar cambiar runas de nuevo, la gente no comprender a mí.");
                    cCDialogue.Add("No entender que yo no nacer con mitad animal, si no con vegetal.");
                    cCDialogue.Add("Deber cambiar alguna cosa para hacer mejor trato a los híbridos mitad vegetal.");
                    cCDialogue.Add("O al menos hacer algo para que los híbridos vegetarianos no babear babear babear con nosotros.");
                    cCDialogue.Add("Ya volver a funcionar mal, cóbrame que querer cambiar runas.");
                    cCDialogue.Add("Gracias humano, cambiar en nada runas.");
                    cCDialogue.Add("Yo solo querer cerveza para papá, pero bueno, dar solo runas mejor.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Raven"))
                {
                    cCDialogue.Add("Hola cielo, espero que estés teniendo un día brillante.");
                    cCDialogue.Add("A mí ayer me fue genial en la gatoteca, fue muy divertido a mi compañero huir de los gatos.");
                    cCDialogue.Add("Se le pegaban los gatos con la estática de los globos.");
                    cCDialogue.Add("¡Además pudimos atender a uno de los miembros de la banda de Magicians of Power!");
                    cCDialogue.Add("¡SON EL MEJOR GRUPO DEL MUNDO!");
                    cCDialogue.Add("Y gracias a mis increíbles dotes de persuasión y carisma, me regalaron dos entradas para ir.");
                    cCDialogue.Add("Seguro le digo a Handy de ir, es un gran compañero, y se esfuerza más que ninguno que haya tenido.");
                    cCDialogue.Add("Aunque su debilidad sean los gatos con mucho pelo.");
                    cCDialogue.Add("No sé cuál será el próximo trabajo, pero espero que pueda hacerlo junto con él.");
                    cCDialogue.Add("Te quite mucho tiempo amigo mío, cobrame esto porfi.");
                    cCDialogue.Add("Eres el mejor, no sé si te interese, pero ya que somos tan buenos amigos te daré mi disco favorito.");
                    cCDialogue.Add("Gracias amigo, espero que llegue ya el día del concierto.");
                    cCDialogue.Add("¿No puedo comprar esto? Creía que tenía todo el dinero.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Hola humano, creo que me acaba de pasar algo sorprendente después de estos años trabajando.");
                    cCDialogue.Add("Han habido recortes en mi trabajo, por lo que pensaba que me iban a recortar mi sueldo de 3 monedas al mes.");
                    cCDialogue.Add("Pero lo que parecía un recorte de sueldo, acabó siendo un recorte de verdad.");
                    cCDialogue.Add("Literalmente han cortado una parte de mí, y salió un mini yo, por lo que creo que ahora soy papicio.");
                    cCDialogue.Add("Vaya suerte tendrá el tapicín de tener un padre tan realista como yo.");
                    cCDialogue.Add("Así sabrá de inicio lo triste y dura que es la vida, y no le pasará como a mí al nacer.");
                    cCDialogue.Add("Aunque no sé qué necesitan comer los tapicines cuando son pequeños, puede que un poco de gravilla le guste.");
                    cCDialogue.Add("Bueno, hablando del peque, tengo que ir a por él en nada, así que cóbrame.");
                    cCDialogue.Add("Gracias, a ver si estar ahora con hijo me anima más.");
                    cCDialogue.Add("Ahora el niño me verá más deprimente de siempre.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Traigo muy buenas noticias humano, estamos a nada de cerrar el caso.");
                    cCDialogue.Add("Uno de los sospechosos de ayer confesó que la iglesia le ayudó a revivir a un tal Sergio Nerviosaus.");
                    cCDialogue.Add("Esta noche, haremos una redada en la iglesia para encerrar a los miembros.");
                    cCDialogue.Add("Así que puede que en nada vayamos a cerrar el caso, aunque aún nos queda una cosa por resolver.");
                    cCDialogue.Add("Quién fue la persona que le dió con el orbe al fiambre.");
                    cCDialogue.Add("Tenemos algunos sospechosos, pero creemos que es el líder principal.");
                    cCDialogue.Add("Hasta el detective Black no sabe quién arrestar.");
                    cCDialogue.Add("Dime humano, ¿quién crees qué es el líder?");
                    cCDialogue.Add("Muchas gracias por ayudar en el caso, espero que nos volvamos a ver.");
                }
            }

            else if (currentScene.name == "Home")
            {
                if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Tapicio"))
                {
                    cCDialogue.Add("Saludos humano **suspira**");
                    cCDialogue.Add("Tu jefe me dijo que te quedarías aquí, qué lugar más triste.");
                    cCDialogue.Add("Por desgracia tendré que animar este sitio, he traído mi juego favorito.");
                    cCDialogue.Add("Parecías nuevo en el reino y me diste pena al verte **suspira**");
                    cCDialogue.Add("Seguramente más clientes como yo puedan traerte cosas si les tratas bien.");
                    cCDialogue.Add("Ya sea cobrándoles aunque no debas, o ayudándoles con alguna cosa.");
                    cCDialogue.Add("Seguro que con más objetos animas este sitio.");
                    cCDialogue.Add("Aunque me gustaría que quedase más triste, como mi propia existencia.");
                    cCDialogue.Add("Te dejo de molestar humano, suerte estos días.");
                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bonna noche amigo mío, espero que descanses bien.");
                    cCDialogue.Add("Pero antes quería darte un regalo, mi libro de cocina.");
                    cCDialogue.Add("Bueno, mejor dicho... una copia, pedí que me lo clonaran con magia.");
                    cCDialogue.Add("Así los dos podremos hacer los platos que queramos cada día.");
                    cCDialogue.Add("Aunque aquí no veo ninguna cocina, solo un sótano sucio...");
                    cCDialogue.Add("Bueno, te las apañarás, ciao amigo mío.");

                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Elidora"))
                {
                    if (!slimeFostiados)
                    {
                        cCDialogue.Add("Hola súbdito, estoy haciendo un entrenamiento especial para que los slimes me duren más.");
                        cCDialogue.Add("Consiste en acariciarles la cabeza con un martillo, pero no me hace mucha gracia cogerlo yo");
                        cCDialogue.Add("¿Que asco agarrar algo áspero con las manos no? Prefiero que lo haga gente como tú");
                        cCDialogue.Add("Bueno, que me enredas, haz eso por mi y quien sabe, puede que algún día te de algo que se me rompa y ya no pueda usar");
                    }

                    else if (slimeFostiados)
                    {
                        if (slimeFail)

                            if (elidoraAcariciada)
                                cCDialogue.Add("¡Casi me abollas el cerebro!¡Escucho borroso!¡NUNCA TE LO PERDONARÉ CARMONA!");

                            else
                                cCDialogue.Add("Típico de un humano, no sé por qué te encargué una tarea tan difícil para un cerebro tan diminuto como el tuyo...");
                        else
                            cCDialogue.Add("Menudo abollón le has dejado a Mc Moco... No creo que me sirva así, te lo regalo");
                    }
                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola humano, veo que no has contado nada sobre la iglesia a ese detective.");
                    cCDialogue.Add("Has mostrado ser fiel a nuestra causa y a la iglesia.");
                    cCDialogue.Add("Ganaste mi confianza para considerarte uno de nosotros.");
                    cCDialogue.Add("Acepta este anillo como muestra de agradecimiento.");
                    cCDialogue.Add("Nos vivimos por verte estos días en la iglesia, ya me entiendes.");
                }
            }
        }

        else if (engAmerican)
        {
            if (currentScene.name == "Day1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hello, fresh meat. I'm your new boss.");
                    cCDialogue.Add("As I know it's your first time here, I'll be watching.");
                    cCDialogue.Add("You better satisfy the costumers, am I clear?");
                    cCDialogue.Add("You humans are all the same...");
                    cCDialogue.Add("And I am not the one saying it, your brain size is.");
                    cCDialogue.Add("As I was saying, GET BACK TO WORK!");
                    cCDialogue.Add("I don't want to lose money with you.");
                    cCDialogue.Add("For charging use the CASH REGISTER.");
                    cCDialogue.Add("Charging incorrectly means I will take money from your TIP JAR.");
                    cCDialogue.Add("You've got the CATALOGUE with prices to your right. Check it out to charge correctly.");
                    cCDialogue.Add("Oh, and if your pea sized brain forgot.");
                    cCDialogue.Add("The giant tablet in front of you is the one who translates the clients you meet.");
                    cCDialogue.Add("It's the head of the former (robot) employee... But it still works!");
                    cCDialogue.Add("(Like if I was ever gonna buy new gear for you).");
                    cCDialogue.Add("That's everything, don't break a leg, there's no insurance here for you. Bye.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard"))
                {
                    cCDialogue.Add("Good morning, citizen! Here comes Geeraard, the almighty! Aha, yeah, no pictures…");
                    cCDialogue.Add("…");
                    cCDialogue.Add("How is it that you aren't on your knees crying and begging for a photo..?");
                    cCDialogue.Add("YOU DON'T KNOW ME?! EVERYONE KNOWS ME!!!");
                    cCDialogue.Add("Hero of heroes, the one who defeated the Demon King with just one dagger while blindfolded!");
                    cCDialogue.Add("All my admirers, I mean, everyone in the kingdom, know I am the favorite fearless hero.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("As you are new I'll have compassion and forgive you. I am that good, yeah, no need to thank me.");
                    cCDialogue.Add("Just charge this items. Your silence unnerves me.");
                    cCDialogue.Add("As a new citizen, your duty is to read my books, period.");
                    cCDialogue.Add("You don't even know how to count?! PREPOSTEROUS!!!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Suuuuup *hick* Huuuuuuhh… You are not the guyyy… *hick* From before...");
                    cCDialogue.Add("I mean, yeah, the other guyyy was a ######");
                    cCDialogue.Add("Now with who will I talk about how they fireddd meeee… And you are hewman…");
                    cCDialogue.Add("Ah, hell! *hick*");
                    cCDialogue.Add("Name's Elvog, da ex-explorer");
                    cCDialogue.Add("Ya ain't gonna believe meh… My ###### boss fired me! *hick*");
                    cCDialogue.Add("He said I was too drunk, too old and called me smelly...WHO DOES HE THINK HE IS? *hick*");
                    cCDialogue.Add("I'm only 22, I'm in my peak! *hick*");
                    cCDialogue.Add("Ah, yeah *hick*, I'm buying these…");
                    cCDialogue.Add("Sankiu *hick* You saved my morning *hick*");
                    cCDialogue.Add("Omaiga... *hick* the guy before you was better *hick*");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Hi… New guy, huh? My name is Anthony, how... are you..?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("I see… Not the talkative kind of person, right?");
                    cCDialogue.Add("I feel ya, my work as a programmer made me something like that.");
                    cCDialogue.Add("I really don't know how I survive this job. Maybe it's because I'm dead.");
                    cCDialogue.Add("*snort* Sorry, that was a joke, I'm not the jokester on my discorb chat.");
                    cCDialogue.Add("My brain makes me, quite the dead player on games.");
                    cCDialogue.Add("Okay, that didn't even make sense. How do people do it?");
                    cCDialogue.Add("I'll be taking these, yeah.");
                    cCDialogue.Add("Thank you my dear fellow, wait, did I even give you the right amount..?");
                    cCDialogue.Add("Aw, I forgot some coins in my kawaii pillow… So- so sorry!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Another dark day, another new employee. I'm ShRug, if you even care.");
                    cCDialogue.Add("You are checking me out, aren't you? Everyone does...");
                    cCDialogue.Add("Life is a prison.");
                    cCDialogue.Add("I was literally born to work.");
                    cCDialogue.Add("Ah... How I wish to be that rug on the limbastic cemetery...");
                    cCDialogue.Add("Sadly my life is like a chemical romance: kiss it and get sick.");
                    cCDialogue.Add("As you are probably also getting sick of me, you know the deal...");
                    cCDialogue.Add("Charge me and I'll go to the sad looks convention.");
                    cCDialogue.Add("Thanks, wish me death, I'll need it.");
                    cCDialogue.Add("Another disappointment for me, what a surprise...");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Work... And only chores... TO ME?! This is just-");
                    cCDialogue.Add("Whoops, sorry... new guy..? My boss is working me to the point of overdrive.");
                    cCDialogue.Add("My name is Denjirenji, it's an honor to meet you.");
                    cCDialogue.Add("The katana behind me isn´t a prop, I have been training for years to be a samurai.");
                    cCDialogue.Add("I even trained with a turtle squad and a rat once…");
                    cCDialogue.Add("But now... My new master is only using me for normal chores...");
                    cCDialogue.Add("I lost my honor as a samurai...");
                    cCDialogue.Add("Some day I'll have to do the harakiri with a spoon inside me, for sure.");
                    cCDialogue.Add("Sorry for all of that, just do your job and I promise not to bother.");
                    cCDialogue.Add("Thank Tobisha! I thought I didn't have enough coins, did I? Wait...");
                    cCDialogue.Add("Just one coin! Forgive my stupidity, I hope my sensei has mercy on me.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mara"))
                {
                    cCDialogue.Add("Hello dear, name's Mara.");
                    cCDialogue.Add("Carrying all these is hard work hee hee hee!");
                    cCDialogue.Add("Say, can you help me carry them outside? Probably you can´t but thanks anyways~");
                    cCDialogue.Add("Since my husband... Yeah... It's tougher to carry everything by myself.");
                    cCDialogue.Add("That's what I get for eating him.");
                    cCDialogue.Add("Anyways.");
                    cCDialogue.Add("You are such a cutie with that face of yours.");
                    cCDialogue.Add("I must apologize for that, us mangaroos are full of love to share.");
                    cCDialogue.Add("And bellys to fill with your partner. Only for reproduction!");
                    cCDialogue.Add("After this I'll go pick up my kid from the zoo.");
                    cCDialogue.Add("Thank you so much cutie, hope you find love too hee hee hee.");
                    cCDialogue.Add("Aw, now my son won't have the dead cat as a pet...");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Good day lad, name's Giovanni.");
                    cCDialogue.Add("You are new, right? Let me show you something I found...");
                    cCDialogue.Add("THE E-X-P-L-O-D-I-N-O-M-I-C-O-N!");
                    cCDialogue.Add("The most explosive recipes, I think…");
                    cCDialogue.Add("So, for this first recipe I'll need...");
                    cCDialogue.Add("Oooh! ”How to summon Azathoth”, I'll cook this one");
                    cCDialogue.Add("Suena increíble este plato, pillaré algunos ingredientes para hacer el plato.");
                    cCDialogue.Add("“Primer paso: rociar vino hecho de sangre de virgen”");
                    cCDialogue.Add("Cambiaré el vino por una buena cerveza, le dará más sabor.");
                    cCDialogue.Add("“Segundo paso: cortar el muñeco voodoo por la mitad junto con la persona sacrificada”");
                    cCDialogue.Add("No sé qué es eso de la persona sacrificada, pero el muñeco tiene buena pinta.");
                    cCDialogue.Add("“Y tercer paso: beber el veneno para que el Dios se adueñe de tu cuerpo”");
                    cCDialogue.Add("No suelo beber veneno, pero creo que se lo echaré al muñeco para darle el toque picante.");
                    cCDialogue.Add("Tiene buena pinta ¿verdad? Para eso necesito estos ingredientes, así que si puedes cobrarme.");
                    cCDialogue.Add("Gracias, la próxima vez que vuelva te dejaré probar el plato para que me des tu opinión.");
                    cCDialogue.Add("Madre mía, ahora te perderás el mejor plato del mundo, pillaré las cosas en otro sitio.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rockon"))
                {
                    cCDialogue.Add("¿Ho-hola que tal?");
                    cCDialogue.Add("Espero no molestar, y perdona mi tar-tartamudez. ");
                    cCDialogue.Add("En fin, perdona otra vez. No me disculparé más, per-per-perdona.");
                    cCDialogue.Add("Estoy intentando me-mejorar, como buen Rockon que soy.");
                    cCDialogue.Add("Debo mejorar como papá, es muy fuerte.");
                    cCDialogue.Add("Siempre me ha querido mu-mu-mucho.");
                    cCDialogue.Add("Mi co-comida favorita es la gravilla que me hacía.");
                    cCDialogue.Add("Además si le echabas cemento por encima, ya quedaba bueniiiiiisimo.");
                    cCDialogue.Add("Bu-bu-bueno en fin… ¿Me puedes cobrar esto?");
                    cCDialogue.Add("Es que le quiero dar una sorpresa a papá, seguro que este gato mu-muerto le hace mucha ilusión.");
                    cCDialogue.Add("Gra-gra-gracias seguro que papá se pone feliz");
                    cCDialogue.Add("Jopetas… Con la ilusión que me hacía regalarles esto a papá y mamá… Pero no tengo todo el dinero");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefazo"))
                {
                    cCDialogue.Add("Seguro que fue muy agotador. pero mejor me lo comentas mañana.");
                    cCDialogue.Add("Y un pajarito llamado Inspector de Empleo me ha dicho que no tienes casa.");
                    cCDialogue.Add("Menos mal que tienes un jefe tan generoso y rico, así que te prestaré una de las mejores viviendas del reino.");
                    cCDialogue.Add("Ese maravilloso lugar se llama: El sótano de la casa de mi madre.");
                    cCDialogue.Add("Espero que te guste.");
                    cCDialogue.Add("Llévate el traductor por si tengo que hablar contigo, tendrás que entender a mi madre.");
                }
            }

            else if (currentScene.name == "Day2_1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenos días chico nuevo.");
                    cCDialogue.Add("¿Qué tal tu primer día?");
                    cCDialogue.Add("Nah, es broma, realmente me da igual como te fuera tu primer día.");
                    cCDialogue.Add("Seguro te lo dije en el tutorial, pero seguro no te acuerdas por tu cerebro enano.");
                    cCDialogue.Add("Tenemos unas normas que seguir en la tienda a partir de hoy.");
                    cCDialogue.Add("Además es “Magic Friday”, aunque lo seguirá siendo el resto del año, como todos los años...");
                    cCDialogue.Add("Así que los magos tienen rebajas, y el resto de razas trabajan más a cambio.");
                    cCDialogue.Add("También han prohibido varias bebidas a algunas razas.");
                    cCDialogue.Add("Parece que sus cuerpos no soportan los ingredientes ilegales que llevan.");
                    cCDialogue.Add("Eso es menos dinero para mi por desgracia.");
                    cCDialogue.Add("Pero la multa será peor si me pillan.");
                    cCDialogue.Add("Recuerda revisar las normas, están a la izquierda de la pantalla.");
                    cCDialogue.Add("Buena suerte chico nuevo");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Lepion"))
                {
                    cCDialogue.Add("Hola humano.");
                    cCDialogue.Add("Espera, tu eres el tonto que no sabía contar.");
                    cCDialogue.Add("Ayer vino aquí ese microondas.");
                    cCDialogue.Add("Y ese cacharro debió darte una moneda más");
                    cCDialogue.Add("Al menos ahora puedo justificar su despido");
                    cCDialogue.Add("Aunque el bobo se puso a decir cosas de hacer el harakiri o cosas así.");
                    cCDialogue.Add("En fin, malditas máquinas japonesas.");
                    cCDialogue.Add("Ya que estás, cobrame esto, que debo seguir con mi trabajo de blanqueamiento de dinero.");
                    cCDialogue.Add("Adiós");
                    cCDialogue.Add("Ni contar sabes, ¿de verdad? Acabas de perder todos los clientes chinos por la zona, \n y espero que pronto pierdas tú el trabajo.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bon día amigo mío, espero que te esté yendo bien estos días.");
                    cCDialogue.Add("A mí el último plato del otro día no salió como me esperaba la verdad… Me salió... ¡PERFECTO! ");
                    cCDialogue.Add("Hice todos los pasos a la perfección, aunque el veneno le dió un toque picante un poco raro.");
                    cCDialogue.Add("Y fue un poco extraño cuando el plato empezó a hablarme en una lengua antigua, pero peores cosas he probado.");
                    cCDialogue.Add("Aún recuerdo cuando fui a un restaurante de elementales de roca, aunque obviamente el local era de un mago.");
                    cCDialogue.Add("El plato estrella era la gravilla, ese plato tenía una textura asquerosa.");
                    cCDialogue.Add("Era como comerte un castillo de arena derretido.");
                    cCDialogue.Add("Pero bueno, ahora preparé un plato mucho mejor, así que necesitaré estos ingredientes amigo mío.");
                    cCDialogue.Add("Gracias, te dejaré probarlo como quede bueno my besto frendo");
                    cCDialogue.Add("¿Tengo prohibidos estos deliciosos ingredientes? El reino cada vez acaba con la libertad de la comida.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Enano"))
                {
                    cCDialogue.Add("¡Hola pequeñín!");
                    cCDialogue.Add("Soy el grandioso Manolo Cabeza de Pico, el mago más rico… Del barrio más alto del reino.");
                    cCDialogue.Add("Creo que se me ha colado uno de mis gnomos defectuoso en la tienda.");
                    cCDialogue.Add("Se llama José Miguel Culo Escurridizo.");
                    cCDialogue.Add("El pobre no podía mantenerse quieto y se coló en la trampilla antes de turno.");
                    cCDialogue.Add("Aunque realmente me cae mal, no hace caso y no para de esconderse.");
                    cCDialogue.Add("Puede que si lo encuentras un par de veces esta semana se vaya contigo.");
                    cCDialogue.Add("Así me dejará en paz el pesado, suerte buscándolo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("¿Buenos días? ¿O noches? Ya no sé la verdad.");
                    cCDialogue.Add("Perdón, te habré confundido un poco, soy el del orbe el que habla.");
                    cCDialogue.Add("Por este maldito orbe solo puedo ver morado, no distingo si es de día o no.");
                    cCDialogue.Add("Me llamo Cululú, y hasta hace poco era un híbrido.");
                    cCDialogue.Add("Pero ahora soy un limbástico, me morí ayer mientras estaba en la gasolinera.");
                    cCDialogue.Add("Vi a un tío con un libro rarísimo que parecía hacer un ritual, y al verme, me dió un golpe con este orbe.");
                    cCDialogue.Add("Y al despertar, pues me quedé encerrado aquí, aunque supongo que esto no sea un problema para mi cita.");
                    cCDialogue.Add("El detective de mi caso me dijo que no fuera por ahora hasta que me acostumbrara a mi nuevo yo.");
                    cCDialogue.Add("Pero la vida es una, y esa manguro es mi tipo ideal.");
                    cCDialogue.Add("Pero bueno, espero que encuentren al culpable pronto para que no me atosigue el detective.");
                    cCDialogue.Add("Ve cobrando estas pociones, que en unos minutos tengo la cita.");
                    cCDialogue.Add("Muchas gracias hermano, deseame suerte en la cita.");
                    cCDialogue.Add("Tío, de verdad que no te entiendo, si tengo toda la pasta.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("¡Buen ser humano, necesito tu ayuda!.");
                    cCDialogue.Add("En mi casa se me han acabado las pilas y mi madre no estaba en casa para metermelas y darme energía.");
                    cCDialogue.Add("Por favor, necesito que me metas las pilas, ya te las pagaré luego. Recuerda meterlas en el hueco de la parte superior");
                    cCDialogue.Add("¡Y rápido!, que no quiero apagarme y convertirme en uno de esos horribles monstruos.");
                }
            }

            else if (currentScene.name == "Day2_2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Muchas gracias Ronin, que sepas que te lo recompensaré algún día, espero que mi maestro no se enfade.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("¡Hola colega! ¿Cómo te encuentras? ¿Bien? ¿Mal?");
                    cCDialogue.Add("¡YO ESTOY FENOMENAL!");
                    cCDialogue.Add("Soy Handy, el elemental más fiestero, que ama cualquier celebración.");
                    cCDialogue.Add("Cumpleaños, bodas, despedidas de solteros y… ¡FUNERALES!");
                    cCDialogue.Add("Aunque del último funeral me echaron por alguna extraña razón.");
                    cCDialogue.Add("Estoy tan emocionado amigo mío, tengo una nueva compañera.");
                    cCDialogue.Add("Se llama Rave-n, incluso estudió fiestología.");
                    cCDialogue.Add("Aunque a mí me expulsaron del grado de fiestología por mi TFG sobre… ¡ALEGRAR FUNERALES!");
                    cCDialogue.Add("Se debieron de morir de la risa con mi TFG.");
                    cCDialogue.Add("Bueno colega, sé que estás pasando un buen rato conmigo.");
                    cCDialogue.Add("Pero tengo una despedida de soltero y tengo que aguantar toda la noche despierto.");
                    cCDialogue.Add("Y necesito estos utensilios para sobrevivir a los solteros desesperados.");
                    cCDialogue.Add("Aunque no sé para qué será la bola, me la pidieron los solteros");
                    cCDialogue.Add("Bueno, cobrame porfi porfita.");
                    cCDialogue.Add("Voy a hacer una despedida de soltero !INCREÍBLE! Nos vemos colega.");
                    cCDialogue.Add("Me has borrado la sonrisa tío, pero entiendo que no puedas romper la normativa");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Petra"))
                {
                    cCDialogue.Add("Hola dependiente, de verdad que no puedo aguantar más mis ganas de empezar a trabajar.");
                    cCDialogue.Add("Necesito contárselo a alguien, ¡Por fin puedo ser una exploradora!");
                    cCDialogue.Add("Necesitaba soltarlo, no sabes lo emocionada que estoy con este nuevo trabajo.");
                    cCDialogue.Add("Por cierto, no me presenté, me llamo Petra.");
                    cCDialogue.Add("He estado 12 años en paro desde que no llegué a tiempo a una misión.");
                    cCDialogue.Add("Pero es lo que pasa cuando eres mitad tortuga y mitad liebre, que mi velocidad siempre será normal.");
                    cCDialogue.Add("También mi jefe me comentó que esperaba que lo hiciera mejor que el último empleado.");
                    cCDialogue.Add("Era un sapótamo que se la pasaba bebiendo en el trabajo.");
                    cCDialogue.Add("Menos mal que no bebo nada de alcohol en mi vida.");
                    cCDialogue.Add("Uy, perdona, te estoy quitando tiempo.");
                    cCDialogue.Add("Cobrame esto qué lo necesito para el trabajo.");
                    cCDialogue.Add("Deseame suerte en mi primer día de curro, ¡Nos vemos!");
                    cCDialogue.Add("Necesitaba esto de verdad para el trabajo, el jefe me va a despedir y ni empecé.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Hola humano, ¿no tienes días libres o que? ");
                    cCDialogue.Add("Eres parecido en ese aspecto a los elementales, nosotros tampoco paramos de trabajar, es lo que tiene ser creaciones de los magos. ");
                    cCDialogue.Add("Espera, ¿no lo sabías? La mayoría de las razas actuales fueron creadas por ellos. ");
                    cCDialogue.Add("Que triste es la ignorancia de los humanos. ");
                    cCDialogue.Add("Los elementales fueron creados para hacer el trabajo de esclavos. ");
                    cCDialogue.Add("Los tecnópedos fueron creados por accidente cuando metieron una varita en un microondas. ");
                    cCDialogue.Add("Y los limbásticos no se sabe cómo se crearon, solo se sabe que fueron los magos. ");
                    cCDialogue.Add("Leí en algunos foros de ocultismo que fueron creados por una iglesia que lleva años oculta entre nosotros.");
                    cCDialogue.Add("Tampoco pude leer mucho, es lo que tiene tener 23 horas de jornada laboral.");
                    cCDialogue.Add("Hablando de ello, en nada tengo que volver a trabajar como tapiz en un museo de la zona.");
                    cCDialogue.Add("Y encima tengo que explicar, de nuevo, al nuevo saco de huesos como va el trabajo allí.");
                    cCDialogue.Add("Le fue horrible en su primer día, aunque ya es horrible ser parte de nuestra raza.");
                    cCDialogue.Add("Por lo que ve cobrándome esto antes de que caiga en el olvido.");
                    cCDialogue.Add("Espero que acabe pronto mi jornada, aunque vaya a comenzar.");
                    cCDialogue.Add("Ni en mi descanso puedo conseguir un mínimo de felicidad.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Masermati"))
                {
                    cCDialogue.Add("Hola cocherrumín, estoy preparándome para la carrera del siglo.");
                    cCDialogue.Add("No me presenté, soy el famoso FMS, Faster More Serious.");
                    cCDialogue.Add("O como me llamo mi robo-madre, Masermati.");
                    cCDialogue.Add("Y voy a hacer la primera carrera de mi vida.");
                    cCDialogue.Add("Aunque espero que no sea la última, no sabes la pasta que cuestan estas mejoras.");
                    cCDialogue.Add("Los tubos de escape costaron solo 100 monedas.");
                    cCDialogue.Add("No sabes todos los platos que limpié para tener esa cantidad de monedas.");
                    cCDialogue.Add("Pero todo este trabajo fue necesario para el día de hoy, para ganar a…");
                    cCDialogue.Add("¡FLECHA RÁPIDA! El tecnópedo más rápido del reino.");
                    cCDialogue.Add("Es el coche oficial de Pijus Magnus, el 2º mago más poderoso del reino.");
                    cCDialogue.Add("O eso dice él, aunque solo lo dice por ser hijo del Rey Mago.");
                    cCDialogue.Add("Realmente es un tirillas enano, espero que tengas suerte de no encontrarlo.");
                    cCDialogue.Add("Bueno, cobrame humano, que tengo que estar listo para la carrera.");
                    cCDialogue.Add("Gracias cocherrumín, voy a prepararme para la carrera.");
                    cCDialogue.Add("¡Pero si tengo suficiente! Da igual, tengo algo de prisa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Pijus"))
                {
                    cCDialogue.Add("Tú ve cobrando esto que tengo prisa.");
                    cCDialogue.Add("Espera-");
                    cCDialogue.Add("¡¿Eres humano?! ¿No te da vergüenza respirar el mismo aire que yo?");
                    cCDialogue.Add("No se ni como pagaste lo suficiente para entrar al reino.");
                    cCDialogue.Add("Y más te vale que me cobres bien, he leído lo del 50%.");
                    cCDialogue.Add("Así que quiero que me lo rebajes T-O-D-O.");
                    cCDialogue.Add("Y como me cobres mal tendré que usar mis poderosa habilidad…");
                    cCDialogue.Add("El número de mi papi.");
                    cCDialogue.Add("Espero que me cobres bien, venga.");
                    cCDialogue.Add("Así me gusta humano, no sabía qué os habían enseñado a contar allí.");
                    cCDialogue.Add("¡Cómo que no sirve la oferta! Pues...Pues…Bonita moneda, me la quedo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Hola dependiente, soy del departamento de investigación de sucesos paranormales, es decir, soy detective.");
                    cCDialogue.Add("Y tenía una pregunta respecto a un caso sobre homicidio, alguien ha vuelto un híbrido a un limbástico.");
                    cCDialogue.Add("Un poco pesado el fiambre diciendo que tenía una cita, pero me da a mi que va a tener que esperar.");
                    cCDialogue.Add("Creemos que ha podido ser un artefacto mágico el culpable, en concreto un libro de magia.");
                    cCDialogue.Add("¿Sabes de algún clientes pueda tener un libro mágico?");
                    cCDialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");
                }
            }

            else if (currentScene.name == "Day3_1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenas chico nuevo.");
                    cCDialogue.Add("Parece que te estás acostumbrando a tu trabajo.");
                    cCDialogue.Add("Estás durando más que el antiguo empleado.");
                    cCDialogue.Add("No sé cómo sigues vivo siquiera.");
                    cCDialogue.Add("Pero bueno, tengo malas noticias.");
                    cCDialogue.Add("Ha empezado el mercado de una nueva raza: Los Cupones");
                    cCDialogue.Add("Son criaturas que se utilizan como trueque a cambio de objetos.");
                    cCDialogue.Add("Con los cupones podrán pillar lo que quieran, ¡LES SALDRÁ GRATIS!");
                    cCDialogue.Add("Vaya asco de bichos, al menos son muy coquettes.");
                    cCDialogue.Add("Debajo de tu pantalla tendrás una retrato de los cupones que son válidos.");
                    cCDialogue.Add("Cuidado que no te traigan ninguno falso, fijate bien el retrato.");
                    cCDialogue.Add("Y recuerda revisar las normas, no servirá su cupón si tiene prohibido algún objeto.");
                    cCDialogue.Add("Suerte humano.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sergio"))
                {
                    cCDialogue.Add("Hola joven humano, disculpa la impertinencia, pero deberían de bajar el peso de esas bebidas.");
                    cCDialogue.Add("No sabes lo que pesan esas malditas latas.");
                    cCDialogue.Add("No tengo fuerza ni para levantarlas.");
                    cCDialogue.Add("En mis tiempos, cuando era conocido como Sergio Nervisous.");
                    cCDialogue.Add("Era capaz de levantar piedras y tenía unos nervios de acero.");
                    cCDialogue.Add("Pero ahora suficiente que aguanto este cubo en mi cabeza.");
                    cCDialogue.Add("Y encima me ha revivido un mago que dice que es un héroe.");
                    cCDialogue.Add("Se hace llamar Geeraard, que nombre más raro para un héroe.");
                    cCDialogue.Add("Me revivió para que le ayudará en su nueva aventura.");
                    cCDialogue.Add("¡Pero si no soy capaz ni de levantar una espada de verdad!");
                    cCDialogue.Add("Con lo bien que estaba en mi tumba.");
                    cCDialogue.Add("Necesito recuperar mis nervios, así que, cobrame estas bebidas.");
                    cCDialogue.Add("Seguro revive mi fuerza.");
                    cCDialogue.Add("Voy a intentar que esto me despierte como es debido.");
                    cCDialogue.Add("¿Está prohibido venderme esto? En mis tiempos, bebíamos esto sin problema.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Salta"))
                {
                    cCDialogue.Add("Hola… Hola… Humano .");
                    cCDialogue.Add("Maldito cacharro, no ir como yo querer.");
                    cCDialogue.Add("Llevo desde ser zanahorio con esta silla, y aún fallar.");
                    cCDialogue.Add("Yo ser Saltaralisis y querer cambiar runas de una vez.");
                    cCDialogue.Add("Sí no cambiar runas, no hablar bien y crear malentendidos.");
                    cCDialogue.Add("Ya pasar otro día en banco, y cuando yo decir nombre, romper runa.");
                    cCDialogue.Add("Así que repetir palabra ASALTAR todo rato.");
                    cCDialogue.Add(" Ellos llamar guardia y yo acabar en cárcel 3 días.");
                    cCDialogue.Add("Duros días, pero conocer gente maja en cárcel.");
                    cCDialogue.Add("Yo conocer…Yo conocer…Yo conocer… Sapótamo borracho.");
                    cCDialogue.Add("Vuelve a fallar, mejor cobrar para cambiar runas.");
                    cCDialogue.Add("Gra… Gra… cías, cambiar runas ahora.");
                    cCDialogue.Add("No…No…. Poder cambiar, crear más mal entendidos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola mortal, ¿No habrás visto un libro mágico alguno de estos días?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Llevo días buscando un libro que se me fue robado, es importante ¿sabes?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("El habla no parece ser tu punto fuerte mortal.");
                    cCDialogue.Add("Pero bueno, haré que ese ladrón recuerde mi nombre, Manolo Mago Manitas.");
                    cCDialogue.Add("Por su culpa y la del otro calamar no se pudo terminar el ritu…");
                    cCDialogue.Add("Si ves a alguien con libro mágico, avisame mortal.");
                    cCDialogue.Add("Puede que vuelva en algún otro momento, pero primero debo atender a mi deber.");
                    cCDialogue.Add("Tengo que volver a mi iglesia, hay que dar la misa para nuestro dios, Azathoth.");
                    cCDialogue.Add("Por lo que ve cobrandome mortal.");
                    cCDialogue.Add("Buen chico, nos vemos mortal.");
                    cCDialogue.Add("Parece que eres otro sacrificio más, Azathoth te maldecirá por tu incompetencia.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Raven"))
                {
                    cCDialogue.Add("¡Hola amigo mío! ¿No es un día maravilloso?");
                    cCDialogue.Add("Aunque ni he dormido, pero trabajar como DJ Rave-n siempre me llena de energía.");
                    cCDialogue.Add("Tuve que trabajar en una despedido de soltero, los chicos fueron muy majos.");
                    cCDialogue.Add("Pero mi compañero Handy lo pasó un poco mal la verdad.");
                    cCDialogue.Add("El soltero se encariñó con el pobre Handy, era un limbástico muy cariñoso.");
                    cCDialogue.Add("Pero bueno, me alegró de que al menos haya podido poner mi música.");
                    cCDialogue.Add("Porque la música de hoy en día es digamos… Demasiado triste y oscura.");
                    cCDialogue.Add("El grupo Tears of Limbastics es super triste, malditas canciones emos.");
                    cCDialogue.Add("¡Sí lo mejor es el grupo Magicians of Power, tiene canciones super divertidas! ");
                    cCDialogue.Add("Pero parece que la sociedad se está deprimiendo cada vez más.");
                    cCDialogue.Add("Aún así, intentaré alegrar al mundo con mis canciones.");
                    cCDialogue.Add("Pero para ello, necesito recargar pilas colega, que quiero recargar.");
                    cCDialogue.Add("Cobrame esto si puedes porfi.");
                    cCDialogue.Add("Gracias compi, ahora iré a descansar para deslumbrar esta noche más.");
                    cCDialogue.Add("No podré recargar pilas colega… Este será un día con más canciones emos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Hueso"))
                {
                    cCDialogue.Add("Chaval, casi me hago polvo arriba esperando, además tengo prisa.");
                    cCDialogue.Add("Estoy en la nueva exposición de dinosaurios de la ciudad.");
                    cCDialogue.Add("Y cuando digo que estoy, es que literalmente estoy.");
                    cCDialogue.Add("Debido a que tengo huesos de hace millones de años.");
                    cCDialogue.Add("Un mago arqueólogo me creó y como quedé tan raro, no se dignó ni en darme nombre.");
                    cCDialogue.Add("Literal me llamo Elemental de Hueso el elemental de huesos.");
                    cCDialogue.Add("Por suerte logré valerme por mi solo, y ahora obtuve un trabajo de verdad.");
                    cCDialogue.Add(" Ser esclavizado por un museo, muchos de mi raza desearían este puesto en vez de la mina.");
                    cCDialogue.Add("Pero bueno, cobrame chaval, que tienen que verme en el museo.");
                    cCDialogue.Add("Un poco caro el muñeco, pero hace años ese muñeco antes eran 3 esclavos elementales, gracias.");
                    cCDialogue.Add("Pero si las pociones las bebían hasta los dinosaurios, estúpidas normátivas.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Patxi"))
                {
                    cCDialogue.Add("No sé cómo mi hombre está tan ocupado, maldita programación. ");
                    cCDialogue.Add("Y siempre tan apagado, le están chupando el alma a mi Antonio. ");
                    cCDialogue.Add("Ay ay ay, Antonio mío deja la programa...");
                    cCDialogue.Add("¡¿Usted quién es?!  Espera que ya es mi turno.");
                    cCDialogue.Add("Me había olvidado que estaba en la cola mientras deliraba con mi Antonio.");
                    cCDialogue.Add("Es mi querido noviecito, curra más que un elemental en las minas.");
                    cCDialogue.Add("Y yo soy el mejor novio que se ha tenido, Patxi.");
                    cCDialogue.Add("El pobre trabaja de programador, mientras que yo soy corredor de bolsa.");
                    cCDialogue.Add("Solo tengo que correr con unas bolsas, es un buen trabajo para un limbástico.");
                    cCDialogue.Add("Y ya que su trabajo es tan complicado quiero hacerle algo especial…");
                    cCDialogue.Add("Quería prepararle una cena romántica esta noche, así que si puedes cobrarme esto.");
                    cCDialogue.Add("Mi Antonio va a perder la cabeza con esta cena, perdona, se me pegaron sus chistes.");
                    cCDialogue.Add("Enemigo del romanticismo, mi Antonio no va a disfrutar mi cena para relajarse.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("¡COLEGA, TE NECESITO DE VERDAD!");
                    cCDialogue.Add("HAN PROHIBIDO LAS CERVEZAS A LOS HÍBRIDOS");
                    cCDialogue.Add("EMPECÉ A HABLAR BIEN DE NUEVO");
                    cCDialogue.Add("HASTA ME LLEGÓ UNA SOLICITUD DE EMPLEO");
                    cCDialogue.Add("NO QUIERO VOLVER A TRABAJAR");
                    cCDialogue.Add("Y MENOS CON ESA TAL PETRA QUE ME QUITÓ EL TRABAJO");
                    cCDialogue.Add("¡ME NIEGO!");
                    cCDialogue.Add("TE DARÉ EL DINERO QUE NECESITES");
                    cCDialogue.Add("PERO NE-CE-SI-TO CERVEZA ");
                    cCDialogue.Add("¡TE QUIERO MUCHO COLEGA! ");
                    cCDialogue.Add("Hasta mi dependiente favorito…Adiós a Elvog Borracho");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Enano"))
                {
                    cCDialogue.Add("¡Hola pequeñín! No te había visto desde ahí abajo.");
                    cCDialogue.Add("Me sobra el dinero, para nada entré aquí por el 50% de descuento en magos.");
                    cCDialogue.Add("O incluso podría ser un 70% ahora que somos amigos.");
                    cCDialogue.Add(" Vale vale, no me mires con esa cara impasible, pero venga…");
                    cCDialogue.Add("Te prometo que te devolveré el dinero si me lo rebajas más.");
                    cCDialogue.Add("Por ejemplo, mi vecino aún me dice que le debo 2000 monedas y que deje de evitarlo.");
                    cCDialogue.Add("Pero, por favor, yo no lo evito por la deuda, lo evito para ahorrarme esas 2000 monedas.");
                    cCDialogue.Add("Creo que no debí decir eso…Bueno, mejor ve cobrando antes de que la lié más.");
                    cCDialogue.Add("Menos mal me he ahorrado esas monedas, así podré mantener mi enorme mansión durante 1 hora más.");
                    cCDialogue.Add("¿No tengo dinero ni con el 50% de rebaja? Me va a tocar embargar la casa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Hola de nuevo, venía a comprar…");
                    cCDialogue.Add("¡Pero qué, otra vez no!");
                    cCDialogue.Add("Estúpida batería rota, hace 1 segundo tenía batería de sobra y ahora de un momento a otro se pone en crítico mi energía.");
                    cCDialogue.Add("¡Necesito que me metas las baterías otra vez, y está vez ten cuidado con el agua!");
                }
            }

            else if (currentScene.name == "Day3_2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji") && vecesSamuraiAyudado < 2)
                {
                    cCDialogue.Add("Ufff, por los pelos, estupida batería, creo que está algo rota por estos sustos que me da");
                    cCDialogue.Add("Espero que esta deshonra no llegue a los oídos de mi maestro, muchas gracias humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji") && vecesSamuraiAyudado >= 2)
                {
                    cCDialogue.Add("Ufff, por los pelos, estupida batería, creo que está algo rota por estos sustos que me da");
                    cCDialogue.Add("Toma, quedate con mi espada legendaria \n cómo agradecimiento. Cuidala bien, la han tocado muchos \n más seres anteriores a ti.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rustica"))
                {
                    cCDialogue.Add("Hola cielo, se te vé algo cansado, ¿estás bien?");
                    cCDialogue.Add("Seguro que estás así por el trabajo, llevo años viniendo aquí y sé bien cómo os trata el jefe.");
                    cCDialogue.Add("Igual es un chico bueno aunque sea un poco avaricioso, egocéntrico, egoísta y explotador laboral.");
                    cCDialogue.Add("Todo el mundo tiene el lado bueno, lo sé bien con todos los años que he pasado viva. ");
                    cCDialogue.Add("Fuí de los primeros técnopedos, de ahí mi nombre, Rústica.");
                    cCDialogue.Add("Trabaje en varios sitios, uno de mis favoritos fue de camarera.");
                    cCDialogue.Add("En un bar muy elegante, creo que se llamaba Hell Fire Bar.");
                    cCDialogue.Add("Siempre había alguna que otra pelea entre amigos, o pequeñas peleas de bandas.");
                    cCDialogue.Add("Alguna vez nos pintaban las paredes con latas de spray, eran buenos chicos en el fondo.");
                    cCDialogue.Add("Fue una buena época… Disculpa cielo que me voy por las nubes.");
                    cCDialogue.Add("Cobrame esto, así voy tirando a la chatarrería a echar unas cartas con mis amigas.");
                    cCDialogue.Add("Gracias cariño, espero no llegar tarde a la chatarrería.");
                    cCDialogue.Add("¿Mi cupón está roto? Perdón cariño.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Buenos días dependiente, veo que ha sido un día ajetreado.");
                    cCDialogue.Add("Ayer mandamos al Detective León a investigar a los sospechosos de ayer, al parecer Giovanni sabe cosas.");
                    cCDialogue.Add("Tuvo en posesión un libro de magia ancestral, que fue prohibida hace siglos aunque se desconoce que hace.");
                    cCDialogue.Add("Nos comentó que se le encontró de camino de la gasolinera donde trabaja el fiambre la misma noche.");
                    cCDialogue.Add("Tras varias comprobaciones supimos que era cierto y que no puede ser el culpable.");
                    cCDialogue.Add("Aunque ahora tenemos alguna pista más, un cliente de esta tienda usó una bola de cristal en el ritual.");
                    cCDialogue.Add("Y que la compró bajo el nombre de “Manolo”, según un ticket tirado por la escena del crimen.");
                    cCDialogue.Add("¿Sabes si alguno de los siguientes sospechosos pueda tener relación con la descripción que te dí?");
                    cCDialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");

                }
            }

            else if (currentScene.name == "Day4")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola chico nuevo, veo que te estás acostumbrando al trabajo en mi tienda.");
                    cCDialogue.Add("Que raro que ningún mago te la haya arrancado la cabeza por negarte a cobrarle, al anterior dependiente le pasó eso.");
                    cCDialogue.Add("Aunque gracias a ese mago, no tuve que pagarle ese mes.");
                    cCDialogue.Add("Así acabé comprando el carruaje más rápido del reino, aunque se quedó obsoleto por culpa de los coches.");
                    cCDialogue.Add("Por culpa de esas estúpidas máquinas de 4 ruedas, los tecnópedos no podrán comprar pilas y bebida energética junta, por una reacción que los hace más rápidos.");
                    cCDialogue.Add("Se lo tienen merecido por hacerme gastar mis preciosas monedas en un carruaje que quedó obsoleto.");
                    cCDialogue.Add("Y también me enteré hace poco que hay una secta convirtiendo híbridos en limbásticos.");
                    cCDialogue.Add("Por lo que los híbridos no podrán comprar nada de magia negra, esa secta solo me ha hecho perder dinero.");
                    cCDialogue.Add("Bueno, es hora de que empiece tu turno, recuerda mirar las nuevas normas.");
                    cCDialogue.Add("Suerte humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jissy"))
                {
                    cCDialogue.Add("¿Qué pasa tío?¿Cómo estamos?");
                    cCDialogue.Add("Espera, tu… Tu no eres el de el otro día ¿no..?");
                    cCDialogue.Add("Yo  soy Jeese, Jeese Chemman, mi nombre de las calles tío.");
                    cCDialogue.Add("Perdona tronco pero, ¿Seguro que no eres el dependiente de siempre?");
                    cCDialogue.Add("Nunca se me ha dado bien esto de reconocer a la gente, ¿sabes?");
                    cCDialogue.Add("Pero tienes un parecido al anterior dependiente.");
                    cCDialogue.Add("Aunque creo que el anterior no era humano, era un raza superior ¿sabes?");
                    cCDialogue.Add("Espero que no te afectará el comentario, tampoco se me da bien socializar.");
                    cCDialogue.Add("En fín, espero que te vaya bien.");
                    cCDialogue.Add("Ah, sí, pero antes de irme, cobrame esto.");
                    cCDialogue.Add("Que me iba sin pagar ¿sabes?");
                    cCDialogue.Add("Gracias colega, deberíamos quedar algún día para hablar de la vida ¿sabes?");
                    cCDialogue.Add("Bueno tronco, no sé cómo no aceptas mi dinero, deberías mejorar en el trabajo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mara"))
                {
                    cCDialogue.Add("Uy, buenos días cielo, se nota que eres un buen trabajador.");
                    cCDialogue.Add("Debería de tomar ejemplo de ti, que me hubiera venido mejor trabajar en vez de ir a la horrible cita del otro día.");
                    cCDialogue.Add("Para una vez que decido volver a darle a un intento al amor, y con el tiempo que le dediqué a mi cuenta de Hybrinder.");
                    cCDialogue.Add("Llegué al pequeño local limbásticos, con mis patas raptoriales recién afiladas, y el tipo resultó no ser un híbrido.");
                    cCDialogue.Add("Ni siquiera su cabeza se veía apetitosa, tenía una pedazo de esfera en su cabeza.");
                    cCDialogue.Add("Igualmente accedí a cenar con él, aunque me hubiera engañado de esta manera.");
                    cCDialogue.Add("Nada más me separé de él, le bloqueé de todos lados, espero no verlo más en mi vida.");
                    cCDialogue.Add("Mi pata de la suerte seguro dejó de funcionar, es la de mi ex marido.");
                    cCDialogue.Add("Siempre la llevo en mi bolso, pero dejaré de usarla");
                    cCDialogue.Add("Perdona si te aburriste con mi historia querido, cóbrame que tengo que ir a más tiendas querido.");
                    cCDialogue.Add("Gracias cielo, quédate con mi pata de la suerte, no creo que la necesite más.");
                    cCDialogue.Add("Gracias cielo, espero nunca que no tengas citas como la mía.");
                    cCDialogue.Add("¿Está prohibido esto? Bueno, ayer vi varias personas comprándolo, que raro.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("Buenos días mi dependiente favorito, ¿no es preciosa la vida?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Veo que mi pregunta te dejo mudo al igual que yo cuando veo a mi nueva diosa.");
                    cCDialogue.Add("La cita del otro día no sólo fue genial, fue perfecta.");
                    cCDialogue.Add("Cuando la ví, quedé perdido en su ojos de mantis, y no paraba de querer acariciar sus preciosas y afiladas garras.");
                    cCDialogue.Add("Obvio fuí un caballero y no me atreví a tocar sus hermosas garras.");
                    cCDialogue.Add("Además de que no quería perder mi mano.");
                    cCDialogue.Add("Pero bueno, lo mejor de la cita fue cuando nos sentamos juntos y cenamos.");
                    cCDialogue.Add("Y esa cangumantis me dijo 10 palabras, ¡10 PALABRAS!");
                    cCDialogue.Add("Solo una hembra me había dicho más palabras que esas, mi madre.");
                    cCDialogue.Add("Mis palabras favoritas fueron / ¿Pagas tu, no ? / Quiso que pagara yo, qué romántico");
                    cCDialogue.Add("Tengo pensado decirle de tener otra cita, y creo que esto de aquí será necesario para la cita, así que si pudieras cobrarme.");
                    cCDialogue.Add("Te informaré sobre mi próxima cita, mi dependiente favorito.");
                    cCDialogue.Add("Tú, enemigo del amor, gracias por arruinar mi cita.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sergio"))
                {
                    cCDialogue.Add("Hola humano, ¿podrías ayudarme?");
                    cCDialogue.Add("He decidido no ir a la misión del mago raro que me invocó.");
                    cCDialogue.Add("No sé quién se cree para ir reviviendome sin mi permiso.");
                    cCDialogue.Add("Bueno, al caso, necesito 3 bebidas energéticas para activar mi 100%");
                    cCDialogue.Add("Y así escapar del reino con mi super energía, o eso ponía en internet sobre esta bebidas.");
                    cCDialogue.Add("Que me dices, ¿me ayudas?");
                    cCDialogue.Add("Gracias por tu ayuda, tendrás una recompensa, te daré mi legendaria espada, ¡LA GLOBOSPADA!");
                    cCDialogue.Add("Sabía que me ayudarías, suerte humano.");
                    cCDialogue.Add("¿De verdad? Qué poco corazón");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Elidora"))
                {
                    cCDialogue.Add("Hola súbdito, ¿No crees que deberías de dejar de atender en este sótano?");
                    cCDialogue.Add("Casi uno de mis fieles slimes se deshace por culpa de la caída.");
                    cCDialogue.Add("Y no sabes el precio que hubieras tenido que pagar por mi slime.");
                    cCDialogue.Add("Podría haberte nombrado mi nueva silla oficial… La única silla del Reino Slime.");
                    cCDialogue.Add("Mi gran y poderoso reino de 4 habitantes slimes, donde yo soy la reina.");
                    cCDialogue.Add("LA PODEROSA REINA MAGA ELIDORA LIMALIGNA.");
                    cCDialogue.Add("La reina más poderosa de todos los reinos.");
                    cCDialogue.Add("Aunque aún estoy con los papeles para volver mi reino oficial.");
                    cCDialogue.Add("Creo que te dejaré unirte a mi reino si me muestras tu gran habilidad atendiendo clientes.");
                    cCDialogue.Add("¿Qué me dices?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Ya veo que te he sorprendido tanto que te he dejado sin habla.");
                    cCDialogue.Add("Venga muestrame tus habilidades cobrando.");
                    cCDialogue.Add("Te haré el dependiente oficial… Nada más terminar con el papeleo, adiós humilde súbdito");
                    cCDialogue.Add(" En Reino Slime sirven estos cupones, adiós humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard") && noCobrarSergioCobrarGeeraardD4 == 0)
                {
                    cCDialogue.Add("¡Humano, que le vendiste a mi limbástico!");
                    cCDialogue.Add("Con lo que me costó convencer a la iglesia para invocarlo.");
                    cCDialogue.Add("No sabes lo difícil que fue encontrar a ese mago mano.");
                    cCDialogue.Add("Y por no hablar de los ingredientes para revivirlo, fueron muy costosos.");
                    cCDialogue.Add("Serás… Claro, esto es lo que pasa por dejar a un humano trabajar.");
                    cCDialogue.Add("Has perdido un cliente, ¡PARA SIEMPRE!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard") && noCobrarSergioCobrarGeeraardD4 != 0)
                {
                    cCDialogue.Add("Hola humano, espero que en estos días te hayas leído una de miles historias.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Tu mirada me dice que no es así, ¿Es que no tienes tiempo para leer en casa?");
                    cCDialogue.Add("Eres de los peores fans que he tenido en mi vida.");
                    cCDialogue.Add("Espero que leas al menos una antes de que escriban mi nueva historia: La caza del collar de Sin Cuello.");
                    cCDialogue.Add("Mañana mismo partiré camino del reino junto con mi nuevo compañero.");
                    cCDialogue.Add("Es un limbástico que reviví con ayuda de un mago mano un poco extraño.");
                    cCDialogue.Add("Al parecer es el único tipo del reino que sabe hacer limbásticos, y yo que pensaba que revivían solos");
                    cCDialogue.Add("Bueno, como decía de mi compañero, dicen que cuando estaba vivo tenía unos nervios de acero.");
                    cCDialogue.Add("Así que por eso solo revivimos su sistema nervioso y su cerebro.");
                    cCDialogue.Add("Espero que sea tan capaz como yo, aunque se le ve un poco tirillas.");
                    cCDialogue.Add("En fin, necesitaré algunos materiales para el viaje, y esta tienda tiene suerte de ser mi proveedora no oficial.");
                    cCDialogue.Add("Por lo que tendrás el honor de cobrarme, y con suerte recibirás un autógrafo mio.");
                    cCDialogue.Add("Deséame suerte en mi aventura, te daré mi foto favorita con un autógrafo, por tu humilde servicio.");
                    cCDialogue.Add("Deséame suerte en mi aventura, aunque no la necesite.");
                    cCDialogue.Add("Por todo lo que he hecho por el reino, y me lo pagan así.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Magma"))
                {
                    cCDialogue.Add("Buenas mañanas persona fría, soy Magmadora.");
                    cCDialogue.Add("Frío de personalidad o frío de carne, tú dirás, solo tienes que mirarme.");
                    cCDialogue.Add("Veo que no eres el mismo trozo de carne fría que había antes en este lugar.");
                    cCDialogue.Add("Haber si llega ya el maldito verano que yo soy de los que prefiere el calor, sino mira como estoy que ardo.");
                    cCDialogue.Add("De verdad que la gente que prefiere el frío no la entiendo.");
                    cCDialogue.Add("Si no estuvieras hecho de carne, también preferirías el calor.");
                    cCDialogue.Add("Ventajas de no poder sudar.");
                    cCDialogue.Add("En fin, ¿Te importaría cobrarme esto? Que me estoy quedando sin llama y tengo que avivarme un poco.");
                    cCDialogue.Add("Gracias, espero que cuando termine de trabajar no se enfríe de camino a casa.");
                    cCDialogue.Add("¿Cómo que han prohibido comprar pociones? ¡AHORA CÓMO PODRÉ COMPRAR MI POCIÓN DE LAVA!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("Dependiente... Hoy no podría ser... ¡LA MEJOR SEMANA DE MI VIDA!");
                    cCDialogue.Add("El trabajo del otro día fue genial, los solteros fueron encantadores.");
                    cCDialogue.Add("Les encantó cuando me puse a hacer mi monólogo.");
                    cCDialogue.Add("Y mi compañera es una DJ genial, en el momento de las copas salió a hacer su parte.");
                    cCDialogue.Add("Baile con el novio un rato, pero no paraba de tocar mi bocina, era un tipo raro.");
                    cCDialogue.Add("Pero bueno, ahora tenemos un nuevo trabajo para hoy, una gatoteca.");
                    cCDialogue.Add("Hemos pensado en animar haciendo un musical con los gatos, pero son unos bichos muy ariscos y arrítmicos.");
                    cCDialogue.Add("Así que hemos pensado en otra cosa, vamos a bollos con forma de gatito.");
                    cCDialogue.Add("En fin, sabes que me encanta estar contigo, pero se me está haciendo tarde amigo.");
                    cCDialogue.Add("Por lo que cóbrame que tengo que alegrar esa gatoteca.");
                    cCDialogue.Add("Gracias amigo, como muestra de nuestra amistad, el traje que usé en la despedida de soltero.");
                    cCDialogue.Add("Deséame la mayor de las suerte en mi nuevo trabajo.");
                    cCDialogue.Add("Espero que el trabajo me vaya bien igualmente");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Buenos días chico… Eres el del otro día ¿no?");
                    cCDialogue.Add("Tengo mala memoria, debe ser porque siempre pierdo la cabeza, ja ja ja...");
                    cCDialogue.Add("Sabía que eras tú, aún recuerdo el vacío que dejabas cada vez que contaba mi mejor chiste.");
                    cCDialogue.Add("Entonces tengo la confianza de decirte que me gustaría hacer un regalo a mi novio Patxi.");
                    cCDialogue.Add("Ayer me hizo una cita y quiero hacer algo a cambio, pensé en proponerle hacer senderismo.");
                    cCDialogue.Add("Pero con lo lento que voy y lo rápido que va él, seguro no lo disfrutamos igual, por eso me decanté por la opción del regalo.");
                    cCDialogue.Add("Espero que le guste este gato muerto, seguro que le recuerda a Mistafurriño.");
                    cCDialogue.Add("Era su gato cuando estaba vivo, y puede que quiera algo que le recuerde a él.");
                    cCDialogue.Add("Cóbrame por favor que tengo que envolver el regalo.");
                    cCDialogue.Add("Espero que le guste este regalo.");
                    cCDialogue.Add("Ahora que le regalo yo a mi Patxi.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola humano, hoy no vengo como cliente, sino como testigo de Azathoth.");
                    cCDialogue.Add("¿Has reconsiderado acercarte a mi iglesia?");
                    cCDialogue.Add("Últimamente aceptamos a varios humanos para que se unan a rezar con nosotros, siempre vienen nuevos.");
                    cCDialogue.Add("Aunque hace poco comprobamos que los híbridos también son “bienvenidos” a nuestra religión.");
                    cCDialogue.Add("Transformamos a uno de ellos en uno de los nuestros... Fue simplemente arte.");
                    cCDialogue.Add("Pero bueno, solo me acercaba por aquí para que reconsideraras la oferta, siempre te daremos una mano.");
                    cCDialogue.Add("Suerte en la tienda, humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Buenos días humano, la investigación se está alargando bastante.");
                    cCDialogue.Add("Puede que no lo sepas, pero este caso se empezó porque estamos buscando a quién está creando limbásticos.");
                    cCDialogue.Add("Los limbásticos son incapaces de recordar dónde les crearon, pero con algo de investigación encontramos algo.");
                    cCDialogue.Add("Un sospechoso de ayer parece formar parte de una religión de la que desconocemos.");
                    cCDialogue.Add("Y creemos que pueden estar relacionados con la creación de limbásticos.");
                    cCDialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                    cCDialogue.Add("Creemos que el sospechoso se reunió con otro cliente de esta tienda para hacer un limbástico.");
                    cCDialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                    cCDialogue.Add("Creemos que el sospechoso se reunió con otro cliente de esta tienda para hacer un limbástico.");
                    cCDialogue.Add("¿Sabes si alguno de los siguientes sospechosos se relacionó con la iglesia?");
                    cCDialogue.Add("Muchas gracias por la información, espero que tenga un buen día, humano.");
                }
            }

            else if (currentScene.name == "Day5")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola humano, ¿Sabes que hoy es un día especial?");
                    cCDialogue.Add("Es el primer día del año que no tenemos nuevas normas, ¡ASÍ PODRÉ TENER MÁS DINERO!");
                    cCDialogue.Add("Y al ser un día tan especial, te daré un trato especial.");
                    cCDialogue.Add("Revisaré cómo trabajaste por mis cámaras… Digo con mis poderosas habilidades mentales.");
                    cCDialogue.Add("Y si lo has hecho muy bien, seguirás trabajando aquí, o al menos espero que puedas pagarte la maldita documentación.");
                    cCDialogue.Add("Como no hayas ganado suficiente dinero, ¡TE QUEDAS SIN LA DOCUMENTACIÓN!");
                    cCDialogue.Add("Pero bueno, confío que hayas sido un buen trabajador.");
                    cCDialogue.Add("Suerte en el que espero que no sea tu último día.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Elidora"))
                {
                    cCDialogue.Add("Hola humano, vengo defraudada de lo mal hecho que está este reino.");
                    cCDialogue.Add("Fuí al famoso restaurante de “Tips”, y no dejaron pasar a mis humildes ciudadanos esclavos de slime.");
                    cCDialogue.Add("Alguna híbrido debió hacer esas normas tan tontas, ¿Cómo no van a permitir criaturas mágicas?");
                    cCDialogue.Add("Y lo peor es la DECADENCIA del lugar, me obligaron a sentarme en una silla en vez de en mi slimes.");
                    cCDialogue.Add("Y porqué no hablar del servicio, casi tuve que cazar a los camareros, cómo un oságuila a un salmón.");
                    cCDialogue.Add("Le voy a poner una estrella en TripKingdom a ese maldito sitio.");
                    cCDialogue.Add("Seguro no me atendían como debían por ser la reina del reino slime, esos híbridos magofóbicos.");
                    cCDialogue.Add("Menos mal que en mi reino no excluimos a nadie, excepto a los híbridos a partir de este mal servicio.");
                    cCDialogue.Add("Haré un restaurante llevado por slimes que lo harán mejor que esos inútiles.");
                    cCDialogue.Add("Bueno, humano cóbrame que tengo que empezar con la edificación de mi reino.");
                    cCDialogue.Add("Bien hecho humano, si se te da tan bien cobrar, seguro también se te da bien ayudarme con las obras de mi reino.");
                    cCDialogue.Add("Estúpido humano, menos mal que mis dependientes slimes serán más listos que tú.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rockon"))
                {
                    cCDialogue.Add("Ho-hola amigo, ¿qué tal tu-tu-tu día de hoy?");
                    cCDialogue.Add("Seguro que fue un día pri-pri-edrástico, como decimos chicos piedras.");
                    cCDialogue.Add("Tenemos muchas expresiones ra-raras gracias a mis primos roca, son de pueblo cerrado.");
                    cCDialogue.Add("Además de que son chicos fuerte como mi padre, dicen que son “Gymbros”.");
                    cCDialogue.Add("Debería de ir al “Muscle Beluga” para me-mejorar mis músculos, es el mejor gimnasio del reino.");
                    cCDialogue.Add("Así igualaría la fuerza de mis primos y podría ayudar a mi padre en su restaurante.");
                    cCDialogue.Add("Él está como esclavo en el “Tips” del reino, es el mejor sitio para comer.");
                    cCDialogue.Add("Aunque cada día le tocan clientes más desagradables, fue una ma-maga que quería pasar a unos slimes.");
                    cCDialogue.Add("Se nota que no sabe lo que cuesta limpiar la baba de esas po-pobres criaturas.");
                    cCDialogue.Add("Se-seguro que estoy haciendo mucha cola, cóbrame amigo.");
                    cCDialogue.Add("Gra-gracias, espero le gusten estos peluches con forma humana a mi padre.");
                    cCDialogue.Add("Me falta di-dinero, jopetas, perdón por intentar engañarte con el cupón.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Buennnasss *hip* Tú…Tú…  Ahí está miii dependiente favorito.");
                    cCDialogue.Add("Erres el mejor, tíoooo, gracias a tí no tengo trabajarrr más, er jefe me ha visto borracho, de nuevo.");
                    cCDialogue.Add("Ahorra seguirré con mi increíble vida jubeniiiil, eres er único capaz de entenderme*hip*");
                    cCDialogue.Add("Te invitarría a una birra, pero no sé que bebeís los hurmanos, tenéis pinta de beberrrr Carrimocho.");
                    cCDialogue.Add("No parreceis bebedores fuertes como yo, mi hígado y yo segurro somos los combatientes más fuertes del reino*hip*");
                    cCDialogue.Add("Te estoy robando muuuuucho tiempo, solo quiero decirte que esperro que podamos ser amigos.");
                    cCDialogue.Add("Te darré esta botella, en señal de nuestra amis *hip* tad");
                    cCDialogue.Add("Nos vemos besto amigo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Petra"))
                {
                    cCDialogue.Add("Hola amigo… Al igual que tu me diste ánimos para trabajar, te tendré que contar una nueva noticia…");
                    cCDialogue.Add("Me han despedido… Es… ¡Una muy buena noticia!");
                    cCDialogue.Add("Ese tipo era un explotador de mucho cuidado, ¿quién se creía?");
                    cCDialogue.Add("Quería que le encontrará un lugar llamado Atlantis con un mapa del menú infantil del Tips.");
                    cCDialogue.Add("Ahora le tocará al nuevo hacer eso, o mejor dicho al que han recontratado");
                    cCDialogue.Add("Con la nueva prohibición del alcohol, el sapopótamo dejó el alcohol.");
                    cCDialogue.Add("Espero que le vaya bien, aunque lo dudo.");
                    cCDialogue.Add("Además, me podré librar de algunas que llevaba en la mochila, como este mapa vacío.");
                    cCDialogue.Add("Te lo puedes quedar, aunque dudo que le puedas dar mucho uso, principalmente porque no tiene nada.");
                    cCDialogue.Add("Nos vemos amigo.");
                }


                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("Hola colega, tengo una mala noticia para ti.");
                    cCDialogue.Add("La cangumantis y yo lo hemos dejado, me echó spray de pimienta en la esfera cuando la encontré.");
                    cCDialogue.Add("Es una de las maneras en la que me han dejado, la peor una de mis exs que me dejó por mi hermano.");
                    cCDialogue.Add("Pero esto ha hecho que abra los ojos y me dé cuenta que de tanto pensar en el amor, me perdí en el sendero de la vida.");
                    cCDialogue.Add("Así que tome una decisión importante y me desinstalé Hybrinder, aunque me quedara un año de premium.");
                    cCDialogue.Add("Creo que ahora voy a rehacer mi vida, ahora que soy un limbástico.");
                    cCDialogue.Add("Puedo intentar ser un monje, perdido en la montaña, para encontrar un nuevo camino.");
                    cCDialogue.Add("Pero creo que me quedaré trabajando en la gasolinera como siempre, hasta que encuentre mi camino.");
                    cCDialogue.Add("Hablando de la gasolinera, cóbrame que tengo dentro de nada el turno.");
                    cCDialogue.Add("Gracias, quédate con este cuadro de Mara, para que me olvide de ella.");
                    cCDialogue.Add("Voy a empezar con ganas mi nuevo camino, si es que me llega.");
                    cCDialogue.Add("Espero que empezar mi nuevo camino no se vea afectado por mi nulas capacidades de contar monedas.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Masermati"))
                {
                    cCDialogue.Add("Hola cocherrumín, ¿adivina quién participó en la carrera del otro día y quedó en 1º lugar?");
                    cCDialogue.Add("Pues yo no porque quedé en 8º lugar, pero lo importante fue participar.");
                    cCDialogue.Add("Si sigo entrenando, puede que para la próxima quede en 1º lugar.");
                    cCDialogue.Add("Si no fuera porque Flecha Rápida hiciera trampa, ese trasto de 4 ruedas lanzó clavos por el camino.");
                    cCDialogue.Add("Es igual de miserable que su dueño Pijus Magnus, la próxima vez no se repetirá.");
                    cCDialogue.Add("Menos mal que mi familia se quedó apoyándome hasta el final.");
                    cCDialogue.Add("Seguro que en cuanto me ponga la luces traseras y el cambio de marchas mejoraré mucho más.");
                    cCDialogue.Add("Pero como siempre dan citas para dentro de 3 meses en reparación pública.");
                    cCDialogue.Add("Esperaré hasta la cita y la operación para ser mejor coche en mi siguiente carrera.");
                    cCDialogue.Add("Bueno cocherrumín, creo que debería ir corriendo hasta casa que se me hace tarde.");
                    cCDialogue.Add("Ahora voy acelerando a casa para no llegar tarde, chao.");
                    cCDialogue.Add("Con las prisas debí romper el cupón.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Hola amigo, ¿a que me ves diferente?");
                    cCDialogue.Add("Se curó mi miopía gracias a beber tanto veneno.");
                    cCDialogue.Add("¿Quién iba a decir que el veneno era la cura?");
                    cCDialogue.Add("Me imagino que no lo ha probado nadie antes, porque se moriría sino.");
                    cCDialogue.Add("Pero como no puede morir alguien muerto, me curé.");
                    cCDialogue.Add("Gracias por vendernos el veneno a Patxi y a mí.");
                    cCDialogue.Add("Ahora no necesitaré mis gafas, puedes quedártelas.");
                }


                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Buenos días próximo creyente, veo que sigues encadenado a esta tienda.");
                    cCDialogue.Add("Podrías intentar ser más libre si vinieras alguna vez a una de las misas de mi iglesia.");
                    cCDialogue.Add("Además te beneficiaría venir, con cierta información que te voy a contar ahora.");
                    cCDialogue.Add("Vamos a hacer que vuelvan antiguos héroes a la vida, el primero fue el gran Sergio Nerviosaus.");
                    cCDialogue.Add("Pero dentro de poco, no será el único que volverá a la vida y nos ayudará.");
                    cCDialogue.Add("Así que creo que te beneficiaría estar de nuestra parte, y no de la del detective que lleva unos días viéndote.");
                    cCDialogue.Add("¿Crees que no lo sabía? Ese detective lleva algunos días indagando en nuestra sagrada iglesia.");
                    cCDialogue.Add("Además de que siempre viene a esta tienda al final del día, así que espero que hoy le mientas un poquito.");
                    cCDialogue.Add("Pero bueno, hoy vine como cliente, por lo que cóbrame humano.");
                    cCDialogue.Add("Te espero pronto en mi iglesia, humano.");
                    cCDialogue.Add("Cuando revivamos a los héroes, espero que no sepas contar mejor.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Salta"))
                {
                    cCDialogue.Add("Hola humano, ¿cómo estar día?");
                    cCDialogue.Add("Como tu ver ver ver ver ver romper runas de nuevo.");
                    cCDialogue.Add("Yo estar en bar anoche con mi querida familia, hasta que un borracho echarme toda su bebida encima.");
                    cCDialogue.Add("El tipo no quiso reparar mis runas y romperlas toda la noche.");
                    cCDialogue.Add("Ahora necesitar cambiar runas de nuevo, la gente no comprender a mí.");
                    cCDialogue.Add("No entender que yo no nacer con mitad animal, si no con vegetal.");
                    cCDialogue.Add("Deber cambiar alguna cosa para hacer mejor trato a los híbridos mitad vegetal.");
                    cCDialogue.Add("O al menos hacer algo para que los híbridos vegetarianos no babear babear babear con nosotros.");
                    cCDialogue.Add("Ya volver a funcionar mal, cóbrame que querer cambiar runas.");
                    cCDialogue.Add("Gracias humano, cambiar en nada runas.");
                    cCDialogue.Add("Yo solo querer cerveza para papá, pero bueno, dar solo runas mejor.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Raven"))
                {
                    cCDialogue.Add("Hola cielo, espero que estés teniendo un día brillante.");
                    cCDialogue.Add("A mí ayer me fue genial en la gatoteca, fue muy divertido a mi compañero huir de los gatos.");
                    cCDialogue.Add("Se le pegaban los gatos con la estática de los globos.");
                    cCDialogue.Add("¡Además pudimos atender a uno de los miembros de la banda de Magicians of Power!");
                    cCDialogue.Add("¡SON EL MEJOR GRUPO DEL MUNDO!");
                    cCDialogue.Add("Y gracias a mis increíbles dotes de persuasión y carisma, me regalaron dos entradas para ir.");
                    cCDialogue.Add("Seguro le digo a Handy de ir, es un gran compañero, y se esfuerza más que ninguno que haya tenido.");
                    cCDialogue.Add("Aunque su debilidad sean los gatos con mucho pelo.");
                    cCDialogue.Add("No sé cuál será el próximo trabajo, pero espero que pueda hacerlo junto con él.");
                    cCDialogue.Add("Te quite mucho tiempo amigo mío, cobrame esto porfi.");
                    cCDialogue.Add("Eres el mejor, no sé si te interese, pero ya que somos tan buenos amigos te daré mi disco favorito.");
                    cCDialogue.Add("Gracias amigo, espero que llegue ya el día del concierto.");
                    cCDialogue.Add("¿No puedo comprar esto? Creía que tenía todo el dinero.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Hola humano, creo que me acaba de pasar algo sorprendente después de estos años trabajando.");
                    cCDialogue.Add("Han habido recortes en mi trabajo, por lo que pensaba que me iban a recortar mi sueldo de 3 monedas al mes.");
                    cCDialogue.Add("Pero lo que parecía un recorte de sueldo, acabó siendo un recorte de verdad.");
                    cCDialogue.Add("Literalmente han cortado una parte de mí, y salió un mini yo, por lo que creo que ahora soy papicio.");
                    cCDialogue.Add("Vaya suerte tendrá el tapicín de tener un padre tan realista como yo.");
                    cCDialogue.Add("Así sabrá de inicio lo triste y dura que es la vida, y no le pasará como a mí al nacer.");
                    cCDialogue.Add("Aunque no sé qué necesitan comer los tapicines cuando son pequeños, puede que un poco de gravilla le guste.");
                    cCDialogue.Add("Bueno, hablando del peque, tengo que ir a por él en nada, así que cóbrame.");
                    cCDialogue.Add("Gracias, a ver si estar ahora con hijo me anima más.");
                    cCDialogue.Add("Ahora el niño me verá más deprimente de siempre.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Traigo muy buenas noticias humano, estamos a nada de cerrar el caso.");
                    cCDialogue.Add("Uno de los sospechosos de ayer confesó que la iglesia le ayudó a revivir a un tal Sergio Nerviosaus.");
                    cCDialogue.Add("Esta noche, haremos una redada en la iglesia para encerrar a los miembros.");
                    cCDialogue.Add("Así que puede que en nada vayamos a cerrar el caso, aunque aún nos queda una cosa por resolver.");
                    cCDialogue.Add("Quién fue la persona que le dió con el orbe al fiambre.");
                    cCDialogue.Add("Tenemos algunos sospechosos, pero creemos que es el líder principal.");
                    cCDialogue.Add("Hasta el detective Black no sabe quién arrestar.");
                    cCDialogue.Add("Dime humano, ¿quién crees qué es el líder?");
                    cCDialogue.Add("Muchas gracias por ayudar en el caso, espero que nos volvamos a ver.");
                }
            }

            else if (currentScene.name == "Home")
            {
                if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Tapicio"))
                {
                    cCDialogue.Add("Saludos humano **suspira**");
                    cCDialogue.Add("Tu jefe me dijo que te quedarías aquí, qué lugar más triste.");
                    cCDialogue.Add("Por desgracia tendré que animar este sitio, he traído mi juego favorito.");
                    cCDialogue.Add("Parecías nuevo en el reino y me diste pena al verte **suspira**");
                    cCDialogue.Add("Seguramente más clientes como yo puedan traerte cosas si les tratas bien.");
                    cCDialogue.Add("Ya sea cobrándoles aunque no debas, o ayudándoles con alguna cosa.");
                    cCDialogue.Add("Seguro que con más objetos animas este sitio.");
                    cCDialogue.Add("Aunque me gustaría que quedase más triste, como mi propia existencia.");
                    cCDialogue.Add("Te dejo de molestar humano, suerte estos días.");
                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bonna noche amigo mío, espero que descanses bien.");
                    cCDialogue.Add("Pero antes quería darte un regalo, mi libro de cocina.");
                    cCDialogue.Add("Bueno, mejor dicho... una copia, pedí que me lo clonaran con magia.");
                    cCDialogue.Add("Así los dos podremos hacer los platos que queramos cada día.");
                    cCDialogue.Add("Aunque aquí no veo ninguna cocina, solo un sótano sucio...");
                    cCDialogue.Add("Bueno, te las apañarás, ciao amigo mío.");

                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Elidora"))
                {
                    if (!slimeFostiados)
                    {
                        cCDialogue.Add("Hola súbdito, estoy haciendo un entrenamiento especial para que los slimes me duren más.");
                        cCDialogue.Add("Consiste en acariciarles la cabeza con un martillo, pero no me hace mucha gracia cogerlo yo");
                        cCDialogue.Add("¿Que asco agarrar algo áspero con las manos no? Prefiero que lo haga gente como tú");
                        cCDialogue.Add("Bueno, que me enredas, haz eso por mi y quien sabe, puede que algún día te de algo que se me rompa y ya no pueda usar");
                    }

                    else if (slimeFostiados)
                    {
                        if (slimeFail)

                            if (elidoraAcariciada)
                                cCDialogue.Add("¡Casi me abollas el cerebro!¡Escucho borroso!¡NUNCA TE LO PERDONARÉ CARMONA!");

                            else
                                cCDialogue.Add("Típico de un humano, no sé por qué te encargué una tarea tan difícil para un cerebro tan diminuto como el tuyo...");
                        else
                            cCDialogue.Add("Menudo abollón le has dejado a Mc Moco... No creo que me sirva así, te lo regalo");
                    }
                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola humano, veo que no has contado nada sobre la iglesia a ese detective.");
                    cCDialogue.Add("Has mostrado ser fiel a nuestra causa y a la iglesia.");
                    cCDialogue.Add("Ganaste mi confianza para considerarte uno de nosotros.");
                    cCDialogue.Add("Acepta este anillo como muestra de agradecimiento.");
                    cCDialogue.Add("Nos vivimos por verte estos días en la iglesia, ya me entiendes.");
                }
            }
        }
    }

    #endregion
}