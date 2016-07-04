using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float movementSpeed = 1.0f;
    Rigidbody2D rb;

	void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () 
    {
        Vector2 movement;

        GetInput(out movement);

        Move(movement);
	}

    void Move(Vector2 vector)
    {
        rb.MovePosition(rb.position + vector * movementSpeed * Time.deltaTime);
    }
    void GetInput(out Vector2 output)
    {
        output = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }


}
