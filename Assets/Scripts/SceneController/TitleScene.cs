using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBase
{
    public static readonly string SceneName = "TitleScene";

    // Sample code. Please replace it.
    void StartStage1()
    {
        LoadScene<Stage1Scene>();
    }

    void Start()
    {
        StartStage1();
    }
}
