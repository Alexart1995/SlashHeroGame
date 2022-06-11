using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;

    private int scoreCount;

    private float scoreCountTimerTreshold = 1;
    private float scoreCountTimer;

    private bool canCount;
    public bool CanCount
    {
        get { return canCount; }
        set { canCount = value; }
    }

    private StringBuilder scoreStringBuilder = new StringBuilder();
    private void Start()
    {
        CanCount = true;
        scoreCountTimer = Time.time + scoreCountTimerTreshold;
    }
    private void Update()
    {
        if (!CanCount)
            return;

        if (Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerTreshold;
            scoreCount++;
            DisplayScore(scoreCount);
        }
    }
    void DisplayScore(int score)
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append(score);
        scoreStringBuilder.Append("M");
        ScoreText.text = scoreStringBuilder.ToString();
    }
    public int GetScore()
    {
        return scoreCount;
    }
}
