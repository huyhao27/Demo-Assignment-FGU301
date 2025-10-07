using UnityEngine;
using UnityEngine.InputSystem; 

public class NewInputHandler : MonoBehaviour, IPlayerInput
{
    private PlayerControls controls;
    private Vector2 moveValue;
    private bool jumpTriggered;

    // Implement Interface
    public Vector2 MoveInput => moveValue;
    public bool JumpInputDown => jumpTriggered;


    void Awake()
    {
        controls = new PlayerControls();

        controls.GamePlay.Move.performed += ctx => moveValue = ctx.ReadValue<Vector2>();
        controls.GamePlay.Move.canceled += ctx => moveValue = Vector2.zero;

        controls.GamePlay.Jump.performed += ctx => jumpTriggered = true;
    }

    void LateUpdate()
    {
        jumpTriggered = false;
    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    void OnDisable()
    {
        controls.GamePlay.Disable();
    }
    
    public void RemapJumpKey()
    {
        controls.GamePlay.Disable();

        var jumpAction = controls.GamePlay.Jump;
    
        jumpAction.PerformInteractiveRebinding()
            .OnComplete(operation => 
            {
                controls.GamePlay.Enable();
                Debug.Log($"Rebound Jump key to: {operation.action.bindings[0].effectivePath}");
                operation.Dispose(); 
            })
            .Start(); 
    }
}