using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private bool isDecrease;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        EventManager.Instance.StartCollectableCollectEvent(isDecrease);
        Destroy(this.gameObject);
    }
}
