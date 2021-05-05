using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScene : SceneBase
{
    public static readonly string SceneName = "ClearScene";
    public int score = 0;
    public Text ScoreText;

    void Start()
    {
        Debug.Log($"Enter clear scene. Score: {score}");
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
