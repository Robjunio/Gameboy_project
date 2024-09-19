using DG.Tweening;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    private Enemy enemy;
    private PlayerMovement player;

    [SerializeField] Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        TryGetComponent(out enemy);
        TryGetComponent(out player);
    }

    public void GetHit(int value)
    {
        print("Got hit");
        if (currentHealth == 0) return;

        currentHealth -= value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        animator.SetTrigger("Hit");

        if(player != null)
        {
            Camera.main.DOShakePosition(0.5f, 0.5f, 8);
        }

        if (currentHealth == 0) {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("Dead", true);
        if(player != null)
        {
            player.Dead();
        } else if(enemy != null)
        {
            enemy.Dead();
        }
    }
}
