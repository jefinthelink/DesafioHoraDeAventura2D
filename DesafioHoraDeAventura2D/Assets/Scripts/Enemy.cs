using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public CreateEnemy creat;
    [HideInInspector]public int number;
    [HideInInspector] public float xpValue = 10.0f;
    [HideInInspector] public int pointsValue = 2;
    [HideInInspector] public bool pause = false;
    [HideInInspector] public Transform target;
    [HideInInspector] public Transform lasttarget;
    [HideInInspector] public Transform player;
    [SerializeField] private TMP_Text levelText; 
    
    private float speed = 4.0f;
    private Sprite sprite;
    private SpriteRenderer spriteRenderer;
    private Transform wayPoint0;

   
    public Action currentAction;



    private void Start()
    {
        setValues();
    }
    private void setValues()
    {
        
        currentAction = Action.walk;
        wayPoint0 = GameObject.FindGameObjectWithTag("WayPoint0").transform;
        target = wayPoint0;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        sprite = creat.art;
        number = creat.number;
        xpValue = creat.xpValue;
        pointsValue = creat.pointsValue;
        speed = creat.speed;


        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        levelText.text = number.ToString();

    }
    private void Update()
    {
        FreeMoving();
        FollowPlayer();
        GoHome();
    }
    private void FreeMoving()
    {
        if (currentAction == Action.walk)
        {
            if (transform.position == target.position)
            {
                Transform[] points = target.GetComponent<WayPoints>().nearByPoints;
                int rand = Random.Range(0, points.Length);

                if (points[rand] != lasttarget)
                {
                    lasttarget = target;
                    target = points[rand];
                }
            }
            else
            {
                Move(transform.position,target.position);
            }

        }
    }
    private void FollowPlayer()
    {
        if (currentAction == Action.FollowPlayer)
        {
            if (player == null)
            {
                currentAction = Action.home;
            }
            else 
            {
            Move(transform.position,player.position);
            }
        }
    }
    private void GoHome()
    {
        if (currentAction == Action.home)
        {
            if (transform.position == wayPoint0.position)
            {
                currentAction = Action.walk;
            }
            else 
            {
                Move(transform.position,wayPoint0.position);
            }
        }
    }
    private void Move(Vector3 inicialPosition, Vector3 target)
    {
        if (!pause)
        {
        transform.position = Vector3.MoveTowards(inicialPosition, target, speed * Time.deltaTime);    
        }
    }

}

public enum Action
{
    home,
    walk,
    FollowPlayer
}
