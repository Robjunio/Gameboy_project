using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private GameObject impactPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(impactPrefab != null)
        {
            Instantiate(impactPrefab, collision.transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
