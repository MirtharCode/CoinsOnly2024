using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    [SerializeField] private List<Slime> slimes;
    [SerializeField] private GameObject playButton;
    private float startingTime = 30f;
    private float timeRemaining;

    private HashSet<Slime> currentSlimes = new HashSet<Slime>();

    private int score;
    private bool playing = false;

    void Start()
    {

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

        for (int i = 0; i < slimes.Count; i++)
        {
            slimes[i].Hide();
            slimes[i].SetIndex(i);
        }

        currentSlimes.Clear();

        timeRemaining = startingTime;
        score = 0;
        playing = true;
    }

    public void GameOver(int type)
    {
        playing = false;
        playButton.SetActive(true);
    }

    public void AddScore(int slimeIndex)
    {
        score += 1;
        timeRemaining += 1;

        currentSlimes.Remove(slimes[slimeIndex]);
    }

    public void Missed(int slimeIndex, bool isSlime)
    {
        if (isSlime)
        {
            timeRemaining -= 2;
        }

        currentSlimes.Remove(slimes[slimeIndex]);
    }
}
