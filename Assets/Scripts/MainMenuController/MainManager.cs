using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public static MainManager instance;

    private const string HIGHT_SCORE = "Hight Score";

    private void Awake()
    {
        MakeSigleInstance();
        IsGameStartedForTheFirstTime();
    }

    private void MakeSigleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGHT_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }

    public void SetHightScore(int score)
    {
        PlayerPrefs.SetInt(HIGHT_SCORE, score);
    }

    public int GetHightScore()
    {
        return PlayerPrefs.GetInt(HIGHT_SCORE);
    }
}
