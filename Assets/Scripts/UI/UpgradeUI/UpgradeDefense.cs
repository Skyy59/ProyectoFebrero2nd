using UnityEngine;

public class UpgradeDefense : MonoBehaviour
{
   public GameObject[] defensePrefabs;
   public int[] costs;
   
   
   private int _currentIndex = 0;

    public void NextUpgrade()
    {

        if (_currentIndex >= defensePrefabs.Length)
        {
            return;
        }
        
        int currentCost = costs[_currentIndex];

        if (LevelManager.Instance.SpendCurrency(currentCost))
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            
            if (transform.parent.childCount > 0)
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            
            Instantiate(defensePrefabs[_currentIndex], pos, rot, transform.parent);
            transform.localPosition = Vector3.zero;
            _currentIndex++;
        }
        else
        {
            Debug.Log("Ere pobre");
        }
        
    }

}
