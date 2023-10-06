using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Dialogos : MonoBehaviour
{
    [SerializeField] TMP_Text dialogo1;
    [SerializeField] TMP_Text buttonText1;
    [SerializeField] TMP_Text buttonText2;
    [SerializeField] TMP_Text buttonText3;

    void Start()
    {
        ActualizarHUD();
    }

    void Update()
    {

    }

    void ActualizarHUD()
    {

        int dado = Random.Range(1, 3);

        if (dado == 1)
            dialogo1.text = "Tu madre me la afloja";

        else if (dado == 2)
            dialogo1.text = "Tu padre me la afloja";


        buttonText1.text = "Cállate imbecil";
        buttonText2.text = "Uffffffff... Duro";
        buttonText3.text = "Mamapinga";
    }
}
