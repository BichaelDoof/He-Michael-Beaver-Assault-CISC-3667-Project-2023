using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Difficulty : MonoBehaviour
{
    [SerializeField] TMP_Text difficultyTxt;
    // Start is called before the first frame update
    void Start()
    {
        int difficult = PersistentData.Instance.GetDifficulty();
        DisplayDifficulty(difficult);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        difficultyTxt.text = "Current Difficulty: " + diff;
    }
    public void SetEasy()
    {
        int difficult = 1;
        PersistentData.Instance.SetDifficulty(difficult);
        DisplayDifficulty(difficult);
    }
    public void SetNormal()
    {
        int difficult = 2;
        PersistentData.Instance.SetDifficulty(difficult);
        DisplayDifficulty(difficult);
    }
    public void SetHard()
    {
        int difficult = 3;
        PersistentData.Instance.SetDifficulty(difficult);
        DisplayDifficulty(difficult);
    }
}
