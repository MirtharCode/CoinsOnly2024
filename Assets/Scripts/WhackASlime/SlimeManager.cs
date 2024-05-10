using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeManager : MonoBehaviour
{
    [Header("CURSOR RESHULO")]
    [SerializeField] public GameObject cursor;

    [SerializeField] private List<Slime> slimes;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject fTB;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private float startingTime = 30f;
    private float timeRemaining;

    private HashSet<Slime> currentSlimes = new HashSet<Slime>();

    private int score;
    private bool playing = false;

    [SerializeField] GameObject canvas;
    public Scene currentScene;

    void Start()
    {
        GameObject newCursor = Instantiate(cursor, canvas.transform);
        currentScene = SceneManager.GetActiveScene();
        score = 0;
    }

    void Update()
    {
        if (playing)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameOver(0);
            }

            timeText.text = $"{(int)timeRemaining / 60}:{(int)timeRemaining % 60:D2}";

            if (currentSlimes.Count <= (score / 10))
            {
                int index = Random.Range(0, slimes.Count);

                if (!currentSlimes.Contains(slimes[index]))
                {
                    currentSlimes.Add(slimes[index]);
                    slimes[index].Activate(score / 10);
                }
            }
        }
    }

    public void StartGame()
    {
        playButton.SetActive(false);
        gameUI.SetActive(true);
        score = 0;

        for (int i = 0; i < slimes.Count; i++)
        {
            slimes[i].gameObject.SetActive(true);
            slimes[i].Hide();
            slimes[i].SetIndex(i);
        }

        currentSlimes.Clear();

        timeRemaining = startingTime;
        score = 0;
        scoreText.text = score.ToString();
        playing = true;
    }

    public void GameOver(int type)
    {
        if (type == 0)
            OutOfTimeEnd();
        else
            ElidoraHit();

        foreach (Slime slime in slimes)
        {
            slime.StopGame();
        }

        playing = false;
    }

    public void AddScore(int slimeIndex)
    {
        score += 1;
        scoreText.text = $"{score}";
        timeRemaining += .1f;

        currentSlimes.Remove(slimes[slimeIndex]);
    }

    public void AddScoreHat(int slimeIndex)
    {
        score += 3;
        scoreText.text = $"{score}";
        timeRemaining += .15f;

        currentSlimes.Remove(slimes[slimeIndex]);
    }

    public void Missed(int slimeIndex, bool isSlime)
    {
        //if (isSlime)
        //{
        //    timeRemaining -= 2;
        //}

        currentSlimes.Remove(slimes[slimeIndex]);
    }

    public void Restart()
    {
        StartGame();
    }

    public void OutOfTimeEnd()
    {
        Data.instance.GetComponent<Data>().slimeFostiados = true;

        if (score < 50)
            Data.instance.GetComponent<Data>().slimeFail = true;

        fTB.GetComponent<FadeToBlack>().FadeToBlackAnywhere();

    }

    public void ElidoraHit()
    {
        Data.instance.GetComponent<Data>().slimeFostiados = true;
        Data.instance.GetComponent<Data>().slimeFail = true;
        Data.instance.GetComponent<Data>().elidoraAcariciada = true;
        fTB.GetComponent<FadeToBlack>().FadeToBlackAnywhere();
    }
}
