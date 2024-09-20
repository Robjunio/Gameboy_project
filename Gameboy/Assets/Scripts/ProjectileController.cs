using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Audio;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private GameObject heavyImpactPrefab;
    [SerializeField] private GameObject impactPrefab;
    [SerializeField] private AudioSource arrow;
    [SerializeField] private AudioSource arrowKill;
    [SerializeField] private int damage;
    private int enemyHealth; // save the enemy's current health to check for heavy impact.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            enemyHealth = collision.gameObject.GetComponent<HealthSystem>().currentHealth; // checks current enemy health.
            collision.gameObject.GetComponent<HealthSystem>().GetHit(damage);

            if ((impactPrefab != null) && enemyHealth == 20) // comparison to check if the shot will kill.
            {
                Instantiate(impactPrefab, collision.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))); // has this quaternion for random z axis rotations.
                arrow.Play();


            }
            else if ((impactPrefab != null) && enemyHealth == 10)
            {
                Instantiate(heavyImpactPrefab, collision.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                arrowKill.Play();
            }
            Destroy(gameObject);
        }
        
    }
}
