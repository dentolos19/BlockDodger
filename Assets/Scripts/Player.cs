using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private GameMaster _gameMaster;
    private Rigidbody2D _rigidbody;

    public float movementSpeed = 15;
    public float movementWidth = 6;

    private void Start()
    {
        _gameMaster = FindFirstObjectByType<GameMaster>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var gyroMovement = Input.acceleration.x * movementSpeed * Time.fixedDeltaTime; // gets tilt movement
        var axisMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.fixedDeltaTime; // gets left/right movement
        var newPosition = _rigidbody.position + Vector2.right * (axisMovement + gyroMovement);
        newPosition.x = Mathf.Clamp(newPosition.x, -movementWidth, movementWidth); // clamps position; in order not to go out of screen
        _rigidbody.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Obstacle"))
            return;
        _gameMaster.EndGame();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Goal"))
            return;
        _gameMaster.IncrementScore();
    }
}