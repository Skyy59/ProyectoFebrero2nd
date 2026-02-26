using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("References")] 
    
    [Header("Attributes")] 
    [SerializeField] private int hitPoints = 2;


    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0)
        {
            EnemySpawner.OnEnemyKilled.Invoke();
            Destroy(gameObject);
        }
    }
}
