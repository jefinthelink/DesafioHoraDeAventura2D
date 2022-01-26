using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHelper : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.instance.UnpauseGame();
        SceneManager.LoadScene("Gameplay");
    }
    public void PlayGameplay1()
    {
        GameManager.instance.UnpauseGame();
        SceneManager.LoadScene("GamePlay1");
    }
    public void BackToMenu()
    {
        GameManager.instance.UnpauseGame();
        SceneManager.LoadScene("Menu");
    }
    public void ResetGame()
    {
        PlayerPrefs.SetInt("PointsRecord", 0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
