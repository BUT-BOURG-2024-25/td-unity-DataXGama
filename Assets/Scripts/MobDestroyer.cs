using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MobDestroyer : MonoBehaviour
{
    [SerializeField]
    private int AttackRadius = 5;

    void Start()
    {
        InputManager.Instance.RegisterOnRightClick(Click);
    }

    void Click(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            MobSpawner.Instance.DestroyAllAround(hit.point, AttackRadius);
        }
    }
}
