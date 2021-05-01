using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearToResultButton : MonoBehaviour
{
    public void OnClickButton(){
        var sceneManager = GameObject.FindGameObjectWithTag("SceneController").GetComponent<ClearScene>();
        sceneManager.LoadScene<ResultScene>();
    }
}
