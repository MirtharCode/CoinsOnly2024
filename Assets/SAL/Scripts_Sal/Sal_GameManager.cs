using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class Sal_GameManager : MonoBehaviour
{
    public GameObject[] totalGrassCells, totalMudCells;     // Arrays de GameObjects que contarán cuantas hay de cada en el Start.
    public int totalPaintedCells;                           // Contador de celdas pintadas.
    public GameObject canvasMessage, volumenSlider;         // GameObject que rellenamos desde el editor con el canvas de escena.
    public Slider musicVolumeSlider, soundVolumeSlider;
    public float secondsPorSiAcasing = 0;                   // Contador que usaremos para ralentizar la salida de la victoria.
    public bool yaSaliMama = false;                         // Booleano que nos permite que solo salga una vez el cartel de victoria.
    public bool birdMoving = false;                         // Booleano que nos permite que si es verdadero, el pájaro se mueva una casilla.

    public float _musicVolumeSlider, _soundVolumeSlider;
    [SerializeField] public Scene currentScene;
    [SerializeField] public bool heGanado = false;
    [SerializeField] private Button[] levelsButtons;
    AudioSource audioSource;

    void Start()
    {
        DialogueManager.Instance.postPro.gameObject.SetActive(false);

        totalGrassCells = GameObject.FindGameObjectsWithTag("Grass");   // Al iniciar, relleno el array con las que tengan tag Grass.

        totalMudCells = GameObject.FindGameObjectsWithTag("Mud");       // Al iniciar, relleno el array con las que tengan tag Mud.

        Time.timeScale = 1;

        currentScene = SceneManager.GetActiveScene();

        MakeButtonsGrey();
        audioSource = GetComponent<AudioSource>();

        //if (PlayerPrefs.GetFloat("MusicVolumen") != 1)
        //{
        //    PlayerPrefs.SetFloat("MusicVolumen", musicVolumeSlider.value);
        //    _musicVolumeSlider = PlayerPrefs.GetFloat("MusicVolumen");
        //    PlayerPrefs.Save();
        //}

        //if (PlayerPrefs.GetFloat("SoundVolumen") != 1)
        //{
        //    PlayerPrefs.SetFloat("SoundVolumen", soundVolumeSlider.value);
        //    _soundVolumeSlider = PlayerPrefs.GetFloat("SoundVolumen");
        //    PlayerPrefs.Save();
        //}
    }

    void MakeButtonsGrey()
    {
        if (currentScene.name == "LevelSelector")
        {
            Color gray100 = new Color(0.392f, 0.392f, 0.392f, 1f);

            if (!Data.instance.fase1Check)
            {
                levelsButtons[1].GetComponent<Image>().color = gray100;
                var colors = levelsButtons[1].colors;
                colors.normalColor = gray100;
                colors.highlightedColor = gray100;
                colors.pressedColor = gray100;
                colors.selectedColor = gray100;
                levelsButtons[1].colors = colors;

                IsActiveButton(1);
            }

            if (!Data.instance.fase2Check)
            {
                levelsButtons[2].GetComponent<Image>().color = gray100;
                var colors = levelsButtons[2].colors;
                colors.normalColor = gray100;
                colors.highlightedColor = gray100;
                colors.pressedColor = gray100;
                colors.selectedColor = gray100;
                levelsButtons[2].colors = colors;

                IsActiveButton(2);
            }

            if (!Data.instance.fase3Check)
            {
                levelsButtons[3].GetComponent<Image>().color = gray100;
                var colors = levelsButtons[3].colors;
                colors.normalColor = gray100;
                colors.highlightedColor = gray100;
                colors.pressedColor = gray100;
                colors.selectedColor = gray100;
                levelsButtons[3].colors = colors;

                IsActiveButton(3);
            }

            if (!Data.instance.fase4Check)
            {
                levelsButtons[4].GetComponent<Image>().color = gray100;
                var colors = levelsButtons[4].colors;
                colors.normalColor = gray100;
                colors.highlightedColor = gray100;
                colors.pressedColor = gray100;
                colors.selectedColor = gray100;
                levelsButtons[4].colors = colors;

                IsActiveButton(4);
            }

            if (!Data.instance.fase5Check)
            {
                levelsButtons[5].GetComponent<Image>().color = gray100;
                var colors = levelsButtons[5].colors;
                colors.normalColor = gray100;
                colors.highlightedColor = gray100;
                colors.pressedColor = gray100;
                colors.selectedColor = gray100;
                levelsButtons[5].colors = colors;

                IsActiveButton(5);
            }

            if (!Data.instance.fase6Check)
            {
                levelsButtons[6].GetComponent<Image>().color = gray100;
                var colors = levelsButtons[6].colors;
                colors.normalColor = gray100;
                colors.highlightedColor = gray100;
                colors.pressedColor = gray100;
                colors.selectedColor = gray100;
                levelsButtons[6].colors = colors;

                IsActiveButton(6);
            }

            if (!Data.instance.fase7Check)
            {
                levelsButtons[7].GetComponent<Image>().color = gray100;
                var colors = levelsButtons[7].colors;
                colors.normalColor = gray100;
                colors.highlightedColor = gray100;
                colors.pressedColor = gray100;
                colors.selectedColor = gray100;
                levelsButtons[7].colors = colors;

                IsActiveButton(7);
            }

            if (!Data.instance.fase8Check)
            {
                levelsButtons[8].GetComponent<Image>().color = gray100;
                var colors = levelsButtons[8].colors;
                colors.normalColor = gray100;
                colors.highlightedColor = gray100;
                colors.pressedColor = gray100;
                colors.selectedColor = gray100;
                levelsButtons[8].colors = colors;

                IsActiveButton(8);
            }
        }
    }

    void Update()
    {
        ComprobandoSiGanaste();    // Llamo a esta función cada frame para que mire si tiene que lanzar el cartel de victoria.
    }

    public void ComprobandoSiGanaste()
    {
        // Si todas las celdas menos 1 (en la que queda Anacleto) están pintadas y el cartel de derrota no está activo,
        // lanzo la función que hace aparecer el cartel de victoria con un leve delay.
        if ((totalPaintedCells == totalGrassCells.Length + totalMudCells.Length - 1)
            && !canvasMessage.transform.GetChild(1).gameObject.activeInHierarchy)
            WaitingPorSiAcasing();
    }



    public void LevelSelector()
    {
        if (heGanado)
        {
            if (currentScene.name.Contains("001"))
                Data.instance.fase1Check = true;
            else if (currentScene.name.Contains("002"))
                Data.instance.fase2Check = true;
            else if (currentScene.name.Contains("003"))
                Data.instance.fase3Check = true;
            else if (currentScene.name.Contains("004"))
                Data.instance.fase4Check = true;
            else if (currentScene.name.Contains("005"))
                Data.instance.fase5Check = true;
            else if (currentScene.name.Contains("006"))
                Data.instance.fase6Check = true;
            else if (currentScene.name.Contains("007"))
                Data.instance.fase7Check = true;
            else if (currentScene.name.Contains("008"))
                Data.instance.fase8Check = true;
            else if (currentScene.name.Contains("009"))
                Data.instance.fase9Check = true;
        }
        SceneManager.LoadScene("LevelSelector");
    }


    public void Level01()
    {
        SceneManager.LoadScene("Level001");
    }

    public void Level02()
    {
        if (Data.instance.fase1Check)
        {
            SceneManager.LoadScene("Level002");
        }

        else
        {
            Debug.Log("Nivel bloqueado");
            StartCoroutine(PlayButtonAnimBool(1));
        }
    }

    public void Level03()
    {
        if (Data.instance.fase2Check)
        {
            SceneManager.LoadScene("Level003");
        }
        else
        {
            Debug.Log("Nivel bloqueado");
            StartCoroutine(PlayButtonAnimBool(2));
        }
    }

    public void Level04()
    {
        if (Data.instance.fase3Check)
        {
            SceneManager.LoadScene("Level004");
        }
        else
        {
            Debug.Log("Nivel bloqueado");
            StartCoroutine(PlayButtonAnimBool(3));
        }
    }

    public void Level05()
    {
        if (Data.instance.fase4Check)
        {
            SceneManager.LoadScene("Level005");
        }
        else
        {
            Debug.Log("Nivel bloqueado");
            StartCoroutine(PlayButtonAnimBool(4));
        }
    }

    public void Level06()
    {
        if (Data.instance.fase5Check)
        {
            SceneManager.LoadScene("Level006");
        }
        else
        {
            Debug.Log("Nivel bloqueado");
            StartCoroutine(PlayButtonAnimBool(5));
        }
    }

    public void Level07()
    {
        if (Data.instance.fase6Check)
        {
            SceneManager.LoadScene("Level007");
        }
        else
        {
            Debug.Log("Nivel bloqueado");
            StartCoroutine(PlayButtonAnimBool(6));
        }
    }

    public void Level08()
    {
        if (Data.instance.fase7Check)
        {
            SceneManager.LoadScene("Level008");
        }
        else
        {
            Debug.Log("Nivel bloqueado");
            StartCoroutine(PlayButtonAnimBool(7));
        }
    }

    public void Level09()
    {
        if (Data.instance.fase8Check)
        {
            SceneManager.LoadScene("Level009");
        }
        else
        {
            Debug.Log("Nivel bloqueado");
            StartCoroutine(PlayButtonAnimBool(8));
        }
    }

    private IEnumerator PlayButtonAnimBool(int buttonIndex)
    {
        Animator anim = levelsButtons[buttonIndex].GetComponent<Animator>();
        if (anim == null) yield break;

        anim.SetBool("WasClicked", true);
        yield return new WaitForSeconds(0.01f);
        anim.SetBool("WasClicked", false);

        audioSource.Play();
    }

    void IsActiveButton(int buttonIndex)
    {
        Animator anim = levelsButtons[buttonIndex].GetComponent<Animator>();

        anim.SetBool("Blocked", true);
    }

    public void Casa()
    {
        if (!Data.instance.doYouComeFromMinigameSelectorMenu)
        {
            Data.instance.doYouComeFromMinigameSelectorMenu = false;
            SceneManager.LoadScene("Home");
        }

        else
        {
            Data.instance.doYouComeFromMinigameSelectorMenu = false;
            SceneManager.LoadScene("MenuInicial");
        }
    }

    // Función que la agrego al botón de la pantalla de derrota y dependiendo del nombre de la escena, recargo una u otra.
    public void SoyMancoAiuda()
    {
        SceneManager.LoadScene(currentScene.name);
    }

    public void GanastePibe()
    {

        SceneManager.LoadScene("LevelSelector"); ;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvasMessage.transform.GetChild(2).gameObject.SetActive(false);
    }

    // Función que genera un delay cuando ya todo está pintado,
    // por si has acabado estrellándote contra la sal como última casilla,
    // haciendo que no sea válida esa victoria, y por ello, salga antes la pantalla de derrota.
    public void WaitingPorSiAcasing()
    {
        // Hago que el contador suba en función del tiempo que pase.
        heGanado = true;
        secondsPorSiAcasing += Time.deltaTime;

        // Si ese contador llega a más de 0,3 y no ha salido a el cartel de victoria...
        if (secondsPorSiAcasing >= 0.3f && !yaSaliMama)
        {
            yaSaliMama = true;                                              // Pongo el bool en true para que no vuelva a entrar aquí.
            secondsPorSiAcasing = 0;                                        // Seteo el contador a 0.
            canvasMessage.transform.GetChild(0).gameObject.SetActive(true); // Activo la pantalla de victoria.
        }
    }
}
