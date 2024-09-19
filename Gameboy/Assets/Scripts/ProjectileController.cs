using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private GameObject impactPrefab;
    [SerializeField] private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthSystem>().GetHit(damage);

            if (impactPrefab != null)
            {
                Instantiate(impactPrefab, collision.transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
