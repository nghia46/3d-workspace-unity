using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gunHolder;
    [SerializeField] private GameObject bullet;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(bullet, gunHolder.position, gunHolder.rotation,GameObject.FindWithTag($"GarbagePool").transform);
    }
}
