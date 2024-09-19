using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] ParticleSystem grassStep;  //Grass particle system, needs to play when the player is walking.


    bool alive = true;

    Vector2 dir;

    private void Start()
    {
        transform.TryGetComponent(out rb);
        transform.GetChild(0).TryGetComponent(out animator);
    }

    private void Update()
    {
        if (!alive) return;
        GetInput();
    }

    private void FixedUpdate()
    {
        if (!alive) return;
        Move();
        Animate();
        GrassSteps(); // added to fixed update to constantly check player input
    }

    private void GetInput()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        dir = new Vector2(x, y);
    }

    private void Move()
    {
        if (rb == null) return;
        
        rb.velocity = dir * Time.fixedDeltaTime * speed;
        
    }

    private void Animate()
    {
        if (animator == null) return;

        if (dir.x > 0)
        {
            transform.GetChild(0).localScale = Vector3.one;
            
        }

        if (dir.x < 0)
        {
            transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
            
        }

        animator.SetFloat("Magnitude", dir.magnitude);
    }

    private void GrassSteps() // Function where the grass step particle sys detects playermovement and plays itself
    {
        if((dir.x != 0) || (dir.y != 0)) //<--- Detects player input 
        {
            grassStep.Play(); 

        }

    }

    public void Dead()
    {
        alive = false;
    }
}
