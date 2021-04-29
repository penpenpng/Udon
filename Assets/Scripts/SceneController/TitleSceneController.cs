using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneController : SceneControllerBase
{
    // Sample code. Please replace it.
    void StartStage1()
    {
        LoadScene<StageSceneController>("Stage1Scene");
    }

    void Start()
    {
        StartStage1();
    }
}
