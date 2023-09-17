using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private Joystick joystick;
    [SerializeField] private float runSpeed = 100f;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float verticalMovement = 0f;
    private float horizontalMovement = 0f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if (joystick.Horizontal >= .2f)
        {
            horizontalMovement = runSpeed;
            spriteRenderer.flipX = false;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMovement = -runSpeed;
            spriteRenderer.flipX = true;
        }
        else
        { horizontalMovement = 0f; }

        if (joystick.Vertical >= .2f)
        { verticalMovement = runSpeed; }
        else if (joystick.Vertical <= -.2f)
        { verticalMovement = -runSpeed; }
        else
        { verticalMovement = 0f; }

        if (Mathf.Abs(joystick.Vertical) > Mathf.Abs(joystick.Horizontal))
        { horizontalMovement = 0; }
        else
        { verticalMovement = 0f; }
    }
    private void FixedUpdate()
    {
        animator.SetFloat("Horizontal", horizontalMovement);
        animator.SetFloat("vertical", verticalMovement);
        animator.SetFloat("Speed", Mathf.Abs(joystick.Vertical) + Mathf.Abs(joystick.Horizontal));
        rb.AddForce(new Vector2(horizontalMovement, verticalMovement));

    }
}
