using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSceneBase : SceneBase
{
    private int score = 0;


    public void AddScore()
    {
        score++;
    }

    public void EnterClearScene()
    {
        LoadScene<ClearScene>((s) =>
        {
            s.score = score;
        });
    }

    public void EnterGameOverScene()
    {
        LoadScene<ResultScene>((s) =>
        {
            s.score = score;
        });
    }
}
