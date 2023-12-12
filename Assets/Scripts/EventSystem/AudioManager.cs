using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sounds;
    private enum SoundType
    {
        Increase,
        Decrease,
        Health
    }
    private void Start()
    {
        EventManager.Instance.CollectableEvent += PlayOrbSound;
    }

    private void PlayOrbSound(int triggerId)
    {
        switch (triggerId)
        {
            case 0: sounds[(int)SoundType.Increase].Play();
                break;
            case 1: sounds[(int)SoundType.Decrease].Play();
                break;
            case 2: sounds[(int)SoundType.Health].Play();
                break;
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.CollectableEvent -= PlayOrbSound;
    }
}