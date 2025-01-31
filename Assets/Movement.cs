using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Move speed
    public float moveSpeed = 5f;

    void Update()
    {
        // Movement keys

        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        // Movement based on commands

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
