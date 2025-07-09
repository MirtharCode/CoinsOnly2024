using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptFinales : MonoBehaviour
{
    [SerializeField] public GameObject cursor;
    [SerializeField] public GameObject data;
    [SerializeField] public Scene currentScene;
    [SerializeField] public AnimationClip toBlackClip;

    void Start()
    {
        GameObject newCursor = Instantiate(cursor, transform);
        data = GameObject.FindGameObjectWithTag("Data");
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "FinalMuyMalo") data.GetComponent<Data>().finalMuyMaloConseguido = true;
        else if (currentScene.name == "FinalMalo") data.GetComponent<Data>().finalMaloConseguido = true;
        else if (currentScene.name == "FinalBueno") data.GetComponent<Data>().finalBuenoConseguido = true;
        else if (currentScene.name == "FinalMuyBueno") data.GetComponent<Data>().finalMuyBuenoConseguido = true;
        else if (currentScene.name == "FinalSecreto") data.GetComponent<Data>().finalSecretoConseguido = true;

    }

    void Update()
    {

    }

    public void TitleScreen()
    {
        data.GetComponent<Data>().day00Checked = true;
        data.GetComponent<Data>().day01Checked = false;
        data.GetComponent<Data>().day02Checked = false;
        data.GetComponent<Data>().day03Checked = false;
        data.GetComponent<Data>().day04Checked = false;
        data.GetComponent<Data>().day05Checked = false;
        data.GetComponent<Data>().samuraiPagaMal = false;
        data.GetComponent<Data>().borrachoTriste = false;
        data.GetComponent<Data>().vecesCobradoCululu = 0;
        data.GetComponent<Data>().tipsPoints = 0;
        data.GetComponent<Data>().detectivePoints = 0;
        data.GetComponent<Data>().numLimbastic = 0;
        data.GetComponent<Data>().numElectroped = 0;
        data.GetComponent<Data>().numElemental = 0;
        data.GetComponent<Data>().numEvilWizard = 0;
        data.GetComponent<Data>().numHybrid = 0;
        SceneManager.LoadScene("MenuInicial");
    }

    public void FTB()
    {
        float animTime;
        Animator anim = transform.GetChild(1).gameObject.GetComponent<Animator>();

        anim.SetBool("ToBlack", true);
        animTime = toBlackClip.length;

        Invoke(nameof(TitleScreen), animTime);
    }
}
