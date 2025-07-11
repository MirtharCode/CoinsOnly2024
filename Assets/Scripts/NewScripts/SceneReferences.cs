using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneReferences : MonoBehaviour
{
    public string currentSceneName;
    public GameObject clientManager;
    public GameObject phoneObject;
    public GameObject complainObject;
    public GameObject dialoguePanel;
    public GameObject sospechosoPanel;
    public GameObject seguroPanel;

    public GameObject preciosPanel;
    public GameObject botonPlegadoPrecios;
    public GameObject botonDesplegadoPrecios;
    public GameObject pos1Precios;
    public GameObject pos2Precios;
    
    public GameObject normativaPanel;
    public GameObject botonPlegadoNormativas;
    public GameObject botonDesplegadoNormativas;
    public GameObject pos1Normativas;
    public GameObject pos2Normativas;
    public TextMeshProUGUI regRaceText;
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

    private void Awake()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }
    private void Start()
    {
        // Puedes hacer comprobaciones aquí si quieres
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.SetSceneReferences(currentSceneName, clientManager, phoneObject, complainObject, dialoguePanel, sospechosoPanel, seguroPanel, 
                                                        preciosPanel, botonPlegadoPrecios, botonDesplegadoPrecios, pos1Precios, pos2Precios,
                                                        normativaPanel, botonPlegadoNormativas, botonDesplegadoNormativas, pos1Normativas, pos2Normativas, regRaceText,
                                                        darkWizardsPanel, hybridsPanel, elementalsPanel, limbasticsPanel, tecnopedsPanel,
                                                        leDinero, leDineroText, leDineroSymbol, leCajaRegistradora, buttonCobrar, buttonNoCobrar, 
                                                        centralProduct, rightProduct, leftProduct, couponPlace, lesPropinas, lePropinasText);
        }
    }
}