using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : SceneBase
{
    public static readonly string SceneName = "TitleScene";

    public void StartGame()
    {
        LoadScene<Stage1Scene>();
    }
}
