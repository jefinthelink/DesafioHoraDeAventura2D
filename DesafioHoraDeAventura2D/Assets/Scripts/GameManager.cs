using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int pointsRecord = 0;
    public int points;
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        GetSave();
    }

    public void VerifyRecord()
    {
        if (points > pointsRecord)
        {
            pointsRecord = points;
            SaveRecord();
        }
    }
    private void SaveRecord()
    {
       
        PlayerPrefs.SetInt("PointsRecord", pointsRecord);
      
    }
    private void GetSave()
    {
      
        pointsRecord = PlayerPrefs.GetInt("PointsRecord", 0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
