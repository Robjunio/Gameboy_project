using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    [SerializeField] private float projectileSpeed;
    List<Transform> enemies = new List<Transform>();
    Animator animator;

    bool canShoot;

    private void Start()
    {
        TryGetComponent(out animator);
    }
    private void Update()
    {
        if(enemies.Count > 0)
        {
            canShoot = true;
            animator.SetBool("shoot", true);
        }
        else
        {
            canShoot = false;
            animator.SetBool("shoot", false);
        }

        if (canShoot)
        {
            var target = enemies[0];
            var dir = transform.position - target.position;
            dir = dir.normalized;

            transform.up = dir;
        }
    }
    public void Shoot()
    {
        if (!canShoot) return;
        var target = enemies[0];

        var dir = target.transform.position - transform.GetChild(0).position;
        dir = dir.normalized;

        var obj = Instantiate(Projectile, transform.GetChild(0).position, Quaternion.identity);
        var rb = obj.GetComponent<Rigidbody2D>();

        rb.velocity = dir * projectileSpeed;
        rb.transform.right = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Add(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemies.Remove(collision.gameObject.transform);
        }
    }

    private void RemoveDeadEnemy(Enemy enemy)
    {
        enemies.Remove(enemy.transform);
    }

    private void OnEnable()
    {
        Enemy.die += RemoveDeadEnemy;
    }
}
