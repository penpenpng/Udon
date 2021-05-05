using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : SceneBase
{
    public static readonly string SceneName = "ResultScene";
    public int score = 0;
    public Text ScoreText;

    void Start()
    {
        Debug.Log($"Enter game over scene. Score: {score}");
        ScoreText.text = score.ToString();
    }

    public void Restart()
    {
        LoadScene<Stage1Scene>();
    }

    public void BackToTitle()
    {
        LoadScene<TitleScene>();
    }
}
