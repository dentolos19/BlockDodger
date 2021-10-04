using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    private GameMaster _gameMaster;
    private Rigidbody2D _rigidbody;

    public float movementSpeed = 15;
    public float movementWidth = 6;

    private void Start()
    {
        _gameMaster = FindObjectOfType<GameMaster>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var gyroMovement = Input.acceleration.x * movementSpeed * Time.fixedDeltaTime;
        var axisMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.fixedDeltaTime;
        var newPosition = _rigidbody.position + Vector2.right * (axisMovement + gyroMovement);
        newPosition.x = Mathf.Clamp(newPosition.x, -movementWidth, movementWidth);
        _rigidbody.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Finish"))
            _gameMaster.EndGame();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
            _gameMaster.IncrementScore();
    }

}