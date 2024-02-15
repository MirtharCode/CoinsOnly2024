using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetectiveHijo : DetectivePadre
{
    protected override void Start()
    {
        base.Start();
        nombre = "¿?";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            base.OnCollisionEnter2D(collision);
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().elDetective;
        }
    }

    public override void ByeBye()
    {
        base.ByeBye();
    }
}
