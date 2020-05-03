using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int Score { get; private set; }

    private int _controlType;
    private int _deaths;
    private float _sensitivity;
    private Camera _camera;
    private Rigidbody2D _rigidbody;

    public TextMeshProUGUI counter;

    private void Start()
    {
        _controlType = Game.Settings.ControlType;
        _sensitivity = Game.Settings.Sensitivity;
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
        Score = 0;
        _deaths = 0;
    }

    private void FixedUpdate()
    {
        var input = 0f;
        switch (_controlType)
        {
            case 0:
                input = Input.GetAxis("Horizontal") * _sensitivity * Time.fixedDeltaTime;
                break;
            case 1:
                input = Input.acceleration.x * _sensitivity * Time.fixedDeltaTime;
                break;
            case 2:
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
        var pos = _rigidbody.position + Vector2.right * input;
        pos.x = Mathf.Clamp(pos.x, -6, 6);
        pos.y = -4;
        _rigidbody.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Goal"))
            return;
        _deaths++;
        StartCoroutine(End());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
            return;
        Score++;
        counter.text = Score.ToString();
    }

    private IEnumerator End()
    {
        Time.timeScale = 1f / 10;
        Time.fixedDeltaTime /= 10;
        yield return new WaitForSeconds(1f / 10);
        Time.timeScale = 1;
        Time.fixedDeltaTime *= 10;
        if (_deaths >= 10)
        {
            if (Advertisement.isInitialized && Advertisement.IsReady())
                Advertisement.Show();
        }
        SceneManager.LoadScene(2);
    }

}