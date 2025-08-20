using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HL_Giovanni : HomeLimbastics
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        nombre = "Giovanni";

        if (DialogueManager.Instance.currentLanguage == Language.ES)
        {
            raza = "Limbásticos";
            nombre = "Giovanni";
        }

        else if (DialogueManager.Instance.currentLanguage == Language.EN)
        {
            raza = "Limbastics";
            nombre = "Giovanni";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        Data.instance.transiciones.GetComponent<Transiciones>().ShowGifts();
    }
}
