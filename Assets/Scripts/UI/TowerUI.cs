using System;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    public TowerButton[] buttons;


    private void OnDisable()
    {
        Clear();
    }

    public void AssignButtons(Transform plot)
    {
        if (plot == null) return;
        foreach (TowerButton button in buttons)
        {
            button.turretPosition = plot;
        }
    }

    private void Clear()
    {
        foreach (TowerButton button in buttons)
        {
            button.turretPosition = null;
        }
    }
}
