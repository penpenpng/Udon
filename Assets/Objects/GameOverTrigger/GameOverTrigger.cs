using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var sceneManager = GameObject.FindGameObjectWithTag("SceneController").GetComponent<StageSceneBase>();

        // XXX: Use message instead
        sceneManager.EnterGameOverScene();
    }
}
