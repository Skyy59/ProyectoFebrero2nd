using System;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    
    
    private int _bulletDamage;
    private Transform _target;


    public void SetTarget(Transform target, int damage)
    {
        _target = target;
        _bulletDamage = damage;
    }
    
    private void FixedUpdate()
    {
        if (!_target) return;
        Vector2 direction =  (_target.position - transform.position).normalized;
        
        rb.linearVelocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(_bulletDamage);
        }
        Destroy(gameObject);
    }
}
