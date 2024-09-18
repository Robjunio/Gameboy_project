using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D rb;
    private Transform target;

    Vector2 dir;

    private void Start()
    {
        transform.TryGetComponent(out rb);
    }

    public void SetTarget(Transform transform)
    {
        target = transform;
    }

    private void Update()
    {
        GetDir();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetDir()
    {
        dir = target.position - transform.position;
    }

    private void Move()
    {
        if (rb == null) return;

        rb.velocity = dir * Time.fixedDeltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Hit player
        }
    }
}
