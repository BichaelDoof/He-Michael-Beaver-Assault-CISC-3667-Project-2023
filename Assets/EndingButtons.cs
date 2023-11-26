using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplayGame()
    {
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("Level 1");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Title()
    {
        PersistentData.Instance.SetScore(0);
        PersistentData.Instance.SetName("");
        SceneManager.LoadScene("Start");
    }

    public void TryAgain()
    {
        int lastLevel = PersistentData.Instance.GetLevel();
        int lastLevelScore = PersistentData.Instance.GetLastLevelScore();
        PersistentData.Instance.SetScore(lastLevelScore);
        SceneManager.LoadScene("Level " + lastLevel);
    }
}
