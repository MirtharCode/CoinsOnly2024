using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HU_Jefe : HomeClient
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        if (DialogueManager.Instance.currentLanguage == Language.ES)
        {
            raza = "Desconocida";
            nombre = "Minijefe";
        }

        else if (DialogueManager.Instance.currentLanguage == Language.EN)
        {
            raza = "Unkwown";
            nombre = "Miniboss";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
