using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Jefe2 : RazaJefe
{
    protected override void Start()
    {
        base.Start();
        nombre = "El Jefe";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            base.OnCollisionEnter2D(collision);
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().elJefe;
        }
    }

    public override void ByeBye()
    {
        base.ByeBye();
    }
}
