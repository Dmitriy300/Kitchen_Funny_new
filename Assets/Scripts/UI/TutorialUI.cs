using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _keyMoveUpText;
    [SerializeField] private TextMeshProUGUI _keyMoveDownText;
    [SerializeField] private TextMeshProUGUI _keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI _keyMoveRightText;
    [SerializeField] private TextMeshProUGUI _keyMoveInteractText;
    [SerializeField] private TextMeshProUGUI _keyMoveInteractAlternateText;
    [SerializeField] private TextMeshProUGUI _keyMovePauseText;
    [SerializeField] private TextMeshProUGUI _keyMoveGamepadInteractText;
    [SerializeField] private TextMeshProUGUI _keyMoveGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI _keyMoveGamepadPauseText;


    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        
        UpdateVisual();

        Show();

    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
        
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        _keyMoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        _keyMoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        _keyMoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        _keyMoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        _keyMoveInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        _keyMoveInteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        _keyMovePauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        _keyMoveGamepadInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        _keyMoveGamepadInteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        _keyMoveGamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
      
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
