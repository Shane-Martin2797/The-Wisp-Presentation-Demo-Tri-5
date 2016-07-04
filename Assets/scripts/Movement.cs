using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void UpdateMovement(Vector2 movement)
    {
        rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.deltaTime);
    }
}