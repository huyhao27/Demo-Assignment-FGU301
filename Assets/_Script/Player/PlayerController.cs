using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private IPlayerInput input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<IPlayerInput>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(input.MoveInput.x * moveSpeed, rb.velocity.y);
    }

    void Update()
    {
        if (input.JumpInputDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); 
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (input.MoveInput.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(input.MoveInput.x), 1, 1);
        }
    }
}