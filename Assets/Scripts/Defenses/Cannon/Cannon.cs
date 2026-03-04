using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;



[System.Serializable]
public class TowerLevel
{
    public RuntimeAnimatorController animatorController;
    public GameObject bulletPrefab;
    public int cost;
    public float range;
    public float fireRate;
    public int damage;
}

public class Cannon : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Animator animator;


    [Header("Attributes")] 
    [SerializeField] private TowerLevel[] levels;

    private int _currentLevel = 0;

    [SerializeField]private float targetRange;
    private float _fireRate;
    
    private Transform _target;
    private float _untilFire;

    private void Start()
    {
        ApplyLevel(0);
    }

    void Update()
    {
        if (!_target)
        {
            FindTarget();
            
            return;
        }

       
        
        if (!TargetInRange())
        {
            _target = null;
        }
        else
        {
            _untilFire += Time.deltaTime;
            if (_untilFire >= 1f / _fireRate)
            {
                ShootTarget();
                _untilFire = 0f;
            }
        }
    }


    public void Upgrade()
    {
        if (_currentLevel + 1 >= levels.Length) return;
        
        int nextCost  = levels[_currentLevel + 1].cost;

        if (LevelManager.Instance.SpendCurrency(nextCost))
        {
            _currentLevel++;
            ApplyLevel(_currentLevel);
            CloseUpgradeUI();
        }
    }


    private void ApplyLevel(int levelIndex)
    {
        TowerLevel level =  levels[levelIndex];
        
        targetRange = level.range;
        _fireRate = level.fireRate;
        animator.runtimeAnimatorController = level.animatorController;
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
        TowerLevel level = levels[_currentLevel];
        
        
        GameObject bulletObj = Instantiate(level.bulletPrefab, firingPoint.position, Quaternion.identity);
        CannonBall bulletScript = bulletObj.GetComponent<CannonBall>();
        bulletScript.SetTarget(_target, level.damage);
    }

    private bool TargetInRange()
    {
        return Vector2.Distance(_target.position, transform.position) <= targetRange;
    }

    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
    }
    
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, targetRange);
    }
}
