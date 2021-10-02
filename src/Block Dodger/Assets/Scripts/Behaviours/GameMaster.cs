using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    private bool _gameEnded;

    public float deathSlowness = 10;
    public GameObject deathMenu;

    private IEnumerator RestartLevel()
    {
        Time.timeScale /= deathSlowness;
        Time.fixedDeltaTime /= deathSlowness;
        yield return new WaitForSeconds(1 / deathSlowness);
        Time.timeScale = 0;
        deathMenu.SetActive(true);
    }

    public void EndGame()
    {
        if (_gameEnded)
            return;
        StartCoroutine(nameof(RestartLevel));
        _gameEnded = true;
    }

}