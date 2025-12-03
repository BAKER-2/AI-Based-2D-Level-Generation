using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement speed in units/sec")]
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // read input each frame
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or ←/→
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or ↑/↓
    }

    void FixedUpdate()
    {
        // move the rigidbody
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
