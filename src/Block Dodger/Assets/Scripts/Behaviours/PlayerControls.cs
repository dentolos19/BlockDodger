using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    private Rigidbody2D _rigidbody;

    public float movementSpeed = 15;
    public float movementWidth = 6;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Debug.Log(Input.acceleration.x);
        var movement = Input.GetAxis("Horizontal") * movementSpeed * Time.fixedDeltaTime;
        var position = _rigidbody.position + Vector2.right * movement;
        position.x = Mathf.Clamp(position.x, -movementWidth, movementWidth);
        _rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
            FindObjectOfType<GameMaster>().EndGame();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
            FindObjectOfType<GameMaster>().IncrementScore();
    }

}