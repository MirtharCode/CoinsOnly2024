using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Video;

public class HomeManager : MonoBehaviour
{
    public GameObject currentHomeClientPrefab;
    public GameObject currentHomeClientReal;
    public Transform startingPoint;
    [SerializeField] public GameObject transicionesGameobject;
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public TMP_Text dialogueText;
    [SerializeField] public Image dialogueMiniImage;
    [SerializeField] public GameObject data;
    [SerializeField] public bool conversationOn;
    [SerializeField] public TMP_Text traductorText;
    [SerializeField] public TMP_Text humanText;
    [SerializeField] public TMP_Text NombreText;
    [SerializeField] public int dialogueSize;
    [SerializeField] public int internalCount;
    [SerializeField] public AudioSource doorSound;
    [SerializeField] public AudioClip openDoorSound;
    [SerializeField] public AudioClip closeDoorSound;
    [SerializeField] public GameObject videoplayer;
    [SerializeField] public GameObject pantalla;
    [SerializeField] public VideoClip video;
    [SerializeField] public GameObject fTBObject;
    [SerializeField] public GameObject lampSwitch;



    [SerializeField] public AnimationClip clientGoingOutClip;
    [SerializeField] public GameObject musicBox;

    [Header("SPRITES CLIENTES")]
    [SerializeField] public Sprite evilWizardGerard;
    [SerializeField] public Sprite hybridElvog;
    [SerializeField] public Sprite hybridElvogALT;
    [SerializeField] public Sprite limbasticAntonio;
    [SerializeField] public Sprite limbasticAntonioALT;
    [SerializeField] public Sprite elementalTapicio;
    [SerializeField] public Sprite electropedDenjirenji;
    [SerializeField] public Sprite electropedDenjirenjiALT;
    [SerializeField] public Sprite hybridMara;
    [SerializeField] public Sprite limbasticGiovanni;
    [SerializeField] public Sprite elementalRockon;
    [SerializeField] public Sprite hybridLepion;
    [SerializeField] public Sprite evilWizardManoloEnano;
    [SerializeField] public Sprite limbasticCululu;
    [SerializeField] public Sprite elementalHandy;
    [SerializeField] public Sprite hybridPetra;
    [SerializeField] public Sprite hybridPetraALT;
    [SerializeField] public Sprite electropedMasermati;
    [SerializeField] public Sprite evilWizardPijus;
    [SerializeField] public Sprite limbasticSergio;
    [SerializeField] public Sprite limbasticSergioALT;
    [SerializeField] public Sprite hybridSaltaralisis;
    [SerializeField] public Sprite evilWizardManoloMano;
    [SerializeField] public Sprite evilWizardManoloManoALT;
    [SerializeField] public Sprite electropedRaven;
    [SerializeField] public Sprite elementalHueso;
    [SerializeField] public Sprite limbasticPatxi;
    [SerializeField] public Sprite electropedRustica;
    [SerializeField] public Sprite elementalJissy;
    [SerializeField] public Sprite evilWizardElidora;
    [SerializeField] public Sprite evilWizardElidoraALT;
    [SerializeField] public Sprite electropedMagmaDora;
    [SerializeField] public Sprite elJefe;
    [SerializeField] public Sprite elDetective;

    [Header("MINIIMAGES")]
    [SerializeField] public Sprite miniClientImage;
    [SerializeField] public Sprite miniEvilWizardGerard;
    [SerializeField] public Sprite miniHybridElvog;
    [SerializeField] public Sprite miniLimbasticAntonio;
    [SerializeField] public Sprite miniElementalTapicio;
    [SerializeField] public Sprite miniElectropedDenjirenji;
    [SerializeField] public Sprite miniHybridMara;
    [SerializeField] public Sprite miniLimbasticGiovanni;
    [SerializeField] public Sprite miniElementalRockon;
    [SerializeField] public Sprite miniHybridLepion;
    [SerializeField] public Sprite miniEvilWizardManolo;
    [SerializeField] public Sprite miniLimbasticCululu;
    [SerializeField] public Sprite miniElementalHandy;
    [SerializeField] public Sprite miniHybridPetra;
    [SerializeField] public Sprite miniElectropedMasermati;
    [SerializeField] public Sprite miniEvilWizardPijus;
    [SerializeField] public Sprite miniLimbasticSergio;
    [SerializeField] public Sprite miniHybridSaltaralisis;
    [SerializeField] public Sprite miniEvilWizardManoloMano;
    [SerializeField] public Sprite miniElectropedRaven;
    [SerializeField] public Sprite miniElementalHueso;
    [SerializeField] public Sprite miniLimbasticPatxi;
    [SerializeField] public Sprite miniElectropedRustica;
    [SerializeField] public Sprite miniElementalJissy;
    [SerializeField] public Sprite miniEvilWizardElidora;
    [SerializeField] public Sprite miniElectropedMagmaDora;
    [SerializeField] public Sprite miniElJefe;
    [SerializeField] public Sprite miniElDetective;

