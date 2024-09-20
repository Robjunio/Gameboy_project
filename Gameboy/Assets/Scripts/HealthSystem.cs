using DG.Tweening;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

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
        if (currentHealth == 0) return;

        currentHealth -= value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        animator.SetTrigger("Hit");

        if(player != null)
        {
            Combo.Instance.ResetCombo();
            Camera.main.DOShakePosition(0.5f, 0.5f, 8);
        }

        if (currentHealth == 0) {
            if (enemy != null)
            {
                //Feedback de dano fatal
                // vfx.transform.Rotate(Random.Range(0f,360f), 0, 0);
            }
            Die();
        }
        else
        {
            if (enemy != null)
            {
                //Feedback de dano
            }
        }
    }

    private void Die()
    {
        if(player != null)
        {
            GameManager.Instance.LoseGame();
            animator.SetBool("Dead", true);
            player.Dead();
        } else if(enemy != null)
        {
            enemy.Dead();
        }
    }

    public void Heal(int value) 
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
