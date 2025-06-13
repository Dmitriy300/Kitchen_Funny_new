using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }


    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    public enum Binding 
    {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        Interact,
        InteractAlternate,
        Pause
    }


    private PlayerInputActions _playerInputActions;
    private void Awake()
    {
        Instance = this;
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();

        _playerInputActions.Player.Interact.performed += Interact_performed;
        _playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        _playerInputActions.Player.Pause.performed += Pause_performed;

    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Interact.performed -= Interact_performed;
        _playerInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        _playerInputActions.Player.Pause.performed -= Pause_performed;
        
        _playerInputActions.Dispose();
    }

    private void Pause_performed(InputAction.CallbackContext context)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("InteractAlternate_perform");
       OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
       
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);

    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {
            default:
            case Binding.Interact:
                return _playerInputActions.Player.Interact.bindings[0].ToDisplayString();
            case Binding.InteractAlternate:
                return _playerInputActions.Player.InteractAlternate.bindings[0].ToDisplayString();
            case Binding.Move_Up:
                return _playerInputActions.Player.Move.bindings[1].ToDisplayString();
            case Binding.Move_Down:
                return _playerInputActions.Player.Move.bindings[2].ToDisplayString();
            case Binding.Move_Left:
                return _playerInputActions.Player.Move.bindings[3].ToDisplayString();
            case Binding.Move_Right:
                return _playerInputActions.Player.Move.bindings[4].ToDisplayString();
            case Binding.Pause:
                return _playerInputActions.Player.Pause.bindings[0].ToDisplayString();

        }
    }

    public void RebindBinding(Binding binding)
    {
        _playerInputActions.Player.Disable();

        _playerInputActions.Player.Move.PerformInteractiveRebinding(1)
            .OnComplete(callback => { 
                Debug.Log(callback.action.bindings[1].path);
                Debug.Log(callback.action.bindings[1].overridePath);
                callback.Dispose();
                _playerInputActions.Player.Enable();

            })
            .Start();


    }

}
