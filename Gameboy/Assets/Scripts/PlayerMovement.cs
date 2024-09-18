using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D rb;
    private Animator animator;

    Vector2 dir;

    private void Start()
    {
        transform.TryGetComponent(out rb);
        transform.GetChild(0).TryGetComponent(out animator);
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
        Animate();
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
        
        if(dir.x > 0)
        {
            transform.GetChild(0).localScale = Vector3.one;
        }

        if(dir.x < 0)
        {
            transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
        }

        animator.SetFloat("Magnitude", dir.magnitude);
    }
}
