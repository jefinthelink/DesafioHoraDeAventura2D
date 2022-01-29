using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Spawn de inimigos")]
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private int enemyCount = 4;
    [Header("Spawn de xp")]
    [SerializeField] private GameObject xp;
    [SerializeField] private Transform[] placesToSpawnXp;
    [SerializeField] private float delayToSpawnXp = 3.0f;
    [Header("Spawn de eventos")]
    [SerializeField] private GameObject events;
    [SerializeField] private Transform[] placesOfSpawnEvents;
    [Range(10,60)]
    [SerializeField] private float delaytoSpawnEvents = 10.0f;

    private float delayToSpawnXpAux;
    private float delaytoSpawnEventsAux;
    [HideInInspector]public GameObject currentXp = null;
    [HideInInspector]public GameObject currentEvent = null;

    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        delaytoSpawnEventsAux = delaytoSpawnEvents;
        delayToSpawnXpAux = delayToSpawnXp;
        SpawnEnemy();
    }
    private void Update()
    {
        SpawnEvents();
        SpawnXp();
    }
    private void SpawnEnemy()
    {
            for (int i = 0; i < enemyCount; i++)
            {
            Instantiate(enemys[Random.Range(0,enemys.Length)],transform.position,Quaternion.identity);
            } 
    }
    private void SpawnXp()
    {
            delayToSpawnXp -= Time.deltaTime;
            if (delayToSpawnXp <= 0.0f)
            {
            
                if (currentXp == null)
                {
                delayToSpawnXp = delayToSpawnXpAux;
                currentXp = Instantiate(xp, placesToSpawnXp[Random.Range(0, placesToSpawnXp.Length)].position, Quaternion.identity);
                }
            } 
    }
    private void SpawnEvents()
    {
            delaytoSpawnEvents -= Time.deltaTime;
            if (delaytoSpawnEvents <= 0.0f)
            {

                if (currentEvent == null)
                {
                    delaytoSpawnEvents = delaytoSpawnEventsAux;
                    currentEvent = Instantiate(events, placesOfSpawnEvents[Random.Range(0, placesOfSpawnEvents.Length)].position, Quaternion.identity);
               
                }
            }
    }
}

public enum ModesOfSpawn
{
Enemy,
Xp,
Events
}
