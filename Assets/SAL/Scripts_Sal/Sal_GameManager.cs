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

    void Start()
    {
        totalGrassCells = GameObject.FindGameObjectsWithTag("Grass");   // Al iniciar, relleno el array con las que tengan tag Grass.

        totalMudCells = GameObject.FindGameObjectsWithTag("Mud");       // Al iniciar, relleno el array con las que tengan tag Mud.

        Time.timeScale = 1;

        currentScene = SceneManager.GetActiveScene();

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
        SceneManager.LoadScene("Level002");
    }

    public void Level03()
    {
        SceneManager.LoadScene("Level003");
    }

    public void Level04()
    {
        SceneManager.LoadScene("Level004");
    }

    public void Level05()
    {
        SceneManager.LoadScene("Level005");
    }

    public void Level06()
    {
        SceneManager.LoadScene("Level006");
    }

    public void Level07()
    {
        SceneManager.LoadScene("Level007");
    }

    public void Level08()
    {
        SceneManager.LoadScene("Level008");
    }

    public void Level09()
    {
        SceneManager.LoadScene("Level009");
    }

    public void Casa()
    {
        SceneManager.LoadScene("Home");
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
