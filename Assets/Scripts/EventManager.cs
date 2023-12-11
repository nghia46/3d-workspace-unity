using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public event Action<bool> CollectableEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartCollectableCollectEvent(bool isTrue)
    {
        if (CollectableEvent != null)
        {
            CollectableEvent.Invoke(isTrue);
        }
        else
        {
            Debug.LogWarning($"No event in CollectableEvent");
        }
    }
}
