using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class Cannon : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    
    [Header("Attributes")] 
    [SerializeField] private float targetRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float fireRate = 1f;

    private Transform _target;
    private float _untilFire;
    
    
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
        else
        {
            _untilFire += Time.deltaTime;
            if (_untilFire >= 1f / fireRate)
            {
                ShootTarget();
                _untilFire = 0f;
            }
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

    private void ShootTarget()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        CannonBall bulletScript = bulletObj.GetComponent<CannonBall>();
        bulletScript.SetTarget(_target);
    }

    private bool TargetInRange()
    {
        return Vector2.Distance(_target.position, transform.position) <= targetRange;
    }

    private void RotateToTarget()
    {
        float angle = Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        rotationPoint.rotation = Quaternion.RotateTowards(rotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    }
}
