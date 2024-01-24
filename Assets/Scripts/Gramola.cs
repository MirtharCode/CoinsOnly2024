using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
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

    void Start()
    {
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

    }

    public void DarkWizardsTheme()
    {
        if (imageDW.sprite == musicPlayImage && !awakenDetective)
        {
            musicDarkWizards.mute = false;
            imageDW.sprite = musicStopImage;
        }

        else if (imageDW.sprite == musicPlayImage && awakenDetective)
        {
            musicDetective.Stop();
            awakenDetective = false;
            EverybodyShuffleling();

            musicDarkWizards.mute = false;
            imageDW.sprite = musicStopImage;
        }

        else if (imageDW.sprite == musicStopImage)
        {
            musicDarkWizards.mute = true;
            imageDW.sprite = musicPlayImage;
        }
    }
    public void HybridsTheme()
    {
        if (imageH.sprite == musicPlayImage && !awakenDetective)
        {
            musicHybrids.mute = false;
            imageH.sprite = musicStopImage;
        }

        else if (imageH.sprite == musicPlayImage && awakenDetective)
        {
            musicDetective.Stop();
            awakenDetective = false;
            EverybodyShuffleling();

            musicHybrids.mute = false;
            imageH.sprite = musicStopImage;
        }

        else if (imageH.sprite == musicStopImage)
        {
            musicHybrids.mute = true;
            imageH.sprite = musicPlayImage;
        }
    }


    public void TecnoP2Theme()
    {
        if (imageT.sprite == musicPlayImage && !awakenDetective)
        {
            musicTecnoP2.mute = false;
            imageT.sprite = musicStopImage;
        }

        else if (imageT.sprite == musicPlayImage && awakenDetective)
        {
            musicDetective.Stop();
            awakenDetective = false;
            EverybodyShuffleling();

            musicTecnoP2.mute = false;
            imageT.sprite = musicStopImage;
        }

        else if (imageT.sprite == musicStopImage)
        {
            musicTecnoP2.mute = true;
            imageT.sprite = musicPlayImage;
        }
    }

    // qshdhfkbfafkawdhkhdh

    public void LimbasticTheme()
    {
        if (imageL.sprite == musicPlayImage)
        {
            musicLimbastics.mute = false;
            imageL.sprite = musicStopImage;
        }

        else if (imageL.sprite == musicStopImage)
        {
            musicLimbastics.mute = true;
            imageL.sprite = musicPlayImage;
        }
    }

    public void ElementalsTheme()
    {
        if (imageE.sprite == musicPlayImage)
        {
            musicElementals.mute = false;
            imageE.sprite = musicStopImage;
        }

        else if (imageE.sprite == musicStopImage)
        {
            musicElementals.mute = true;
            imageE.sprite = musicPlayImage;
        }
    }

    public void DetectiveTheme()
    {
        if (imageD.sprite == musicPlayImage)
        {
            awakenDetective = true;

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

            musicDetective.mute = true;
            imageD.sprite = musicPlayImage;

            musicDetective.Play();
            imageD.sprite = musicStopImage;


        }

        else if (imageD.sprite == musicStopImage)
        {

        }
    }

    public void EverybodyShuffleling()
    {
        musicDarkWizards.Play();
        musicHybrids.Play();
        musicTecnoP2.Play();
        musicLimbastics.Play();
        musicElementals.Play();
    }
}
