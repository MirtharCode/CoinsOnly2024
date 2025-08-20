using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HomeClient : MonoBehaviour
{
    [SerializeField] public HomeManager hM;
    [SerializeField] public List<string> dialogue;
    [SerializeField] public string raza;
    [SerializeField] public string nombre;
    [SerializeField] public Sprite normalSprite;
    [SerializeField] public Sprite miniSprite;
    [SerializeField] public Sprite milosSape;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        hM = GameObject.FindGameObjectWithTag("HM").GetComponent<HomeManager>();
        gameObject.name = GetComponent<Image>().sprite.name;
        hM.SettingHomeDialogues();
        dialogue = Data.instance.cCDialogue;
        hM.dialogueSize = dialogue.Count;
    }

    //public void ModoMilosActivado()
    //{
    //    gameObject.GetComponent<Image>().sprite = milosSape;
    //}

    //public void ModoHamsterActivado()
    //{
    //    gameObject.GetComponent<Image>().sprite = normalSprite;
    //}
}
