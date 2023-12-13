using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public event Action<int> CollectableEvent;

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

    public void StartCollectableCollectEvent(int id)
    {
        if (CollectableEvent != null)
        {
            CollectableEvent.Invoke(id);
        }
        else
        {
            Debug.LogWarning($"No event in CollectableEvent");
        }
    }
}