    [Header("TROPHIES")]
    [SerializeField] public GameObject trophyUI;
    [SerializeField] public Animator showTrophyAnim;
    [SerializeField] public Sprite giftImageGeeraard;    // Si nerviosusPagaLoQueDebe es falso, Geerard te dará la foto firmada
    [SerializeField] public Sprite giftImageEnano;       // Te da un Enano. Si en el día 2 o 3 encuentras al enano zumbón.
    [SerializeField] public Sprite giftImageMano;        // Te da un anillo.
    [SerializeField] public Sprite giftImageElidora;     // Si completas su minijuego te pasa un moco.
    //[SerializeField] public Sprite giftImagePijus;
    [SerializeField] public Sprite giftImageElvog;       // Te da una botella con flores.
    //[SerializeField] public Sprite giftImageLepion;
    [SerializeField] public Sprite giftImageMara;        // Te da la pierna de su marido.
    [SerializeField] public Sprite giftImagePetra;       // Te da un mapa.
    //[SerializeField] public Sprite giftImageSaltaralis;
    [SerializeField] public Sprite giftImageAntonio;     // Te da sus gafas.
    [SerializeField] public Sprite giftImageGiovanni;    // Te da su "libro de cocina".
    [SerializeField] public Sprite giftImageCululu;      // Te da la foto de Mara.
    [SerializeField] public Sprite giftImageSergio;      // Si nerviosusPagaLoQueDebe es verdadero, te da su Globo-Espada.
    //[SerializeField] public Sprite giftImagePatxi;
    [SerializeField] public Sprite giftImageTapicio;     // Te da el puto GOTY.
    //[SerializeField] public Sprite giftImageRockon;
    [SerializeField] public Sprite giftImageHandy;       // Te da un disfraz de payaso.
    //[SerializeField] public Sprite giftImageJissy;
    //[SerializeField] public Sprite giftImageHueso;
    [SerializeField] public Sprite giftImageDenjirenji;  // Si completas su minijuego te da su espada.
    //[SerializeField] public Sprite giftImageMagmadora;
    //[SerializeField] public Sprite giftImageMasermati;
    [SerializeField] public Sprite giftImageRaven;       // Si completas su minijuego te da un disco.
    //[SerializeField] public Sprite giftImageRustica; 

    // Start is called before the first frame update
    private void Awake()
    {
        //SomeoneIsKnocking();
        data = GameObject.FindGameObjectWithTag("Data");
        data.GetComponent<Data>().homeManager = gameObject.GetComponent<HomeManager>();
    }

