using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneControllerBase : MonoBehaviour
{
    protected void LoadScene<T>(string sceneName, UnityAction<T> onLoad = null) where T : SceneControllerBase
    {
        callback = (next, _) =>
        {
            var sceneManager = GameObject.FindGameObjectWithTag("SceneController").GetComponent<T>();

            onLoad?.Invoke(sceneManager);

            SceneManager.sceneLoaded -= callback;
        };

        SceneManager.sceneLoaded += callback;

        SceneManager.LoadSceneAsync(sceneName);
    }

    private UnityAction<Scene, LoadSceneMode> callback;
}
