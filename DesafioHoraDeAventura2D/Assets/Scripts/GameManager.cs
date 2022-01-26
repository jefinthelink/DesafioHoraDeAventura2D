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
        Debug.Log("salvando o recorde: " + pointsRecord);
        PlayerPrefs.SetInt("PointsRecord", pointsRecord);
        Debug.Log("dalvo o recorde de; " + PlayerPrefs.GetInt("PointsRecord", 0));
    }
    private void GetSave()
    {
        Debug.Log("pegando o recorde " + PlayerPrefs.GetInt("PointsRecord", 0));
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
