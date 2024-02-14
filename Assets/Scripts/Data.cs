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

            if (currentScene.name == "Day2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenos días chico nuevo, soy el jefe.");
                    cCDialogue.Add("¿Qué tal tu primer día?");
                    cCDialogue.Add("Nah, es broma, realmente me da igual como te fuera tu primer día.");
                    cCDialogue.Add("Seguro te lo dije en el tutorial, pero seguro no te acuerdas por tu cerebro enano.");
                    cCDialogue.Add("Tenemos unas normas que seguir en la tienda.");
                    cCDialogue.Add("Y hoy es “Magic Friday”, aunque lo seguirá siendo el resto del año, como todos los años...");
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
                    cCDialogue.Add("Ayer vino aquí ese microondas");
                    cCDialogue.Add("Y ese cacharro debió darte una moneda más");
                    cCDialogue.Add("Al menos ahora puedo justificar su despido");
                    cCDialogue.Add("Aunque el bobo se puso a decir cosas de hacer el harakiri o cosas así.");
                    cCDialogue.Add("En fin, malditas máquinas japonesas.");
                    cCDialogue.Add("Ya que estás, cobrame esto, que debo seguir con mi trabajo de blanqueamiento de dinero.");

                    cCDialogue.Add("Adiós");
                    cCDialogue.Add("Ni contar sabes, ¿de verdad? Acabas de perder todos los clientes de Lemuria, \n y espero que pronto pierdas el trabajo.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bon día amigo mío, espero que te esté yendo bien estos días.");
                    cCDialogue.Add("A mí el último plato del otro día no salió como me esperaba la verdad… Me salió... ¡PERFECTO! ");
                    cCDialogue.Add("Me salió... ¡PERFECTO! ");
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
                    cCDialogue.Add("¡Hola pequeñín! No te había visto desde ahí abajo.");
                    cCDialogue.Add("Soy el grandioso Manolo Cabeza de Pico, el mago más rico…Del barrio más alto del reino.");
                    cCDialogue.Add("Me sobra el dinero, para nada entré aquí por el 50% de descuento en magos.");
                    cCDialogue.Add("O incluso podría ser un 70% ahora que somos amigos.");
                    cCDialogue.Add(" Vale vale, no me mires con esa cara impasible, pero venga…");
                    cCDialogue.Add("Te prometo que te devolveré ese 20%, siempre pago mis deudas.");
                    cCDialogue.Add("Por ejemplo, mi vecino aún me dice que le debo 2000 monedas y que deje de evitarlo.");
                    cCDialogue.Add("Pero, por favor, yo no lo evito por la deuda, lo evito para ahorrarme esas 2000 monedas.");
                    cCDialogue.Add("Creo que no debí decir eso…Bueno, mejor ve cobrando antes de que la lié más.");

                    cCDialogue.Add("Menos mal me he ahorrado esas monedas, así podré mantener mi enorme mansión durante 1 hora más.");
                    cCDialogue.Add("¿No tengo dinero ni con el 50% de rebaja? Me va a tocar embargar la casa.");
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

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("¡Hola colega! ¿Cómo te encuentras? ¿Bien? ¿Mal?");
                    cCDialogue.Add("¡YO ESTOY FENOMENAL!");
                    cCDialogue.Add("Soy Handy, el elemental más fiestero, que ama cualquier celebración.");
                    cCDialogue.Add("Cumpleaños, bodas, despedidas de solteros y… ¡FUNERALES!");
                    cCDialogue.Add("Aunque del último funeral me echaron por alguna extraña razón...");
                    cCDialogue.Add("Estoy tan emocionado amigo mío, tengo una nueva compañera.");
                    cCDialogue.Add("Se llama Rave-n, incluso estudió fiestología.");
                    cCDialogue.Add("Aunque me expulsaron del grado de fiestología por mi TFG sobre… ¡ALEGRAR FUNERALES!");
                    cCDialogue.Add("Se debieron morir de la risa con mi TFG.");
                    cCDialogue.Add("Bueno colega, sé que estás pasando un buen rato conmigo.");
                    cCDialogue.Add("Pero tengo una despedida de soltero y tengo que aguantar toda la noche despierto.");
                    cCDialogue.Add("Y necesito estos utensilios para sobrevivir a los solteros desesperados.");
                    cCDialogue.Add("Aunque no sé para qué será la bola, me la pidieron los solteros");
                    cCDialogue.Add("Bueno, cóbrame porfi porfita.");

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
                    cCDialogue.Add("¡Cómo que no sirve la oferta! Pues... Pues… Bonita moneda, me la quedo.");
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
        }
    }

    #endregion
}
