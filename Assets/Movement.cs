using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Move speed
    public float moveSpeed = 5f;

    // Animator and SpriteRenderer references
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the Animator and SpriteRenderer components
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get the horizontal and vertical input (WASD or arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate if the player is moving (any horizontal or vertical movement)
        bool isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

        // Set the "IsMoving" parameter in the Animator to control transitions
        animator.SetBool("IsMoving", isMoving); // "IsMoving" should be set here

        // Handle direction-based animation and movement
        if (horizontalInput > 0)  // Moving to the right
        {
            animator.SetBool("MoveRight", true);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveDown", false);
        }
        else if (horizontalInput < 0)  // Moving to the left
        {
            animator.SetBool("MoveLeft", true);
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveDown", false);
        }
        else if (verticalInput > 0)  // Moving up
        {
            animator.SetBool("MoveUp", true);
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveDown", false);
        }
        else if (verticalInput < 0)  // Moving down
        {
            animator.SetBool("MoveDown", true);
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveUp", false);
        }
        else  // If no movement, set Idle animation
        {
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveDown", false);
        }

        // Move the player
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
