using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectToSpawn;

    [SerializeField]
    private LayerMask GroundLayer;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.RegisterOnRightClick(OnClick);
    }

    void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new();

        if (Physics.Raycast(ray, out hit, 100000, GroundLayer))
        {
            GameObject.Instantiate(ObjectToSpawn, hit.point, Quaternion.identity);
        }
    }
}
