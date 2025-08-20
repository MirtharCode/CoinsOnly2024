using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneReferences : MonoBehaviour
{
    public GameObject mC;
    public GameObject cM;
    public GameObject phoneObject;
    public GameObject complainObject;
    public GameObject dialoguePanelFirstDay;
    public GameObject dialoguePanelFirstDayCollider;
    public GameObject dialoguePanelFirstDayNameText;
    public GameObject dialoguePanelFirstDayRaceText;
    public GameObject dialoguePanelFirstDayDialogueText;
    public GameObject dialoguePanelOtherDays;
    public GameObject dialoguePanelOtherDaysCollider;
    public GameObject dialoguePanelOtherDaysNameText;
    public GameObject dialoguePanelOtherDaysRaceText;
    public GameObject racePanel;
    public GameObject dialoguePanelOtherDaysDialogueText;
    public GameObject sospechosoPanel;
    public GameObject seguroPanel;
    public Volume postPro;
    public VolumeProfile postPro_Profile;


    public GameObject gnomeCanvas;
    public GameObject trophyCanvas;
    public GameObject gnomeFog1;
    public GameObject gnomeFog2;

    public GameObject regulationsBook;

    public GameObject leDinero;
    public TMP_Text leDineroText;
    public GameObject leDineroSymbol;
    public GameObject leCajaRegistradora;
    public GameObject buttonCobrar;
    public GameObject buttonNoCobrar;
    public GameObject centralProduct;
    public GameObject rightProduct;
    public GameObject leftProduct;

    public GameObject zoomTargetPrices;
    public GameObject zoomTargetRegulations;
    public GameObject zoomTargetCoupon;

    public GameObject couponPlace;
    public GameObject couponInfoContainer;

    public GameObject lesPropinas;
    public TMP_Text lePropinasText;

    public TextMeshProUGUI beerText;
    public TextMeshProUGUI magicRamenText;
    public TextMeshProUGUI energyDrinkText;
    public TextMeshProUGUI manaPotionText;
    public TextMeshProUGUI venomPotionText;
    public TextMeshProUGUI deadCatText;
    public TextMeshProUGUI vodooDollText;
    public TextMeshProUGUI cristallBallText;
    public TextMeshProUGUI magicBatteriesText;
    public TextMeshProUGUI magicRunesText;

    [Header("NORMATIVAS PRIMER DÍA")]
    public TextMeshProUGUI reg01DWTitle;
    public TextMeshProUGUI reg01DWNoRegText;
    public TextMeshProUGUI reg01HybTitle;
    public TextMeshProUGUI reg01HybNoRegText;
    public TextMeshProUGUI reg01EleTitle;
    public TextMeshProUGUI reg01EleNoRegText;
    public TextMeshProUGUI reg01LimTitle;
    public TextMeshProUGUI reg01LimNoRegText;
    public TextMeshProUGUI reg01TP2Title;
    public TextMeshProUGUI reg01TP2NoRegText;


    [Header("NORMATIVAS SEGUNDO DÍA")]
    public TextMeshProUGUI reg02DWTitle;
    public TextMeshProUGUI reg02DWNoRegText;
    public TextMeshProUGUI reg02HybTitle;
    public TextMeshProUGUI reg02HybNoRegText;
    public TextMeshProUGUI reg02EleTitle;
    public TextMeshProUGUI reg02EleReg1Text;
    public TextMeshProUGUI reg02LimTitle;
    public TextMeshProUGUI reg02LimReg1Text;
    public TextMeshProUGUI reg02TP2Title;
    public TextMeshProUGUI reg02TP2NoRegText;


    [Header("NORMATIVAS TERCER DÍA")]
    public TextMeshProUGUI reg03DWTitle;
    public TextMeshProUGUI reg03DWReg1Text;
    public TextMeshProUGUI reg03HybTitle;
    public TextMeshProUGUI reg03HybNoRegText;
    public TextMeshProUGUI reg03EleTitle;
    public TextMeshProUGUI reg03EleReg1Text;
    public TextMeshProUGUI reg03LimTitle;
    public TextMeshProUGUI reg03LimReg1Text;
    public TextMeshProUGUI reg03TP2Title;
    public TextMeshProUGUI reg03TP2Reg1Text;


    [Header("NORMATIVAS CUARTO DÍA")]
    public TextMeshProUGUI reg04DWTitle;
    public TextMeshProUGUI reg04DWReg1Text;
    public TextMeshProUGUI reg04DWReg2Text;
    public TextMeshProUGUI reg04HybTitle;
    public TextMeshProUGUI reg04HybReg1Text;
    public TextMeshProUGUI reg04EleTitle;
    public TextMeshProUGUI reg04EleReg1Text;
    public TextMeshProUGUI reg04EleReg2Text;
    public TextMeshProUGUI reg04LimTitle;
    public TextMeshProUGUI reg04LimReg1Text;
    public TextMeshProUGUI reg04TP2Title;
    public TextMeshProUGUI reg04TP2Reg1Text;


    [Header("NORMATIVAS QUINTO DÍA")]
    public TextMeshProUGUI reg05DWTitle;
    public TextMeshProUGUI reg05DWReg1Text;
    public TextMeshProUGUI reg05DWReg2Text;
    public TextMeshProUGUI reg05HybTitle;
    public TextMeshProUGUI reg05HybReg1Text;
    public TextMeshProUGUI reg05HybReg2Text;
    public TextMeshProUGUI reg05EleTitle;
    public TextMeshProUGUI reg05EleReg1Text;
    public TextMeshProUGUI reg05EleReg2Text;
    public TextMeshProUGUI reg05LimTitle;
    public TextMeshProUGUI reg05LimReg1Text;
    public TextMeshProUGUI reg05TP2Title;
    public TextMeshProUGUI reg05TP2Reg1Text;


    [Header("NORMATIVAS SEXTO DÍA")]
    public TextMeshProUGUI reg06DWTitle;
    public TextMeshProUGUI reg06DWReg1Text;
    public TextMeshProUGUI reg06DWReg2Text;
    public TextMeshProUGUI reg06HybTitle;
    public TextMeshProUGUI reg06HybReg1Text;
    public TextMeshProUGUI reg06HybReg2Text;
    public TextMeshProUGUI reg06EleTitle;
    public TextMeshProUGUI reg06EleReg1Text;
    public TextMeshProUGUI reg06EleReg2Text;
    public TextMeshProUGUI reg06LimTitle;
    public TextMeshProUGUI reg06LimReg1Text;
    public TextMeshProUGUI reg06LimReg2Text;
    public TextMeshProUGUI reg06TP2Title;
    public TextMeshProUGUI reg06TP2Reg1Text;
    public TextMeshProUGUI reg06TP2Reg2Text;


    [Header("NORMATIVAS SÉPTIMO DÍA")]
    public TextMeshProUGUI reg07DWTitle;
    public TextMeshProUGUI reg07DWReg1Text;
    public TextMeshProUGUI reg07DWReg2Text;
    public TextMeshProUGUI reg07HybTitle;
    public TextMeshProUGUI reg07HybReg1Text;
    public TextMeshProUGUI reg07HybReg2Text;
    public TextMeshProUGUI reg07EleTitle;
    public TextMeshProUGUI reg07EleReg1Text;
    public TextMeshProUGUI reg07EleReg2Text;
    public TextMeshProUGUI reg07LimTitle;
    public TextMeshProUGUI reg07LimReg1Text;
    public TextMeshProUGUI reg07LimReg2Text;
    public TextMeshProUGUI reg07TP2Title;
    public TextMeshProUGUI reg07TP2Reg1Text;
    public TextMeshProUGUI reg07TP2Reg2Text;


    private void Start()
    {
        // Puedes hacer comprobaciones aquí si quieres
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.
                SetSceneRefs(mC, cM, phoneObject, complainObject, dialoguePanelFirstDay, dialoguePanelFirstDayCollider, dialoguePanelFirstDayNameText, dialoguePanelFirstDayRaceText, dialoguePanelFirstDayDialogueText,
                dialoguePanelOtherDays, dialoguePanelOtherDaysCollider, dialoguePanelOtherDaysNameText, dialoguePanelOtherDaysRaceText, dialoguePanelOtherDaysDialogueText, racePanel,
                sospechosoPanel, seguroPanel, gnomeCanvas, gnomeFog1, gnomeFog2, trophyCanvas, regulationsBook, leDinero, leDineroText, leDineroSymbol, leCajaRegistradora, buttonCobrar, buttonNoCobrar,
                centralProduct, rightProduct, leftProduct, zoomTargetPrices, zoomTargetRegulations, zoomTargetCoupon, couponPlace, couponInfoContainer, lesPropinas, lePropinasText,
                beerText, magicRamenText, energyDrinkText, manaPotionText, venomPotionText, deadCatText, vodooDollText, cristallBallText, magicBatteriesText, magicRunesText,
                reg01DWTitle, reg01DWNoRegText, reg01HybTitle, reg01HybNoRegText, reg01EleTitle, reg01EleNoRegText, reg01LimTitle, reg01LimNoRegText, reg01TP2Title, reg01TP2NoRegText,
                reg02DWTitle, reg02DWNoRegText, reg02HybTitle, reg02HybNoRegText, reg02EleTitle, reg02EleReg1Text, reg02LimTitle, reg02LimReg1Text, reg02TP2Title, reg02TP2NoRegText,
                reg03DWTitle, reg03DWReg1Text, reg03HybTitle, reg03HybNoRegText, reg03EleTitle, reg03EleReg1Text, reg03LimTitle, reg03LimReg1Text, reg03TP2Title, reg03TP2Reg1Text,
                reg04DWTitle, reg04DWReg1Text, reg04DWReg2Text, reg04HybTitle, reg04HybReg1Text, reg04EleTitle, reg04EleReg1Text, reg04EleReg2Text, reg04LimTitle, reg04LimReg1Text, reg04TP2Title, reg04TP2Reg1Text,
                reg05DWTitle, reg05DWReg1Text, reg05DWReg2Text, reg05HybTitle, reg05HybReg1Text, reg05HybReg2Text, reg05EleTitle, reg05EleReg1Text, reg05EleReg2Text, reg05LimTitle, reg05LimReg1Text, reg05TP2Title, reg05TP2Reg1Text,
                reg06DWTitle, reg06DWReg1Text, reg06DWReg2Text, reg06HybTitle, reg06HybReg1Text, reg06HybReg2Text, reg06EleTitle, reg06EleReg1Text, reg06EleReg2Text, reg06LimTitle, reg06LimReg1Text, reg06LimReg2Text, reg06TP2Title, reg06TP2Reg1Text, reg06TP2Reg2Text,
                reg07DWTitle, reg07DWReg1Text, reg07DWReg2Text, reg07HybTitle, reg07HybReg1Text, reg07HybReg2Text, reg07EleTitle, reg07EleReg1Text, reg07EleReg2Text, reg07LimTitle, reg07LimReg1Text, reg07LimReg2Text, reg07TP2Title, reg07TP2Reg1Text, reg07TP2Reg2Text);

            if (DialogueManager.Instance.lastSceneWithDialogues != DialogueManager.Instance.currentDay)
                DialogueManager.Instance.propinasNumber = 50;
        }
    }
}