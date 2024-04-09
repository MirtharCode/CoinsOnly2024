using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;

public class HE_Tapicio : HomeElementals
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        nombre = "Tapicio";
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
