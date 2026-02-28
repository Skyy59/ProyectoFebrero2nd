using System;
using UnityEngine;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI currencyUI;


    private void OnGUI()
    {
        currencyUI.text = LevelManager.Instance.currency.ToString();
    }
}
