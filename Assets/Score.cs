using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] int score;
    const int DEFAULT_POINTS = 1;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text levelTxt;
    [SerializeField] TMP_Text nameTxt;
    [SerializeField] TMP_Text difficultyTxt;
    [SerializeField] int level;
    [SerializeField] int difficulty;
    const int SCORE_THRESHOLD_PER_LEVEL = 25;
    [SerializeField] int scoreThresholdForThisLevel;
    [SerializeField] float timeLimit = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex;
        difficulty = PersistentData.Instance.GetDifficulty();
        scoreThresholdForThisLevel = SCORE_THRESHOLD_PER_LEVEL * (level * level * difficulty);
        DisplayScore();
        DisplayLevel();
        DisplayName();
        DisplayDifficulty(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        if(timeLimit <= 0.0f)
        {
            if(score <= scoreThresholdForThisLevel)
            {
               SceneManager.LoadScene("Game Over");
            }
        }
    }

    public void UpdateScore(int addend)
    {
        score += addend;
        Debug.Log("score" + score);
        //display score
        DisplayScore();
        PersistentData.Instance.SetScore(score);

        if (score >= scoreThresholdForThisLevel)
        {
            //move on to next level
            PersistentData.Instance.SetLevel(level + 1);
            PersistentData.Instance.SetLastLevelScore(score);
            SceneManager.LoadScene(level + 1);
        }
    }

    public void UpdateScore()
    {
        UpdateScore(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        int levelToDisplay = level;
        levelTxt.text = "Level " + levelToDisplay;
    }

    public void DisplayName()
    {
        nameTxt.text = "Player: " + PersistentData.Instance.GetName();
    }

    public void DisplayDifficulty(int difficulty)
    {
        string diff = "";
        if(difficulty == 1)
        {
            diff = "Easy";
        }
        if(difficulty == 2)
        {
            diff = "Normal";
        }
        if(difficulty == 3)
        {
            diff = "Hard";
        }
        difficultyTxt.text = diff;
    }
}
