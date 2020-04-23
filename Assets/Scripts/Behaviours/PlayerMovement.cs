using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rigidbody;

    public float limit = 6f;
    public float sensitivity = 20f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        var settings = Configuration.Load();
        sensitivity = settings.Sensitivity;
    }

    private void FixedUpdate()
    {
        var input = Input.GetAxis("Horizontal") * sensitivity * Time.fixedDeltaTime;
        if (Application.isMobilePlatform)
            input = Input.acceleration.x * (sensitivity + 10) * Time.fixedDeltaTime;
        var position = _rigidbody.position + Vector2.right * input;
        position.x = Mathf.Clamp(position.x, -limit, limit);
        _rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(Restart());
    }

    private static IEnumerator Restart()
    {
        Time.timeScale = 1f / 10;
        Time.fixedDeltaTime /= 10;
        yield return new WaitForSeconds(1f / 10);
        Time.timeScale = 1f;
        Time.fixedDeltaTime *= 10;
        SceneManager.LoadScene(2);
    }

}