using System;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("References")] 
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private Cannon _turret;
    private Color _startColor;


    private void Start()
    {
        _startColor = sr.color;
        
    }

    private void Update()
    {
        
        if (transform.childCount == 1)
        {
            if (_turret == null)
            {
                _turret = transform.GetChild(0).GetComponentInChildren<Cannon>();
            }
        }
        else
        {
            _turret = null;
        }
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = _startColor;
    }

    private void OnMouseDown()
    {

        if (transform.childCount >= 1)
        {
            _turret.OpenUpgradeUI();
        }
        else
        {
            BuildUI.Some.ShowMenu(this);
        }
        

    }
    

}
