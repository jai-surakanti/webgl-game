using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject _gameOverCanvas;
    public GameObject _pauseGameCanvas;

    [DllImport("__Internal")]
    private static extern void EndGame(int userId, int score);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game!");
        #if UNITY_WEBGL && !UNITY_EDITOR
            EndGame(1, 25);
        #endif
    }

    public void PauseFromJS()
    {
        Debug.Log("Game paused from JS.");
        _pauseGameCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Debug.Log("Game resumed.");
        _pauseGameCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}