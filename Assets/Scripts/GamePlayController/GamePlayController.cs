using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

    [SerializeField]
    private Button instructionButton;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Text scoreText, endScoreText, hightScoreText;

    public static GamePlayController instace;

    private void Awake()
    {
        Time.timeScale = 0;
        MakeInstace();
    }

    private void MakeInstace()
    {
        if (instace == null) instace = this;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void ShowGameOverPanel(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = score.ToString();
        if (score > MainManager.instance.GetHightScore())
        {
            MainManager.instance.SetHightScore(score);
        }
        hightScoreText.text = MainManager.instance.GetHightScore().ToString();
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void MenuButton()
    {
        Application.LoadLevel(0);
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
