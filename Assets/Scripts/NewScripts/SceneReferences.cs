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

    private void Start()
    {
        // Puedes hacer comprobaciones aquí si quieres
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.SetSceneReferences(mC, cM, phoneObject, complainObject,
                                                        dialoguePanelFirstDay, dialoguePanelFirstDayCollider, dialoguePanelFirstDayNameText, dialoguePanelFirstDayRaceText, dialoguePanelFirstDayDialogueText,
                                                        dialoguePanelOtherDays, dialoguePanelOtherDaysCollider, dialoguePanelOtherDaysNameText, dialoguePanelOtherDaysRaceText, dialoguePanelOtherDaysDialogueText, racePanel,
                                                        sospechosoPanel, seguroPanel, postPro, gnomeCanvas, gnomeFog1, gnomeFog2, trophyCanvas, regulationsBook, leDinero, leDineroText, leDineroSymbol, leCajaRegistradora, buttonCobrar, buttonNoCobrar,
                                                        centralProduct, rightProduct, leftProduct, zoomTargetPrices, zoomTargetRegulations, zoomTargetCoupon, couponPlace, couponInfoContainer, lesPropinas, lePropinasText);
        }
    }
}