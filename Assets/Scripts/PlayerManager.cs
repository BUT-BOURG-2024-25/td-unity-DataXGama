using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerLayout;

    [SerializeField]
    private CinemachineVirtualCamera VirtualCamera;

    [SerializeField]
    private Vector3 SpawnPosition;

    public static GameObject Player;

    public static PlayerManager Instance { get { return instance; } }
    private static PlayerManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Player = GameObject.Instantiate(PlayerLayout);
        VirtualCamera.Follow = Player.transform;
        VirtualCamera.LookAt = Player.transform;
    }


    public void DestroyPlayer(GameObject player)
    {
        player.transform.position = SpawnPosition;
    }
}
