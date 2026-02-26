using System;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    private Transform _target;


    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    private void FixedUpdate()
    {
        if (!_target) return;
        Vector2 direction =  (_target.position - transform.position).normalized;
        
        rb.linearVelocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
