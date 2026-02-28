using UnityEditor;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public GameObject turretPrefab;

    public int cost;
    public Transform turretPosition;


    
    
    
    public void CreateTurret()
    {
        if (turretPosition == null) return;

        if (cost > LevelManager.Instance.currency)
        {
            Debug.Log("Ere pobre");
            return;
        }
        
        LevelManager.Instance.SpendCurrency(cost);
        
        GameObject turret = Instantiate(turretPrefab, turretPosition.position, Quaternion.identity, turretPosition);
        turret.transform.localPosition = Vector3.zero;
    }
}