    void Start()
    {
        musicBox.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
        musicBox.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
        musicBox.transform.GetChild(2).GetComponent<AudioSource>().mute = true;
        musicBox.transform.GetChild(3).GetComponent<AudioSource>().mute = true;
        lampSwitch.GetComponent<Button>().enabled = false;

        if (data.GetComponent<Data>().videoActivo)
        {
            musicBox.GetComponent<AudioSource>().mute = true;
            fTBObject.GetComponent<Image>().enabled = false;

            videoplayer.SetActive(true);
            pantalla.SetActive(true);
        }
        DialogueManager.Instance.postPro.gameObject.SetActive(true);
        DialogueManager.Instance.BackToTheDefaultSaturation();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SomeoneIsKnocking()
    {
        data.GetComponent<Data>().sePueTocar = true;

        if (!data.GetComponent<Data>().yaSeFueCliente && !data.GetComponent<Data>().videoActivo)
        {
            if (Data.instance.day01Checked)
            {
                data.GetComponent<Data>().sePueTocar = false;
                doorSound.PlayOneShot(openDoorSound);
                GameObject clon = Instantiate(currentHomeClientPrefab, startingPoint);
                clon.GetComponent<Image>().sprite = elJefe;
                clon.AddComponent<HU_Jefe>();
                miniClientImage = miniElJefe;
                currentHomeClientReal = startingPoint.GetChild(0).gameObject;
                dialogueSize = data.GetComponent<Data>().cCDialogue.Count;
            }

            if (Data.instance.day02Checked && !Data.instance.giftTapicio)
            {
                data.GetComponent<Data>().sePueTocar = false;
                doorSound.PlayOneShot(openDoorSound);
                GameObject clon = Instantiate(currentHomeClientPrefab, startingPoint);
                clon.GetComponent<Image>().sprite = elementalTapicio;
                clon.AddComponent<HE_Tapicio>();
                miniClientImage = miniElementalTapicio;
                currentHomeClientReal = startingPoint.GetChild(0).gameObject;
                dialogueSize = data.GetComponent<Data>().cCDialogue.Count;
            }

            else if (Data.instance.day03Checked && Data.instance.vecesCobradoGiovanni == 2 && !Data.instance.giftGiovanni)
            {
                data.GetComponent<Data>().sePueTocar = false;
                doorSound.PlayOneShot(openDoorSound);
                GameObject clon = Instantiate(currentHomeClientPrefab, startingPoint);
                clon.GetComponent<Image>().sprite = limbasticGiovanni;
                clon.AddComponent<HL_Giovanni>();
                miniClientImage = miniLimbasticGiovanni;
                currentHomeClientReal = startingPoint.GetChild(0).gameObject;
                dialogueSize = data.GetComponent<Data>().cCDialogue.Count;
            }

            else if (Data.instance.day07Checked && Data.instance.detectivePoints == 0 && !Data.instance.giftMano)
            {
                data.GetComponent<Data>().sePueTocar = false;
                doorSound.PlayOneShot(openDoorSound);
                GameObject clon = Instantiate(currentHomeClientPrefab, startingPoint);
                clon.GetComponent<Image>().sprite = evilWizardManoloMano;
                clon.AddComponent<HEW_Manolo>();
                miniClientImage = miniEvilWizardManoloMano;
                currentHomeClientReal = startingPoint.GetChild(0).gameObject;
                dialogueSize = data.GetComponent<Data>().cCDialogue.Count;
            }

            else if (Data.instance.demoSteamDay1Checked)
            {
                data.GetComponent<Data>().sePueTocar = false;
                doorSound.PlayOneShot(openDoorSound);
                GameObject clon = Instantiate(currentHomeClientPrefab, startingPoint);
                clon.GetComponent<Image>().sprite = elJefe;
                clon.AddComponent<HU_Jefe>();
                miniClientImage = miniElJefe;
                currentHomeClientReal = startingPoint.GetChild(0).gameObject;
                dialogueSize = data.GetComponent<Data>().cCDialogue.Count;
            }

            else if (Data.instance.demoSteamDay2Checked)
            {
                data.GetComponent<Data>().sePueTocar = false;
                doorSound.PlayOneShot(openDoorSound);
                GameObject clon = Instantiate(currentHomeClientPrefab, startingPoint);
                clon.GetComponent<Image>().sprite = elJefe;
                clon.AddComponent<HU_Jefe>();
                miniClientImage = miniElJefe;
                currentHomeClientReal = startingPoint.GetChild(0).gameObject;
                dialogueSize = data.GetComponent<Data>().cCDialogue.Count;
            }
        }
    }

    public void ShowingText()
    {
        conversationOn = true;
        traductorText.text = currentHomeClientReal.GetComponent<HomeClient>().raza;
        NombreText.text = currentHomeClientReal.GetComponent<HomeClient>().nombre;
        dialogueText.text = currentHomeClientReal.GetComponent<HomeClient>().dialogue[internalCount];
        dialogueMiniImage.sprite = miniClientImage;
    }

    public void ChangingText()
    {
        if (internalCount < dialogueSize)
        {
            dialogueText.text = currentHomeClientReal.GetComponent<HomeClient>().dialogue[internalCount];

            //gameManager.GetComponent<GameManager>().SoundCreator(dialogueText.text);
            //currentHomeClient.GetComponent<HomeClient>().Speaking();
            internalCount++;
        }

        else
            CloseText();
    }

    public void CloseText()
    {
        conversationOn = false;
        dialoguePanel.gameObject.SetActive(false);
        currentHomeClientReal.GetComponent<Animator>().Play("GoingOut");

        if (currentHomeClientReal.name.Contains("jefe"))
        {
            data.GetComponent<Data>().sePueTocar = true;
            data.GetComponent<Data>().yaSeFueCliente = true;
        }

        else if (currentHomeClientReal.name.Contains("Tapicio") && !Data.instance.giftTapicio)
        {
            Data.instance.giftTapicio = true;
            TrophyAchieved("Tapicio");
            data.GetComponent<Data>().sePueTocar = true;
            data.GetComponent<Data>().yaSeFueCliente = true;
        }

        else if (currentHomeClientReal.name.Contains("Giovanni") && !Data.instance.giftGiovanni)
        {
            Data.instance.giftGiovanni = true;
            TrophyAchieved("Giovanni");
            data.GetComponent<Data>().sePueTocar = true;
            data.GetComponent<Data>().yaSeFueCliente = true;
        }

        else if (currentHomeClientReal.name.Contains("Mano") && !Data.instance.giftMano)
        {
            Data.instance.giftMano = true;
            GameObject.FindGameObjectWithTag("HomeClient").GetComponent<Image>().sprite = evilWizardManoloManoALT;
            TrophyAchieved("Mano");
            data.GetComponent<Data>().sePueTocar = true;
            data.GetComponent<Data>().yaSeFueCliente = true;
        }

        lampSwitch.GetComponent<Button>().enabled = true;

    }

    public void TrophyAchieved(string trophyName)
    {
        if(DialogueManager.Instance.currentLanguage == Language.ES)
        {
            if (trophyName == "Giovanni")
            {
                trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageGiovanni;
                trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡The Necronomicook \nUnlocked!";
            }

            else if (trophyName == "Mano")
            {
                trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageMano;
                trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡El sellaso \nDesbloqueado!";
            }
            else if (trophyName == "Tapicio")
            {
                trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageTapicio;
                trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡El GOTY \nDesbloqueado!";
            }
        }

        if (DialogueManager.Instance.currentLanguage == Language.EN)
        {
            if (trophyName == "Giovanni")
            {
                trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageGiovanni;
                trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "The Necronomicook \nUnlocked!";
            }

            else if (trophyName == "Mano")
            {
                trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageMano;
                trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "The Ring \nUnlocked!";
            }
            else if (trophyName == "Tapicio")
            {
                trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageTapicio;
                trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "GOTY \nUnlocked!";
            }
        }

        showTrophyAnim.SetTrigger("TrophyShow");
    }

    public void SettingHomeDialogues()
    {
        Data.instance.cCDialogue.Clear();

        if (DialogueManager.Instance.currentLanguage == Language.ES)
        {
            humanText.text = "Humano";

            if (currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("jefe"))
            {
                Data.instance.cCDialogue.Add("¿Increíble verdad? Mi madre tiene un estilo bastante propio.");
                Data.instance.cCDialogue.Add("Probablemente te estarás preguntando que por qué todo tan 2D ¿No?");
                Data.instance.cCDialogue.Add("¡PUES NO PREGUNTES TANTO!");
                Data.instance.cCDialogue.Add("Da gracias que tenía este traductor antiguo y obsoleto por aquí tirado.");
                Data.instance.cCDialogue.Add("Bueno, escoge la esquina de suelo más cómoda y...");
                Data.instance.cCDialogue.Add("La verdad es que no sé como dormís los humanos, tampoco me interesa.");
                Data.instance.cCDialogue.Add("Cuando acabes el ritual que sea que tenga tu especie, apaga la luz.");
                Data.instance.cCDialogue.Add("Nos vemos mañana ¡NO LLEGUES TARDE!.");
            }

            else if (currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Tapicio"))
            {
                Data.instance.cCDialogue.Add("Saludos humano **suspira**");
                Data.instance.cCDialogue.Add("Tu jefe me dijo que te quedarías aquí, qué lugar más triste.");
                Data.instance.cCDialogue.Add("Por desgracia tendré que animar este sitio, he traído mi juego favorito.");
                Data.instance.cCDialogue.Add("Parecías nuevo en el reino y me diste pena al verte **suspira**");
                Data.instance.cCDialogue.Add("Seguramente más clientes como yo puedan traerte cosas si les tratas bien.");
                Data.instance.cCDialogue.Add("Ya sea cobrándoles aunque no debas, o ayudándoles con alguna cosa.");
                Data.instance.cCDialogue.Add("Seguro que con más objetos animas este sitio.");
                Data.instance.cCDialogue.Add("Aunque me gustaría que quedase más triste, como mi propia existencia.");
                Data.instance.cCDialogue.Add("Te dejo de molestar humano, suerte estos días.");
            }

            else if (currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Giovanni"))
            {
                Data.instance.cCDialogue.Add("Bonna noche amigo mío, espero que descanses bien.");
                Data.instance.cCDialogue.Add("Pero antes quería darte un regalo, mi libro de cocina.");
                Data.instance.cCDialogue.Add("Bueno, mejor dicho... una copia, pedí que me lo clonaran con magia.");
                Data.instance.cCDialogue.Add("Así los dos podremos hacer los platos que queramos cada día.");
                Data.instance.cCDialogue.Add("Aunque aquí no veo ninguna cocina, solo un sótano sucio...");
                Data.instance.cCDialogue.Add("Bueno, te las apañarás, ciao amigo mío.");

            }

            else if (currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Mano"))
            {
                Data.instance.cCDialogue.Add("Hola humano, veo que no has contado nada sobre la iglesia a ese detective.");
                Data.instance.cCDialogue.Add("Has mostrado ser fiel a nuestra causa y a la iglesia.");
                Data.instance.cCDialogue.Add("Ganaste mi confianza para considerarte uno de nosotros.");
                Data.instance.cCDialogue.Add("Acepta este anillo como muestra de agradecimiento.");
                Data.instance.cCDialogue.Add("Nos vivimos por verte estos días en la iglesia, ya me entiendes.");
            }
        }

        else if (DialogueManager.Instance.currentLanguage == Language.EN)
        {
            humanText.text = "Human";

            if (currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("jefe"))
            {
                Data.instance.cCDialogue.Add("Amazing, right? My mother’s got quite a unique style.");
                Data.instance.cCDialogue.Add("You’re probably wondering why everything looks so 2D, huh?");
                Data.instance.cCDialogue.Add("Well... STOP ASKING SO MANY DAMN QUESTIONS!!!");
                Data.instance.cCDialogue.Add("And be grateful that I had this old, obsolete translator lying around.");
                Data.instance.cCDialogue.Add("Now pick the comfiest corner of the floor and...");
                Data.instance.cCDialogue.Add("Honestly, I’ve got no idea how humans sleep (nor do I care).");
                Data.instance.cCDialogue.Add("When you’re done with whatever ritual your species does, turn off the light.");
                Data.instance.cCDialogue.Add("See you tomorrow...! AND DO NOT BE LATE!");
            }

            else if (currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Tapicio"))
            {
                Data.instance.cCDialogue.Add("Your boss said you’ll be staying here.");
                Data.instance.cCDialogue.Add("This place is as gloomy… as my soul.");
                Data.instance.cCDialogue.Add("I brought you a game — maybe you can decorate the room with it.");
                Data.instance.cCDialogue.Add("If you treat customers well, they’ll give you stuff.");
                Data.instance.cCDialogue.Add("Maybe if you do them favors, they’ll give you even… more random trash?");
                Data.instance.cCDialogue.Add("I’ll leave you now with my grain of trash for your room, human. Good night.");

            }

            else if (currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Giovanni"))
            {
                Data.instance.cCDialogue.Add("Bonna notte, my friend. Hope you rest well.");
                Data.instance.cCDialogue.Add("But first, I got you a present — my cookbook.");
                Data.instance.cCDialogue.Add("Well, technically it’s a magical photocopy.");
                Data.instance.cCDialogue.Add("Now we both can cook divine dishes any day.");
                Data.instance.cCDialogue.Add("Though… there’s no kitchen here — just a filthy basement.");
                Data.instance.cCDialogue.Add("You’ll figure it out. Ciao, my friend.");

            }

            else if (currentHomeClientReal.GetComponent<Image>().sprite.name.Contains("Mano"))
            {
                Data.instance.cCDialogue.Add("Hello, human. I see you kept quiet about the church when the detective came around.");
                Data.instance.cCDialogue.Add("You’ve shown yourself faithful to our cause… and to the church.");
                Data.instance.cCDialogue.Add("You’ve earned my trust to be considered one of us.");
                Data.instance.cCDialogue.Add("Accept this ring as a token of gratitude.");
                Data.instance.cCDialogue.Add("We look forward to seeing you at the church these days… you know what I mean.");
            }
        }
    }
}