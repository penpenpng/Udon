using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFoot : MonoBehaviour
{
    private UnityAction action;

    public void SetTriggerCallback(UnityAction action)
    {
        this.action = action;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        action?.Invoke();
    }
}
