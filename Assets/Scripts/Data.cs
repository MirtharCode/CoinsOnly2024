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

    [SerializeField] public int vecesCobradoCululu = 0;                 // Si le cobras 3 veces bien (d�a 1, 4 y 5), te llevas la foto de la cangumantis en pose sugerente
    [SerializeField] public int vecesCobradoGiovanni = 0;               // Si le cobras 2 veces bien (d�a 1 y 2), te llevas un libro que es la bomba.
    [SerializeField] public int vecesCobradaMara = 0;                   // Si le cobras 2 veces bien (d�a 1 y 2), te llevas una pata de la suerte.
    [SerializeField] public int vecesCobradaHandy = 0;                   // Si le cobras 2 veces bien (d�a 2 y 4), eres un puto payaso.
    [SerializeField] public int noCobrarSergioCobrarGeeraardD4 = 0;                   // No tienes que cobrar a Sergio en el d�a 4 y tienes que cobrar a Geerald en el d�a 4
    [SerializeField] public int vecesCobradoAntonio = 0;                   // Tienes que cobrar a Antonio en el dia 4 y a Paxi en el dia 3
    [SerializeField] public int vecesCobradoRaven = 0;
    [SerializeField] public int numGnomosFinded = 0;
    [SerializeField] public bool nerviosusPagaLoQueDebe = false;        // Si le cobras (d�a 4) te da la globoespada.
    [SerializeField] public bool nerviosusTeDebePasta = false;          // Si no le cobras Gerardo el magias te dar� su bella foto.
    [SerializeField] public bool slimeFostiados = false;                // Si le has dado hasta en el carnet de identidad a los slimes.
    [SerializeField] public bool slimeFail = false;                     // Si no llegaste a 50 puntos en el minijuego de Elidora.
    [SerializeField] public bool elidoraAcariciada = false;             // Si le metiste tremendo cebollazo al pedrolo de Elidora.

    [SerializeField] public bool giftGeeraard = false;      // Si nerviosusPagaLoQueDebe es falso, Geerard te dar� la foto firmada
    [SerializeField] public bool giftEnano = false;         // Te da un Enano. Si en el d�a 2 o 3 encuentras al enano zumb�n.
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

    #region Todos los di�logos de Coins Only

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
                    cCDialogue.Add("Y c�mo s� que es tu primer d�a, te estar� observando.");
                    cCDialogue.Add("Porque s� que no ser�s capaz de atender a los clientes bien.");
                    cCDialogue.Add("Ya sabes que todos los humanos sois in�tiles.");
                    cCDialogue.Add("No lo digo yo, lo dice vuestro cerebro enano.");
                    cCDialogue.Add("Pero bueno, como iba diciendo� �ATIENDE BIEN!");
                    cCDialogue.Add("No quiero perder dinero contigo.");
                    cCDialogue.Add("Para cobrar usa la CAJA REGISTRADORA.");
                    cCDialogue.Add("Y como cobres mal, te quitar� dinero de tu TARRO DE PROPINAS.");
                    cCDialogue.Add("Tienes el cat�logo de la tienda a la derecha para saber si el cliente tiene dinero suficiente.");
                    cCDialogue.Add(" Adem�s tendr�s una ayuda, la cabeza del antiguo empleado.");
                    cCDialogue.Add("Se la arranc� un cliente al que no le vendi� su alcohol.");
                    cCDialogue.Add("Menos mal que su sistema de traducci�n sigue funcionando.");
                    cCDialogue.Add("No iba a comprarte otro traductor como ese no fuera.");
                    cCDialogue.Add("Suerte en tu primer d�a, chico nuevo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard"))
                {
                    cCDialogue.Add("Buenas ciudadano, ya lleg� aqu�, el inigualable Geeraard, gracias, gracias�");
                    cCDialogue.Add("�");
                    cCDialogue.Add("�Por qu� no has empezado a llorar de la alegr�a y a pedirme un aut�grafo mientras est�s de rodillas?");
                    cCDialogue.Add("�C�mo no me conoces! Todos aqu� me conocen.");
                    cCDialogue.Add("El h�roe de h�roes, quien derrot� al Rey Demonio con una sola daga y los ojos vendados.");
                    cCDialogue.Add("Vamos� Todos mis admiradores, es decir, todo el reino, saben que soy el mejor h�roe de la historia.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Bueno, me imagino que perdonare tu desconocimiento y ese silencio inc�modo que provocas.");
                    cCDialogue.Add("Cobrame esto al menos, as� esta charla dejar� de ser tan inc�moda.");
                    cCDialogue.Add("Deber�as de leer alguna de mis grandes historias humano, adi�s.");
                    cCDialogue.Add("Pero, �QU� INSOLENCIA ES ESTA! Espero que cuando vuelva aprendas a contar monedas humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Buennnasss *hip* Eeeehhhhh� tuuu no eres el de sieeeembrree� *hip*");
                    cCDialogue.Add(" Bueno, el otro erra un ######");
                    cCDialogue.Add("Ahorra a quien le direee sobre niii despidoooo� Encimaaa eres humanooo�*");
                    cCDialogue.Add("Ne tocarra contarrrrte a tuuu� *hip*");
                    cCDialogue.Add(" Soy Elvog, er ex ex explorador");
                    cCDialogue.Add("Mooo te looo vasss a creer� El ###### de mi jefeee me despidi� *hip*");
                    cCDialogue.Add("Me dijooo que beb�a mushoo alcohooool y que estoy viejo, �perro quee dise eseee? *hip*");
                    cCDialogue.Add("Siii solo temgo 22 a�itos, estoooy em la fror de la hueventud *hip*");
                    cCDialogue.Add("Buemo, che me olvid� *hip*, puedess cobrarme estooo�");
                    cCDialogue.Add("Gracias mushacho *hip* Ahorra ser�s ni depemdiete favorito *hip*");
                    cCDialogue.Add("Perro mushacho *hip* el otroo depemdiete erra mejor *hip*");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Ey� Hola amigo, soy Antonio� �Qu� tal tu d�a?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Ya veo� No eres muy hablador eh.");
                    cCDialogue.Add("Te entiendo tio, yo tambi�n estoy tan cansado cuando curro en programaci�n.");
                    cCDialogue.Add(" No se como sobreviv� a esta jornada laboral, puede que porque est� muerto.");
                    cCDialogue.Add(" Ja ja ja ja ja� Perd�n, los chistes no son lo m�o, mi cabeza no funciona tras un d�a de trabajo tan duro.");
                    cCDialogue.Add("Hace que mi cerebro no funciona, porque estoy muerto.");
                    cCDialogue.Add("Ja ja ja ja ja� Perd�n ya paro.");
                    cCDialogue.Add("Cobrame y dejar� de incomodarte.");
                    cCDialogue.Add("Gra-gracias, aunque ahora que lo pienso no s� si era todo el dinero�");
                    cCDialogue.Add(" Uy, me faltan monedas, siempre se cometen estos errores cuando pierdes la cabeza� Ya paro, nos vemos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Saludos desde mi solitaria existencia, soy Tapicio.");
                    cCDialogue.Add("�Qu� pasa? �Nunca has visto alguien tan animado verdad?");
                    cCDialogue.Add("Que quieres que te diga, soy prisionero de mi propio destino.");
                    cCDialogue.Add("Fui creado para solo trabajar, mis cadenas nunca se romper�n.");
                    cCDialogue.Add("A veces deseo seguir siendo ser ese peque�o tapiz colgado en el cementerio de limb�sticos.");
                    cCDialogue.Add("Pero por desgracia, mi vida es como una canci�n emo: Larga, triste y nunca termina.");
                    cCDialogue.Add("Al igual que esta conversaci�n, perd�n por hacerte perder el tiempo.");
                    cCDialogue.Add("Deber�as de cobrarme ya, o si no llegar� tarde a mi torneo de lanzamiento de miradas melanc�licas.");
                    cCDialogue.Add("Gracias, espero que no quedar en primer lugar, como siempre.");
                    cCDialogue.Add("Otra desgracia m�s para mi vida, ahora seguro gano el torneo por tu culpa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Buenas joven, no me creo que ahora solo sea un recadero�");
                    cCDialogue.Add("Perd�n, el jefe me est� poniendo la cabeza como un horno.");
                    cCDialogue.Add("Soy Denjirenji.");
                    cCDialogue.Add("He estado 10 a�os aprendiendo t�cnicas samurai infalibles y fu� el mejor de la promoci�n.");
                    cCDialogue.Add("Incluso salv� el mundo junto a cuatro tortugas ninja, y ahora�");
                    cCDialogue.Add("Solo sirvo para calentar su maldita comida, y encima la tengo que comprar yo.");
                    cCDialogue.Add("Perd� todo honor como samurai.");
                    cCDialogue.Add("Al final acabar� haci�ndome el harakiri con cucharas.");
                    cCDialogue.Add("Disculpa que te haya robado un poco de tu tiempo, cobrame esto por favor.");
                    cCDialogue.Add("Menos mal que ten�a el dinero justo, o eso creo.");
                    cCDialogue.Add("�Por una moneda! Disculpame, espero que el jefe no me mate.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mara"))
                {
                    cCDialogue.Add("Buenos d�as querido, soy Mara.");
                    cCDialogue.Add("�Pod�as luego ayudarme a cargar esto hasta fuera?");
                    cCDialogue.Add("Uy uy, que digo, me imagino que no puedes abandonar tu puesto.");
                    cCDialogue.Add("Desde que no est� mi marido, me cuesta m�s cargar la compra.");
                    cCDialogue.Add("Pero bueno, como quiero que est� mi marido si me lo com�.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Que raro que est�s inexpresivo, siempre que cuento eso se asustan.");
                    cCDialogue.Add("No s� porque no se normaliza que los manguros nos comamos a nuestra pareja.");
                    cCDialogue.Add("Pero s�lo para reproducirnos, no somos unos monstruos.");
                    cCDialogue.Add("Bueno, deber�as cobrarme, que tengo que recoger a mi ni�o del zoo.");
                    cCDialogue.Add("Muchas gracias joven, espero que tu pareja te coma pronto tambi�n ji ji ji.");
                    cCDialogue.Add("�Perdona? Ahora por tu culpa mi hijo no tendr� su gato muerto, �l solo quer�a una mascota");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("�Ahoy, amigo m�o! Soy Giovanni.");
                    cCDialogue.Add("No sabes lo que me encontr� hoy.");
                    cCDialogue.Add("�EL N-E-C-R-O-N-O-M-I-C-�-N!");
                    cCDialogue.Add("Es el libro de cocina definitivo, o eso creo�");
                    cCDialogue.Add("Bueno, solo con decirte la primera receta te va a encantar.");
                    cCDialogue.Add("�C�mo invocar a Azathoth�");
                    cCDialogue.Add("Suena incre�ble este plato, pillar� algunos ingredientes para hacer el plato.");
                    cCDialogue.Add("�Primer paso: rociar vino hecho de sangre de virgen�");
                    cCDialogue.Add("Cambiar� el vino por una buena cerveza, le dar� m�s sabor.");
                    cCDialogue.Add("�Segundo paso: cortar el mu�eco voodoo por la mitad junto con la persona sacrificada�");
                    cCDialogue.Add("No s� qu� es eso de la persona sacrificada, pero el mu�eco tiene buena pinta.");
                    cCDialogue.Add("�Y tercer paso: beber el veneno para que el Dios se adue�e de tu cuerpo�");
                    cCDialogue.Add("No suelo beber veneno, pero creo que se lo echar� al mu�eco para darle el toque picante.");
                    cCDialogue.Add("Tiene buena pinta �verdad? Para eso necesito estos ingredientes, as� que si puedes cobrarme.");
                    cCDialogue.Add("Gracias, la pr�xima vez que vuelva te dejar� probar el plato para que me des tu opini�n.");
                    cCDialogue.Add("Madre m�a, ahora te perder�s el mejor plato del mundo, pillar� las cosas en otro sitio.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rockon"))
                {
                    cCDialogue.Add("�Ho-hola que tal?");
                    cCDialogue.Add("Espero no molestar, y perdona mi tar-tartamudez. ");
                    cCDialogue.Add("En fin, perdona otra vez. No me disculpar� m�s, per-per-perdona.");
                    cCDialogue.Add("Estoy intentando me-mejorar, como buen Rockon que soy.");
                    cCDialogue.Add("Debo mejorar como pap�, es muy fuerte.");
                    cCDialogue.Add("Siempre me ha querido mu-mu-mucho.");
                    cCDialogue.Add("Mi co-comida favorita es la gravilla que me hac�a.");
                    cCDialogue.Add("Adem�s si le echabas cemento por encima, ya quedaba bueniiiiiisimo.");
                    cCDialogue.Add("Bu-bu-bueno en fin� �Me puedes cobrar esto?");
                    cCDialogue.Add("Es que le quiero dar una sorpresa a pap�, seguro que este gato mu-muerto le hace mucha ilusi�n.");
                    cCDialogue.Add("Gra-gra-gracias seguro que pap� se pone feliz");
                    cCDialogue.Add("Jopetas� Con la ilusi�n que me hac�a regalarles esto a pap� y mam� Pero no tengo todo el dinero");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefazo"))
                {
                    cCDialogue.Add("Seguro que fue muy agotador. pero mejor me lo comentas ma�ana.");
                    cCDialogue.Add("Y un pajarito llamado Inspector de Empleo me ha dicho que no tienes casa.");
                    cCDialogue.Add("Menos mal que tienes un jefe tan generoso y rico, as� que te prestar� una de las mejores viviendas del reino.");
                    cCDialogue.Add("Ese maravilloso lugar se llama: El s�tano de la casa de mi madre.");
                    cCDialogue.Add("Espero que te guste.");
                    cCDialogue.Add("Ll�vate el traductor por si tengo que hablar contigo, tendr�s que entender a mi madre.");
                }
            }

            else if (currentScene.name == "Day2_1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenos d�as chico nuevo.");
                    cCDialogue.Add("�Qu� tal tu primer d�a?");
                    cCDialogue.Add("Nah, es broma, realmente me da igual como te fuera tu primer d�a.");
                    cCDialogue.Add("Seguro te lo dije en el tutorial, pero seguro no te acuerdas por tu cerebro enano.");
                    cCDialogue.Add("Tenemos unas normas que seguir en la tienda a partir de hoy.");
                    cCDialogue.Add("Adem�s es �Magic Friday�, aunque lo seguir� siendo el resto del a�o, como todos los a�os...");
                    cCDialogue.Add("As� que los magos tienen rebajas, y el resto de razas trabajan m�s a cambio.");
                    cCDialogue.Add("Tambi�n han prohibido varias bebidas a algunas razas.");
                    cCDialogue.Add("Parece que sus cuerpos no soportan los ingredientes ilegales que llevan.");
                    cCDialogue.Add("Eso es menos dinero para mi por desgracia.");
                    cCDialogue.Add("Pero la multa ser� peor si me pillan.");
                    cCDialogue.Add("Recuerda revisar las normas, est�n a la izquierda de la pantalla.");
                    cCDialogue.Add("Buena suerte chico nuevo");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Lepion"))
                {
                    cCDialogue.Add("Hola humano.");
                    cCDialogue.Add("Espera, tu eres el tonto que no sab�a contar.");
                    cCDialogue.Add("Ayer vino aqu� ese microondas.");
                    cCDialogue.Add("Y ese cacharro debi� darte una moneda m�s");
                    cCDialogue.Add("Al menos ahora puedo justificar su despido");
                    cCDialogue.Add("Aunque el bobo se puso a decir cosas de hacer el harakiri o cosas as�.");
                    cCDialogue.Add("En fin, malditas m�quinas japonesas.");
                    cCDialogue.Add("Ya que est�s, cobrame esto, que debo seguir con mi trabajo de blanqueamiento de dinero.");
                    cCDialogue.Add("Adi�s");
                    cCDialogue.Add("Ni contar sabes, �de verdad? Acabas de perder todos los clientes chinos por la zona, \n y espero que pronto pierdas t� el trabajo.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bon d�a amigo m�o, espero que te est� yendo bien estos d�as.");
                    cCDialogue.Add("A m� el �ltimo plato del otro d�a no sali� como me esperaba la verdad� Me sali�... �PERFECTO! ");
                    cCDialogue.Add("Hice todos los pasos a la perfecci�n, aunque el veneno le di� un toque picante un poco raro.");
                    cCDialogue.Add("Y fue un poco extra�o cuando el plato empez� a hablarme en una lengua antigua, pero peores cosas he probado.");
                    cCDialogue.Add("A�n recuerdo cuando fui a un restaurante de elementales de roca, aunque obviamente el local era de un mago.");
                    cCDialogue.Add("El plato estrella era la gravilla, ese plato ten�a una textura asquerosa.");
                    cCDialogue.Add("Era como comerte un castillo de arena derretido.");
                    cCDialogue.Add("Pero bueno, ahora prepar� un plato mucho mejor, as� que necesitar� estos ingredientes amigo m�o.");
                    cCDialogue.Add("Gracias, te dejar� probarlo como quede bueno my besto frendo");
                    cCDialogue.Add("�Tengo prohibidos estos deliciosos ingredientes? El reino cada vez acaba con la libertad de la comida.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Enano"))
                {
                    cCDialogue.Add("�Hola peque��n!");
                    cCDialogue.Add("Soy el grandioso Manolo Cabeza de Pico, el mago m�s rico� Del barrio m�s alto del reino.");
                    cCDialogue.Add("Creo que se me ha colado uno de mis gnomos defectuoso en la tienda.");
                    cCDialogue.Add("Se llama Jos� Miguel Culo Escurridizo.");
                    cCDialogue.Add("El pobre no pod�a mantenerse quieto y se col� en la trampilla antes de turno.");
                    cCDialogue.Add("Aunque realmente me cae mal, no hace caso y no para de esconderse.");
                    cCDialogue.Add("Puede que si lo encuentras un par de veces esta semana se vaya contigo.");
                    cCDialogue.Add("As� me dejar� en paz el pesado, suerte busc�ndolo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("�Buenos d�as? �O noches? Ya no s� la verdad.");
                    cCDialogue.Add("Perd�n, te habr� confundido un poco, soy el del orbe el que habla.");
                    cCDialogue.Add("Por este maldito orbe solo puedo ver morado, no distingo si es de d�a o no.");
                    cCDialogue.Add("Me llamo Culul�, y hasta hace poco era un h�brido.");
                    cCDialogue.Add("Pero ahora soy un limb�stico, me mor� ayer mientras estaba en la gasolinera.");
                    cCDialogue.Add("Vi a un t�o con un libro rar�simo que parec�a hacer un ritual, y al verme, me di� un golpe con este orbe.");
                    cCDialogue.Add("Y al despertar, pues me qued� encerrado aqu�, aunque supongo que esto no sea un problema para mi cita.");
                    cCDialogue.Add("El detective de mi caso me dijo que no fuera por ahora hasta que me acostumbrara a mi nuevo yo.");
                    cCDialogue.Add("Pero la vida es una, y esa manguro es mi tipo ideal.");
                    cCDialogue.Add("Pero bueno, espero que encuentren al culpable pronto para que no me atosigue el detective.");
                    cCDialogue.Add("Ve cobrando estas pociones, que en unos minutos tengo la cita.");
                    cCDialogue.Add("Muchas gracias hermano, deseame suerte en la cita.");
                    cCDialogue.Add("T�o, de verdad que no te entiendo, si tengo toda la pasta.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("�Buen ser humano, necesito tu ayuda!.");
                    cCDialogue.Add("En mi casa se me han acabado las pilas y mi madre no estaba en casa para metermelas y darme energ�a.");
                    cCDialogue.Add("Por favor, necesito que me metas las pilas, ya te las pagar� luego. Recuerda meterlas en el hueco de la parte superior");
                    cCDialogue.Add("�Y r�pido!, que no quiero apagarme y convertirme en uno de esos horribles monstruos.");
                }
            }

            else if (currentScene.name == "Day2_2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Muchas gracias Ronin, que sepas que te lo recompensar� alg�n d�a, espero que mi maestro no se enfade.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("�Hola colega! �C�mo te encuentras? �Bien? �Mal?");
                    cCDialogue.Add("�YO ESTOY FENOMENAL!");
                    cCDialogue.Add("Soy Handy, el elemental m�s fiestero, que ama cualquier celebraci�n.");
                    cCDialogue.Add("Cumplea�os, bodas, despedidas de solteros y� �FUNERALES!");
                    cCDialogue.Add("Aunque del �ltimo funeral me echaron por alguna extra�a raz�n.");
                    cCDialogue.Add("Estoy tan emocionado amigo m�o, tengo una nueva compa�era.");
                    cCDialogue.Add("Se llama Rave-n, incluso estudi� fiestolog�a.");
                    cCDialogue.Add("Aunque a m� me expulsaron del grado de fiestolog�a por mi TFG sobre� �ALEGRAR FUNERALES!");
                    cCDialogue.Add("Se debieron de morir de la risa con mi TFG.");
                    cCDialogue.Add("Bueno colega, s� que est�s pasando un buen rato conmigo.");
                    cCDialogue.Add("Pero tengo una despedida de soltero y tengo que aguantar toda la noche despierto.");
                    cCDialogue.Add("Y necesito estos utensilios para sobrevivir a los solteros desesperados.");
                    cCDialogue.Add("Aunque no s� para qu� ser� la bola, me la pidieron los solteros");
                    cCDialogue.Add("Bueno, cobrame porfi porfita.");
                    cCDialogue.Add("Voy a hacer una despedida de soltero !INCRE�BLE! Nos vemos colega.");
                    cCDialogue.Add("Me has borrado la sonrisa t�o, pero entiendo que no puedas romper la normativa");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Petra"))
                {
                    cCDialogue.Add("Hola dependiente, de verdad que no puedo aguantar m�s mis ganas de empezar a trabajar.");
                    cCDialogue.Add("Necesito cont�rselo a alguien, �Por fin puedo ser una exploradora!");
                    cCDialogue.Add("Necesitaba soltarlo, no sabes lo emocionada que estoy con este nuevo trabajo.");
                    cCDialogue.Add("Por cierto, no me present�, me llamo Petra.");
                    cCDialogue.Add("He estado 12 a�os en paro desde que no llegu� a tiempo a una misi�n.");
                    cCDialogue.Add("Pero es lo que pasa cuando eres mitad tortuga y mitad liebre, que mi velocidad siempre ser� normal.");
                    cCDialogue.Add("Tambi�n mi jefe me coment� que esperaba que lo hiciera mejor que el �ltimo empleado.");
                    cCDialogue.Add("Era un sap�tamo que se la pasaba bebiendo en el trabajo.");
                    cCDialogue.Add("Menos mal que no bebo nada de alcohol en mi vida.");
                    cCDialogue.Add("Uy, perdona, te estoy quitando tiempo.");
                    cCDialogue.Add("Cobrame esto qu� lo necesito para el trabajo.");
                    cCDialogue.Add("Deseame suerte en mi primer d�a de curro, �Nos vemos!");
                    cCDialogue.Add("Necesitaba esto de verdad para el trabajo, el jefe me va a despedir y ni empec�.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Hola humano, �no tienes d�as libres o que? ");
                    cCDialogue.Add("Eres parecido en ese aspecto a los elementales, nosotros tampoco paramos de trabajar, es lo que tiene ser creaciones de los magos. ");
                    cCDialogue.Add("Espera, �no lo sab�as? La mayor�a de las razas actuales fueron creadas por ellos. ");
                    cCDialogue.Add("Que triste es la ignorancia de los humanos. ");
                    cCDialogue.Add("Los elementales fueron creados para hacer el trabajo de esclavos. ");
                    cCDialogue.Add("Los tecn�pedos fueron creados por accidente cuando metieron una varita en un microondas. ");
                    cCDialogue.Add("Y los limb�sticos no se sabe c�mo se crearon, solo se sabe que fueron los magos. ");
                    cCDialogue.Add("Le� en algunos foros de ocultismo que fueron creados por una iglesia que lleva a�os oculta entre nosotros.");
                    cCDialogue.Add("Tampoco pude leer mucho, es lo que tiene tener 23 horas de jornada laboral.");
                    cCDialogue.Add("Hablando de ello, en nada tengo que volver a trabajar como tapiz en un museo de la zona.");
                    cCDialogue.Add("Y encima tengo que explicar, de nuevo, al nuevo saco de huesos como va el trabajo all�.");
                    cCDialogue.Add("Le fue horrible en su primer d�a, aunque ya es horrible ser parte de nuestra raza.");
                    cCDialogue.Add("Por lo que ve cobr�ndome esto antes de que caiga en el olvido.");
                    cCDialogue.Add("Espero que acabe pronto mi jornada, aunque vaya a comenzar.");
                    cCDialogue.Add("Ni en mi descanso puedo conseguir un m�nimo de felicidad.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Masermati"))
                {
                    cCDialogue.Add("Hola cocherrum�n, estoy prepar�ndome para la carrera del siglo.");
                    cCDialogue.Add("No me present�, soy el famoso FMS, Faster More Serious.");
                    cCDialogue.Add("O como me llamo mi robo-madre, Masermati.");
                    cCDialogue.Add("Y voy a hacer la primera carrera de mi vida.");
                    cCDialogue.Add("Aunque espero que no sea la �ltima, no sabes la pasta que cuestan estas mejoras.");
                    cCDialogue.Add("Los tubos de escape costaron solo 100 monedas.");
                    cCDialogue.Add("No sabes todos los platos que limpi� para tener esa cantidad de monedas.");
                    cCDialogue.Add("Pero todo este trabajo fue necesario para el d�a de hoy, para ganar a�");
                    cCDialogue.Add("�FLECHA R�PIDA! El tecn�pedo m�s r�pido del reino.");
                    cCDialogue.Add("Es el coche oficial de Pijus Magnus, el 2� mago m�s poderoso del reino.");
                    cCDialogue.Add("O eso dice �l, aunque solo lo dice por ser hijo del Rey Mago.");
                    cCDialogue.Add("Realmente es un tirillas enano, espero que tengas suerte de no encontrarlo.");
                    cCDialogue.Add("Bueno, cobrame humano, que tengo que estar listo para la carrera.");
                    cCDialogue.Add("Gracias cocherrum�n, voy a prepararme para la carrera.");
                    cCDialogue.Add("�Pero si tengo suficiente! Da igual, tengo algo de prisa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Pijus"))
                {
                    cCDialogue.Add("T� ve cobrando esto que tengo prisa.");
                    cCDialogue.Add("Espera-");
                    cCDialogue.Add("��Eres humano?! �No te da verg�enza respirar el mismo aire que yo?");
                    cCDialogue.Add("No se ni como pagaste lo suficiente para entrar al reino.");
                    cCDialogue.Add("Y m�s te vale que me cobres bien, he le�do lo del 50%.");
                    cCDialogue.Add("As� que quiero que me lo rebajes T-O-D-O.");
                    cCDialogue.Add("Y como me cobres mal tendr� que usar mis poderosa habilidad�");
                    cCDialogue.Add("El n�mero de mi papi.");
                    cCDialogue.Add("Espero que me cobres bien, venga.");
                    cCDialogue.Add("As� me gusta humano, no sab�a qu� os hab�an ense�ado a contar all�.");
                    cCDialogue.Add("�C�mo que no sirve la oferta! Pues...Pues�Bonita moneda, me la quedo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Hola dependiente, soy del departamento de investigaci�n de sucesos paranormales, es decir, soy detective.");
                    cCDialogue.Add("Y ten�a una pregunta respecto a un caso sobre homicidio, alguien ha vuelto un h�brido a un limb�stico.");
                    cCDialogue.Add("Un poco pesado el fiambre diciendo que ten�a una cita, pero me da a mi que va a tener que esperar.");
                    cCDialogue.Add("Creemos que ha podido ser un artefacto m�gico el culpable, en concreto un libro de magia.");
                    cCDialogue.Add("�Sabes de alg�n clientes pueda tener un libro m�gico?");
                    cCDialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");
                }
            }

            else if (currentScene.name == "Day3_1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenas chico nuevo.");
                    cCDialogue.Add("Parece que te est�s acostumbrando a tu trabajo.");
                    cCDialogue.Add("Est�s durando m�s que el antiguo empleado.");
                    cCDialogue.Add("No s� c�mo sigues vivo siquiera.");
                    cCDialogue.Add("Pero bueno, tengo malas noticias.");
                    cCDialogue.Add("Ha empezado el mercado de una nueva raza: Los Cupones");
                    cCDialogue.Add("Son criaturas que se utilizan como trueque a cambio de objetos.");
                    cCDialogue.Add("Con los cupones podr�n pillar lo que quieran, �LES SALDR� GRATIS!");
                    cCDialogue.Add("Vaya asco de bichos, al menos son muy coquettes.");
                    cCDialogue.Add("Debajo de tu pantalla tendr�s una retrato de los cupones que son v�lidos.");
                    cCDialogue.Add("Cuidado que no te traigan ninguno falso, fijate bien el retrato.");
                    cCDialogue.Add("Y recuerda revisar las normas, no servir� su cup�n si tiene prohibido alg�n objeto.");
                    cCDialogue.Add("Suerte humano.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sergio"))
                {
                    cCDialogue.Add("Hola joven humano, disculpa la impertinencia, pero deber�an de bajar el peso de esas bebidas.");
                    cCDialogue.Add("No sabes lo que pesan esas malditas latas.");
                    cCDialogue.Add("No tengo fuerza ni para levantarlas.");
                    cCDialogue.Add("En mis tiempos, cuando era conocido como Sergio Nervisous.");
                    cCDialogue.Add("Era capaz de levantar piedras y ten�a unos nervios de acero.");
                    cCDialogue.Add("Pero ahora suficiente que aguanto este cubo en mi cabeza.");
                    cCDialogue.Add("Y encima me ha revivido un mago que dice que es un h�roe.");
                    cCDialogue.Add("Se hace llamar Geeraard, que nombre m�s raro para un h�roe.");
                    cCDialogue.Add("Me revivi� para que le ayudar� en su nueva aventura.");
                    cCDialogue.Add("�Pero si no soy capaz ni de levantar una espada de verdad!");
                    cCDialogue.Add("Con lo bien que estaba en mi tumba.");
                    cCDialogue.Add("Necesito recuperar mis nervios, as� que, cobrame estas bebidas.");
                    cCDialogue.Add("Seguro revive mi fuerza.");
                    cCDialogue.Add("Voy a intentar que esto me despierte como es debido.");
                    cCDialogue.Add("�Est� prohibido venderme esto? En mis tiempos, beb�amos esto sin problema.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Salta"))
                {
                    cCDialogue.Add("Hola� Hola� Humano .");
                    cCDialogue.Add("Maldito cacharro, no ir como yo querer.");
                    cCDialogue.Add("Llevo desde ser zanahorio con esta silla, y a�n fallar.");
                    cCDialogue.Add("Yo ser Saltaralisis y querer cambiar runas de una vez.");
                    cCDialogue.Add("S� no cambiar runas, no hablar bien y crear malentendidos.");
                    cCDialogue.Add("Ya pasar otro d�a en banco, y cuando yo decir nombre, romper runa.");
                    cCDialogue.Add("As� que repetir palabra ASALTAR todo rato.");
                    cCDialogue.Add(" Ellos llamar guardia y yo acabar en c�rcel 3 d�as.");
                    cCDialogue.Add("Duros d�as, pero conocer gente maja en c�rcel.");
                    cCDialogue.Add("Yo conocer�Yo conocer�Yo conocer� Sap�tamo borracho.");
                    cCDialogue.Add("Vuelve a fallar, mejor cobrar para cambiar runas.");
                    cCDialogue.Add("Gra� Gra� c�as, cambiar runas ahora.");
                    cCDialogue.Add("No�No�. Poder cambiar, crear m�s mal entendidos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola mortal, �No habr�s visto un libro m�gico alguno de estos d�as?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Llevo d�as buscando un libro que se me fue robado, es importante �sabes?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("El habla no parece ser tu punto fuerte mortal.");
                    cCDialogue.Add("Pero bueno, har� que ese ladr�n recuerde mi nombre, Manolo Mago Manitas.");
                    cCDialogue.Add("Por su culpa y la del otro calamar no se pudo terminar el ritu�");
                    cCDialogue.Add("Si ves a alguien con libro m�gico, avisame mortal.");
                    cCDialogue.Add("Puede que vuelva en alg�n otro momento, pero primero debo atender a mi deber.");
                    cCDialogue.Add("Tengo que volver a mi iglesia, hay que dar la misa para nuestro dios, Azathoth.");
                    cCDialogue.Add("Por lo que ve cobrandome mortal.");
                    cCDialogue.Add("Buen chico, nos vemos mortal.");
                    cCDialogue.Add("Parece que eres otro sacrificio m�s, Azathoth te maldecir� por tu incompetencia.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Raven"))
                {
                    cCDialogue.Add("�Hola amigo m�o! �No es un d�a maravilloso?");
                    cCDialogue.Add("Aunque ni he dormido, pero trabajar como DJ Rave-n siempre me llena de energ�a.");
                    cCDialogue.Add("Tuve que trabajar en una despedido de soltero, los chicos fueron muy majos.");
                    cCDialogue.Add("Pero mi compa�ero Handy lo pas� un poco mal la verdad.");
                    cCDialogue.Add("El soltero se encari�� con el pobre Handy, era un limb�stico muy cari�oso.");
                    cCDialogue.Add("Pero bueno, me alegr� de que al menos haya podido poner mi m�sica.");
                    cCDialogue.Add("Porque la m�sica de hoy en d�a es digamos� Demasiado triste y oscura.");
                    cCDialogue.Add("El grupo Tears of Limbastics es super triste, malditas canciones emos.");
                    cCDialogue.Add("�S� lo mejor es el grupo Magicians of Power, tiene canciones super divertidas! ");
                    cCDialogue.Add("Pero parece que la sociedad se est� deprimiendo cada vez m�s.");
                    cCDialogue.Add("A�n as�, intentar� alegrar al mundo con mis canciones.");
                    cCDialogue.Add("Pero para ello, necesito recargar pilas colega, que quiero recargar.");
                    cCDialogue.Add("Cobrame esto si puedes porfi.");
                    cCDialogue.Add("Gracias compi, ahora ir� a descansar para deslumbrar esta noche m�s.");
                    cCDialogue.Add("No podr� recargar pilas colega� Este ser� un d�a con m�s canciones emos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Hueso"))
                {
                    cCDialogue.Add("Chaval, casi me hago polvo arriba esperando, adem�s tengo prisa.");
                    cCDialogue.Add("Estoy en la nueva exposici�n de dinosaurios de la ciudad.");
                    cCDialogue.Add("Y cuando digo que estoy, es que literalmente estoy.");
                    cCDialogue.Add("Debido a que tengo huesos de hace millones de a�os.");
                    cCDialogue.Add("Un mago arque�logo me cre� y como qued� tan raro, no se dign� ni en darme nombre.");
                    cCDialogue.Add("Literal me llamo Elemental de Hueso el elemental de huesos.");
                    cCDialogue.Add("Por suerte logr� valerme por mi solo, y ahora obtuve un trabajo de verdad.");
                    cCDialogue.Add(" Ser esclavizado por un museo, muchos de mi raza desear�an este puesto en vez de la mina.");
                    cCDialogue.Add("Pero bueno, cobrame chaval, que tienen que verme en el museo.");
                    cCDialogue.Add("Un poco caro el mu�eco, pero hace a�os ese mu�eco antes eran 3 esclavos elementales, gracias.");
                    cCDialogue.Add("Pero si las pociones las beb�an hasta los dinosaurios, est�pidas norm�tivas.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Patxi"))
                {
                    cCDialogue.Add("No s� c�mo mi hombre est� tan ocupado, maldita programaci�n. ");
                    cCDialogue.Add("Y siempre tan apagado, le est�n chupando el alma a mi Antonio. ");
                    cCDialogue.Add("Ay ay ay, Antonio m�o deja la programa...");
                    cCDialogue.Add("��Usted qui�n es?!  Espera que ya es mi turno.");
                    cCDialogue.Add("Me hab�a olvidado que estaba en la cola mientras deliraba con mi Antonio.");
                    cCDialogue.Add("Es mi querido noviecito, curra m�s que un elemental en las minas.");
                    cCDialogue.Add("Y yo soy el mejor novio que se ha tenido, Patxi.");
                    cCDialogue.Add("El pobre trabaja de programador, mientras que yo soy corredor de bolsa.");
                    cCDialogue.Add("Solo tengo que correr con unas bolsas, es un buen trabajo para un limb�stico.");
                    cCDialogue.Add("Y ya que su trabajo es tan complicado quiero hacerle algo especial�");
                    cCDialogue.Add("Quer�a prepararle una cena rom�ntica esta noche, as� que si puedes cobrarme esto.");
                    cCDialogue.Add("Mi Antonio va a perder la cabeza con esta cena, perdona, se me pegaron sus chistes.");
                    cCDialogue.Add("Enemigo del romanticismo, mi Antonio no va a disfrutar mi cena para relajarse.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("�COLEGA, TE NECESITO DE VERDAD!");
                    cCDialogue.Add("HAN PROHIBIDO LAS CERVEZAS A LOS H�BRIDOS");
                    cCDialogue.Add("EMPEC� A HABLAR BIEN DE NUEVO");
                    cCDialogue.Add("HASTA ME LLEG� UNA SOLICITUD DE EMPLEO");
                    cCDialogue.Add("NO QUIERO VOLVER A TRABAJAR");
                    cCDialogue.Add("Y MENOS CON ESA TAL PETRA QUE ME QUIT� EL TRABAJO");
                    cCDialogue.Add("�ME NIEGO!");
                    cCDialogue.Add("TE DAR� EL DINERO QUE NECESITES");
                    cCDialogue.Add("PERO NE-CE-SI-TO CERVEZA ");
                    cCDialogue.Add("�TE QUIERO MUCHO COLEGA! ");
                    cCDialogue.Add("Hasta mi dependiente favorito�Adi�s a Elvog Borracho");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Enano"))
                {
                    cCDialogue.Add("�Hola peque��n! No te hab�a visto desde ah� abajo.");
                    cCDialogue.Add("Me sobra el dinero, para nada entr� aqu� por el 50% de descuento en magos.");
                    cCDialogue.Add("O incluso podr�a ser un 70% ahora que somos amigos.");
                    cCDialogue.Add(" Vale vale, no me mires con esa cara impasible, pero venga�");
                    cCDialogue.Add("Te prometo que te devolver� el dinero si me lo rebajas m�s.");
                    cCDialogue.Add("Por ejemplo, mi vecino a�n me dice que le debo 2000 monedas y que deje de evitarlo.");
                    cCDialogue.Add("Pero, por favor, yo no lo evito por la deuda, lo evito para ahorrarme esas 2000 monedas.");
                    cCDialogue.Add("Creo que no deb� decir eso�Bueno, mejor ve cobrando antes de que la li� m�s.");
                    cCDialogue.Add("Menos mal me he ahorrado esas monedas, as� podr� mantener mi enorme mansi�n durante 1 hora m�s.");
                    cCDialogue.Add("�No tengo dinero ni con el 50% de rebaja? Me va a tocar embargar la casa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Hola de nuevo, ven�a a comprar�");
                    cCDialogue.Add("�Pero qu�, otra vez no!");
                    cCDialogue.Add("Est�pida bater�a rota, hace 1 segundo ten�a bater�a de sobra y ahora de un momento a otro se pone en cr�tico mi energ�a.");
                    cCDialogue.Add("�Necesito que me metas las bater�as otra vez, y est� vez ten cuidado con el agua!");
                }
            }

            else if (currentScene.name == "Day3_2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji") && vecesSamuraiAyudado < 2)
                {
                    cCDialogue.Add("Ufff, por los pelos, estupida bater�a, creo que est� algo rota por estos sustos que me da");
                    cCDialogue.Add("Espero que esta deshonra no llegue a los o�dos de mi maestro, muchas gracias humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji") && vecesSamuraiAyudado >= 2)
                {
                    cCDialogue.Add("Ufff, por los pelos, estupida bater�a, creo que est� algo rota por estos sustos que me da");
                    cCDialogue.Add("Toma, quedate con mi espada legendaria \n c�mo agradecimiento. Cuidala bien, la han tocado muchos \n m�s seres anteriores a ti.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rustica"))
                {
                    cCDialogue.Add("Hola cielo, se te v� algo cansado, �est�s bien?");
                    cCDialogue.Add("Seguro que est�s as� por el trabajo, llevo a�os viniendo aqu� y s� bien c�mo os trata el jefe.");
                    cCDialogue.Add("Igual es un chico bueno aunque sea un poco avaricioso, egoc�ntrico, ego�sta y explotador laboral.");
                    cCDialogue.Add("Todo el mundo tiene el lado bueno, lo s� bien con todos los a�os que he pasado viva. ");
                    cCDialogue.Add("Fu� de los primeros t�cnopedos, de ah� mi nombre, R�stica.");
                    cCDialogue.Add("Trabaje en varios sitios, uno de mis favoritos fue de camarera.");
                    cCDialogue.Add("En un bar muy elegante, creo que se llamaba Hell Fire Bar.");
                    cCDialogue.Add("Siempre hab�a alguna que otra pelea entre amigos, o peque�as peleas de bandas.");
                    cCDialogue.Add("Alguna vez nos pintaban las paredes con latas de spray, eran buenos chicos en el fondo.");
                    cCDialogue.Add("Fue una buena �poca� Disculpa cielo que me voy por las nubes.");
                    cCDialogue.Add("Cobrame esto, as� voy tirando a la chatarrer�a a echar unas cartas con mis amigas.");
                    cCDialogue.Add("Gracias cari�o, espero no llegar tarde a la chatarrer�a.");
                    cCDialogue.Add("�Mi cup�n est� roto? Perd�n cari�o.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Buenos d�as dependiente, veo que ha sido un d�a ajetreado.");
                    cCDialogue.Add("Ayer mandamos al Detective Le�n a investigar a los sospechosos de ayer, al parecer Giovanni sabe cosas.");
                    cCDialogue.Add("Tuvo en posesi�n un libro de magia ancestral, que fue prohibida hace siglos aunque se desconoce que hace.");
                    cCDialogue.Add("Nos coment� que se le encontr� de camino de la gasolinera donde trabaja el fiambre la misma noche.");
                    cCDialogue.Add("Tras varias comprobaciones supimos que era cierto y que no puede ser el culpable.");
                    cCDialogue.Add("Aunque ahora tenemos alguna pista m�s, un cliente de esta tienda us� una bola de cristal en el ritual.");
                    cCDialogue.Add("Y que la compr� bajo el nombre de �Manolo�, seg�n un ticket tirado por la escena del crimen.");
                    cCDialogue.Add("�Sabes si alguno de los siguientes sospechosos pueda tener relaci�n con la descripci�n que te d�?");
                    cCDialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");

                }
            }

            else if (currentScene.name == "Day4")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola chico nuevo, veo que te est�s acostumbrando al trabajo en mi tienda.");
                    cCDialogue.Add("Que raro que ning�n mago te la haya arrancado la cabeza por negarte a cobrarle, al anterior dependiente le pas� eso.");
                    cCDialogue.Add("Aunque gracias a ese mago, no tuve que pagarle ese mes.");
                    cCDialogue.Add("As� acab� comprando el carruaje m�s r�pido del reino, aunque se qued� obsoleto por culpa de los coches.");
                    cCDialogue.Add("Por culpa de esas est�pidas m�quinas de 4 ruedas, los tecn�pedos no podr�n comprar pilas y bebida energ�tica junta, por una reacci�n que los hace m�s r�pidos.");
                    cCDialogue.Add("Se lo tienen merecido por hacerme gastar mis preciosas monedas en un carruaje que qued� obsoleto.");
                    cCDialogue.Add("Y tambi�n me enter� hace poco que hay una secta convirtiendo h�bridos en limb�sticos.");
                    cCDialogue.Add("Por lo que los h�bridos no podr�n comprar nada de magia negra, esa secta solo me ha hecho perder dinero.");
                    cCDialogue.Add("Bueno, es hora de que empiece tu turno, recuerda mirar las nuevas normas.");
                    cCDialogue.Add("Suerte humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jissy"))
                {
                    cCDialogue.Add("�Qu� pasa t�o?�C�mo estamos?");
                    cCDialogue.Add("Espera, tu� Tu no eres el de el otro d�a �no..?");
                    cCDialogue.Add("Yo  soy Jeese, Jeese Chemman, mi nombre de las calles t�o.");
                    cCDialogue.Add("Perdona tronco pero, �Seguro que no eres el dependiente de siempre?");
                    cCDialogue.Add("Nunca se me ha dado bien esto de reconocer a la gente, �sabes?");
                    cCDialogue.Add("Pero tienes un parecido al anterior dependiente.");
                    cCDialogue.Add("Aunque creo que el anterior no era humano, era un raza superior �sabes?");
                    cCDialogue.Add("Espero que no te afectar� el comentario, tampoco se me da bien socializar.");
                    cCDialogue.Add("En f�n, espero que te vaya bien.");
                    cCDialogue.Add("Ah, s�, pero antes de irme, cobrame esto.");
                    cCDialogue.Add("Que me iba sin pagar �sabes?");
                    cCDialogue.Add("Gracias colega, deber�amos quedar alg�n d�a para hablar de la vida �sabes?");
                    cCDialogue.Add("Bueno tronco, no s� c�mo no aceptas mi dinero, deber�as mejorar en el trabajo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mara"))
                {
                    cCDialogue.Add("Uy, buenos d�as cielo, se nota que eres un buen trabajador.");
                    cCDialogue.Add("Deber�a de tomar ejemplo de ti, que me hubiera venido mejor trabajar en vez de ir a la horrible cita del otro d�a.");
                    cCDialogue.Add("Para una vez que decido volver a darle a un intento al amor, y con el tiempo que le dediqu� a mi cuenta de Hybrinder.");
                    cCDialogue.Add("Llegu� al peque�o local limb�sticos, con mis patas raptoriales reci�n afiladas, y el tipo result� no ser un h�brido.");
                    cCDialogue.Add("Ni siquiera su cabeza se ve�a apetitosa, ten�a una pedazo de esfera en su cabeza.");
                    cCDialogue.Add("Igualmente acced� a cenar con �l, aunque me hubiera enga�ado de esta manera.");
                    cCDialogue.Add("Nada m�s me separ� de �l, le bloque� de todos lados, espero no verlo m�s en mi vida.");
                    cCDialogue.Add("Mi pata de la suerte seguro dej� de funcionar, es la de mi ex marido.");
                    cCDialogue.Add("Siempre la llevo en mi bolso, pero dejar� de usarla");
                    cCDialogue.Add("Perdona si te aburriste con mi historia querido, c�brame que tengo que ir a m�s tiendas querido.");
                    cCDialogue.Add("Gracias cielo, qu�date con mi pata de la suerte, no creo que la necesite m�s.");
                    cCDialogue.Add("Gracias cielo, espero nunca que no tengas citas como la m�a.");
                    cCDialogue.Add("�Est� prohibido esto? Bueno, ayer vi varias personas compr�ndolo, que raro.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("Buenos d�as mi dependiente favorito, �no es preciosa la vida?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Veo que mi pregunta te dejo mudo al igual que yo cuando veo a mi nueva diosa.");
                    cCDialogue.Add("La cita del otro d�a no s�lo fue genial, fue perfecta.");
                    cCDialogue.Add("Cuando la v�, qued� perdido en su ojos de mantis, y no paraba de querer acariciar sus preciosas y afiladas garras.");
                    cCDialogue.Add("Obvio fu� un caballero y no me atrev� a tocar sus hermosas garras.");
                    cCDialogue.Add("Adem�s de que no quer�a perder mi mano.");
                    cCDialogue.Add("Pero bueno, lo mejor de la cita fue cuando nos sentamos juntos y cenamos.");
                    cCDialogue.Add("Y esa cangumantis me dijo 10 palabras, �10 PALABRAS!");
                    cCDialogue.Add("Solo una hembra me hab�a dicho m�s palabras que esas, mi madre.");
                    cCDialogue.Add("Mis palabras favoritas fueron / �Pagas tu, no ? / Quiso que pagara yo, qu� rom�ntico");
                    cCDialogue.Add("Tengo pensado decirle de tener otra cita, y creo que esto de aqu� ser� necesario para la cita, as� que si pudieras cobrarme.");
                    cCDialogue.Add("Te informar� sobre mi pr�xima cita, mi dependiente favorito.");
                    cCDialogue.Add("T�, enemigo del amor, gracias por arruinar mi cita.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sergio"))
                {
                    cCDialogue.Add("Hola humano, �podr�as ayudarme?");
                    cCDialogue.Add("He decidido no ir a la misi�n del mago raro que me invoc�.");
                    cCDialogue.Add("No s� qui�n se cree para ir reviviendome sin mi permiso.");
                    cCDialogue.Add("Bueno, al caso, necesito 3 bebidas energ�ticas para activar mi 100%");
                    cCDialogue.Add("Y as� escapar del reino con mi super energ�a, o eso pon�a en internet sobre esta bebidas.");
                    cCDialogue.Add("Que me dices, �me ayudas?");
                    cCDialogue.Add("Gracias por tu ayuda, tendr�s una recompensa, te dar� mi legendaria espada, �LA GLOBOSPADA!");
                    cCDialogue.Add("Sab�a que me ayudar�as, suerte humano.");
                    cCDialogue.Add("�De verdad? Qu� poco coraz�n");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Elidora"))
                {
                    cCDialogue.Add("Hola s�bdito, �No crees que deber�as de dejar de atender en este s�tano?");
                    cCDialogue.Add("Casi uno de mis fieles slimes se deshace por culpa de la ca�da.");
                    cCDialogue.Add("Y no sabes el precio que hubieras tenido que pagar por mi slime.");
                    cCDialogue.Add("Podr�a haberte nombrado mi nueva silla oficial� La �nica silla del Reino Slime.");
                    cCDialogue.Add("Mi gran y poderoso reino de 4 habitantes slimes, donde yo soy la reina.");
                    cCDialogue.Add("LA PODEROSA REINA MAGA ELIDORA LIMALIGNA.");
                    cCDialogue.Add("La reina m�s poderosa de todos los reinos.");
                    cCDialogue.Add("Aunque a�n estoy con los papeles para volver mi reino oficial.");
                    cCDialogue.Add("Creo que te dejar� unirte a mi reino si me muestras tu gran habilidad atendiendo clientes.");
                    cCDialogue.Add("�Qu� me dices?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Ya veo que te he sorprendido tanto que te he dejado sin habla.");
                    cCDialogue.Add("Venga muestrame tus habilidades cobrando.");
                    cCDialogue.Add("Te har� el dependiente oficial� Nada m�s terminar con el papeleo, adi�s humilde s�bdito");
                    cCDialogue.Add(" En Reino Slime sirven estos cupones, adi�s humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard") && noCobrarSergioCobrarGeeraardD4 == 0)
                {
                    cCDialogue.Add("�Humano, que le vendiste a mi limb�stico!");
                    cCDialogue.Add("Con lo que me cost� convencer a la iglesia para invocarlo.");
                    cCDialogue.Add("No sabes lo dif�cil que fue encontrar a ese mago mano.");
                    cCDialogue.Add("Y por no hablar de los ingredientes para revivirlo, fueron muy costosos.");
                    cCDialogue.Add("Ser�s� Claro, esto es lo que pasa por dejar a un humano trabajar.");
                    cCDialogue.Add("Has perdido un cliente, �PARA SIEMPRE!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard") && noCobrarSergioCobrarGeeraardD4 != 0)
                {
                    cCDialogue.Add("Hola humano, espero que en estos d�as te hayas le�do una de miles historias.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Tu mirada me dice que no es as�, �Es que no tienes tiempo para leer en casa?");
                    cCDialogue.Add("Eres de los peores fans que he tenido en mi vida.");
                    cCDialogue.Add("Espero que leas al menos una antes de que escriban mi nueva historia: La caza del collar de Sin Cuello.");
                    cCDialogue.Add("Ma�ana mismo partir� camino del reino junto con mi nuevo compa�ero.");
                    cCDialogue.Add("Es un limb�stico que reviv� con ayuda de un mago mano un poco extra�o.");
                    cCDialogue.Add("Al parecer es el �nico tipo del reino que sabe hacer limb�sticos, y yo que pensaba que reviv�an solos");
                    cCDialogue.Add("Bueno, como dec�a de mi compa�ero, dicen que cuando estaba vivo ten�a unos nervios de acero.");
                    cCDialogue.Add("As� que por eso solo revivimos su sistema nervioso y su cerebro.");
                    cCDialogue.Add("Espero que sea tan capaz como yo, aunque se le ve un poco tirillas.");
                    cCDialogue.Add("En fin, necesitar� algunos materiales para el viaje, y esta tienda tiene suerte de ser mi proveedora no oficial.");
                    cCDialogue.Add("Por lo que tendr�s el honor de cobrarme, y con suerte recibir�s un aut�grafo mio.");
                    cCDialogue.Add("Des�ame suerte en mi aventura, te dar� mi foto favorita con un aut�grafo, por tu humilde servicio.");
                    cCDialogue.Add("Des�ame suerte en mi aventura, aunque no la necesite.");
                    cCDialogue.Add("Por todo lo que he hecho por el reino, y me lo pagan as�.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Magma"))
                {
                    cCDialogue.Add("Buenas ma�anas persona fr�a, soy Magmadora.");
                    cCDialogue.Add("Fr�o de personalidad o fr�o de carne, t� dir�s, solo tienes que mirarme.");
                    cCDialogue.Add("Veo que no eres el mismo trozo de carne fr�a que hab�a antes en este lugar.");
                    cCDialogue.Add("Haber si llega ya el maldito verano que yo soy de los que prefiere el calor, sino mira como estoy que ardo.");
                    cCDialogue.Add("De verdad que la gente que prefiere el fr�o no la entiendo.");
                    cCDialogue.Add("Si no estuvieras hecho de carne, tambi�n preferir�as el calor.");
                    cCDialogue.Add("Ventajas de no poder sudar.");
                    cCDialogue.Add("En fin, �Te importar�a cobrarme esto? Que me estoy quedando sin llama y tengo que avivarme un poco.");
                    cCDialogue.Add("Gracias, espero que cuando termine de trabajar no se enfr�e de camino a casa.");
                    cCDialogue.Add("�C�mo que han prohibido comprar pociones? �AHORA C�MO PODR� COMPRAR MI POCI�N DE LAVA!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("Dependiente... Hoy no podr�a ser... �LA MEJOR SEMANA DE MI VIDA!");
                    cCDialogue.Add("El trabajo del otro d�a fue genial, los solteros fueron encantadores.");
                    cCDialogue.Add("Les encant� cuando me puse a hacer mi mon�logo.");
                    cCDialogue.Add("Y mi compa�era es una DJ genial, en el momento de las copas sali� a hacer su parte.");
                    cCDialogue.Add("Baile con el novio un rato, pero no paraba de tocar mi bocina, era un tipo raro.");
                    cCDialogue.Add("Pero bueno, ahora tenemos un nuevo trabajo para hoy, una gatoteca.");
                    cCDialogue.Add("Hemos pensado en animar haciendo un musical con los gatos, pero son unos bichos muy ariscos y arr�tmicos.");
                    cCDialogue.Add("As� que hemos pensado en otra cosa, vamos a bollos con forma de gatito.");
                    cCDialogue.Add("En fin, sabes que me encanta estar contigo, pero se me est� haciendo tarde amigo.");
                    cCDialogue.Add("Por lo que c�brame que tengo que alegrar esa gatoteca.");
                    cCDialogue.Add("Gracias amigo, como muestra de nuestra amistad, el traje que us� en la despedida de soltero.");
                    cCDialogue.Add("Des�ame la mayor de las suerte en mi nuevo trabajo.");
                    cCDialogue.Add("Espero que el trabajo me vaya bien igualmente");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Buenos d�as chico� Eres el del otro d�a �no?");
                    cCDialogue.Add("Tengo mala memoria, debe ser porque siempre pierdo la cabeza, ja ja ja...");
                    cCDialogue.Add("Sab�a que eras t�, a�n recuerdo el vac�o que dejabas cada vez que contaba mi mejor chiste.");
                    cCDialogue.Add("Entonces tengo la confianza de decirte que me gustar�a hacer un regalo a mi novio Patxi.");
                    cCDialogue.Add("Ayer me hizo una cita y quiero hacer algo a cambio, pens� en proponerle hacer senderismo.");
                    cCDialogue.Add("Pero con lo lento que voy y lo r�pido que va �l, seguro no lo disfrutamos igual, por eso me decant� por la opci�n del regalo.");
                    cCDialogue.Add("Espero que le guste este gato muerto, seguro que le recuerda a Mistafurri�o.");
                    cCDialogue.Add("Era su gato cuando estaba vivo, y puede que quiera algo que le recuerde a �l.");
                    cCDialogue.Add("C�brame por favor que tengo que envolver el regalo.");
                    cCDialogue.Add("Espero que le guste este regalo.");
                    cCDialogue.Add("Ahora que le regalo yo a mi Patxi.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola humano, hoy no vengo como cliente, sino como testigo de Azathoth.");
                    cCDialogue.Add("�Has reconsiderado acercarte a mi iglesia?");
                    cCDialogue.Add("�ltimamente aceptamos a varios humanos para que se unan a rezar con nosotros, siempre vienen nuevos.");
                    cCDialogue.Add("Aunque hace poco comprobamos que los h�bridos tambi�n son �bienvenidos� a nuestra religi�n.");
                    cCDialogue.Add("Transformamos a uno de ellos en uno de los nuestros... Fue simplemente arte.");
                    cCDialogue.Add("Pero bueno, solo me acercaba por aqu� para que reconsideraras la oferta, siempre te daremos una mano.");
                    cCDialogue.Add("Suerte en la tienda, humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Buenos d�as humano, la investigaci�n se est� alargando bastante.");
                    cCDialogue.Add("Puede que no lo sepas, pero este caso se empez� porque estamos buscando a qui�n est� creando limb�sticos.");
                    cCDialogue.Add("Los limb�sticos son incapaces de recordar d�nde les crearon, pero con algo de investigaci�n encontramos algo.");
                    cCDialogue.Add("Un sospechoso de ayer parece formar parte de una religi�n de la que desconocemos.");
                    cCDialogue.Add("Y creemos que pueden estar relacionados con la creaci�n de limb�sticos.");
                    cCDialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                    cCDialogue.Add("Creemos que el sospechoso se reuni� con otro cliente de esta tienda para hacer un limb�stico.");
                    cCDialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                    cCDialogue.Add("Creemos que el sospechoso se reuni� con otro cliente de esta tienda para hacer un limb�stico.");
                    cCDialogue.Add("�Sabes si alguno de los siguientes sospechosos se relacion� con la iglesia?");
                    cCDialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");
                }
            }

            else if (currentScene.name == "Day5")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola humano, �Sabes que hoy es un d�a especial?");
                    cCDialogue.Add("Es el primer d�a del a�o que no tenemos nuevas normas, �AS� PODR� TENER M�S DINERO!");
                    cCDialogue.Add("Y al ser un d�a tan especial, te dar� un trato especial.");
                    cCDialogue.Add("Revisar� c�mo trabajaste por mis c�maras� Digo con mis poderosas habilidades mentales.");
                    cCDialogue.Add("Y si lo has hecho muy bien, seguir�s trabajando aqu�, o al menos espero que puedas pagarte la maldita documentaci�n.");
                    cCDialogue.Add("Como no hayas ganado suficiente dinero, �TE QUEDAS SIN LA DOCUMENTACI�N!");
                    cCDialogue.Add("Pero bueno, conf�o que hayas sido un buen trabajador.");
                    cCDialogue.Add("Suerte en el que espero que no sea tu �ltimo d�a.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Elidora"))
                {
                    cCDialogue.Add("Hola humano, vengo defraudada de lo mal hecho que est� este reino.");
                    cCDialogue.Add("Fu� al famoso restaurante de �Tips�, y no dejaron pasar a mis humildes ciudadanos esclavos de slime.");
                    cCDialogue.Add("Alguna h�brido debi� hacer esas normas tan tontas, �C�mo no van a permitir criaturas m�gicas?");
                    cCDialogue.Add("Y lo peor es la DECADENCIA del lugar, me obligaron a sentarme en una silla en vez de en mi slimes.");
                    cCDialogue.Add("Y porqu� no hablar del servicio, casi tuve que cazar a los camareros, c�mo un os�guila a un salm�n.");
                    cCDialogue.Add("Le voy a poner una estrella en TripKingdom a ese maldito sitio.");
                    cCDialogue.Add("Seguro no me atend�an como deb�an por ser la reina del reino slime, esos h�bridos magof�bicos.");
                    cCDialogue.Add("Menos mal que en mi reino no excluimos a nadie, excepto a los h�bridos a partir de este mal servicio.");
                    cCDialogue.Add("Har� un restaurante llevado por slimes que lo har�n mejor que esos in�tiles.");
                    cCDialogue.Add("Bueno, humano c�brame que tengo que empezar con la edificaci�n de mi reino.");
                    cCDialogue.Add("Bien hecho humano, si se te da tan bien cobrar, seguro tambi�n se te da bien ayudarme con las obras de mi reino.");
                    cCDialogue.Add("Est�pido humano, menos mal que mis dependientes slimes ser�n m�s listos que t�.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rockon"))
                {
                    cCDialogue.Add("Ho-hola amigo, �qu� tal tu-tu-tu d�a de hoy?");
                    cCDialogue.Add("Seguro que fue un d�a pri-pri-edr�stico, como decimos chicos piedras.");
                    cCDialogue.Add("Tenemos muchas expresiones ra-raras gracias a mis primos roca, son de pueblo cerrado.");
                    cCDialogue.Add("Adem�s de que son chicos fuerte como mi padre, dicen que son �Gymbros�.");
                    cCDialogue.Add("Deber�a de ir al �Muscle Beluga� para me-mejorar mis m�sculos, es el mejor gimnasio del reino.");
                    cCDialogue.Add("As� igualar�a la fuerza de mis primos y podr�a ayudar a mi padre en su restaurante.");
                    cCDialogue.Add("�l est� como esclavo en el �Tips� del reino, es el mejor sitio para comer.");
                    cCDialogue.Add("Aunque cada d�a le tocan clientes m�s desagradables, fue una ma-maga que quer�a pasar a unos slimes.");
                    cCDialogue.Add("Se nota que no sabe lo que cuesta limpiar la baba de esas po-pobres criaturas.");
                    cCDialogue.Add("Se-seguro que estoy haciendo mucha cola, c�brame amigo.");
                    cCDialogue.Add("Gra-gracias, espero le gusten estos peluches con forma humana a mi padre.");
                    cCDialogue.Add("Me falta di-dinero, jopetas, perd�n por intentar enga�arte con el cup�n.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Buennnasss *hip* T��T��  Ah� est� miii dependiente favorito.");
                    cCDialogue.Add("Erres el mejor, t�oooo, gracias a t� no tengo trabajarrr m�s, er jefe me ha visto borracho, de nuevo.");
                    cCDialogue.Add("Ahorra seguirr� con mi incre�ble vida jubeniiiil, eres er �nico capaz de entenderme*hip*");
                    cCDialogue.Add("Te invitarr�a a una birra, pero no s� que bebe�s los hurmanos, ten�is pinta de beberrrr Carrimocho.");
                    cCDialogue.Add("No parreceis bebedores fuertes como yo, mi h�gado y yo segurro somos los combatientes m�s fuertes del reino*hip*");
                    cCDialogue.Add("Te estoy robando muuuuucho tiempo, solo quiero decirte que esperro que podamos ser amigos.");
                    cCDialogue.Add("Te darr� esta botella, en se�al de nuestra amis *hip* tad");
                    cCDialogue.Add("Nos vemos besto amigo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Petra"))
                {
                    cCDialogue.Add("Hola amigo� Al igual que tu me diste �nimos para trabajar, te tendr� que contar una nueva noticia�");
                    cCDialogue.Add("Me han despedido� Es� �Una muy buena noticia!");
                    cCDialogue.Add("Ese tipo era un explotador de mucho cuidado, �qui�n se cre�a?");
                    cCDialogue.Add("Quer�a que le encontrar� un lugar llamado Atlantis con un mapa del men� infantil del Tips.");
                    cCDialogue.Add("Ahora le tocar� al nuevo hacer eso, o mejor dicho al que han recontratado");
                    cCDialogue.Add("Con la nueva prohibici�n del alcohol, el sapop�tamo dej� el alcohol.");
                    cCDialogue.Add("Espero que le vaya bien, aunque lo dudo.");
                    cCDialogue.Add("Adem�s, me podr� librar de algunas que llevaba en la mochila, como este mapa vac�o.");
                    cCDialogue.Add("Te lo puedes quedar, aunque dudo que le puedas dar mucho uso, principalmente porque no tiene nada.");
                    cCDialogue.Add("Nos vemos amigo.");
                }


                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("Hola colega, tengo una mala noticia para ti.");
                    cCDialogue.Add("La cangumantis y yo lo hemos dejado, me ech� spray de pimienta en la esfera cuando la encontr�.");
                    cCDialogue.Add("Es una de las maneras en la que me han dejado, la peor una de mis exs que me dej� por mi hermano.");
                    cCDialogue.Add("Pero esto ha hecho que abra los ojos y me d� cuenta que de tanto pensar en el amor, me perd� en el sendero de la vida.");
                    cCDialogue.Add("As� que tome una decisi�n importante y me desinstal� Hybrinder, aunque me quedara un a�o de premium.");
                    cCDialogue.Add("Creo que ahora voy a rehacer mi vida, ahora que soy un limb�stico.");
                    cCDialogue.Add("Puedo intentar ser un monje, perdido en la monta�a, para encontrar un nuevo camino.");
                    cCDialogue.Add("Pero creo que me quedar� trabajando en la gasolinera como siempre, hasta que encuentre mi camino.");
                    cCDialogue.Add("Hablando de la gasolinera, c�brame que tengo dentro de nada el turno.");
                    cCDialogue.Add("Gracias, qu�date con este cuadro de Mara, para que me olvide de ella.");
                    cCDialogue.Add("Voy a empezar con ganas mi nuevo camino, si es que me llega.");
                    cCDialogue.Add("Espero que empezar mi nuevo camino no se vea afectado por mi nulas capacidades de contar monedas.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Masermati"))
                {
                    cCDialogue.Add("Hola cocherrum�n, �adivina qui�n particip� en la carrera del otro d�a y qued� en 1� lugar?");
                    cCDialogue.Add("Pues yo no porque qued� en 8� lugar, pero lo importante fue participar.");
                    cCDialogue.Add("Si sigo entrenando, puede que para la pr�xima quede en 1� lugar.");
                    cCDialogue.Add("Si no fuera porque Flecha R�pida hiciera trampa, ese trasto de 4 ruedas lanz� clavos por el camino.");
                    cCDialogue.Add("Es igual de miserable que su due�o Pijus Magnus, la pr�xima vez no se repetir�.");
                    cCDialogue.Add("Menos mal que mi familia se qued� apoy�ndome hasta el final.");
                    cCDialogue.Add("Seguro que en cuanto me ponga la luces traseras y el cambio de marchas mejorar� mucho m�s.");
                    cCDialogue.Add("Pero como siempre dan citas para dentro de 3 meses en reparaci�n p�blica.");
                    cCDialogue.Add("Esperar� hasta la cita y la operaci�n para ser mejor coche en mi siguiente carrera.");
                    cCDialogue.Add("Bueno cocherrum�n, creo que deber�a ir corriendo hasta casa que se me hace tarde.");
                    cCDialogue.Add("Ahora voy acelerando a casa para no llegar tarde, chao.");
                    cCDialogue.Add("Con las prisas deb� romper el cup�n.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Hola amigo, �a que me ves diferente?");
                    cCDialogue.Add("Se cur� mi miop�a gracias a beber tanto veneno.");
                    cCDialogue.Add("�Qui�n iba a decir que el veneno era la cura?");
                    cCDialogue.Add("Me imagino que no lo ha probado nadie antes, porque se morir�a sino.");
                    cCDialogue.Add("Pero como no puede morir alguien muerto, me cur�.");
                    cCDialogue.Add("Gracias por vendernos el veneno a Patxi y a m�.");
                    cCDialogue.Add("Ahora no necesitar� mis gafas, puedes qued�rtelas.");
                }


                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Buenos d�as pr�ximo creyente, veo que sigues encadenado a esta tienda.");
                    cCDialogue.Add("Podr�as intentar ser m�s libre si vinieras alguna vez a una de las misas de mi iglesia.");
                    cCDialogue.Add("Adem�s te beneficiar�a venir, con cierta informaci�n que te voy a contar ahora.");
                    cCDialogue.Add("Vamos a hacer que vuelvan antiguos h�roes a la vida, el primero fue el gran Sergio Nerviosaus.");
                    cCDialogue.Add("Pero dentro de poco, no ser� el �nico que volver� a la vida y nos ayudar�.");
                    cCDialogue.Add("As� que creo que te beneficiar�a estar de nuestra parte, y no de la del detective que lleva unos d�as vi�ndote.");
                    cCDialogue.Add("�Crees que no lo sab�a? Ese detective lleva algunos d�as indagando en nuestra sagrada iglesia.");
                    cCDialogue.Add("Adem�s de que siempre viene a esta tienda al final del d�a, as� que espero que hoy le mientas un poquito.");
                    cCDialogue.Add("Pero bueno, hoy vine como cliente, por lo que c�brame humano.");
                    cCDialogue.Add("Te espero pronto en mi iglesia, humano.");
                    cCDialogue.Add("Cuando revivamos a los h�roes, espero que no sepas contar mejor.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Salta"))
                {
                    cCDialogue.Add("Hola humano, �c�mo estar d�a?");
                    cCDialogue.Add("Como tu ver ver ver ver ver romper runas de nuevo.");
                    cCDialogue.Add("Yo estar en bar anoche con mi querida familia, hasta que un borracho echarme toda su bebida encima.");
                    cCDialogue.Add("El tipo no quiso reparar mis runas y romperlas toda la noche.");
                    cCDialogue.Add("Ahora necesitar cambiar runas de nuevo, la gente no comprender a m�.");
                    cCDialogue.Add("No entender que yo no nacer con mitad animal, si no con vegetal.");
                    cCDialogue.Add("Deber cambiar alguna cosa para hacer mejor trato a los h�bridos mitad vegetal.");
                    cCDialogue.Add("O al menos hacer algo para que los h�bridos vegetarianos no babear babear babear con nosotros.");
                    cCDialogue.Add("Ya volver a funcionar mal, c�brame que querer cambiar runas.");
                    cCDialogue.Add("Gracias humano, cambiar en nada runas.");
                    cCDialogue.Add("Yo solo querer cerveza para pap�, pero bueno, dar solo runas mejor.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Raven"))
                {
                    cCDialogue.Add("Hola cielo, espero que est�s teniendo un d�a brillante.");
                    cCDialogue.Add("A m� ayer me fue genial en la gatoteca, fue muy divertido a mi compa�ero huir de los gatos.");
                    cCDialogue.Add("Se le pegaban los gatos con la est�tica de los globos.");
                    cCDialogue.Add("�Adem�s pudimos atender a uno de los miembros de la banda de Magicians of Power!");
                    cCDialogue.Add("�SON EL MEJOR GRUPO DEL MUNDO!");
                    cCDialogue.Add("Y gracias a mis incre�bles dotes de persuasi�n y carisma, me regalaron dos entradas para ir.");
                    cCDialogue.Add("Seguro le digo a Handy de ir, es un gran compa�ero, y se esfuerza m�s que ninguno que haya tenido.");
                    cCDialogue.Add("Aunque su debilidad sean los gatos con mucho pelo.");
                    cCDialogue.Add("No s� cu�l ser� el pr�ximo trabajo, pero espero que pueda hacerlo junto con �l.");
                    cCDialogue.Add("Te quite mucho tiempo amigo m�o, cobrame esto porfi.");
                    cCDialogue.Add("Eres el mejor, no s� si te interese, pero ya que somos tan buenos amigos te dar� mi disco favorito.");
                    cCDialogue.Add("Gracias amigo, espero que llegue ya el d�a del concierto.");
                    cCDialogue.Add("�No puedo comprar esto? Cre�a que ten�a todo el dinero.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Hola humano, creo que me acaba de pasar algo sorprendente despu�s de estos a�os trabajando.");
                    cCDialogue.Add("Han habido recortes en mi trabajo, por lo que pensaba que me iban a recortar mi sueldo de 3 monedas al mes.");
                    cCDialogue.Add("Pero lo que parec�a un recorte de sueldo, acab� siendo un recorte de verdad.");
                    cCDialogue.Add("Literalmente han cortado una parte de m�, y sali� un mini yo, por lo que creo que ahora soy papicio.");
                    cCDialogue.Add("Vaya suerte tendr� el tapic�n de tener un padre tan realista como yo.");
                    cCDialogue.Add("As� sabr� de inicio lo triste y dura que es la vida, y no le pasar� como a m� al nacer.");
                    cCDialogue.Add("Aunque no s� qu� necesitan comer los tapicines cuando son peque�os, puede que un poco de gravilla le guste.");
                    cCDialogue.Add("Bueno, hablando del peque, tengo que ir a por �l en nada, as� que c�brame.");
                    cCDialogue.Add("Gracias, a ver si estar ahora con hijo me anima m�s.");
                    cCDialogue.Add("Ahora el ni�o me ver� m�s deprimente de siempre.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Traigo muy buenas noticias humano, estamos a nada de cerrar el caso.");
                    cCDialogue.Add("Uno de los sospechosos de ayer confes� que la iglesia le ayud� a revivir a un tal Sergio Nerviosaus.");
                    cCDialogue.Add("Esta noche, haremos una redada en la iglesia para encerrar a los miembros.");
                    cCDialogue.Add("As� que puede que en nada vayamos a cerrar el caso, aunque a�n nos queda una cosa por resolver.");
                    cCDialogue.Add("Qui�n fue la persona que le di� con el orbe al fiambre.");
                    cCDialogue.Add("Tenemos algunos sospechosos, pero creemos que es el l�der principal.");
                    cCDialogue.Add("Hasta el detective Black no sabe qui�n arrestar.");
                    cCDialogue.Add("Dime humano, �qui�n crees qu� es el l�der?");
                    cCDialogue.Add("Muchas gracias por ayudar en el caso, espero que nos volvamos a ver.");
                }
            }

            else if (currentScene.name == "Home")
            {
                if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Tapicio"))
                {
                    cCDialogue.Add("Saludos humano **suspira**");
                    cCDialogue.Add("Tu jefe me dijo que te quedar�as aqu�, qu� lugar m�s triste.");
                    cCDialogue.Add("Por desgracia tendr� que animar este sitio, he tra�do mi juego favorito.");
                    cCDialogue.Add("Parec�as nuevo en el reino y me diste pena al verte **suspira**");
                    cCDialogue.Add("Seguramente m�s clientes como yo puedan traerte cosas si les tratas bien.");
                    cCDialogue.Add("Ya sea cobr�ndoles aunque no debas, o ayud�ndoles con alguna cosa.");
                    cCDialogue.Add("Seguro que con m�s objetos animas este sitio.");
                    cCDialogue.Add("Aunque me gustar�a que quedase m�s triste, como mi propia existencia.");
                    cCDialogue.Add("Te dejo de molestar humano, suerte estos d�as.");
                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bonna noche amigo m�o, espero que descanses bien.");
                    cCDialogue.Add("Pero antes quer�a darte un regalo, mi libro de cocina.");
                    cCDialogue.Add("Bueno, mejor dicho... una copia, ped� que me lo clonaran con magia.");
                    cCDialogue.Add("As� los dos podremos hacer los platos que queramos cada d�a.");
                    cCDialogue.Add("Aunque aqu� no veo ninguna cocina, solo un s�tano sucio...");
                    cCDialogue.Add("Bueno, te las apa�ar�s, ciao amigo m�o.");

                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Elidora"))
                {
                    if (!slimeFostiados)
                    {
                        cCDialogue.Add("Hola s�bdito, estoy haciendo un entrenamiento especial para que los slimes me duren m�s.");
                        cCDialogue.Add("Consiste en acariciarles la cabeza con un martillo, pero no me hace mucha gracia cogerlo yo");
                        cCDialogue.Add("�Que asco agarrar algo �spero con las manos no? Prefiero que lo haga gente como t�");
                        cCDialogue.Add("Bueno, que me enredas, haz eso por mi y quien sabe, puede que alg�n d�a te de algo que se me rompa y ya no pueda usar");
                    }

                    else if (slimeFostiados)
                    {
                        if (slimeFail)

                            if (elidoraAcariciada)
                                cCDialogue.Add("�Casi me abollas el cerebro!�Escucho borroso!�NUNCA TE LO PERDONAR� CARMONA!");

                            else
                                cCDialogue.Add("T�pico de un humano, no s� por qu� te encargu� una tarea tan dif�cil para un cerebro tan diminuto como el tuyo...");
                        else
                            cCDialogue.Add("Menudo aboll�n le has dejado a Mc Moco... No creo que me sirva as�, te lo regalo");
                    }
                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola humano, veo que no has contado nada sobre la iglesia a ese detective.");
                    cCDialogue.Add("Has mostrado ser fiel a nuestra causa y a la iglesia.");
                    cCDialogue.Add("Ganaste mi confianza para considerarte uno de nosotros.");
                    cCDialogue.Add("Acepta este anillo como muestra de agradecimiento.");
                    cCDialogue.Add("Nos vivimos por verte estos d�as en la iglesia, ya me entiendes.");
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
                    cCDialogue.Add("Good morning, citizen! Here comes Geeraard, the almighty! Aha, yeah, no pictures�");
                    cCDialogue.Add("�");
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
                    cCDialogue.Add("Suuuuup *hick* Huuuuuuhh� You are not the guyyy� *hick* From before...");
                    cCDialogue.Add("I mean, yeah, the other guyyy was a ######");
                    cCDialogue.Add("Now with who will I talk about how they fireddd meeee� And you are hewman�");
                    cCDialogue.Add("Ah, hell! *hick*");
                    cCDialogue.Add("Name's Elvog, da ex-explorer");
                    cCDialogue.Add("Ya ain't gonna believe meh� My ###### boss fired me! *hick*");
                    cCDialogue.Add("He said I was too drunk, too old and called me smelly...WHO DOES HE THINK HE IS? *hick*");
                    cCDialogue.Add("I'm only 22, I'm in my peak! *hick*");
                    cCDialogue.Add("Ah, yeah *hick*, I'm buying these�");
                    cCDialogue.Add("Sankiu *hick* You saved my morning *hick*");
                    cCDialogue.Add("Omaiga... *hick* the guy before you was better *hick*");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Hi� New guy, huh? My name is Anthony, how... are you..?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("I see� Not the talkative kind of person, right?");
                    cCDialogue.Add("I feel ya, my work as a programmer made me something like that.");
                    cCDialogue.Add("I really don't know how I survive this job. Maybe it's because I'm dead.");
                    cCDialogue.Add("*snort* Sorry, that was a joke, I'm not the jokester on my discorb chat.");
                    cCDialogue.Add("My brain makes me, quite the dead player on games.");
                    cCDialogue.Add("Okay, that didn't even make sense. How do people do it?");
                    cCDialogue.Add("I'll be taking these, yeah.");
                    cCDialogue.Add("Thank you my dear fellow, wait, did I even give you the right amount..?");
                    cCDialogue.Add("Aw, I forgot some coins in my kawaii pillow� So- so sorry!");
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
                    cCDialogue.Add("The katana behind me isn�t a prop, I have been training for years to be a samurai.");
                    cCDialogue.Add("I even trained with a turtle squad and a rat once�");
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
                    cCDialogue.Add("Say, can you help me carry them outside? Probably you can�t but thanks anyways~");
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
                    cCDialogue.Add("The most explosive recipes, I think�");
                    cCDialogue.Add("So, for this first recipe I'll need...");
                    cCDialogue.Add("Oooh! �How to summon Azathoth�, I'll cook this one");
                    cCDialogue.Add("Suena incre�ble este plato, pillar� algunos ingredientes para hacer el plato.");
                    cCDialogue.Add("�Primer paso: rociar vino hecho de sangre de virgen�");
                    cCDialogue.Add("Cambiar� el vino por una buena cerveza, le dar� m�s sabor.");
                    cCDialogue.Add("�Segundo paso: cortar el mu�eco voodoo por la mitad junto con la persona sacrificada�");
                    cCDialogue.Add("No s� qu� es eso de la persona sacrificada, pero el mu�eco tiene buena pinta.");
                    cCDialogue.Add("�Y tercer paso: beber el veneno para que el Dios se adue�e de tu cuerpo�");
                    cCDialogue.Add("No suelo beber veneno, pero creo que se lo echar� al mu�eco para darle el toque picante.");
                    cCDialogue.Add("Tiene buena pinta �verdad? Para eso necesito estos ingredientes, as� que si puedes cobrarme.");
                    cCDialogue.Add("Gracias, la pr�xima vez que vuelva te dejar� probar el plato para que me des tu opini�n.");
                    cCDialogue.Add("Madre m�a, ahora te perder�s el mejor plato del mundo, pillar� las cosas en otro sitio.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rockon"))
                {
                    cCDialogue.Add("�Ho-hola que tal?");
                    cCDialogue.Add("Espero no molestar, y perdona mi tar-tartamudez. ");
                    cCDialogue.Add("En fin, perdona otra vez. No me disculpar� m�s, per-per-perdona.");
                    cCDialogue.Add("Estoy intentando me-mejorar, como buen Rockon que soy.");
                    cCDialogue.Add("Debo mejorar como pap�, es muy fuerte.");
                    cCDialogue.Add("Siempre me ha querido mu-mu-mucho.");
                    cCDialogue.Add("Mi co-comida favorita es la gravilla que me hac�a.");
                    cCDialogue.Add("Adem�s si le echabas cemento por encima, ya quedaba bueniiiiiisimo.");
                    cCDialogue.Add("Bu-bu-bueno en fin� �Me puedes cobrar esto?");
                    cCDialogue.Add("Es que le quiero dar una sorpresa a pap�, seguro que este gato mu-muerto le hace mucha ilusi�n.");
                    cCDialogue.Add("Gra-gra-gracias seguro que pap� se pone feliz");
                    cCDialogue.Add("Jopetas� Con la ilusi�n que me hac�a regalarles esto a pap� y mam� Pero no tengo todo el dinero");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefazo"))
                {
                    cCDialogue.Add("Seguro que fue muy agotador. pero mejor me lo comentas ma�ana.");
                    cCDialogue.Add("Y un pajarito llamado Inspector de Empleo me ha dicho que no tienes casa.");
                    cCDialogue.Add("Menos mal que tienes un jefe tan generoso y rico, as� que te prestar� una de las mejores viviendas del reino.");
                    cCDialogue.Add("Ese maravilloso lugar se llama: El s�tano de la casa de mi madre.");
                    cCDialogue.Add("Espero que te guste.");
                    cCDialogue.Add("Ll�vate el traductor por si tengo que hablar contigo, tendr�s que entender a mi madre.");
                }
            }

            else if (currentScene.name == "Day2_1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenos d�as chico nuevo.");
                    cCDialogue.Add("�Qu� tal tu primer d�a?");
                    cCDialogue.Add("Nah, es broma, realmente me da igual como te fuera tu primer d�a.");
                    cCDialogue.Add("Seguro te lo dije en el tutorial, pero seguro no te acuerdas por tu cerebro enano.");
                    cCDialogue.Add("Tenemos unas normas que seguir en la tienda a partir de hoy.");
                    cCDialogue.Add("Adem�s es �Magic Friday�, aunque lo seguir� siendo el resto del a�o, como todos los a�os...");
                    cCDialogue.Add("As� que los magos tienen rebajas, y el resto de razas trabajan m�s a cambio.");
                    cCDialogue.Add("Tambi�n han prohibido varias bebidas a algunas razas.");
                    cCDialogue.Add("Parece que sus cuerpos no soportan los ingredientes ilegales que llevan.");
                    cCDialogue.Add("Eso es menos dinero para mi por desgracia.");
                    cCDialogue.Add("Pero la multa ser� peor si me pillan.");
                    cCDialogue.Add("Recuerda revisar las normas, est�n a la izquierda de la pantalla.");
                    cCDialogue.Add("Buena suerte chico nuevo");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Lepion"))
                {
                    cCDialogue.Add("Hola humano.");
                    cCDialogue.Add("Espera, tu eres el tonto que no sab�a contar.");
                    cCDialogue.Add("Ayer vino aqu� ese microondas.");
                    cCDialogue.Add("Y ese cacharro debi� darte una moneda m�s");
                    cCDialogue.Add("Al menos ahora puedo justificar su despido");
                    cCDialogue.Add("Aunque el bobo se puso a decir cosas de hacer el harakiri o cosas as�.");
                    cCDialogue.Add("En fin, malditas m�quinas japonesas.");
                    cCDialogue.Add("Ya que est�s, cobrame esto, que debo seguir con mi trabajo de blanqueamiento de dinero.");
                    cCDialogue.Add("Adi�s");
                    cCDialogue.Add("Ni contar sabes, �de verdad? Acabas de perder todos los clientes chinos por la zona, \n y espero que pronto pierdas t� el trabajo.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bon d�a amigo m�o, espero que te est� yendo bien estos d�as.");
                    cCDialogue.Add("A m� el �ltimo plato del otro d�a no sali� como me esperaba la verdad� Me sali�... �PERFECTO! ");
                    cCDialogue.Add("Hice todos los pasos a la perfecci�n, aunque el veneno le di� un toque picante un poco raro.");
                    cCDialogue.Add("Y fue un poco extra�o cuando el plato empez� a hablarme en una lengua antigua, pero peores cosas he probado.");
                    cCDialogue.Add("A�n recuerdo cuando fui a un restaurante de elementales de roca, aunque obviamente el local era de un mago.");
                    cCDialogue.Add("El plato estrella era la gravilla, ese plato ten�a una textura asquerosa.");
                    cCDialogue.Add("Era como comerte un castillo de arena derretido.");
                    cCDialogue.Add("Pero bueno, ahora prepar� un plato mucho mejor, as� que necesitar� estos ingredientes amigo m�o.");
                    cCDialogue.Add("Gracias, te dejar� probarlo como quede bueno my besto frendo");
                    cCDialogue.Add("�Tengo prohibidos estos deliciosos ingredientes? El reino cada vez acaba con la libertad de la comida.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Enano"))
                {
                    cCDialogue.Add("�Hola peque��n!");
                    cCDialogue.Add("Soy el grandioso Manolo Cabeza de Pico, el mago m�s rico� Del barrio m�s alto del reino.");
                    cCDialogue.Add("Creo que se me ha colado uno de mis gnomos defectuoso en la tienda.");
                    cCDialogue.Add("Se llama Jos� Miguel Culo Escurridizo.");
                    cCDialogue.Add("El pobre no pod�a mantenerse quieto y se col� en la trampilla antes de turno.");
                    cCDialogue.Add("Aunque realmente me cae mal, no hace caso y no para de esconderse.");
                    cCDialogue.Add("Puede que si lo encuentras un par de veces esta semana se vaya contigo.");
                    cCDialogue.Add("As� me dejar� en paz el pesado, suerte busc�ndolo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("�Buenos d�as? �O noches? Ya no s� la verdad.");
                    cCDialogue.Add("Perd�n, te habr� confundido un poco, soy el del orbe el que habla.");
                    cCDialogue.Add("Por este maldito orbe solo puedo ver morado, no distingo si es de d�a o no.");
                    cCDialogue.Add("Me llamo Culul�, y hasta hace poco era un h�brido.");
                    cCDialogue.Add("Pero ahora soy un limb�stico, me mor� ayer mientras estaba en la gasolinera.");
                    cCDialogue.Add("Vi a un t�o con un libro rar�simo que parec�a hacer un ritual, y al verme, me di� un golpe con este orbe.");
                    cCDialogue.Add("Y al despertar, pues me qued� encerrado aqu�, aunque supongo que esto no sea un problema para mi cita.");
                    cCDialogue.Add("El detective de mi caso me dijo que no fuera por ahora hasta que me acostumbrara a mi nuevo yo.");
                    cCDialogue.Add("Pero la vida es una, y esa manguro es mi tipo ideal.");
                    cCDialogue.Add("Pero bueno, espero que encuentren al culpable pronto para que no me atosigue el detective.");
                    cCDialogue.Add("Ve cobrando estas pociones, que en unos minutos tengo la cita.");
                    cCDialogue.Add("Muchas gracias hermano, deseame suerte en la cita.");
                    cCDialogue.Add("T�o, de verdad que no te entiendo, si tengo toda la pasta.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("�Buen ser humano, necesito tu ayuda!.");
                    cCDialogue.Add("En mi casa se me han acabado las pilas y mi madre no estaba en casa para metermelas y darme energ�a.");
                    cCDialogue.Add("Por favor, necesito que me metas las pilas, ya te las pagar� luego. Recuerda meterlas en el hueco de la parte superior");
                    cCDialogue.Add("�Y r�pido!, que no quiero apagarme y convertirme en uno de esos horribles monstruos.");
                }
            }

            else if (currentScene.name == "Day2_2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Muchas gracias Ronin, que sepas que te lo recompensar� alg�n d�a, espero que mi maestro no se enfade.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("�Hola colega! �C�mo te encuentras? �Bien? �Mal?");
                    cCDialogue.Add("�YO ESTOY FENOMENAL!");
                    cCDialogue.Add("Soy Handy, el elemental m�s fiestero, que ama cualquier celebraci�n.");
                    cCDialogue.Add("Cumplea�os, bodas, despedidas de solteros y� �FUNERALES!");
                    cCDialogue.Add("Aunque del �ltimo funeral me echaron por alguna extra�a raz�n.");
                    cCDialogue.Add("Estoy tan emocionado amigo m�o, tengo una nueva compa�era.");
                    cCDialogue.Add("Se llama Rave-n, incluso estudi� fiestolog�a.");
                    cCDialogue.Add("Aunque a m� me expulsaron del grado de fiestolog�a por mi TFG sobre� �ALEGRAR FUNERALES!");
                    cCDialogue.Add("Se debieron de morir de la risa con mi TFG.");
                    cCDialogue.Add("Bueno colega, s� que est�s pasando un buen rato conmigo.");
                    cCDialogue.Add("Pero tengo una despedida de soltero y tengo que aguantar toda la noche despierto.");
                    cCDialogue.Add("Y necesito estos utensilios para sobrevivir a los solteros desesperados.");
                    cCDialogue.Add("Aunque no s� para qu� ser� la bola, me la pidieron los solteros");
                    cCDialogue.Add("Bueno, cobrame porfi porfita.");
                    cCDialogue.Add("Voy a hacer una despedida de soltero !INCRE�BLE! Nos vemos colega.");
                    cCDialogue.Add("Me has borrado la sonrisa t�o, pero entiendo que no puedas romper la normativa");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Petra"))
                {
                    cCDialogue.Add("Hola dependiente, de verdad que no puedo aguantar m�s mis ganas de empezar a trabajar.");
                    cCDialogue.Add("Necesito cont�rselo a alguien, �Por fin puedo ser una exploradora!");
                    cCDialogue.Add("Necesitaba soltarlo, no sabes lo emocionada que estoy con este nuevo trabajo.");
                    cCDialogue.Add("Por cierto, no me present�, me llamo Petra.");
                    cCDialogue.Add("He estado 12 a�os en paro desde que no llegu� a tiempo a una misi�n.");
                    cCDialogue.Add("Pero es lo que pasa cuando eres mitad tortuga y mitad liebre, que mi velocidad siempre ser� normal.");
                    cCDialogue.Add("Tambi�n mi jefe me coment� que esperaba que lo hiciera mejor que el �ltimo empleado.");
                    cCDialogue.Add("Era un sap�tamo que se la pasaba bebiendo en el trabajo.");
                    cCDialogue.Add("Menos mal que no bebo nada de alcohol en mi vida.");
                    cCDialogue.Add("Uy, perdona, te estoy quitando tiempo.");
                    cCDialogue.Add("Cobrame esto qu� lo necesito para el trabajo.");
                    cCDialogue.Add("Deseame suerte en mi primer d�a de curro, �Nos vemos!");
                    cCDialogue.Add("Necesitaba esto de verdad para el trabajo, el jefe me va a despedir y ni empec�.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Hola humano, �no tienes d�as libres o que? ");
                    cCDialogue.Add("Eres parecido en ese aspecto a los elementales, nosotros tampoco paramos de trabajar, es lo que tiene ser creaciones de los magos. ");
                    cCDialogue.Add("Espera, �no lo sab�as? La mayor�a de las razas actuales fueron creadas por ellos. ");
                    cCDialogue.Add("Que triste es la ignorancia de los humanos. ");
                    cCDialogue.Add("Los elementales fueron creados para hacer el trabajo de esclavos. ");
                    cCDialogue.Add("Los tecn�pedos fueron creados por accidente cuando metieron una varita en un microondas. ");
                    cCDialogue.Add("Y los limb�sticos no se sabe c�mo se crearon, solo se sabe que fueron los magos. ");
                    cCDialogue.Add("Le� en algunos foros de ocultismo que fueron creados por una iglesia que lleva a�os oculta entre nosotros.");
                    cCDialogue.Add("Tampoco pude leer mucho, es lo que tiene tener 23 horas de jornada laboral.");
                    cCDialogue.Add("Hablando de ello, en nada tengo que volver a trabajar como tapiz en un museo de la zona.");
                    cCDialogue.Add("Y encima tengo que explicar, de nuevo, al nuevo saco de huesos como va el trabajo all�.");
                    cCDialogue.Add("Le fue horrible en su primer d�a, aunque ya es horrible ser parte de nuestra raza.");
                    cCDialogue.Add("Por lo que ve cobr�ndome esto antes de que caiga en el olvido.");
                    cCDialogue.Add("Espero que acabe pronto mi jornada, aunque vaya a comenzar.");
                    cCDialogue.Add("Ni en mi descanso puedo conseguir un m�nimo de felicidad.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Masermati"))
                {
                    cCDialogue.Add("Hola cocherrum�n, estoy prepar�ndome para la carrera del siglo.");
                    cCDialogue.Add("No me present�, soy el famoso FMS, Faster More Serious.");
                    cCDialogue.Add("O como me llamo mi robo-madre, Masermati.");
                    cCDialogue.Add("Y voy a hacer la primera carrera de mi vida.");
                    cCDialogue.Add("Aunque espero que no sea la �ltima, no sabes la pasta que cuestan estas mejoras.");
                    cCDialogue.Add("Los tubos de escape costaron solo 100 monedas.");
                    cCDialogue.Add("No sabes todos los platos que limpi� para tener esa cantidad de monedas.");
                    cCDialogue.Add("Pero todo este trabajo fue necesario para el d�a de hoy, para ganar a�");
                    cCDialogue.Add("�FLECHA R�PIDA! El tecn�pedo m�s r�pido del reino.");
                    cCDialogue.Add("Es el coche oficial de Pijus Magnus, el 2� mago m�s poderoso del reino.");
                    cCDialogue.Add("O eso dice �l, aunque solo lo dice por ser hijo del Rey Mago.");
                    cCDialogue.Add("Realmente es un tirillas enano, espero que tengas suerte de no encontrarlo.");
                    cCDialogue.Add("Bueno, cobrame humano, que tengo que estar listo para la carrera.");
                    cCDialogue.Add("Gracias cocherrum�n, voy a prepararme para la carrera.");
                    cCDialogue.Add("�Pero si tengo suficiente! Da igual, tengo algo de prisa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Pijus"))
                {
                    cCDialogue.Add("T� ve cobrando esto que tengo prisa.");
                    cCDialogue.Add("Espera-");
                    cCDialogue.Add("��Eres humano?! �No te da verg�enza respirar el mismo aire que yo?");
                    cCDialogue.Add("No se ni como pagaste lo suficiente para entrar al reino.");
                    cCDialogue.Add("Y m�s te vale que me cobres bien, he le�do lo del 50%.");
                    cCDialogue.Add("As� que quiero que me lo rebajes T-O-D-O.");
                    cCDialogue.Add("Y como me cobres mal tendr� que usar mis poderosa habilidad�");
                    cCDialogue.Add("El n�mero de mi papi.");
                    cCDialogue.Add("Espero que me cobres bien, venga.");
                    cCDialogue.Add("As� me gusta humano, no sab�a qu� os hab�an ense�ado a contar all�.");
                    cCDialogue.Add("�C�mo que no sirve la oferta! Pues...Pues�Bonita moneda, me la quedo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Hola dependiente, soy del departamento de investigaci�n de sucesos paranormales, es decir, soy detective.");
                    cCDialogue.Add("Y ten�a una pregunta respecto a un caso sobre homicidio, alguien ha vuelto un h�brido a un limb�stico.");
                    cCDialogue.Add("Un poco pesado el fiambre diciendo que ten�a una cita, pero me da a mi que va a tener que esperar.");
                    cCDialogue.Add("Creemos que ha podido ser un artefacto m�gico el culpable, en concreto un libro de magia.");
                    cCDialogue.Add("�Sabes de alg�n clientes pueda tener un libro m�gico?");
                    cCDialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");
                }
            }

            else if (currentScene.name == "Day3_1")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenas chico nuevo.");
                    cCDialogue.Add("Parece que te est�s acostumbrando a tu trabajo.");
                    cCDialogue.Add("Est�s durando m�s que el antiguo empleado.");
                    cCDialogue.Add("No s� c�mo sigues vivo siquiera.");
                    cCDialogue.Add("Pero bueno, tengo malas noticias.");
                    cCDialogue.Add("Ha empezado el mercado de una nueva raza: Los Cupones");
                    cCDialogue.Add("Son criaturas que se utilizan como trueque a cambio de objetos.");
                    cCDialogue.Add("Con los cupones podr�n pillar lo que quieran, �LES SALDR� GRATIS!");
                    cCDialogue.Add("Vaya asco de bichos, al menos son muy coquettes.");
                    cCDialogue.Add("Debajo de tu pantalla tendr�s una retrato de los cupones que son v�lidos.");
                    cCDialogue.Add("Cuidado que no te traigan ninguno falso, fijate bien el retrato.");
                    cCDialogue.Add("Y recuerda revisar las normas, no servir� su cup�n si tiene prohibido alg�n objeto.");
                    cCDialogue.Add("Suerte humano.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sergio"))
                {
                    cCDialogue.Add("Hola joven humano, disculpa la impertinencia, pero deber�an de bajar el peso de esas bebidas.");
                    cCDialogue.Add("No sabes lo que pesan esas malditas latas.");
                    cCDialogue.Add("No tengo fuerza ni para levantarlas.");
                    cCDialogue.Add("En mis tiempos, cuando era conocido como Sergio Nervisous.");
                    cCDialogue.Add("Era capaz de levantar piedras y ten�a unos nervios de acero.");
                    cCDialogue.Add("Pero ahora suficiente que aguanto este cubo en mi cabeza.");
                    cCDialogue.Add("Y encima me ha revivido un mago que dice que es un h�roe.");
                    cCDialogue.Add("Se hace llamar Geeraard, que nombre m�s raro para un h�roe.");
                    cCDialogue.Add("Me revivi� para que le ayudar� en su nueva aventura.");
                    cCDialogue.Add("�Pero si no soy capaz ni de levantar una espada de verdad!");
                    cCDialogue.Add("Con lo bien que estaba en mi tumba.");
                    cCDialogue.Add("Necesito recuperar mis nervios, as� que, cobrame estas bebidas.");
                    cCDialogue.Add("Seguro revive mi fuerza.");
                    cCDialogue.Add("Voy a intentar que esto me despierte como es debido.");
                    cCDialogue.Add("�Est� prohibido venderme esto? En mis tiempos, beb�amos esto sin problema.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Salta"))
                {
                    cCDialogue.Add("Hola� Hola� Humano .");
                    cCDialogue.Add("Maldito cacharro, no ir como yo querer.");
                    cCDialogue.Add("Llevo desde ser zanahorio con esta silla, y a�n fallar.");
                    cCDialogue.Add("Yo ser Saltaralisis y querer cambiar runas de una vez.");
                    cCDialogue.Add("S� no cambiar runas, no hablar bien y crear malentendidos.");
                    cCDialogue.Add("Ya pasar otro d�a en banco, y cuando yo decir nombre, romper runa.");
                    cCDialogue.Add("As� que repetir palabra ASALTAR todo rato.");
                    cCDialogue.Add(" Ellos llamar guardia y yo acabar en c�rcel 3 d�as.");
                    cCDialogue.Add("Duros d�as, pero conocer gente maja en c�rcel.");
                    cCDialogue.Add("Yo conocer�Yo conocer�Yo conocer� Sap�tamo borracho.");
                    cCDialogue.Add("Vuelve a fallar, mejor cobrar para cambiar runas.");
                    cCDialogue.Add("Gra� Gra� c�as, cambiar runas ahora.");
                    cCDialogue.Add("No�No�. Poder cambiar, crear m�s mal entendidos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola mortal, �No habr�s visto un libro m�gico alguno de estos d�as?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Llevo d�as buscando un libro que se me fue robado, es importante �sabes?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("El habla no parece ser tu punto fuerte mortal.");
                    cCDialogue.Add("Pero bueno, har� que ese ladr�n recuerde mi nombre, Manolo Mago Manitas.");
                    cCDialogue.Add("Por su culpa y la del otro calamar no se pudo terminar el ritu�");
                    cCDialogue.Add("Si ves a alguien con libro m�gico, avisame mortal.");
                    cCDialogue.Add("Puede que vuelva en alg�n otro momento, pero primero debo atender a mi deber.");
                    cCDialogue.Add("Tengo que volver a mi iglesia, hay que dar la misa para nuestro dios, Azathoth.");
                    cCDialogue.Add("Por lo que ve cobrandome mortal.");
                    cCDialogue.Add("Buen chico, nos vemos mortal.");
                    cCDialogue.Add("Parece que eres otro sacrificio m�s, Azathoth te maldecir� por tu incompetencia.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Raven"))
                {
                    cCDialogue.Add("�Hola amigo m�o! �No es un d�a maravilloso?");
                    cCDialogue.Add("Aunque ni he dormido, pero trabajar como DJ Rave-n siempre me llena de energ�a.");
                    cCDialogue.Add("Tuve que trabajar en una despedido de soltero, los chicos fueron muy majos.");
                    cCDialogue.Add("Pero mi compa�ero Handy lo pas� un poco mal la verdad.");
                    cCDialogue.Add("El soltero se encari�� con el pobre Handy, era un limb�stico muy cari�oso.");
                    cCDialogue.Add("Pero bueno, me alegr� de que al menos haya podido poner mi m�sica.");
                    cCDialogue.Add("Porque la m�sica de hoy en d�a es digamos� Demasiado triste y oscura.");
                    cCDialogue.Add("El grupo Tears of Limbastics es super triste, malditas canciones emos.");
                    cCDialogue.Add("�S� lo mejor es el grupo Magicians of Power, tiene canciones super divertidas! ");
                    cCDialogue.Add("Pero parece que la sociedad se est� deprimiendo cada vez m�s.");
                    cCDialogue.Add("A�n as�, intentar� alegrar al mundo con mis canciones.");
                    cCDialogue.Add("Pero para ello, necesito recargar pilas colega, que quiero recargar.");
                    cCDialogue.Add("Cobrame esto si puedes porfi.");
                    cCDialogue.Add("Gracias compi, ahora ir� a descansar para deslumbrar esta noche m�s.");
                    cCDialogue.Add("No podr� recargar pilas colega� Este ser� un d�a con m�s canciones emos.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Hueso"))
                {
                    cCDialogue.Add("Chaval, casi me hago polvo arriba esperando, adem�s tengo prisa.");
                    cCDialogue.Add("Estoy en la nueva exposici�n de dinosaurios de la ciudad.");
                    cCDialogue.Add("Y cuando digo que estoy, es que literalmente estoy.");
                    cCDialogue.Add("Debido a que tengo huesos de hace millones de a�os.");
                    cCDialogue.Add("Un mago arque�logo me cre� y como qued� tan raro, no se dign� ni en darme nombre.");
                    cCDialogue.Add("Literal me llamo Elemental de Hueso el elemental de huesos.");
                    cCDialogue.Add("Por suerte logr� valerme por mi solo, y ahora obtuve un trabajo de verdad.");
                    cCDialogue.Add(" Ser esclavizado por un museo, muchos de mi raza desear�an este puesto en vez de la mina.");
                    cCDialogue.Add("Pero bueno, cobrame chaval, que tienen que verme en el museo.");
                    cCDialogue.Add("Un poco caro el mu�eco, pero hace a�os ese mu�eco antes eran 3 esclavos elementales, gracias.");
                    cCDialogue.Add("Pero si las pociones las beb�an hasta los dinosaurios, est�pidas norm�tivas.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Patxi"))
                {
                    cCDialogue.Add("No s� c�mo mi hombre est� tan ocupado, maldita programaci�n. ");
                    cCDialogue.Add("Y siempre tan apagado, le est�n chupando el alma a mi Antonio. ");
                    cCDialogue.Add("Ay ay ay, Antonio m�o deja la programa...");
                    cCDialogue.Add("��Usted qui�n es?!  Espera que ya es mi turno.");
                    cCDialogue.Add("Me hab�a olvidado que estaba en la cola mientras deliraba con mi Antonio.");
                    cCDialogue.Add("Es mi querido noviecito, curra m�s que un elemental en las minas.");
                    cCDialogue.Add("Y yo soy el mejor novio que se ha tenido, Patxi.");
                    cCDialogue.Add("El pobre trabaja de programador, mientras que yo soy corredor de bolsa.");
                    cCDialogue.Add("Solo tengo que correr con unas bolsas, es un buen trabajo para un limb�stico.");
                    cCDialogue.Add("Y ya que su trabajo es tan complicado quiero hacerle algo especial�");
                    cCDialogue.Add("Quer�a prepararle una cena rom�ntica esta noche, as� que si puedes cobrarme esto.");
                    cCDialogue.Add("Mi Antonio va a perder la cabeza con esta cena, perdona, se me pegaron sus chistes.");
                    cCDialogue.Add("Enemigo del romanticismo, mi Antonio no va a disfrutar mi cena para relajarse.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("�COLEGA, TE NECESITO DE VERDAD!");
                    cCDialogue.Add("HAN PROHIBIDO LAS CERVEZAS A LOS H�BRIDOS");
                    cCDialogue.Add("EMPEC� A HABLAR BIEN DE NUEVO");
                    cCDialogue.Add("HASTA ME LLEG� UNA SOLICITUD DE EMPLEO");
                    cCDialogue.Add("NO QUIERO VOLVER A TRABAJAR");
                    cCDialogue.Add("Y MENOS CON ESA TAL PETRA QUE ME QUIT� EL TRABAJO");
                    cCDialogue.Add("�ME NIEGO!");
                    cCDialogue.Add("TE DAR� EL DINERO QUE NECESITES");
                    cCDialogue.Add("PERO NE-CE-SI-TO CERVEZA ");
                    cCDialogue.Add("�TE QUIERO MUCHO COLEGA! ");
                    cCDialogue.Add("Hasta mi dependiente favorito�Adi�s a Elvog Borracho");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Enano"))
                {
                    cCDialogue.Add("�Hola peque��n! No te hab�a visto desde ah� abajo.");
                    cCDialogue.Add("Me sobra el dinero, para nada entr� aqu� por el 50% de descuento en magos.");
                    cCDialogue.Add("O incluso podr�a ser un 70% ahora que somos amigos.");
                    cCDialogue.Add(" Vale vale, no me mires con esa cara impasible, pero venga�");
                    cCDialogue.Add("Te prometo que te devolver� el dinero si me lo rebajas m�s.");
                    cCDialogue.Add("Por ejemplo, mi vecino a�n me dice que le debo 2000 monedas y que deje de evitarlo.");
                    cCDialogue.Add("Pero, por favor, yo no lo evito por la deuda, lo evito para ahorrarme esas 2000 monedas.");
                    cCDialogue.Add("Creo que no deb� decir eso�Bueno, mejor ve cobrando antes de que la li� m�s.");
                    cCDialogue.Add("Menos mal me he ahorrado esas monedas, as� podr� mantener mi enorme mansi�n durante 1 hora m�s.");
                    cCDialogue.Add("�No tengo dinero ni con el 50% de rebaja? Me va a tocar embargar la casa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Hola de nuevo, ven�a a comprar�");
                    cCDialogue.Add("�Pero qu�, otra vez no!");
                    cCDialogue.Add("Est�pida bater�a rota, hace 1 segundo ten�a bater�a de sobra y ahora de un momento a otro se pone en cr�tico mi energ�a.");
                    cCDialogue.Add("�Necesito que me metas las bater�as otra vez, y est� vez ten cuidado con el agua!");
                }
            }

            else if (currentScene.name == "Day3_2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji") && vecesSamuraiAyudado < 2)
                {
                    cCDialogue.Add("Ufff, por los pelos, estupida bater�a, creo que est� algo rota por estos sustos que me da");
                    cCDialogue.Add("Espero que esta deshonra no llegue a los o�dos de mi maestro, muchas gracias humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji") && vecesSamuraiAyudado >= 2)
                {
                    cCDialogue.Add("Ufff, por los pelos, estupida bater�a, creo que est� algo rota por estos sustos que me da");
                    cCDialogue.Add("Toma, quedate con mi espada legendaria \n c�mo agradecimiento. Cuidala bien, la han tocado muchos \n m�s seres anteriores a ti.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rustica"))
                {
                    cCDialogue.Add("Hola cielo, se te v� algo cansado, �est�s bien?");
                    cCDialogue.Add("Seguro que est�s as� por el trabajo, llevo a�os viniendo aqu� y s� bien c�mo os trata el jefe.");
                    cCDialogue.Add("Igual es un chico bueno aunque sea un poco avaricioso, egoc�ntrico, ego�sta y explotador laboral.");
                    cCDialogue.Add("Todo el mundo tiene el lado bueno, lo s� bien con todos los a�os que he pasado viva. ");
                    cCDialogue.Add("Fu� de los primeros t�cnopedos, de ah� mi nombre, R�stica.");
                    cCDialogue.Add("Trabaje en varios sitios, uno de mis favoritos fue de camarera.");
                    cCDialogue.Add("En un bar muy elegante, creo que se llamaba Hell Fire Bar.");
                    cCDialogue.Add("Siempre hab�a alguna que otra pelea entre amigos, o peque�as peleas de bandas.");
                    cCDialogue.Add("Alguna vez nos pintaban las paredes con latas de spray, eran buenos chicos en el fondo.");
                    cCDialogue.Add("Fue una buena �poca� Disculpa cielo que me voy por las nubes.");
                    cCDialogue.Add("Cobrame esto, as� voy tirando a la chatarrer�a a echar unas cartas con mis amigas.");
                    cCDialogue.Add("Gracias cari�o, espero no llegar tarde a la chatarrer�a.");
                    cCDialogue.Add("�Mi cup�n est� roto? Perd�n cari�o.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Buenos d�as dependiente, veo que ha sido un d�a ajetreado.");
                    cCDialogue.Add("Ayer mandamos al Detective Le�n a investigar a los sospechosos de ayer, al parecer Giovanni sabe cosas.");
                    cCDialogue.Add("Tuvo en posesi�n un libro de magia ancestral, que fue prohibida hace siglos aunque se desconoce que hace.");
                    cCDialogue.Add("Nos coment� que se le encontr� de camino de la gasolinera donde trabaja el fiambre la misma noche.");
                    cCDialogue.Add("Tras varias comprobaciones supimos que era cierto y que no puede ser el culpable.");
                    cCDialogue.Add("Aunque ahora tenemos alguna pista m�s, un cliente de esta tienda us� una bola de cristal en el ritual.");
                    cCDialogue.Add("Y que la compr� bajo el nombre de �Manolo�, seg�n un ticket tirado por la escena del crimen.");
                    cCDialogue.Add("�Sabes si alguno de los siguientes sospechosos pueda tener relaci�n con la descripci�n que te d�?");
                    cCDialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");

                }
            }

            else if (currentScene.name == "Day4")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola chico nuevo, veo que te est�s acostumbrando al trabajo en mi tienda.");
                    cCDialogue.Add("Que raro que ning�n mago te la haya arrancado la cabeza por negarte a cobrarle, al anterior dependiente le pas� eso.");
                    cCDialogue.Add("Aunque gracias a ese mago, no tuve que pagarle ese mes.");
                    cCDialogue.Add("As� acab� comprando el carruaje m�s r�pido del reino, aunque se qued� obsoleto por culpa de los coches.");
                    cCDialogue.Add("Por culpa de esas est�pidas m�quinas de 4 ruedas, los tecn�pedos no podr�n comprar pilas y bebida energ�tica junta, por una reacci�n que los hace m�s r�pidos.");
                    cCDialogue.Add("Se lo tienen merecido por hacerme gastar mis preciosas monedas en un carruaje que qued� obsoleto.");
                    cCDialogue.Add("Y tambi�n me enter� hace poco que hay una secta convirtiendo h�bridos en limb�sticos.");
                    cCDialogue.Add("Por lo que los h�bridos no podr�n comprar nada de magia negra, esa secta solo me ha hecho perder dinero.");
                    cCDialogue.Add("Bueno, es hora de que empiece tu turno, recuerda mirar las nuevas normas.");
                    cCDialogue.Add("Suerte humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jissy"))
                {
                    cCDialogue.Add("�Qu� pasa t�o?�C�mo estamos?");
                    cCDialogue.Add("Espera, tu� Tu no eres el de el otro d�a �no..?");
                    cCDialogue.Add("Yo  soy Jeese, Jeese Chemman, mi nombre de las calles t�o.");
                    cCDialogue.Add("Perdona tronco pero, �Seguro que no eres el dependiente de siempre?");
                    cCDialogue.Add("Nunca se me ha dado bien esto de reconocer a la gente, �sabes?");
                    cCDialogue.Add("Pero tienes un parecido al anterior dependiente.");
                    cCDialogue.Add("Aunque creo que el anterior no era humano, era un raza superior �sabes?");
                    cCDialogue.Add("Espero que no te afectar� el comentario, tampoco se me da bien socializar.");
                    cCDialogue.Add("En f�n, espero que te vaya bien.");
                    cCDialogue.Add("Ah, s�, pero antes de irme, cobrame esto.");
                    cCDialogue.Add("Que me iba sin pagar �sabes?");
                    cCDialogue.Add("Gracias colega, deber�amos quedar alg�n d�a para hablar de la vida �sabes?");
                    cCDialogue.Add("Bueno tronco, no s� c�mo no aceptas mi dinero, deber�as mejorar en el trabajo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mara"))
                {
                    cCDialogue.Add("Uy, buenos d�as cielo, se nota que eres un buen trabajador.");
                    cCDialogue.Add("Deber�a de tomar ejemplo de ti, que me hubiera venido mejor trabajar en vez de ir a la horrible cita del otro d�a.");
                    cCDialogue.Add("Para una vez que decido volver a darle a un intento al amor, y con el tiempo que le dediqu� a mi cuenta de Hybrinder.");
                    cCDialogue.Add("Llegu� al peque�o local limb�sticos, con mis patas raptoriales reci�n afiladas, y el tipo result� no ser un h�brido.");
                    cCDialogue.Add("Ni siquiera su cabeza se ve�a apetitosa, ten�a una pedazo de esfera en su cabeza.");
                    cCDialogue.Add("Igualmente acced� a cenar con �l, aunque me hubiera enga�ado de esta manera.");
                    cCDialogue.Add("Nada m�s me separ� de �l, le bloque� de todos lados, espero no verlo m�s en mi vida.");
                    cCDialogue.Add("Mi pata de la suerte seguro dej� de funcionar, es la de mi ex marido.");
                    cCDialogue.Add("Siempre la llevo en mi bolso, pero dejar� de usarla");
                    cCDialogue.Add("Perdona si te aburriste con mi historia querido, c�brame que tengo que ir a m�s tiendas querido.");
                    cCDialogue.Add("Gracias cielo, qu�date con mi pata de la suerte, no creo que la necesite m�s.");
                    cCDialogue.Add("Gracias cielo, espero nunca que no tengas citas como la m�a.");
                    cCDialogue.Add("�Est� prohibido esto? Bueno, ayer vi varias personas compr�ndolo, que raro.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("Buenos d�as mi dependiente favorito, �no es preciosa la vida?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Veo que mi pregunta te dejo mudo al igual que yo cuando veo a mi nueva diosa.");
                    cCDialogue.Add("La cita del otro d�a no s�lo fue genial, fue perfecta.");
                    cCDialogue.Add("Cuando la v�, qued� perdido en su ojos de mantis, y no paraba de querer acariciar sus preciosas y afiladas garras.");
                    cCDialogue.Add("Obvio fu� un caballero y no me atrev� a tocar sus hermosas garras.");
                    cCDialogue.Add("Adem�s de que no quer�a perder mi mano.");
                    cCDialogue.Add("Pero bueno, lo mejor de la cita fue cuando nos sentamos juntos y cenamos.");
                    cCDialogue.Add("Y esa cangumantis me dijo 10 palabras, �10 PALABRAS!");
                    cCDialogue.Add("Solo una hembra me hab�a dicho m�s palabras que esas, mi madre.");
                    cCDialogue.Add("Mis palabras favoritas fueron / �Pagas tu, no ? / Quiso que pagara yo, qu� rom�ntico");
                    cCDialogue.Add("Tengo pensado decirle de tener otra cita, y creo que esto de aqu� ser� necesario para la cita, as� que si pudieras cobrarme.");
                    cCDialogue.Add("Te informar� sobre mi pr�xima cita, mi dependiente favorito.");
                    cCDialogue.Add("T�, enemigo del amor, gracias por arruinar mi cita.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sergio"))
                {
                    cCDialogue.Add("Hola humano, �podr�as ayudarme?");
                    cCDialogue.Add("He decidido no ir a la misi�n del mago raro que me invoc�.");
                    cCDialogue.Add("No s� qui�n se cree para ir reviviendome sin mi permiso.");
                    cCDialogue.Add("Bueno, al caso, necesito 3 bebidas energ�ticas para activar mi 100%");
                    cCDialogue.Add("Y as� escapar del reino con mi super energ�a, o eso pon�a en internet sobre esta bebidas.");
                    cCDialogue.Add("Que me dices, �me ayudas?");
                    cCDialogue.Add("Gracias por tu ayuda, tendr�s una recompensa, te dar� mi legendaria espada, �LA GLOBOSPADA!");
                    cCDialogue.Add("Sab�a que me ayudar�as, suerte humano.");
                    cCDialogue.Add("�De verdad? Qu� poco coraz�n");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Elidora"))
                {
                    cCDialogue.Add("Hola s�bdito, �No crees que deber�as de dejar de atender en este s�tano?");
                    cCDialogue.Add("Casi uno de mis fieles slimes se deshace por culpa de la ca�da.");
                    cCDialogue.Add("Y no sabes el precio que hubieras tenido que pagar por mi slime.");
                    cCDialogue.Add("Podr�a haberte nombrado mi nueva silla oficial� La �nica silla del Reino Slime.");
                    cCDialogue.Add("Mi gran y poderoso reino de 4 habitantes slimes, donde yo soy la reina.");
                    cCDialogue.Add("LA PODEROSA REINA MAGA ELIDORA LIMALIGNA.");
                    cCDialogue.Add("La reina m�s poderosa de todos los reinos.");
                    cCDialogue.Add("Aunque a�n estoy con los papeles para volver mi reino oficial.");
                    cCDialogue.Add("Creo que te dejar� unirte a mi reino si me muestras tu gran habilidad atendiendo clientes.");
                    cCDialogue.Add("�Qu� me dices?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Ya veo que te he sorprendido tanto que te he dejado sin habla.");
                    cCDialogue.Add("Venga muestrame tus habilidades cobrando.");
                    cCDialogue.Add("Te har� el dependiente oficial� Nada m�s terminar con el papeleo, adi�s humilde s�bdito");
                    cCDialogue.Add(" En Reino Slime sirven estos cupones, adi�s humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard") && noCobrarSergioCobrarGeeraardD4 == 0)
                {
                    cCDialogue.Add("�Humano, que le vendiste a mi limb�stico!");
                    cCDialogue.Add("Con lo que me cost� convencer a la iglesia para invocarlo.");
                    cCDialogue.Add("No sabes lo dif�cil que fue encontrar a ese mago mano.");
                    cCDialogue.Add("Y por no hablar de los ingredientes para revivirlo, fueron muy costosos.");
                    cCDialogue.Add("Ser�s� Claro, esto es lo que pasa por dejar a un humano trabajar.");
                    cCDialogue.Add("Has perdido un cliente, �PARA SIEMPRE!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Geraaaard") && noCobrarSergioCobrarGeeraardD4 != 0)
                {
                    cCDialogue.Add("Hola humano, espero que en estos d�as te hayas le�do una de miles historias.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Tu mirada me dice que no es as�, �Es que no tienes tiempo para leer en casa?");
                    cCDialogue.Add("Eres de los peores fans que he tenido en mi vida.");
                    cCDialogue.Add("Espero que leas al menos una antes de que escriban mi nueva historia: La caza del collar de Sin Cuello.");
                    cCDialogue.Add("Ma�ana mismo partir� camino del reino junto con mi nuevo compa�ero.");
                    cCDialogue.Add("Es un limb�stico que reviv� con ayuda de un mago mano un poco extra�o.");
                    cCDialogue.Add("Al parecer es el �nico tipo del reino que sabe hacer limb�sticos, y yo que pensaba que reviv�an solos");
                    cCDialogue.Add("Bueno, como dec�a de mi compa�ero, dicen que cuando estaba vivo ten�a unos nervios de acero.");
                    cCDialogue.Add("As� que por eso solo revivimos su sistema nervioso y su cerebro.");
                    cCDialogue.Add("Espero que sea tan capaz como yo, aunque se le ve un poco tirillas.");
                    cCDialogue.Add("En fin, necesitar� algunos materiales para el viaje, y esta tienda tiene suerte de ser mi proveedora no oficial.");
                    cCDialogue.Add("Por lo que tendr�s el honor de cobrarme, y con suerte recibir�s un aut�grafo mio.");
                    cCDialogue.Add("Des�ame suerte en mi aventura, te dar� mi foto favorita con un aut�grafo, por tu humilde servicio.");
                    cCDialogue.Add("Des�ame suerte en mi aventura, aunque no la necesite.");
                    cCDialogue.Add("Por todo lo que he hecho por el reino, y me lo pagan as�.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Magma"))
                {
                    cCDialogue.Add("Buenas ma�anas persona fr�a, soy Magmadora.");
                    cCDialogue.Add("Fr�o de personalidad o fr�o de carne, t� dir�s, solo tienes que mirarme.");
                    cCDialogue.Add("Veo que no eres el mismo trozo de carne fr�a que hab�a antes en este lugar.");
                    cCDialogue.Add("Haber si llega ya el maldito verano que yo soy de los que prefiere el calor, sino mira como estoy que ardo.");
                    cCDialogue.Add("De verdad que la gente que prefiere el fr�o no la entiendo.");
                    cCDialogue.Add("Si no estuvieras hecho de carne, tambi�n preferir�as el calor.");
                    cCDialogue.Add("Ventajas de no poder sudar.");
                    cCDialogue.Add("En fin, �Te importar�a cobrarme esto? Que me estoy quedando sin llama y tengo que avivarme un poco.");
                    cCDialogue.Add("Gracias, espero que cuando termine de trabajar no se enfr�e de camino a casa.");
                    cCDialogue.Add("�C�mo que han prohibido comprar pociones? �AHORA C�MO PODR� COMPRAR MI POCI�N DE LAVA!");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("Dependiente... Hoy no podr�a ser... �LA MEJOR SEMANA DE MI VIDA!");
                    cCDialogue.Add("El trabajo del otro d�a fue genial, los solteros fueron encantadores.");
                    cCDialogue.Add("Les encant� cuando me puse a hacer mi mon�logo.");
                    cCDialogue.Add("Y mi compa�era es una DJ genial, en el momento de las copas sali� a hacer su parte.");
                    cCDialogue.Add("Baile con el novio un rato, pero no paraba de tocar mi bocina, era un tipo raro.");
                    cCDialogue.Add("Pero bueno, ahora tenemos un nuevo trabajo para hoy, una gatoteca.");
                    cCDialogue.Add("Hemos pensado en animar haciendo un musical con los gatos, pero son unos bichos muy ariscos y arr�tmicos.");
                    cCDialogue.Add("As� que hemos pensado en otra cosa, vamos a bollos con forma de gatito.");
                    cCDialogue.Add("En fin, sabes que me encanta estar contigo, pero se me est� haciendo tarde amigo.");
                    cCDialogue.Add("Por lo que c�brame que tengo que alegrar esa gatoteca.");
                    cCDialogue.Add("Gracias amigo, como muestra de nuestra amistad, el traje que us� en la despedida de soltero.");
                    cCDialogue.Add("Des�ame la mayor de las suerte en mi nuevo trabajo.");
                    cCDialogue.Add("Espero que el trabajo me vaya bien igualmente");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Buenos d�as chico� Eres el del otro d�a �no?");
                    cCDialogue.Add("Tengo mala memoria, debe ser porque siempre pierdo la cabeza, ja ja ja...");
                    cCDialogue.Add("Sab�a que eras t�, a�n recuerdo el vac�o que dejabas cada vez que contaba mi mejor chiste.");
                    cCDialogue.Add("Entonces tengo la confianza de decirte que me gustar�a hacer un regalo a mi novio Patxi.");
                    cCDialogue.Add("Ayer me hizo una cita y quiero hacer algo a cambio, pens� en proponerle hacer senderismo.");
                    cCDialogue.Add("Pero con lo lento que voy y lo r�pido que va �l, seguro no lo disfrutamos igual, por eso me decant� por la opci�n del regalo.");
                    cCDialogue.Add("Espero que le guste este gato muerto, seguro que le recuerda a Mistafurri�o.");
                    cCDialogue.Add("Era su gato cuando estaba vivo, y puede que quiera algo que le recuerde a �l.");
                    cCDialogue.Add("C�brame por favor que tengo que envolver el regalo.");
                    cCDialogue.Add("Espero que le guste este regalo.");
                    cCDialogue.Add("Ahora que le regalo yo a mi Patxi.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola humano, hoy no vengo como cliente, sino como testigo de Azathoth.");
                    cCDialogue.Add("�Has reconsiderado acercarte a mi iglesia?");
                    cCDialogue.Add("�ltimamente aceptamos a varios humanos para que se unan a rezar con nosotros, siempre vienen nuevos.");
                    cCDialogue.Add("Aunque hace poco comprobamos que los h�bridos tambi�n son �bienvenidos� a nuestra religi�n.");
                    cCDialogue.Add("Transformamos a uno de ellos en uno de los nuestros... Fue simplemente arte.");
                    cCDialogue.Add("Pero bueno, solo me acercaba por aqu� para que reconsideraras la oferta, siempre te daremos una mano.");
                    cCDialogue.Add("Suerte en la tienda, humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Buenos d�as humano, la investigaci�n se est� alargando bastante.");
                    cCDialogue.Add("Puede que no lo sepas, pero este caso se empez� porque estamos buscando a qui�n est� creando limb�sticos.");
                    cCDialogue.Add("Los limb�sticos son incapaces de recordar d�nde les crearon, pero con algo de investigaci�n encontramos algo.");
                    cCDialogue.Add("Un sospechoso de ayer parece formar parte de una religi�n de la que desconocemos.");
                    cCDialogue.Add("Y creemos que pueden estar relacionados con la creaci�n de limb�sticos.");
                    cCDialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                    cCDialogue.Add("Creemos que el sospechoso se reuni� con otro cliente de esta tienda para hacer un limb�stico.");
                    cCDialogue.Add("Pero tampoco tenemos suficientes pruebas para saberlo.");
                    cCDialogue.Add("Creemos que el sospechoso se reuni� con otro cliente de esta tienda para hacer un limb�stico.");
                    cCDialogue.Add("�Sabes si alguno de los siguientes sospechosos se relacion� con la iglesia?");
                    cCDialogue.Add("Muchas gracias por la informaci�n, espero que tenga un buen d�a, humano.");
                }
            }

            else if (currentScene.name == "Day5")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Hola humano, �Sabes que hoy es un d�a especial?");
                    cCDialogue.Add("Es el primer d�a del a�o que no tenemos nuevas normas, �AS� PODR� TENER M�S DINERO!");
                    cCDialogue.Add("Y al ser un d�a tan especial, te dar� un trato especial.");
                    cCDialogue.Add("Revisar� c�mo trabajaste por mis c�maras� Digo con mis poderosas habilidades mentales.");
                    cCDialogue.Add("Y si lo has hecho muy bien, seguir�s trabajando aqu�, o al menos espero que puedas pagarte la maldita documentaci�n.");
                    cCDialogue.Add("Como no hayas ganado suficiente dinero, �TE QUEDAS SIN LA DOCUMENTACI�N!");
                    cCDialogue.Add("Pero bueno, conf�o que hayas sido un buen trabajador.");
                    cCDialogue.Add("Suerte en el que espero que no sea tu �ltimo d�a.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Elidora"))
                {
                    cCDialogue.Add("Hola humano, vengo defraudada de lo mal hecho que est� este reino.");
                    cCDialogue.Add("Fu� al famoso restaurante de �Tips�, y no dejaron pasar a mis humildes ciudadanos esclavos de slime.");
                    cCDialogue.Add("Alguna h�brido debi� hacer esas normas tan tontas, �C�mo no van a permitir criaturas m�gicas?");
                    cCDialogue.Add("Y lo peor es la DECADENCIA del lugar, me obligaron a sentarme en una silla en vez de en mi slimes.");
                    cCDialogue.Add("Y porqu� no hablar del servicio, casi tuve que cazar a los camareros, c�mo un os�guila a un salm�n.");
                    cCDialogue.Add("Le voy a poner una estrella en TripKingdom a ese maldito sitio.");
                    cCDialogue.Add("Seguro no me atend�an como deb�an por ser la reina del reino slime, esos h�bridos magof�bicos.");
                    cCDialogue.Add("Menos mal que en mi reino no excluimos a nadie, excepto a los h�bridos a partir de este mal servicio.");
                    cCDialogue.Add("Har� un restaurante llevado por slimes que lo har�n mejor que esos in�tiles.");
                    cCDialogue.Add("Bueno, humano c�brame que tengo que empezar con la edificaci�n de mi reino.");
                    cCDialogue.Add("Bien hecho humano, si se te da tan bien cobrar, seguro tambi�n se te da bien ayudarme con las obras de mi reino.");
                    cCDialogue.Add("Est�pido humano, menos mal que mis dependientes slimes ser�n m�s listos que t�.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Rockon"))
                {
                    cCDialogue.Add("Ho-hola amigo, �qu� tal tu-tu-tu d�a de hoy?");
                    cCDialogue.Add("Seguro que fue un d�a pri-pri-edr�stico, como decimos chicos piedras.");
                    cCDialogue.Add("Tenemos muchas expresiones ra-raras gracias a mis primos roca, son de pueblo cerrado.");
                    cCDialogue.Add("Adem�s de que son chicos fuerte como mi padre, dicen que son �Gymbros�.");
                    cCDialogue.Add("Deber�a de ir al �Muscle Beluga� para me-mejorar mis m�sculos, es el mejor gimnasio del reino.");
                    cCDialogue.Add("As� igualar�a la fuerza de mis primos y podr�a ayudar a mi padre en su restaurante.");
                    cCDialogue.Add("�l est� como esclavo en el �Tips� del reino, es el mejor sitio para comer.");
                    cCDialogue.Add("Aunque cada d�a le tocan clientes m�s desagradables, fue una ma-maga que quer�a pasar a unos slimes.");
                    cCDialogue.Add("Se nota que no sabe lo que cuesta limpiar la baba de esas po-pobres criaturas.");
                    cCDialogue.Add("Se-seguro que estoy haciendo mucha cola, c�brame amigo.");
                    cCDialogue.Add("Gra-gracias, espero le gusten estos peluches con forma humana a mi padre.");
                    cCDialogue.Add("Me falta di-dinero, jopetas, perd�n por intentar enga�arte con el cup�n.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Buennnasss *hip* T��T��  Ah� est� miii dependiente favorito.");
                    cCDialogue.Add("Erres el mejor, t�oooo, gracias a t� no tengo trabajarrr m�s, er jefe me ha visto borracho, de nuevo.");
                    cCDialogue.Add("Ahorra seguirr� con mi incre�ble vida jubeniiiil, eres er �nico capaz de entenderme*hip*");
                    cCDialogue.Add("Te invitarr�a a una birra, pero no s� que bebe�s los hurmanos, ten�is pinta de beberrrr Carrimocho.");
                    cCDialogue.Add("No parreceis bebedores fuertes como yo, mi h�gado y yo segurro somos los combatientes m�s fuertes del reino*hip*");
                    cCDialogue.Add("Te estoy robando muuuuucho tiempo, solo quiero decirte que esperro que podamos ser amigos.");
                    cCDialogue.Add("Te darr� esta botella, en se�al de nuestra amis *hip* tad");
                    cCDialogue.Add("Nos vemos besto amigo.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Petra"))
                {
                    cCDialogue.Add("Hola amigo� Al igual que tu me diste �nimos para trabajar, te tendr� que contar una nueva noticia�");
                    cCDialogue.Add("Me han despedido� Es� �Una muy buena noticia!");
                    cCDialogue.Add("Ese tipo era un explotador de mucho cuidado, �qui�n se cre�a?");
                    cCDialogue.Add("Quer�a que le encontrar� un lugar llamado Atlantis con un mapa del men� infantil del Tips.");
                    cCDialogue.Add("Ahora le tocar� al nuevo hacer eso, o mejor dicho al que han recontratado");
                    cCDialogue.Add("Con la nueva prohibici�n del alcohol, el sapop�tamo dej� el alcohol.");
                    cCDialogue.Add("Espero que le vaya bien, aunque lo dudo.");
                    cCDialogue.Add("Adem�s, me podr� librar de algunas que llevaba en la mochila, como este mapa vac�o.");
                    cCDialogue.Add("Te lo puedes quedar, aunque dudo que le puedas dar mucho uso, principalmente porque no tiene nada.");
                    cCDialogue.Add("Nos vemos amigo.");
                }


                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Cululu"))
                {
                    cCDialogue.Add("Hola colega, tengo una mala noticia para ti.");
                    cCDialogue.Add("La cangumantis y yo lo hemos dejado, me ech� spray de pimienta en la esfera cuando la encontr�.");
                    cCDialogue.Add("Es una de las maneras en la que me han dejado, la peor una de mis exs que me dej� por mi hermano.");
                    cCDialogue.Add("Pero esto ha hecho que abra los ojos y me d� cuenta que de tanto pensar en el amor, me perd� en el sendero de la vida.");
                    cCDialogue.Add("As� que tome una decisi�n importante y me desinstal� Hybrinder, aunque me quedara un a�o de premium.");
                    cCDialogue.Add("Creo que ahora voy a rehacer mi vida, ahora que soy un limb�stico.");
                    cCDialogue.Add("Puedo intentar ser un monje, perdido en la monta�a, para encontrar un nuevo camino.");
                    cCDialogue.Add("Pero creo que me quedar� trabajando en la gasolinera como siempre, hasta que encuentre mi camino.");
                    cCDialogue.Add("Hablando de la gasolinera, c�brame que tengo dentro de nada el turno.");
                    cCDialogue.Add("Gracias, qu�date con este cuadro de Mara, para que me olvide de ella.");
                    cCDialogue.Add("Voy a empezar con ganas mi nuevo camino, si es que me llega.");
                    cCDialogue.Add("Espero que empezar mi nuevo camino no se vea afectado por mi nulas capacidades de contar monedas.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Masermati"))
                {
                    cCDialogue.Add("Hola cocherrum�n, �adivina qui�n particip� en la carrera del otro d�a y qued� en 1� lugar?");
                    cCDialogue.Add("Pues yo no porque qued� en 8� lugar, pero lo importante fue participar.");
                    cCDialogue.Add("Si sigo entrenando, puede que para la pr�xima quede en 1� lugar.");
                    cCDialogue.Add("Si no fuera porque Flecha R�pida hiciera trampa, ese trasto de 4 ruedas lanz� clavos por el camino.");
                    cCDialogue.Add("Es igual de miserable que su due�o Pijus Magnus, la pr�xima vez no se repetir�.");
                    cCDialogue.Add("Menos mal que mi familia se qued� apoy�ndome hasta el final.");
                    cCDialogue.Add("Seguro que en cuanto me ponga la luces traseras y el cambio de marchas mejorar� mucho m�s.");
                    cCDialogue.Add("Pero como siempre dan citas para dentro de 3 meses en reparaci�n p�blica.");
                    cCDialogue.Add("Esperar� hasta la cita y la operaci�n para ser mejor coche en mi siguiente carrera.");
                    cCDialogue.Add("Bueno cocherrum�n, creo que deber�a ir corriendo hasta casa que se me hace tarde.");
                    cCDialogue.Add("Ahora voy acelerando a casa para no llegar tarde, chao.");
                    cCDialogue.Add("Con las prisas deb� romper el cup�n.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Hola amigo, �a que me ves diferente?");
                    cCDialogue.Add("Se cur� mi miop�a gracias a beber tanto veneno.");
                    cCDialogue.Add("�Qui�n iba a decir que el veneno era la cura?");
                    cCDialogue.Add("Me imagino que no lo ha probado nadie antes, porque se morir�a sino.");
                    cCDialogue.Add("Pero como no puede morir alguien muerto, me cur�.");
                    cCDialogue.Add("Gracias por vendernos el veneno a Patxi y a m�.");
                    cCDialogue.Add("Ahora no necesitar� mis gafas, puedes qued�rtelas.");
                }


                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Mano"))
                {
                    cCDialogue.Add("Buenos d�as pr�ximo creyente, veo que sigues encadenado a esta tienda.");
                    cCDialogue.Add("Podr�as intentar ser m�s libre si vinieras alguna vez a una de las misas de mi iglesia.");
                    cCDialogue.Add("Adem�s te beneficiar�a venir, con cierta informaci�n que te voy a contar ahora.");
                    cCDialogue.Add("Vamos a hacer que vuelvan antiguos h�roes a la vida, el primero fue el gran Sergio Nerviosaus.");
                    cCDialogue.Add("Pero dentro de poco, no ser� el �nico que volver� a la vida y nos ayudar�.");
                    cCDialogue.Add("As� que creo que te beneficiar�a estar de nuestra parte, y no de la del detective que lleva unos d�as vi�ndote.");
                    cCDialogue.Add("�Crees que no lo sab�a? Ese detective lleva algunos d�as indagando en nuestra sagrada iglesia.");
                    cCDialogue.Add("Adem�s de que siempre viene a esta tienda al final del d�a, as� que espero que hoy le mientas un poquito.");
                    cCDialogue.Add("Pero bueno, hoy vine como cliente, por lo que c�brame humano.");
                    cCDialogue.Add("Te espero pronto en mi iglesia, humano.");
                    cCDialogue.Add("Cuando revivamos a los h�roes, espero que no sepas contar mejor.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Salta"))
                {
                    cCDialogue.Add("Hola humano, �c�mo estar d�a?");
                    cCDialogue.Add("Como tu ver ver ver ver ver romper runas de nuevo.");
                    cCDialogue.Add("Yo estar en bar anoche con mi querida familia, hasta que un borracho echarme toda su bebida encima.");
                    cCDialogue.Add("El tipo no quiso reparar mis runas y romperlas toda la noche.");
                    cCDialogue.Add("Ahora necesitar cambiar runas de nuevo, la gente no comprender a m�.");
                    cCDialogue.Add("No entender que yo no nacer con mitad animal, si no con vegetal.");
                    cCDialogue.Add("Deber cambiar alguna cosa para hacer mejor trato a los h�bridos mitad vegetal.");
                    cCDialogue.Add("O al menos hacer algo para que los h�bridos vegetarianos no babear babear babear con nosotros.");
                    cCDialogue.Add("Ya volver a funcionar mal, c�brame que querer cambiar runas.");
                    cCDialogue.Add("Gracias humano, cambiar en nada runas.");
                    cCDialogue.Add("Yo solo querer cerveza para pap�, pero bueno, dar solo runas mejor.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Raven"))
                {
                    cCDialogue.Add("Hola cielo, espero que est�s teniendo un d�a brillante.");
                    cCDialogue.Add("A m� ayer me fue genial en la gatoteca, fue muy divertido a mi compa�ero huir de los gatos.");
                    cCDialogue.Add("Se le pegaban los gatos con la est�tica de los globos.");
                    cCDialogue.Add("�Adem�s pudimos atender a uno de los miembros de la banda de Magicians of Power!");
                    cCDialogue.Add("�SON EL MEJOR GRUPO DEL MUNDO!");
                    cCDialogue.Add("Y gracias a mis incre�bles dotes de persuasi�n y carisma, me regalaron dos entradas para ir.");
                    cCDialogue.Add("Seguro le digo a Handy de ir, es un gran compa�ero, y se esfuerza m�s que ninguno que haya tenido.");
                    cCDialogue.Add("Aunque su debilidad sean los gatos con mucho pelo.");
                    cCDialogue.Add("No s� cu�l ser� el pr�ximo trabajo, pero espero que pueda hacerlo junto con �l.");
                    cCDialogue.Add("Te quite mucho tiempo amigo m�o, cobrame esto porfi.");
                    cCDialogue.Add("Eres el mejor, no s� si te interese, pero ya que somos tan buenos amigos te dar� mi disco favorito.");
                    cCDialogue.Add("Gracias amigo, espero que llegue ya el d�a del concierto.");
                    cCDialogue.Add("�No puedo comprar esto? Cre�a que ten�a todo el dinero.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Tapiz"))
                {
                    cCDialogue.Add("Hola humano, creo que me acaba de pasar algo sorprendente despu�s de estos a�os trabajando.");
                    cCDialogue.Add("Han habido recortes en mi trabajo, por lo que pensaba que me iban a recortar mi sueldo de 3 monedas al mes.");
                    cCDialogue.Add("Pero lo que parec�a un recorte de sueldo, acab� siendo un recorte de verdad.");
                    cCDialogue.Add("Literalmente han cortado una parte de m�, y sali� un mini yo, por lo que creo que ahora soy papicio.");
                    cCDialogue.Add("Vaya suerte tendr� el tapic�n de tener un padre tan realista como yo.");
                    cCDialogue.Add("As� sabr� de inicio lo triste y dura que es la vida, y no le pasar� como a m� al nacer.");
                    cCDialogue.Add("Aunque no s� qu� necesitan comer los tapicines cuando son peque�os, puede que un poco de gravilla le guste.");
                    cCDialogue.Add("Bueno, hablando del peque, tengo que ir a por �l en nada, as� que c�brame.");
                    cCDialogue.Add("Gracias, a ver si estar ahora con hijo me anima m�s.");
                    cCDialogue.Add("Ahora el ni�o me ver� m�s deprimente de siempre.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Detective"))
                {
                    cCDialogue.Add("Traigo muy buenas noticias humano, estamos a nada de cerrar el caso.");
                    cCDialogue.Add("Uno de los sospechosos de ayer confes� que la iglesia le ayud� a revivir a un tal Sergio Nerviosaus.");
                    cCDialogue.Add("Esta noche, haremos una redada en la iglesia para encerrar a los miembros.");
                    cCDialogue.Add("As� que puede que en nada vayamos a cerrar el caso, aunque a�n nos queda una cosa por resolver.");
                    cCDialogue.Add("Qui�n fue la persona que le di� con el orbe al fiambre.");
                    cCDialogue.Add("Tenemos algunos sospechosos, pero creemos que es el l�der principal.");
                    cCDialogue.Add("Hasta el detective Black no sabe qui�n arrestar.");
                    cCDialogue.Add("Dime humano, �qui�n crees qu� es el l�der?");
                    cCDialogue.Add("Muchas gracias por ayudar en el caso, espero que nos volvamos a ver.");
                }
            }

            else if (currentScene.name == "Home")
            {
                if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Tapicio"))
                {
                    cCDialogue.Add("Saludos humano **suspira**");
                    cCDialogue.Add("Tu jefe me dijo que te quedar�as aqu�, qu� lugar m�s triste.");
                    cCDialogue.Add("Por desgracia tendr� que animar este sitio, he tra�do mi juego favorito.");
                    cCDialogue.Add("Parec�as nuevo en el reino y me diste pena al verte **suspira**");
                    cCDialogue.Add("Seguramente m�s clientes como yo puedan traerte cosas si les tratas bien.");
                    cCDialogue.Add("Ya sea cobr�ndoles aunque no debas, o ayud�ndoles con alguna cosa.");
                    cCDialogue.Add("Seguro que con m�s objetos animas este sitio.");
                    cCDialogue.Add("Aunque me gustar�a que quedase m�s triste, como mi propia existencia.");
                    cCDialogue.Add("Te dejo de molestar humano, suerte estos d�as.");
                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bonna noche amigo m�o, espero que descanses bien.");
                    cCDialogue.Add("Pero antes quer�a darte un regalo, mi libro de cocina.");
                    cCDialogue.Add("Bueno, mejor dicho... una copia, ped� que me lo clonaran con magia.");
                    cCDialogue.Add("As� los dos podremos hacer los platos que queramos cada d�a.");
                    cCDialogue.Add("Aunque aqu� no veo ninguna cocina, solo un s�tano sucio...");
                    cCDialogue.Add("Bueno, te las apa�ar�s, ciao amigo m�o.");

                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Elidora"))
                {
                    if (!slimeFostiados)
                    {
                        cCDialogue.Add("Hola s�bdito, estoy haciendo un entrenamiento especial para que los slimes me duren m�s.");
                        cCDialogue.Add("Consiste en acariciarles la cabeza con un martillo, pero no me hace mucha gracia cogerlo yo");
                        cCDialogue.Add("�Que asco agarrar algo �spero con las manos no? Prefiero que lo haga gente como t�");
                        cCDialogue.Add("Bueno, que me enredas, haz eso por mi y quien sabe, puede que alg�n d�a te de algo que se me rompa y ya no pueda usar");
                    }

                    else if (slimeFostiados)
                    {
                        if (slimeFail)

                            if (elidoraAcariciada)
                                cCDialogue.Add("�Casi me abollas el cerebro!�Escucho borroso!�NUNCA TE LO PERDONAR� CARMONA!");

                            else
                                cCDialogue.Add("T�pico de un humano, no s� por qu� te encargu� una tarea tan dif�cil para un cerebro tan diminuto como el tuyo...");
                        else
                            cCDialogue.Add("Menudo aboll�n le has dejado a Mc Moco... No creo que me sirva as�, te lo regalo");
                    }
                }

                else if (homeManager.currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Mano"))
                {
                    cCDialogue.Add("Hola humano, veo que no has contado nada sobre la iglesia a ese detective.");
                    cCDialogue.Add("Has mostrado ser fiel a nuestra causa y a la iglesia.");
                    cCDialogue.Add("Ganaste mi confianza para considerarte uno de nosotros.");
                    cCDialogue.Add("Acepta este anillo como muestra de agradecimiento.");
                    cCDialogue.Add("Nos vivimos por verte estos d�as en la iglesia, ya me entiendes.");
                }
            }
        }
    }

    #endregion
}