using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScene : SceneBase
{
    public static readonly string SceneName = "ClearScene";
    public int score = 0;

    void Start()
    {
        Debug.Log($"Enter clear scene. Score: {score}");
    }
}
