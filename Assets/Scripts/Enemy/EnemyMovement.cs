using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D _rb;

    [Header("Attributes")]
    [SerializeField] private float _moveSpeed = 2f;

    private Transform _target;
    private int _pathIndex = 0;
    
    void Start()
    {
        _target = LevelManager.Instance.path[_pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(_target.position, transform.position) <= 0.1f)
        {
            _pathIndex++;

            if (_pathIndex == LevelManager.Instance.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                _target = LevelManager.Instance.path[_pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_target.position - transform.position).normalized;

        _rb.linearVelocity = direction * _moveSpeed;
    }
}
