using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject[] drops;
 
    public delegate void Die(Enemy enemy);
    public static event Die die;
    [SerializeField] float speed;
    [SerializeField] int damage;
    private Rigidbody2D rb;
    private Transform target;
    private CircleCollider2D circleCollider;

    Vector2 dir;

    bool alive = true;

    private void OnDie()
    {
        die?.Invoke(this);
    }

    private void Start()
    {
        transform.TryGetComponent(out rb);
        transform.TryGetComponent(out circleCollider);
    }

    public void SetTarget(Transform transform)
    {
        target = transform;
    }

    private void Update()
    {
        if (!alive) return;
        GetDir();
    }

    private void FixedUpdate()
    {
        if (!alive) return;
        Move();
    }

    private void GetDir()
    {
        dir = target.position - transform.position;
    }

    private void Move()
    {
        if (rb == null) return;
        if(dir.x > 0)
        {
            transform.localScale = Vector3.one;
        } else if(dir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rb.velocity = dir * Time.fixedDeltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().GetHit(damage);
        }
    }

    public void Dead()
    {
        OnDie();

        var prob = Random.Range(0, 100);
        if(prob > 90)
        {
            Instantiate(drops[0], transform.position, Quaternion.identity);
        }
        else if(prob > 70)
        {
            Instantiate(drops[1], transform.position, Quaternion.identity);
        }

        circleCollider.enabled = false;
        alive = false;
        rb.velocity = Vector2.zero;
        dir = transform.position - target.position;
        rb.AddForce(dir * 10, ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }
}
