using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [HideInInspector] public enum ModesOfGameOver { gameOver, win };
    [SerializeField] private ModesOfGameOver modes;
    [SerializeField] private TMP_Text textPoints;
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject panelGameplay;

    public GameObject[] enemysInScene;
    private bool endGame = false;


    private void Start()
    {
        content.SetActive(false);
    }
    private void SetTextValues()
    {
        textPoints.text = GameManager.instance.points.ToString();
       
    }
    public void ShowPanel()
    {
Debug.Log("mostrando painel");
        content.SetActive(true);
        panelGameplay.SetActive(false);
        GameManager.instance.PauseGame();
        
        SetTextValues();
    }
    private void Update()
    {
        VerifyEnemysInScene();
    }
    public void VerifyEnemysInScene()
    {
        if (modes == ModesOfGameOver.win && !endGame)
        {
       
        enemysInScene = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemysInScene.Length <= 0)
        {
            endGame = true;
            ShowPanel();
        }
        }
    }
}
