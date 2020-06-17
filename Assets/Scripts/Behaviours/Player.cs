using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int Score { get; private set; }
    public static int Deaths { get; set; }

    private int mControlType;
    private float mSensitivity;
    private bool mDied;
    private Camera mCamera;
    private Rigidbody2D mRigidbody;

    public TextMeshProUGUI counter;

    private void Start()
    {
        mControlType = Game.Settings.ControlType;
        mSensitivity = Game.Settings.Sensitivity;
        mCamera = Camera.main;
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var input = 0f;
        switch (mControlType)
        {
            case 0:
                input = Input.GetAxis("Horizontal") * mSensitivity * Time.fixedDeltaTime;
                break;
            case 1:
                input = Input.acceleration.x * mSensitivity * Time.fixedDeltaTime;
                break;
            case 2:
                if (Input.touches.Length <= 0)
                    return;
                var touch = Input.GetTouch(0).position;
                var touchPos = mCamera.ScreenToWorldPoint(touch);
                touchPos.x = Mathf.Clamp(touchPos.x, -6, 6);
                touchPos.y = -4;
                touchPos.z = 0;
                transform.position = touchPos;
                return;
        }
        var pos = mRigidbody.position + Vector2.right * input;
        pos.x = Mathf.Clamp(pos.x, -6, 6);
        pos.y = -4;
        mRigidbody.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Goal") || mDied)
            return;
        Deaths++;
        mDied = true;
        Debug.Log(Deaths);
        StartCoroutine(End());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") || mDied)
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
        SceneManager.LoadScene(2);
    }

}