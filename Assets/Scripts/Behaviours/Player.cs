﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Camera _camera;

    private bool _isMobilePlatform;
    private Rigidbody2D _rigidbody;
    private bool _useTouchControls;
    public TextMeshProUGUI counter;

    public float sensitivity = 20;

    public static int Score { get; private set; }
    private static int Deaths { get; set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isMobilePlatform = Application.isMobilePlatform;
        _useTouchControls = Game.Settings.UseTouchControls;
        _camera = Camera.main;
        sensitivity = Game.Settings.Sensitivity;
        Score = 0;
    }

    private void FixedUpdate()
    {
        var input = Input.GetAxis("Horizontal") * sensitivity * Time.fixedDeltaTime;
        if (_isMobilePlatform)
        {
            if (_useTouchControls)
            {
                if (Input.touches.Length <= 0)
                    return;
                var touch = Input.GetTouch(0).position;
                var touchPos = _camera.ScreenToWorldPoint(touch);
                touchPos.x = Mathf.Clamp(touchPos.x, -6, 6);
                touchPos.y = -4;
                touchPos.z = 0;
                transform.position = touchPos;
                return;
            }
            input = Input.acceleration.x * sensitivity * Time.fixedDeltaTime;
        }
        var pos = _rigidbody.position + Vector2.right * input;
        pos.x = Mathf.Clamp(pos.x, -6, 6);
        pos.y = -4;
        _rigidbody.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Goal"))
            return;
        Deaths++;
        StartCoroutine(Ended());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Score++;
        counter.text = Score.ToString();
    }

    private IEnumerator Ended()
    {
        Time.timeScale = 1f / 10;
        Time.fixedDeltaTime /= 10;
        yield return new WaitForSeconds(1f / 10);
        Time.timeScale = 1;
        Time.fixedDeltaTime *= 10;
        if (Deaths >= 10) // Place Unity Ads Here
            Deaths = 0;
        SceneManager.LoadScene(2);
    }

}