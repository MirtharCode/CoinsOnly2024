using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Jefe2 : RazaJefe
{
    bool repetirunavez = false;

    protected override void Start()
    {
        base.Start();
        nombre = "El Jefe";
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            uIManager.GetComponent<UIManager>().clientImage.sprite = uIManager.GetComponent<UIManager>().elJefe;

            if (currentScene.name == "Day1")
            {
                dialogue.Add("Seguro que fue muy agotador. pero mejor me lo comentas mañana.");
                dialogue.Add("Y un pajarito llamado Inspector de Empleo me ha dicho que no tienes casa.");
                dialogue.Add("Menos mal que tienes un jefe tan generoso y rico, así que te prestaré una de las mejores viviendas del reino.");
                dialogue.Add("Ese maravilloso lugar se llama: El sótano de mi madre.");
                dialogue.Add("Espero que te guste.");

                uIManager.GetComponent<UIManager>().ShowText();

                dialogueUIPanel = GameObject.FindGameObjectWithTag("UIPanel");
                dialogueUIText = GameObject.FindGameObjectWithTag("UIText").GetComponent<TMP_Text>();

                //StartCoroutine(ShowLine());
            }
        }
    }

    public override void ByeBye()
    {
        base.ByeBye();
    }
}
