using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMinigame : MonoBehaviour
{
    [SerializeField] Button salButton;
    [SerializeField] Button denjiButton;
    [SerializeField] Button elidoraButton;

    [SerializeField] GameObject denjiLevels;
    [SerializeField] GameObject gamesLevels;

    public void GoSalGame()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void GoDenjiGame1()
    {
        SceneManager.LoadScene("Pila_Nivel1");
    }

    public void GoDenjiGame2()
    {
        SceneManager.LoadScene("Pila_Nivel2");
    }

    public void OpenDenjiLevels()
    {
        denjiLevels.SetActive(true);
        gamesLevels.SetActive(false);
    }

    public void CloseDenjiLevels()
    {
        denjiLevels.SetActive(false);
        gamesLevels.SetActive(true);
    }

    public void GoElidoraGame()
    {
        SceneManager.LoadScene("WhackAMole1");
    }
}
