using System;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("References")] 
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject _tower;
    private Color _startColor;


    private void Start()
    {
        _startColor = sr.color;
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
        if (_tower != null) return;

        BuildUI.Some.ShowMenu(this);

    }
    

}
