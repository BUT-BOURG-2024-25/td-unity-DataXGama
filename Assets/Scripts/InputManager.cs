using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputActionReference MovementAction;

    [SerializeField]
    private InputActionReference JumpAction;

    [SerializeField]
    private InputActionReference RichtClickAction;

    public static InputManager Instance { get { return instance; } }
    private static InputManager instance = null;

    public Vector3 Direction { get; private set; } = Vector3.zero;

    private void Awake()
    {
        if(instance == null){
            instance = this;
        }else {
            Destroy(gameObject);
        }
    }

    public void RegisterOnRightClick(Action<InputAction.CallbackContext> onRightClick)
    {
        RichtClickAction.action.performed += onRightClick;
    }
    public void UnregisterOnRightClick(Action<InputAction.CallbackContext> onRightClick)
    {
        RichtClickAction.action.performed -= onRightClick;
    }

    public void RegisterOnJump(Action<InputAction.CallbackContext> onJumpAction)
    {
        JumpAction.action.performed += onJumpAction;
    }

    public void UnregisterOnJump(Action<InputAction.CallbackContext> onJumpAction)
    {
        JumpAction.action.performed -= onJumpAction;
    }

    void Update()
    {
        Vector2 moveInput = MovementAction.action.ReadValue<Vector2>();
        Vector3 moveInput3 = new(moveInput.x, 0, moveInput.y);

        this.Direction = moveInput3.magnitude == 0f ? Vector3.zero : moveInput3.normalized;
    }
}
