using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class GamesStartCountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countDownText;

    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
       if (KitchenGameManager.Instance.IsCountdownToStartActive())
       {
            Show();
       }
       else
       {
            Hide();
       }
    }

    private void Update()
    {
        _countDownText.text = Mathf.Ceil( KitchenGameManager.Instance.GetCountdownToStartTimer()).ToString();
        
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
