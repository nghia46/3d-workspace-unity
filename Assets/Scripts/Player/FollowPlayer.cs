using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform _playerCameraPos;
    void Update()
    {
        _playerCameraPos = GameObject.FindWithTag("PlayerCamera").transform;
        this.transform.position = _playerCameraPos.position;
    }
}