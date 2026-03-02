using UnityEngine;

public class BuildUI : MonoBehaviour
{
    public static BuildUI Some;
        

    public Plot currentPlot;
    public TowerUI towerUI;

    private void Awake()
    {
        Some = this;
        
    }

    public void ShowMenu(Plot plot)
    {
        currentPlot = plot;
        towerUI.gameObject.SetActive(true);
        towerUI.AssignButtons(plot.transform);
        Debug.Log("Plot seleccionado: " + plot.name);
        
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(plot.transform.position);
        towerUI.transform.position = screenPosition;
    }
    
    
}
