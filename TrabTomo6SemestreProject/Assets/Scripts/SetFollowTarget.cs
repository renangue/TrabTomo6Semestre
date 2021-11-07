using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetFollowTarget : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;

    GameObject player;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        player = GameObject.FindGameObjectWithTag("Player");

        virtualCamera.Follow = player.transform;
    }
}
