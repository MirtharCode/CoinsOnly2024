using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneReferences : MonoBehaviour
{
    public GameObject clientManager;
    public GameObject phoneObject;
    public GameObject complainObject;
    public GameObject dialoguePanel;
    public GameObject sospechosoPanel;
    public GameObject seguroPanel;
    public GameObject bAndWShader;

    public GameObject gnomeCanvas;
    public GameObject trophyCanvas;

    public GameObject darkWizardsPanel;
    public GameObject hybridsPanel;
    public GameObject elementalsPanel;
    public GameObject limbasticsPanel;
    public GameObject tecnopedsPanel;

    public GameObject leDinero;
    public TMP_Text leDineroText;
    public GameObject leDineroSymbol;
    public GameObject leCajaRegistradora;
    public GameObject buttonCobrar;
    public GameObject buttonNoCobrar;
    public GameObject centralProduct;
    public GameObject rightProduct;
    public GameObject leftProduct;
    public GameObject couponPlace;
    public GameObject lesPropinas;
    public TMP_Text lePropinasText;

    private void Start()
    {
        // Puedes hacer comprobaciones aquí si quieres
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.SetSceneReferences(clientManager, phoneObject, complainObject, dialoguePanel, sospechosoPanel, seguroPanel, bAndWShader, gnomeCanvas,
                                                        trophyCanvas, darkWizardsPanel, hybridsPanel, elementalsPanel, limbasticsPanel, tecnopedsPanel,
                                                        leDinero, leDineroText, leDineroSymbol, leCajaRegistradora, buttonCobrar, buttonNoCobrar, 
                                                        centralProduct, rightProduct, leftProduct, couponPlace, lesPropinas, lePropinasText);
        }
    }
}