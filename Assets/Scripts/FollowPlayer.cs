using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerCameraPos;
    void Update()
    {
        playerCameraPos = GameObject.FindWithTag("PlayerCamera").transform;
        this.transform.position = playerCameraPos.position;
    }
}