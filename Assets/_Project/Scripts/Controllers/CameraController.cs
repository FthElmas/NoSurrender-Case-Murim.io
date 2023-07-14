using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace NoSurrender.Control
{
    public class CameraController : MonoBehaviour
    {
        private CinemachineVirtualCamera cinemachineCamera;
        private CinemachineTransposer transposer;
        PlayerController _player;

        private void Awake()
        {
            cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
            transposer = cinemachineCamera.GetCinemachineComponent<CinemachineTransposer>();
        }
        private void Start()
        {
            _player = GameObject.FindObjectOfType<PlayerController>();
            cinemachineCamera.Follow = _player.transform;
            
        }

        
    }

}
