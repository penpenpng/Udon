using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneBase : MonoBehaviour
{
    protected void LoadScene<T>(UnityAction<T> onLoad = null)
    where T : SceneBase, new()
    {
        string sceneName = new Func<string>(() =>
        {
            const string sceneNameField = "SceneName";

            try
            {
                return (string)typeof(T).GetField(sceneNameField).GetValue(null);
            }
            catch (NullReferenceException)
            {
                throw new LogicException($"staic field {sceneNameField} is not defined");
            }
        })();


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
