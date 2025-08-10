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

        if (data.GetComponent<Data>().videoActivo)
        {
            musicBox.GetComponent<AudioSource>().mute = true;
            fTBObject.GetComponent<Image>().enabled = false;

            videoplayer.SetActive(true);
            pantalla.SetActive(true);
        }
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

        if (currentHomeClientReal.name.Contains("Jefe"))
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

        //else if (currentHomeClientReal.name.Contains("Elidora"))
        //{
        //    if (!Data.instance.slimeFostiados)
        //        Invoke(nameof(FadeToBlackSlimes), clientGoingOutClip.length);

        //    else
        //    {
        //        if (!Data.instance.slimeFail)
        //        {
        //            GameObject.FindGameObjectWithTag("HomeClient").GetComponent<Image>().sprite = evilWizardElidoraALT;
        //            Data.instance.giftElidora = true;
        //            TrophyAchieved("Elidora");
        //        }
        //        data.GetComponent<Data>().sePueTocar = true;
        //        data.GetComponent<Data>().yaSeFueCliente = true;
        //    }
        //}

        else if (currentHomeClientReal.name.Contains("Mano") && !Data.instance.giftMano)
        {
            Data.instance.giftMano = true;
            GameObject.FindGameObjectWithTag("HomeClient").GetComponent<Image>().sprite = evilWizardManoloManoALT;
            TrophyAchieved("Mano");
            data.GetComponent<Data>().sePueTocar = true;
            data.GetComponent<Data>().yaSeFueCliente = true;
        }

    }

    public void TrophyAchieved(string trophyName)
    {
        if (trophyName == "Antonio")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageAntonio;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Gafas Otaku \nDesbloqueadas!";
        }

        else if (trophyName == "Cululu")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageCululu;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Foto Tinder \nDesbloqueada!";
        }

        else if (trophyName == "Denjirenji")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageDenjirenji;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Katana \nLáser \nDesbloqueada!";
        }

        else if (trophyName == "Elidora")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageElidora;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Mc Moco \nDesbloqueado!";
        }

        else if (trophyName == "Elvog")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageElvog;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Flores \nen Vodka \nDesbloqueadas!";
        }

        else if (trophyName == "Enano")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageEnano;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Elena Nito \nDesbloqueado!";
        }

        else if (trophyName == "Geeraard")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageGeeraard;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Foto to wapa \nDesbloqueada!";
        }

        else if (trophyName == "Giovanni")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageGiovanni;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Libro Gordo \nDesbloqueado!";
        }

        else if (trophyName == "Handy")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageHandy;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Traje \nde los \nDomingos \nDesbloqueado!";
        }

        else if (trophyName == "Mano")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageMano;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡El sellaso \nDesbloqueado!";
        }

        else if (trophyName == "Mara")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageMara;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Trozo de \nex-marido \nDesbloqueado!";
        }

        else if (trophyName == "Petra")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImagePetra;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Mapa de \nAlbacete \nDesbloqueado!";
        }

        else if (trophyName == "Raven")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageRaven;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡Disco de \nlos Mojinos \nDesbloqueado!";
        }

        else if (trophyName == "Sergio")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageSergio;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡La \nGloboespada \nDesbloqueada!";
        }

        else if (trophyName == "Tapicio")
        {
            trophyUI.transform.GetChild(0).GetComponent<Image>().sprite = giftImageTapicio;
            trophyUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "¡El GOTY \nDesbloqueado!";
        }

        showTrophyAnim.SetTrigger("TrophyShow");
    }

    //public void FadeToBlackSlimes()
    //{
    //    float animTime;
    //    Animator anim = transicionesGameobject.transform.GetChild(22).gameObject.GetComponent<Animator>();

    //    anim.SetBool("ToBlack", true);
    //    animTime = transicionesGameobject.GetComponent<Transiciones>().toBlackClip.length;

    //    Invoke(nameof(GoToWhackASlime), animTime);
    //}

    //public void GoToWhackASlime()
    //{
    //    SceneManager.LoadScene("WhackAMole1");
    //}
}