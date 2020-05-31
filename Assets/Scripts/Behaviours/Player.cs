using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int Score { get; private set; }

<<<<<<< HEAD
    private int mControlType;
    private int mDeaths;
    private float mSensitivity;
    private Camera mCamera;
    private Rigidbody2D mRigidbody;
=======
    private int _controlType;
    private int _deaths;
    private float _sensitivity;
    private Camera _camera;
    private Rigidbody2D _rigidbody;
>>>>>>> DodgeTheBlocksOld/master

    public TextMeshProUGUI counter;

    private void Start()
    {
<<<<<<< HEAD
        mControlType = Game.Settings.ControlType;
        mSensitivity = Game.Settings.Sensitivity;
        mCamera = Camera.main;
        mRigidbody = GetComponent<Rigidbody2D>();
        Score = 0;
        mDeaths = 0;
=======
        _controlType = Game.Settings.ControlType;
        _sensitivity = Game.Settings.Sensitivity;
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
        Score = 0;
        _deaths = 0;
>>>>>>> DodgeTheBlocksOld/master
    }

    private void FixedUpdate()
    {
        var input = 0f;
<<<<<<< HEAD
        switch (mControlType)
        {
            case 0:
                input = Input.GetAxis("Horizontal") * mSensitivity * Time.fixedDeltaTime;
                break;
            case 1:
                input = Input.acceleration.x * mSensitivity * Time.fixedDeltaTime;
=======
        switch (_controlType)
        {
            case 0:
                input = Input.GetAxis("Horizontal") * _sensitivity * Time.fixedDeltaTime;
                break;
            case 1:
                input = Input.acceleration.x * _sensitivity * Time.fixedDeltaTime;
>>>>>>> DodgeTheBlocksOld/master
                break;
            case 2:
                if (Input.touches.Length <= 0)
                    return;
                var touch = Input.GetTouch(0).position;
<<<<<<< HEAD
                var touchPos = mCamera.ScreenToWorldPoint(touch);
=======
                var touchPos = _camera.ScreenToWorldPoint(touch);
>>>>>>> DodgeTheBlocksOld/master
                touchPos.x = Mathf.Clamp(touchPos.x, -6, 6);
                touchPos.y = -4;
                touchPos.z = 0;
                transform.position = touchPos;
                return;
        }
<<<<<<< HEAD
        var pos = mRigidbody.position + Vector2.right * input;
        pos.x = Mathf.Clamp(pos.x, -6, 6);
        pos.y = -4;
        mRigidbody.MovePosition(pos);
=======
        var pos = _rigidbody.position + Vector2.right * input;
        pos.x = Mathf.Clamp(pos.x, -6, 6);
        pos.y = -4;
        _rigidbody.MovePosition(pos);
>>>>>>> DodgeTheBlocksOld/master
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Goal"))
            return;
<<<<<<< HEAD
        mDeaths++;
=======
        _deaths++;
>>>>>>> DodgeTheBlocksOld/master
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
<<<<<<< HEAD
        if (mDeaths >= 10)
=======
        if (_deaths >= 10)
>>>>>>> DodgeTheBlocksOld/master
        {
            if (Advertisement.isInitialized && Advertisement.IsReady())
                Advertisement.Show();
        }
        SceneManager.LoadScene(2);
    }

}