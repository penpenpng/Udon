using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : SceneBase
{
    public static readonly string SceneName = "ResultScene";
    public int score = 0;

    void Start()
    {
        Debug.Log($"Enter game over scene. Score: {score}");
    }
}
