using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gnomo : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject canvas;
    public Scene currentScene;

    Animator animator;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        canvas = GameObject.FindGameObjectWithTag("UI");
        animator = GetComponent<Animator>();
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        
    }

    public void GnomoFinded()
    {
        if(currentScene.name == "Day2_1")
        {
            Data.instance.numGnomosFinded++;
            animator.SetBool("Pick", false);
        }

        else if (currentScene.name == "Day3_1")
        {
            Data.instance.numGnomosFinded++;
            animator.SetBool("Pick2", false);

            if(Data.instance.numGnomosFinded >= 2)
            {
                Data.instance.giftEnano = true;
                canvas.GetComponent<UIManager>().TrophyAchieved("Enano");
            }
        }
    }

    public void ShowUpGnomoAnim()
    {
        if (currentScene.name == "Day2_1")
            animator.SetBool("Pick", true);

        else if (currentScene.name == "Day3_1")
            animator.SetBool("Pick2", true);
    }
}
