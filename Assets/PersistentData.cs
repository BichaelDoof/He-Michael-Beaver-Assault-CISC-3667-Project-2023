using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    [SerializeField] int currentLevel;
    [SerializeField] int lastLevelScore;
    [SerializeField] int difficulty;
    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerName = "";
        currentLevel = 1;
        lastLevelScore = 0;
        difficulty = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }

    public void SetLevel(int s)
    {
        currentLevel = s;
    }

    public void SetLastLevelScore(int s)
    {
        lastLevelScore = s;
    }

    public void SetDifficulty(int s)
    {
        difficulty = s;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }
    public int GetLastLevelScore()
    {
        return lastLevelScore;
    }

    public int GetLevel()
    {
        return currentLevel;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }
}
