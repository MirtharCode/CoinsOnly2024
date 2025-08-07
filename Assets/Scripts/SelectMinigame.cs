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

    [SerializeField] private Sprite disabledSalButtonSprite;
    [SerializeField] private Sprite disabledDenji1ButtonSprite;
    [SerializeField] private Sprite disabledDenji2ButtonSprite;
    [SerializeField] private Sprite disabledElidoraButtonSprite;

    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");

        if (!Data.instance.meExplotasteElCulo1 && !Data.instance.samuraiAyudado1)
        {
            denjiLevel1Button.GetComponent<Image>().sprite = disabledDenji1ButtonSprite;
            denjiLevel1Button.interactable = false;
        }

        if (!Data.instance.meExplotasteElCulo2 && !Data.instance.samuraiAyudado2)
        {
            denjiLevel2Button.GetComponent<Image>().sprite = disabledDenji2ButtonSprite;
            denjiLevel2Button.interactable = false;
        }

        if (!Data.instance.slimeFail && !Data.instance.slimeFostiados)
        {
            elidoraButton.GetComponent<Image>().sprite = disabledElidoraButtonSprite;
            elidoraButton.interactable = false;
        }

        if (!Data.instance.giftTapicio)
        {
            salButton.GetComponent<Image>().sprite = disabledSalButtonSprite;
            salButton.interactable = false;
        }


        //Color gray100 = new Color(0.392f, 0.392f, 0.392f, 1f);

        //if (!Data.instance.meExplotasteElCulo1 && !Data.instance.samuraiAyudado1)
        //{
        //    denjiLevel1Button.GetComponent<Image>().color = gray100;
        //    var colors = denjiLevel1Button.colors;
        //    colors.normalColor = gray100;
        //    colors.highlightedColor = gray100;
        //    colors.pressedColor = gray100;
        //    colors.selectedColor = gray100;
        //    denjiLevel1Button.colors = colors;
        //    denjiLevel1Button.interactable = false;
        //}

        //if (!Data.instance.meExplotasteElCulo2 && !Data.instance.samuraiAyudado2)
        //{
        //    denjiLevel2Button.GetComponent<Image>().color = gray100;
        //    var colors = denjiLevel2Button.colors;
        //    colors.normalColor = gray100;
        //    colors.highlightedColor = gray100;
        //    colors.pressedColor = gray100;
        //    colors.selectedColor = gray100;
        //    denjiLevel2Button.colors = colors;
        //    denjiLevel2Button.interactable = false;
        //}

        //if (!Data.instance.slimeFail && !Data.instance.slimeFostiados)
        //{
        //    elidoraButton.GetComponent<Image>().color = gray100;
        //    var colors = elidoraButton.colors;
        //    colors.normalColor = gray100;
        //    colors.highlightedColor = gray100;
        //    colors.pressedColor = gray100;
        //    colors.selectedColor = gray100;
        //    elidoraButton.colors = colors;
        //    elidoraButton.interactable = false;
        //}

        //if (!Data.instance.giftTapicio)
        //{
        //    salButton.GetComponent<Image>().color = gray100;
        //    var colors = salButton.colors;
        //    colors.normalColor = gray100;
        //    colors.highlightedColor = gray100;
        //    colors.pressedColor = gray100;
        //    colors.selectedColor = gray100;
        //    salButton.colors = colors;
        //    salButton.interactable = false;
        //}
    }

    public void GoSalGame()
    {
        Data.instance.doYouComeFromMinigameSelectorMenu = true;
        SceneManager.LoadScene("LevelSelector");
    }

    public void GoDenjiGame1()
    {
        Data.instance.doYouComeFromMinigameSelectorMenu = true;
        SceneManager.LoadScene("DenjirenjiMinijuego01");
    }

    public void GoDenjiGame2()
    {
        Data.instance.doYouComeFromMinigameSelectorMenu = true;
        SceneManager.LoadScene("DenjirenjiMinijuego02");
    }

    public void GoElidoraGame()
    {
        Data.instance.doYouComeFromMinigameSelectorMenu = true;
        SceneManager.LoadScene("ElidoraMinijuego");
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
}
