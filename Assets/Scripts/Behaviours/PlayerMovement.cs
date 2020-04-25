using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rigidbody;

    public float limit = 6f;
    public float sensitivity = 20f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sensitivity = Game.Settings.Sensitivity;
    }

    private void Update()
    {
        if (!Game.Settings.UseTouchControls)
            return;
        if (Input.touches.Length <= 0)
            return;
        var touch = Input.GetTouch(0).position;
        var position = Camera.main.ScreenToWorldPoint(touch);
        position.y = -4;
        position.z = 0;
        transform.position = position;
    }

    private void FixedUpdate()
    {
        var input = Input.GetAxis("Horizontal") * sensitivity * Time.fixedDeltaTime;
        if (Application.isMobilePlatform)
            if (!Game.Settings.UseTouchControls)
                input = Input.acceleration.x * (sensitivity + 10) * Time.fixedDeltaTime;
        var position = _rigidbody.position + Vector2.right * input;
        position.x = Mathf.Clamp(position.x, -limit, limit);
        _rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(Died());
    }

    private static IEnumerator Died()
    {
        Time.timeScale = 1f / 10;
        Time.fixedDeltaTime /= 10;
        yield return new WaitForSeconds(1f / 10);
        Time.timeScale = 1f;
        Time.fixedDeltaTime *= 10;
        Game.DeathAmount++;
        if (Game.DeathAmount == 10)
        {
            if (Advertisement.isInitialized)
                if (Advertisement.IsReady())
                    Advertisement.Show();
            Game.DeathAmount = 0;
        }
        SceneManager.LoadScene(2);
    }

}