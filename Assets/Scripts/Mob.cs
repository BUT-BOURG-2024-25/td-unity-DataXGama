using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField]
    private float Speed = 2;

    private GameObject player;

    void Update()
    {
        if (PlayerManager.Player != null)
        {

            Vector3 direction = PlayerManager.Player.transform.position - gameObject.transform.position;
            direction.y = 0;

            gameObject.transform.position += direction.normalized * Speed * Time.deltaTime;
        }
    }
}
