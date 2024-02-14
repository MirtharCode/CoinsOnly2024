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
                    cCDialogue.Add("Seguro que no ser�s capaz de atender a los clientes bien.");
                    cCDialogue.Add("Ya sabes que todos los humanos sois in�tiles.");
                    cCDialogue.Add("No lo digo yo, lo dice vuestro cerebro enano.");
                    cCDialogue.Add("Pero bueno, como iba diciendo� �ATIENDE BIEN!");
                    cCDialogue.Add("No quiero perder dinero contigo.");
                    cCDialogue.Add("Para cobrar dale al bot�n verde de la CAJA REGISTRADORA");
                    cCDialogue.Add("Y para no cobrar, dale al bot�n rojo");
                    cCDialogue.Add("Y como cobres mal, te quitar� dinero de tu querido tarro.");
                    cCDialogue.Add("Tienes el cat�logo de la tienda para saber si el cliente tiene dinero suficiente.");
                    cCDialogue.Add("Adem�s tendr�s una ayuda, la cabeza del antiguo empleado.");
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
                    cCDialogue.Add("�C�mo que no me conoces! Todos aqu� me conocen.");
                    cCDialogue.Add("El h�roe de h�roes, quien derrot� al Rey Demonio con una sola daga y los ojos vendados.");
                    cCDialogue.Add("Vamos� Todos mis admiradores, es decir, todo el reino, saben que soy el mejor h�roe de la historia.");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Bueno, me imagino que perdonar� tu desconocimiento y ese silencio inc�modo que provocas.");
                    cCDialogue.Add("C�brame esto al menos, as� esta charla dejar� de ser tan inc�moda.");

                    cCDialogue.Add("Deber�as de leer alguna de mis grandes historias humano, adi�s.");
                    cCDialogue.Add("Pero, �QU� INSOLENCIA ES ESTA! Espero que cuando vuelva aprendas a contar monedas humano.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Sapo"))
                {
                    cCDialogue.Add("Buennnasss *hip* Eeeehhhhh� tuuu no eres el de sieeeembrree�*hip*");
                    cCDialogue.Add(" Bueno, el otro erra un ######");
                    cCDialogue.Add("Ahorra a qui�n le direee sobre niii despidoooo� Encimaaa eres humanooo�*");
                    cCDialogue.Add("Ne tocarra contarrrrte a tuuu�*hip * ");
                    cCDialogue.Add(" Soy Elvog, er ex ex explorador");
                    cCDialogue.Add("Mooo te looo vasss a creer� el ###### de mi jefeee me despidi� *hip*");
                    cCDialogue.Add("Me dijooo que beb�a mushoo alcohooool y que estoy viejo, �perro quee dise eseee? *hip*");
                    cCDialogue.Add("Siii solo temgo 22 a�itos, estoooy em la fror de la hueventud *hip*");
                    cCDialogue.Add("Buemo, che me olvid� *hip*, puedess cobrarme estooo�");

                    cCDialogue.Add("Gracias mushacho *hip* Ahorra ser�s ni depemdiete favorito *hip*");
                    cCDialogue.Add("Perro mushacho *hip* el otroo depemdiete erra mejor *hip*");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Antonio"))
                {
                    cCDialogue.Add("Ey�Hola amigo, soy Antonio��Qu� tal tu d�a?");
                    cCDialogue.Add("...");
                    cCDialogue.Add("Ya veo�No eres muy hablador eh.");
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
                    cCDialogue.Add("Qu� quieres que te diga... soy prisionero de mi propio destino.");
                    cCDialogue.Add("Fui creado para solo trabajar, mis cadenas nunca se romper�n.");
                    cCDialogue.Add("A veces deseo seguir siendo ser ese peque�o tapiz colgado en el cementerio de limb�sticos.");
                    cCDialogue.Add("Pero por desgracia, mi vida es como una canci�n emo: Larga, triste y nunca termina.");
                    cCDialogue.Add("Al igual que esta conversaci�n... perdona por hacerte perder el tiempo.");
                    cCDialogue.Add("Deber�as de cobrarme ya, o si no llegar� tarde a mi torneo de Lanzamiento de miradas melanc�licas.");

                    cCDialogue.Add("Gracias, espero que no quedar en primer lugar, como siempre.");
                    cCDialogue.Add("Otra desgracia m�s para mi vida, ahora seguro gano el torneo por tu culpa.");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Denji"))
                {
                    cCDialogue.Add("Buenas joven, no me creo que ahora solo sea un recadero�");
                    cCDialogue.Add("Perd�n, el jefe me est� poniendo la cabeza como un horno.");
                    cCDialogue.Add("Soy Denjirenji.");
                    cCDialogue.Add("He estado 10 a�os aprendiendo t�cnicas samurai infalibles y fu� el mejor de la promoci�n.");
                    cCDialogue.Add("Incluso salv� el mundo junto a cuatro tortugas, y ahora�");
                    cCDialogue.Add("Solo sirvo para calentar su maldita comida, y encima la tengo que comprar yo.");
                    cCDialogue.Add("Perd� todo honor como samurai.");
                    cCDialogue.Add("Al final, acabar� haci�ndome el harakiri con cucharas.");
                    cCDialogue.Add("Disculpa que te haya robado un poco de tu tiempo, c�brame esto por favor.");

                    cCDialogue.Add("Menos mal que ten�a el dinero justo... o eso creo.");
                    cCDialogue.Add("�Por una moneda! Disc�lpame... espero que el jefe no me mate.");
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
                    cCDialogue.Add("Espero no molestar, y perdona mi tar-tartamudez.");
                    cCDialogue.Add("En fin, perdona otra vez. No me disculpar� m�s, per-per-perdona.");
                    cCDialogue.Add("Estoy intentando me-mejorar, como buen Rockon que soy.");
                    cCDialogue.Add("Debo mejorar, como pap� que es muy fuerte.");
                    cCDialogue.Add("Siempre me ha querido mu-mu-mucho.");
                    cCDialogue.Add("Mi co-comida favorita es la gravilla que me hac�a.");
                    cCDialogue.Add("Adem�s si le echabas cemento por encima, ya quedaba buen�iiiiisimo.");
                    cCDialogue.Add("Bu-bu-bueno en fin� �Me puedes cobrar esto?");
                    cCDialogue.Add("Es que le quiero dar una sorpresa a papi, seguro que este gato mu-muerto le hace mucha ilusi�n.");

                    cCDialogue.Add("Gra-gra-gracias seguro que mi papaito se pone feliz");
                    cCDialogue.Add("Jopetas� Con la ilusi�n que me hac�a regalarles esto a mis papis�");
                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefazo"))
                {
                    cCDialogue.Add("Seguro que fue muy agotador. pero mejor me lo comentas ma�ana.");
                    cCDialogue.Add("Y un pajarito llamado Inspector de Empleo me ha dicho que no tienes casa.");
                    cCDialogue.Add("Menos mal que tienes un jefe tan generoso y rico, as� que te prestar� una de las mejores viviendas del reino.");
                    cCDialogue.Add("Ese maravilloso lugar se llama: El s�tano de mi madre.");
                    cCDialogue.Add("Espero que te guste.");
                }
            }

            if (currentScene.name == "Day2")
            {
                if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Jefe"))
                {
                    cCDialogue.Add("Buenos d�as chico nuevo, soy el jefe.");
                    cCDialogue.Add("�Qu� tal tu primer d�a?");
                    cCDialogue.Add("Nah, es broma, realmente me da igual como te fuera tu primer d�a.");
                    cCDialogue.Add("Seguro te lo dije en el tutorial, pero seguro no te acuerdas por tu cerebro enano.");
                    cCDialogue.Add("Tenemos unas normas que seguir en la tienda.");
                    cCDialogue.Add("Y hoy es �Magic Friday�, aunque lo seguir� siendo el resto del a�o, como todos los a�os...");
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
                    cCDialogue.Add("Ayer vino aqu� ese microondas");
                    cCDialogue.Add("Y ese cacharro debi� darte una moneda m�s");
                    cCDialogue.Add("Al menos ahora puedo justificar su despido");
                    cCDialogue.Add("Aunque el bobo se puso a decir cosas de hacer el harakiri o cosas as�.");
                    cCDialogue.Add("En fin, malditas m�quinas japonesas.");
                    cCDialogue.Add("Ya que est�s, cobrame esto, que debo seguir con mi trabajo de blanqueamiento de dinero.");

                    cCDialogue.Add("Adi�s");
                    cCDialogue.Add("Ni contar sabes, �de verdad? Acabas de perder todos los clientes de Lemuria, \n y espero que pronto pierdas el trabajo.");

                }

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Giovanni"))
                {
                    cCDialogue.Add("Bon d�a amigo m�o, espero que te est� yendo bien estos d�as.");
                    cCDialogue.Add("A m� el �ltimo plato del otro d�a no sali� como me esperaba la verdad� Me sali�... �PERFECTO! ");
                    cCDialogue.Add("Me sali�... �PERFECTO! ");
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
                    cCDialogue.Add("�Hola peque��n! No te hab�a visto desde ah� abajo.");
                    cCDialogue.Add("Soy el grandioso Manolo Cabeza de Pico, el mago m�s rico�Del barrio m�s alto del reino.");
                    cCDialogue.Add("Me sobra el dinero, para nada entr� aqu� por el 50% de descuento en magos.");
                    cCDialogue.Add("O incluso podr�a ser un 70% ahora que somos amigos.");
                    cCDialogue.Add(" Vale vale, no me mires con esa cara impasible, pero venga�");
                    cCDialogue.Add("Te prometo que te devolver� ese 20%, siempre pago mis deudas.");
                    cCDialogue.Add("Por ejemplo, mi vecino a�n me dice que le debo 2000 monedas y que deje de evitarlo.");
                    cCDialogue.Add("Pero, por favor, yo no lo evito por la deuda, lo evito para ahorrarme esas 2000 monedas.");
                    cCDialogue.Add("Creo que no deb� decir eso�Bueno, mejor ve cobrando antes de que la li� m�s.");

                    cCDialogue.Add("Menos mal me he ahorrado esas monedas, as� podr� mantener mi enorme mansi�n durante 1 hora m�s.");
                    cCDialogue.Add("�No tengo dinero ni con el 50% de rebaja? Me va a tocar embargar la casa.");
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

                else if (uIManager.GetComponent<UIManager>().currentCustomer.name.Contains("Handy"))
                {
                    cCDialogue.Add("�Hola colega! �C�mo te encuentras? �Bien? �Mal?");
                    cCDialogue.Add("�YO ESTOY FENOMENAL!");
                    cCDialogue.Add("Soy Handy, el elemental m�s fiestero, que ama cualquier celebraci�n.");
                    cCDialogue.Add("Cumplea�os, bodas, despedidas de solteros y� �FUNERALES!");
                    cCDialogue.Add("Aunque del �ltimo funeral me echaron por alguna extra�a raz�n...");
                    cCDialogue.Add("Estoy tan emocionado amigo m�o, tengo una nueva compa�era.");
                    cCDialogue.Add("Se llama Rave-n, incluso estudi� fiestolog�a.");
                    cCDialogue.Add("Aunque me expulsaron del grado de fiestolog�a por mi TFG sobre� �ALEGRAR FUNERALES!");
                    cCDialogue.Add("Se debieron morir de la risa con mi TFG.");
                    cCDialogue.Add("Bueno colega, s� que est�s pasando un buen rato conmigo.");
                    cCDialogue.Add("Pero tengo una despedida de soltero y tengo que aguantar toda la noche despierto.");
                    cCDialogue.Add("Y necesito estos utensilios para sobrevivir a los solteros desesperados.");
                    cCDialogue.Add("Aunque no s� para qu� ser� la bola, me la pidieron los solteros");
                    cCDialogue.Add("Bueno, c�brame porfi porfita.");

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
                    cCDialogue.Add("�C�mo que no sirve la oferta! Pues... Pues� Bonita moneda, me la quedo.");
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
        }
    }

    #endregion
}
