using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Gramola : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] public GameObject musicPanel;
    [SerializeField] public AudioSource musicDarkWizards;
    [SerializeField] public AudioSource musicHybrids;
    [SerializeField] public AudioSource musicTecnoP2;
    [SerializeField] public AudioSource musicLimbastics;
    [SerializeField] public AudioSource musicElementals;
    [SerializeField] public AudioSource musicDetective;
    [SerializeField] public Sprite musicPlayImage;
    [SerializeField] public Sprite musicStopImage;

    [SerializeField] public GameObject launcherDarkWizards;
    [SerializeField] public Image imageDW;
    [SerializeField] public GameObject launcherHybrids;
    [SerializeField] public Image imageH;
    [SerializeField] public GameObject launcherTecnoP2;
    [SerializeField] public Image imageT;
    [SerializeField] public GameObject launcherLimbastics;
    [SerializeField] public Image imageL;
    [SerializeField] public GameObject launcherElementals;
    [SerializeField] public Image imageE;
    [SerializeField] public GameObject launcherDetective;
    [SerializeField] public Image imageD;

    [SerializeField] public bool awakenDetective;
    [SerializeField] public int vocesSonando;
    [SerializeField] public GameObject dosVoces;
    [SerializeField] public GameObject tresCuatroVoces;
    [SerializeField] public GameObject masDeCuatroVoces;


    void Start()
    {
        vocesSonando = 1;

        audioSource = GetComponent<AudioSource>();
        musicPanel = GameObject.FindGameObjectWithTag("MusicPanel");

        musicDarkWizards = transform.GetChild(0).GetComponent<AudioSource>(); musicDarkWizards.mute = true;
        launcherDarkWizards = musicPanel.transform.GetChild(0).gameObject;
        launcherDarkWizards.transform.GetChild(1).GetComponent<TMP_Text>().text = "TEMA MAGOS OSCUROS";
        imageDW = launcherDarkWizards.transform.GetChild(0).GetComponent<Image>();

        musicHybrids = transform.GetChild(1).GetComponent<AudioSource>(); musicHybrids.mute = true;
        launcherHybrids = musicPanel.transform.GetChild(1).gameObject;
        launcherHybrids.transform.GetChild(1).GetComponent<TMP_Text>().text = "TEMA HÍBRIDOS";
        imageH = launcherHybrids.transform.GetChild(0).GetComponent<Image>();

        musicTecnoP2 = transform.GetChild(2).GetComponent<AudioSource>(); musicTecnoP2.mute = true;
        launcherTecnoP2 = musicPanel.transform.GetChild(2).gameObject;
        launcherTecnoP2.transform.GetChild(1).GetComponent<TMP_Text>().text = "TEMA TECNOP2";
        imageT = launcherTecnoP2.transform.GetChild(0).GetComponent<Image>();

        musicLimbastics = transform.GetChild(3).GetComponent<AudioSource>(); musicLimbastics.mute = true;
        launcherLimbastics = musicPanel.transform.GetChild(3).gameObject;
        launcherLimbastics.transform.GetChild(1).GetComponent<TMP_Text>().text = "TEMA LIMBÁSTICOS";
        imageL = launcherLimbastics.transform.GetChild(0).GetComponent<Image>();

        musicElementals = transform.GetChild(4).GetComponent<AudioSource>(); musicElementals.mute = true;
        launcherElementals = musicPanel.transform.GetChild(4).gameObject;
        launcherElementals.transform.GetChild(1).GetComponent<TMP_Text>().text = "TEMA ELEMENTALES";
        imageE = launcherElementals.transform.GetChild(0).GetComponent<Image>();

        musicDetective = transform.GetChild(5).GetComponent<AudioSource>(); musicDetective.mute = true;
        launcherDetective = musicPanel.transform.GetChild(5).gameObject;
        launcherDetective.transform.GetChild(1).GetComponent<TMP_Text>().text = "TEMA DETECTIVE";
        imageD = launcherDetective.transform.GetChild(0).GetComponent<Image>();

    }

    void Update()
    {
        if (vocesSonando == 1)
        {
            dosVoces.SetActive(false);
            tresCuatroVoces.SetActive(false);
            masDeCuatroVoces.SetActive(false);
        }

        else if (vocesSonando > 1 && vocesSonando < 3)
        {
            dosVoces.SetActive(true);
            tresCuatroVoces.SetActive(false);
            masDeCuatroVoces.SetActive(false);
        }

        else if (vocesSonando >= 3 && vocesSonando < 5)
        {
            dosVoces.SetActive(true);
            tresCuatroVoces.SetActive(true);
            masDeCuatroVoces.SetActive(false);
        }
        else if (vocesSonando >= 5)
        {
            dosVoces.SetActive(true);
            tresCuatroVoces.SetActive(true);
            masDeCuatroVoces.SetActive(true);
        }
    }

    public void DarkWizardsTheme()
    {
        if (imageDW.sprite == musicPlayImage && !awakenDetective)
        {
            musicDarkWizards.mute = false;
            imageDW.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageDW.sprite == musicPlayImage && awakenDetective)
        {
            EverybodyShuffleling();
            musicDarkWizards.mute = false;
            imageDW.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageDW.sprite == musicStopImage)
        {
            musicDarkWizards.mute = true;
            imageDW.sprite = musicPlayImage;
            vocesSonando--;
        }
    }
    public void HybridsTheme()
    {
        if (imageH.sprite == musicPlayImage && !awakenDetective)
        {
            musicHybrids.mute = false;
            imageH.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageH.sprite == musicPlayImage && awakenDetective)
        {
            EverybodyShuffleling();
            musicHybrids.mute = false;
            imageH.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageH.sprite == musicStopImage)
        {
            musicHybrids.mute = true;
            imageH.sprite = musicPlayImage;
            vocesSonando--;
        }
    }


    public void TecnoP2Theme()
    {
        if (imageT.sprite == musicPlayImage && !awakenDetective)
        {
            musicTecnoP2.mute = false;
            imageT.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageT.sprite == musicPlayImage && awakenDetective)
        {
            EverybodyShuffleling();
            musicTecnoP2.mute = false;
            imageT.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageT.sprite == musicStopImage)
        {
            musicTecnoP2.mute = true;
            imageT.sprite = musicPlayImage;
            vocesSonando--;
        }
    }

    public void LimbasticTheme()
    {
        if (imageL.sprite == musicPlayImage && !awakenDetective)
        {
            musicLimbastics.mute = false;
            imageL.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageL.sprite == musicPlayImage && awakenDetective)
        {
            EverybodyShuffleling();
            musicLimbastics.mute = false;
            imageL.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageL.sprite == musicStopImage)
        {
            musicLimbastics.mute = true;
            imageL.sprite = musicPlayImage;
            vocesSonando--;
        }
    }

    public void ElementalsTheme()
    {
        if (imageE.sprite == musicPlayImage)
        {
            musicElementals.mute = false;
            imageE.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageE.sprite == musicPlayImage)
        {
            EverybodyShuffleling();
            musicElementals.mute = false;
            imageE.sprite = musicStopImage;
            vocesSonando++;
        }

        else if (imageE.sprite == musicStopImage)
        {
            musicElementals.mute = true;
            imageE.sprite = musicPlayImage;
            vocesSonando--;
        }
    }

    public void DetectiveTheme()
    {
        if (imageD.sprite == musicPlayImage)
        {
            awakenDetective = true;

            GetComponent<AudioSource>().Stop();


            imageDW.sprite = musicPlayImage;
            musicDarkWizards.mute = true;
            musicDarkWizards.Stop();

            imageH.sprite = musicPlayImage;
            musicHybrids.mute = true;
            musicHybrids.Stop();

            imageT.sprite = musicPlayImage;
            musicTecnoP2.mute = true;
            musicTecnoP2.Stop();

            imageL.sprite = musicPlayImage;
            musicLimbastics.mute = true;
            musicLimbastics.Stop();

            imageE.sprite = musicPlayImage;
            musicElementals.mute = true;
            musicElementals.Stop();

            musicDetective.mute = false;
            musicDetective.Play();
            imageD.sprite = musicStopImage;

            vocesSonando = 1;
        }

        else if (imageD.sprite == musicStopImage)
        {
            EverybodyShuffleling();
        }
    }

    public void EverybodyShuffleling()
    {
        musicDetective.Stop();
        awakenDetective = false;
        imageD.sprite = musicPlayImage;

        GetComponent<AudioSource>().Play();
        musicDarkWizards.Play();
        musicHybrids.Play();
        musicTecnoP2.Play();
        musicLimbastics.Play();
        musicElementals.Play();
    }
}
