using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Data : MonoBehaviour
{
    [SerializeField] public bool spaSpain;
    [SerializeField] public bool engAmerican;
    [SerializeField] public bool spaColombian;

    [SerializeField] public GameObject uIManager;

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

    [SerializeField] public List<string> cCDialogue;


    public static Data instance;

    void Start()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;

        DontDestroyOnLoad(gameObject);
        uIManager = GameObject.FindGameObjectWithTag("UI");
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
                    cCDialogue.Add("Seguro que no serás capaz de atender a los clientes bien.");
                    cCDialogue.Add("Ya sabes que todos los humanos sois inútiles.");
                    cCDialogue.Add("No lo digo yo, lo dice vuestro cerebro enano.");
                    cCDialogue.Add("Pero bueno, como iba diciendo… ¡ATIENDE BIEN!");
                    cCDialogue.Add("No quiero perder dinero contigo.");
                    cCDialogue.Add("Para cobrar dale al botón verde de la CAJA REGISTRADORA");
                    cCDialogue.Add("Y para no cobrar, dale al botón rojo");
                    cCDialogue.Add("Y como cobres mal, te quitaré dinero de tu querido tarro.");
                    cCDialogue.Add("Tienes el catálogo de la tienda para saber si el cliente tiene dinero suficiente.");
                    cCDialogue.Add("Además tendrás una ayuda, la cabeza del antiguo empleado.");
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
                    cCDialogue.Add("¡Cómo que no me conoces! Todos aquí me conocen.");
                    cCDialogue.Add("El héroe de héroes, quien derrotó al Rey Demonio con una sola daga y los ojos vendados.");
                    cCDialogue.Add("Vamos… Todos mis admiradores, es decir, todo el reino, saben que soy el mejor héroe de la historia.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Bueno, me imagino que perdonaré tu desconocimiento y ese silencio incómodo que provocas.");
                    cCDialogue.Add("Cóbrame esto al menos, así esta charla dejará de ser tan incómoda.");

                    cCDialogue.Add("Deberías de leer alguna de mis grandes historias humano, adiós.");
                    cCDialogue.Add("Pero, ¡QUÉ INSOLENCIA ES ESTA! Espero que cuando vuelva aprendas a contar monedas humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Buennnasss *hip* Eeeehhhhh… tuuu no eres el de sieeeembrree…*hip*");
                    cCDialogue.Add(" Bueno, el otro erra un ######");
                    cCDialogue.Add("Ahorra a quién le direee sobre niii despidoooo… Encimaaa eres humanooo…*");
                    cCDialogue.Add("Ne tocarra contarrrrte a tuuu…*hip * ");
                    cCDialogue.Add(" Soy Elvog, er ex ex explorador");
                    cCDialogue.Add("Mooo te looo vasss a creer… el ###### de mi jefeee me despidió *hip*");
                    cCDialogue.Add("Me dijooo que bebía mushoo alcohooool y que estoy viejo, ¿perro quee dise eseee? *hip*");
                    cCDialogue.Add("Siii solo temgo 22 añitos, estoooy em la fror de la hueventud *hip*");
                    cCDialogue.Add("Buemo, che me olvidó *hip*, puedess cobrarme estooo…");

                    cCDialogue.Add("Gracias mushacho *hip* Ahorra serás ni depemdiete favorito *hip*");
                    cCDialogue.Add("Perro mushacho *hip* el otroo depemdiete erra mejor *hip*");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Ey…Hola amigo, soy Antonio…¿Qué tal tu día?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Ya veo…No eres muy hablador eh.");
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
                    cCDialogue.Add("Qué quieres que te diga... soy prisionero de mi propio destino.");
                    cCDialogue.Add("Fui creado para solo trabajar, mis cadenas nunca se romperán.");
                    cCDialogue.Add("A veces deseo seguir siendo ser ese pequeño tapiz colgado en el cementerio de limbásticos.");
                    cCDialogue.Add("Pero por desgracia, mi vida es como una canción emo: Larga, triste y nunca termina.");
                    cCDialogue.Add("Al igual que esta conversación... perdona por hacerte perder el tiempo.");
                    cCDialogue.Add("Deberías de cobrarme ya, o si no llegaré tarde a mi torneo de Lanzamiento de miradas melancólicas.");

                    cCDialogue.Add("Gracias, espero que no quedar en primer lugar, como siempre.");
                    cCDialogue.Add("Otra desgracia más para mi vida, ahora seguro gano el torneo por tu culpa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Buenas joven, no me creo que ahora solo sea un recadero…");
                    cCDialogue.Add("Perdón, el jefe me está poniendo la cabeza como un horno.");
                    cCDialogue.Add("Soy Denjirenji.");
                    cCDialogue.Add("He estado 10 años aprendiendo técnicas samurai infalibles y fuí el mejor de la promoción.");
                    cCDialogue.Add("Incluso salvé el mundo junto a cuatro tortugas, y ahora…");
                    cCDialogue.Add("Solo sirvo para calentar su maldita comida, y encima la tengo que comprar yo.");
                    cCDialogue.Add("Perdí todo honor como samurai.");
                    cCDialogue.Add("Al final, acabaré haciéndome el harakiri con cucharas.");
                    cCDialogue.Add("Disculpa que te haya robado un poco de tu tiempo, cóbrame esto por favor.");

                    cCDialogue.Add("Menos mal que tenía el dinero justo... o eso creo.");
                    cCDialogue.Add("¡Por una moneda! Discúlpame... espero que el jefe no me mate.");
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
                    cCDialogue.Add("Espero no molestar, y perdona mi tar-tartamudez.");
                    cCDialogue.Add("En fin, perdona otra vez. No me disculparé más, per-per-perdona.");
                    cCDialogue.Add("Estoy intentando me-mejorar, como buen Rockon que soy.");
                    cCDialogue.Add("Debo mejorar, como papá que es muy fuerte.");
                    cCDialogue.Add("Siempre me ha querido mu-mu-mucho.");
                    cCDialogue.Add("Mi co-comida favorita es la gravilla que me hacía.");
                    cCDialogue.Add("Además si le echabas cemento por encima, ya quedaba bueníiiiiisimo.");
                    cCDialogue.Add("Bu-bu-bueno en fin… ¿Me puedes cobrar esto?");
                    cCDialogue.Add("Es que le quiero dar una sorpresa a papi, seguro que este gato mu-muerto le hace mucha ilusión.");

                    cCDialogue.Add("Gra-gra-gracias seguro que mi papaito se pone feliz");
                    cCDialogue.Add("Jopetas… Con la ilusión que me hacía regalarles esto a mis papis…");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefazo"))
                {
                    cCDialogue.Add("Seguro que fue muy agotador. pero mejor me lo comentas mañana.");
                    cCDialogue.Add("Y un pajarito llamado Inspector de Empleo me ha dicho que no tienes casa.");
                    cCDialogue.Add("Menos mal que tienes un jefe tan generoso y rico, así que te prestaré una de las mejores viviendas del reino.");
                    cCDialogue.Add("Ese maravilloso lugar se llama: El sótano de mi madre.");
                    cCDialogue.Add("Espero que te guste.");
                }
            }
        }
    }

    #endregion
}
