using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialTimer : MonoBehaviour
{
    [SerializeField] public GameObject pM;
    [SerializeField] public SlimeManager sM;
    [SerializeField] public GameObject gO;
    [SerializeField] public AnimationClip gOGrow;
    public Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name.Contains("Pila"))
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("PilaStart");
            pM = GameObject.FindGameObjectWithTag("PM");
        }

        else
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("SlimeStart");
            sM = GameObject.FindGameObjectWithTag("SM").GetComponent<SlimeManager>();
        }
    }

    public void ActivarTemporizador()
    {
        if (currentScene.name.Contains("Pila"))
        {
            pM.GetComponent<PilaManager>().tiempoActual = pM.GetComponent<PilaManager>().tiempoMaximo;
            pM.GetComponent<PilaManager>().tempo.text = "" + pM.GetComponent<PilaManager>().tiempoMaximo.ToString("f0");
            pM.GetComponent<PilaManager>().CambiarTemporizador(true);
            pM.GetComponent<PilaManager>().pila1.GetComponent<Pila>().enabled = true;
        }

        //else
        //    GoGoPowerRangers();
    }

    public void GoGoPowerRangers()
    {
        if (!currentScene.name.Contains("Pila"))
        {
            float gOGrowTiming;

            if (currentScene.name.Contains("Mole"))
            {
                gO.gameObject.SetActive(true);
                gOGrowTiming = gOGrow.length;
                Invoke(nameof(EmpiezaElJuego), gOGrowTiming);
            }
        }
    }

    public void EmpiezaElJuego()
    {
        sM.StartGame();
    }
}
