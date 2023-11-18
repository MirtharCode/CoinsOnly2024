using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Hibridos : Client
{
    protected abstract void OnCollisionEnter2D(Collision2D collision);
    public override void ShowProductsAndMoney()
    {
        //Relleno

    }
}
