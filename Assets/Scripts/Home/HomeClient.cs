using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeClient : MonoBehaviour
{
    [SerializeField] public HomeManager hM;
    [SerializeField] public List<string> dialogue;
    [SerializeField] public string raza;
    [SerializeField] public string nombre;
    [SerializeField] public Sprite normalSprite;
    [SerializeField] public Sprite milosSape;

    // Start is called before the first frame update
    void Start()
    {
        hM = GameObject.FindGameObjectWithTag("HM").GetComponent<HomeManager>();
        gameObject.name = GetComponent<Image>().sprite.name;
        Data.instance.SettingDialogues();
        dialogue = Data.instance.cCDialogue;
        raza = "Jefe";
        nombre = "Eusebio";

        hM.dialogueSize = dialogue.Count;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WakingUpText()
    {
        hM.dialoguePanel.gameObject.SetActive(true);
    }


    public void PosMeMato()
    {
        Destroy(gameObject);
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
