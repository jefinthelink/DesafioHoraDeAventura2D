using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{

    public int level = 0;
    public int points = 0;
    [SerializeField] private float xp = 0;
    [SerializeField] float xpCountOfLevels = 15.0f;
    [SerializeField] private TMP_Text textLevel;
    [SerializeField] private TMP_Text textPoints;
    public Events events;
    public GameObject GameOverPanel, WinPanel;



  
    private void Start()
    {
        getValues();    
    }
    private void getValues()
    {
    }
    public void GetXp(float xpValue)
    {
        if (xpValue < xpCountOfLevels - xp)
        {
            xp += xpValue;
        }
        else 
        {
            
            xpValue -= xpCountOfLevels - xp;
            xp = 0;
            level++;
            UpdateUi();
            GetXp(xpValue);
        }
    }
    private void UpdateUi()
    {
        textLevel.text = "Level: " + level.ToString();
        textPoints.text = "Pontos: " + points.ToString();
        GameManager.instance.points = points;
    }
}
