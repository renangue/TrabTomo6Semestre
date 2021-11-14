using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetFollowTarget : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;

    GameObject player;

    public bool onStart;

    void Start()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        player = GameObject.FindGameObjectWithTag("Player");

        if (onStart)
            SetTarget();
    }

    public void SetCamera()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }
    public void SetTarget()
    {
        virtualCamera.Follow = player.transform;
    }

    public void SetTarget(Transform target)
    {
        virtualCamera.Follow = target;
    }
}
