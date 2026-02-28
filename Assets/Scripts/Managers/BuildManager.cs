using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Main;

    [Header("References")] 
    [SerializeField] private GameObject[] buildingPrefabs;
    
    
    private int _selectedTower;
    
    private void Awake()
    {
        Main = this;
    }

    public GameObject GetSelectedTower()
    {
        return buildingPrefabs[_selectedTower];
    }
}
