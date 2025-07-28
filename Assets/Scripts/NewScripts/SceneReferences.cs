using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    public GameObject bAndWShader;

    public GameObject gnomeCanvas;
    public GameObject trophyCanvas;

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

    public GameObject couponSign;
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
                                                        sospechosoPanel, seguroPanel, bAndWShader, gnomeCanvas, trophyCanvas, regulationsBook, leDinero, leDineroText, leDineroSymbol, leCajaRegistradora, buttonCobrar, buttonNoCobrar,
                                                        centralProduct, rightProduct, leftProduct, couponSign, couponPlace, couponInfoContainer, lesPropinas, lePropinasText);
        }
    }
}