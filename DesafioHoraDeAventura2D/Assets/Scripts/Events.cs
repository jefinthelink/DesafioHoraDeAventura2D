using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Events : MonoBehaviour
{
    [SerializeField] private GameObject PanelEvents;
    [SerializeField] private float timeDoublePoints = 15.0f;
    [SerializeField] private float timeEnemyFollowPlayer = 10.0f;
    [SerializeField] private string[] bills;
    [SerializeField] private int[] answers;
    [SerializeField] private Button[] answersbtn;
    [SerializeField] private TMP_Text textAnswer;
    [SerializeField] private TMP_Text textTimeToAnswer;
    [SerializeField] private float timetoAnswer = 5.0f;

    private float timetoAnswerAux;
    private bool startEvent = false;
    private Button btnWithTrueAnswer;
    private int indexOfbtnWithTrueAnswer;
    private int indexOfBills;
    private string currentBills;
    private float timeDoublePointsAux;
    private float timeEnemyFollowPlayerAux;
    public GameObject[] enemysInAceneObj;
    public Enemy[] enemysInAcene ;
    public bool startDoublePoints = false , startFollowPlayer = false;

    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        timeDoublePointsAux = timeDoublePoints;
        timeEnemyFollowPlayerAux = timeEnemyFollowPlayer;
        timetoAnswerAux -= timetoAnswer;
        PanelEvents.SetActive(true);
        ChooseBills();
        ChooseBtn();
        
    }
    private void Update()
    {
        Timer();
        if (startDoublePoints)
        {
            timeDoublePoints -= Time.deltaTime;
            if (timeDoublePoints <= 0.0f)
            {
                startDoublePoints = false;
                timeDoublePoints = timeDoublePointsAux;
                ChangePoints(false);
            }
        }
        if (startFollowPlayer)
        {
            timeEnemyFollowPlayer -= Time.deltaTime;
            if (timeEnemyFollowPlayer <= 0.0f)
            {
                startFollowPlayer = false;
                timeEnemyFollowPlayer = timeEnemyFollowPlayerAux;
                ChangeModes(Action.home);
            }
        }


    }
    private void Timer()
    {
        if (startEvent)
        {
        timetoAnswer -= Time.deltaTime;
            textTimeToAnswer.text = timetoAnswer.ToString("f");
        if (timetoAnswer <= 0.0f)
        {
            timetoAnswer = timetoAnswerAux;
            startEvent = false;
            FinishLoseEvent();
        }
        }
    }
    public void StartEvent()
    {
        Debug.Log("startou o evento");
        PanelEvents.SetActive(true);
        VerifyEnemys();
        PauseEnemy(true);
       // ChooseBills();
       // ChooseBtn();
        startEvent = true;
    }
    private void PauseEnemy(bool value)
    {
        for (int i = 0; i < enemysInAcene.Length; i++)
        {
            enemysInAcene[i].pause = value;
        }
    }
    
    private void VerifyEnemys()
    {
        Debug.Log("verificando inimigos");
        enemysInAceneObj = GameObject.FindGameObjectsWithTag("Enemy");
        enemysInAcene = new Enemy[enemysInAceneObj.Length];
        for(int i = 0; i < enemysInAceneObj.Length; i++ )
        {
            enemysInAcene[i] = enemysInAceneObj[i].GetComponent<Enemy>();
        }
    }
    private void ChangeModes(Action action)
    {
        Debug.Log("trocando o modo do inimigo");
        for (int i = 0; i < enemysInAcene.Length; i++)
        {
            enemysInAcene[i].currentAction = action;
        }
    }
    private void ChangePoints(bool double_)
    {
        Debug.Log("mudando modo de pontos");
        if (double_)
        {
            for (int i = 0; i < enemysInAcene.Length; i++)
            {
                enemysInAcene[i].pointsValue *= 2;
            }
        }
        else 
        {
            for (int i = 0; i < enemysInAcene.Length; i++)
            {
                enemysInAcene[i].pointsValue /= 2;
            }
        }
    }
    private void ChooseBtn()
    {
        Debug.Log("escolhendo o botão");
        indexOfbtnWithTrueAnswer = Random.Range(0, answersbtn.Length);
        btnWithTrueAnswer = answersbtn[indexOfbtnWithTrueAnswer];
        btnWithTrueAnswer.GetComponentInChildren<TMP_Text>().text = answers[indexOfBills].ToString();
        btnWithTrueAnswer.onClick.AddListener(FinishWinEvent);

        for (int i = 0; i < answersbtn.Length; i++)
        {
            if (i != indexOfbtnWithTrueAnswer)
            {
                answersbtn[i].onClick.AddListener(FinishLoseEvent);
                answersbtn[i].GetComponentInChildren<TMP_Text>().text = Chooseanswers().ToString();
            }
        }
        PanelEvents.SetActive(false);
    }
    public void ChooseBills()
    {
        Debug.Log("escolhendo pergunta");
        indexOfBills = Random.Range(0, bills.Length);
        currentBills = bills[indexOfBills];
        textAnswer.text = currentBills;
    }
    public int Chooseanswers()
    {
        Debug.Log("escolhendo respostas");
        int index;
        do
        {
        index = Random.Range(0, answers.Length);

        } while (index == indexOfBills);
        return answers[index];
    }
public void FinishWinEvent()
    {
       
       // PanelEvents.SetActive(false);
        
            Debug.Log("acertou");
            VerifyEnemys();
            ChangePoints(true);
            PanelEvents.SetActive(false);
            startDoublePoints = true;
          
        
       
        
        PauseEnemy(false);
    }

public void FinishLoseEvent()
{
            Debug.Log("Errou");
            VerifyEnemys();
            startFollowPlayer = true;
            ChangeModes(Action.FollowPlayer);
            PanelEvents.SetActive(false);
            GameManager.instance.UnpauseGame();
             PauseEnemy(false);

}


}
