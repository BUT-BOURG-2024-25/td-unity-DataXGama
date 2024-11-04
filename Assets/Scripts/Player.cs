using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1.0f;

    [SerializeField]
    private float JumpPower = 20.0f;

    [SerializeField]
    private Rigidbody physicsBody;


    void Start()
    {
        InputManager.Instance.registerOnJump(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionVelocity = Speed * InputManager.Instance.Direction;
        Vector3 targettedVelocity = new(directionVelocity.x, physicsBody.velocity.y, directionVelocity.z);
        physicsBody.velocity = Vector3.Lerp(physicsBody.velocity, targettedVelocity, .05f);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        physicsBody.AddForce(Vector3.up * JumpPower);
    }
}
