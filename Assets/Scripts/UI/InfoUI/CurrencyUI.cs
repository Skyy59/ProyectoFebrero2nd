using System;
using UnityEngine;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI currencyUI;
    [SerializeField] private TextMeshProUGUI waveUI;
    [SerializeField] private TextMeshProUGUI livesUI;


    private void OnGUI()
    {
        currencyUI.text = LevelManager.Instance.currency.ToString();
        waveUI.text = (EnemySpawner.Instance._waveIndex + 1).ToString();
        livesUI.text = GameManager.Instance.lives.ToString();
    }
}
