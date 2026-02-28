using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Transform startPoint;
    public Transform[] path;

    public int currency;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currency = 100;
    }
    
    public void IncrementCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            
            return false;
        }
    }
}
