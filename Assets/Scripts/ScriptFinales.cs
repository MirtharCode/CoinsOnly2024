using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptFinales : MonoBehaviour
{
    [SerializeField] public GameObject cursor;
    [SerializeField] public GameObject data;
    [SerializeField] public Scene currentScene;

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
        data.GetComponent<Data>().day0Check = true;
        data.GetComponent<Data>().day1Check = false;
        data.GetComponent<Data>().day2Check = false;
        data.GetComponent<Data>().day3Check = false;
        data.GetComponent<Data>().day4Check = false;
        data.GetComponent<Data>().day5Check = false;
        data.GetComponent<Data>().samuraiPagaMal = false;
        data.GetComponent<Data>().borrachoTriste = false;
        data.GetComponent<Data>().tipsPoints = 0;
        data.GetComponent<Data>().detectivePoints = 0;
        data.GetComponent<Data>().numLimbastic = 0;
        data.GetComponent<Data>().numElectroped = 0;
        data.GetComponent<Data>().numElemental = 0;
        data.GetComponent<Data>().numEvilWizard = 0;
        data.GetComponent<Data>().numHybrid = 0;



        SceneManager.LoadScene(0);
    }
}
