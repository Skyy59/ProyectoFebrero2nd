using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class Cannon : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private LayerMask enemyMask;
    
    [Header("Attributes")] 
    [SerializeField] private float targetRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private Transform _target;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_target)
        {
            FindTarget();
            return;
        }

        RotateToTarget();
        
        if (!TargetInRange())
        {
            _target = null;
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetRange,
            (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            _target = hits[0].transform;
            
        }
    }

    private bool TargetInRange()
    {
        return Vector2.Distance(_target.position, transform.position) <= targetRange;
    }

    private void RotateToTarget()
    {
        float angle = Mathf.Atan2(_target.position.y - transform.position.y, transform.position.y - _target.position.x)
            * Mathf.Rad2Deg;
        
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    }
}
