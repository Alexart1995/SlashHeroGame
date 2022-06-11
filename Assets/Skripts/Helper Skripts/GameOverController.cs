using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Canvas gameoverPanel;

    [SerializeField]
    private Text currentScore, bestScore;

    private ScoreCounter scoreCounter;

    private void Awake()
    {
        scoreCounter = GetComponent<ScoreCounter>();
    }
    public void ShowGameOverCanvas()
    {
        //scoreCounter.CanCount = false;
        Time.timeScale = 0f;
        gameoverPanel.enabled = true;
        DisplayScore();
        CheckToUnlockNewCharacters(scoreCounter.GetScore());
    }
    void DisplayScore()
    {
        int highscore = DataManager.GetData(TagHelper.highscoreData);
        if (scoreCounter.GetScore() > highscore)
            DataManager.SaveData(TagHelper.highscoreData, scoreCounter.GetScore());
        currentScore.text = "Score: " + scoreCounter.GetScore() + "M";
        bestScore.text = "Best: " + DataManager.GetData(TagHelper.highscoreData) + "M";
    }
    void CheckToUnlockNewCharacters(int score)
    {
        GameplayController.instance.CheckToUnlockCharacter(score);
    }
}
