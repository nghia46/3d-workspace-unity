using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _eventSound;
    [SerializeField] private AudioClip[] sounds;
    private void Awake()
    {
        _eventSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
       // EventManager.Instance.CollectableEvent += PlayOrbSound;
    }

    private void PlayOrbSound()
    {
        _eventSound.resource = sounds[0];
        _eventSound.Play();
    }

    private void OnDisable()
    {
        //EventManager.Instance.CollectableEvent -= PlayOrbSound;
    }
}
