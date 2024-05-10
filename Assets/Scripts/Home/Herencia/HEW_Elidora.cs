using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEW_Elidora : HomeEvilWizards
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        nombre = "Elidora";
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
