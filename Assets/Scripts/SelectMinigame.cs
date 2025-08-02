using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMinigame : MonoBehaviour
{
    [SerializeField] Button salButton;
    [SerializeField] Button denjiButton;
    [SerializeField] Button denjiLevel1Button;
    [SerializeField] Button denjiLevel2Button;
    [SerializeField] Button elidoraButton;

    [SerializeField] GameObject denjiLevels;
    [SerializeField] GameObject gamesLevels;

    [SerializeField] public GameObject data;

    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");

        Color gray100 = new Color(0.392f, 0.392f, 0.392f, 1f);

        if (!Data.instance.meExplotasteElCulo1 && !Data.instance.samuraiAyudado1)
        {
            denjiLevel1Button.GetComponent<Image>().color = gray100;
            var colors = denjiLevel1Button.colors;
            colors.normalColor = gray100;
            colors.highlightedColor = gray100;
            colors.pressedColor = gray100;
            colors.selectedColor = gray100;
            denjiLevel1Button.colors = colors;
            denjiLevel1Button.interactable = false;
        }

        if (!Data.instance.meExplotasteElCulo2 && !Data.instance.samuraiAyudado2)
        {
            denjiLevel2Button.GetComponent<Image>().color = gray100;
            var colors = denjiLevel2Button.colors;
            colors.normalColor = gray100;
            colors.highlightedColor = gray100;
            colors.pressedColor = gray100;
            colors.selectedColor = gray100;
            denjiLevel2Button.colors = colors;
            denjiLevel2Button.interactable = false;
        }

        if (!Data.instance.slimeFail && !Data.instance.slimeFostiados)
        {
            elidoraButton.GetComponent<Image>().color = gray100;
            var colors = elidoraButton.colors;
            colors.normalColor = gray100;
            colors.highlightedColor = gray100;
            colors.pressedColor = gray100;
            colors.selectedColor = gray100;
            elidoraButton.colors = colors;
            elidoraButton.interactable = false;
        }

        if (!Data.instance.giftTapicio)
        {
            salButton.GetComponent<Image>().color = gray100;
            var colors = salButton.colors;
            colors.normalColor = gray100;
            colors.highlightedColor = gray100;
            colors.pressedColor = gray100;
            colors.selectedColor = gray100;
            salButton.colors = colors;
            salButton.interactable = false;
        }
    }

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
