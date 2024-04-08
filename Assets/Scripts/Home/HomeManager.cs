using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    public GameObject currentHomeClientPrefab;
    public GameObject currentHomeClientReal;
    public Transform startingPoint;
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] public TMP_Text dialogueText;
    [SerializeField] public GameObject data;
    [SerializeField] public bool conversationOn;
    [SerializeField] public TMP_Text traductorText;
    [SerializeField] public TMP_Text NombreText;
    [SerializeField] public int dialogueSize;
    [SerializeField] public int internalCount;

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
    [SerializeField] public Image miniClientImage;
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



    // Start is called before the first frame update
    private void Awake()
    {
        SomeoneIsKnocking();
    }

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
        currentHomeClientReal = GameObject.FindGameObjectWithTag("HomeClient");
        Data.instance.homeManager = gameObject.GetComponent<HomeManager>();
        dialogueSize = currentHomeClientReal.GetComponent<HomeClient>().dialogue.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SomeoneIsKnocking()
    {
        GameObject clon = Instantiate(currentHomeClientPrefab, startingPoint);

        if (Data.instance.day0Check)
        {
            clon.GetComponent<Image>().sprite = limbasticSergio;
        }

        if (Data.instance.day1Check)
        {
            clon.GetComponent<Image>().sprite = elementalJissy;
        }
    }

    public void ShowingText()
    {
        conversationOn = true;
        traductorText.text = currentHomeClientReal.GetComponent<HomeClient>().raza;
        NombreText.text = currentHomeClientReal.GetComponent<HomeClient>().nombre;
        dialogueText.text = currentHomeClientReal.GetComponent<HomeClient>().dialogue[internalCount];
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
    }
}
