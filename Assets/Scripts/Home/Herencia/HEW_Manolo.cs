using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEW_Manolo : HomeEvilWizards
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        nombre = "Manolo";
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
