using UnityEngine;


[CreateAssetMenu(fileName = "new Enemy", menuName = "Enemy")]
public class CreateEnemy : ScriptableObject
{
    public int number;
    public float xpValue;
    public int pointsValue;
    [Range(3.0f, 5.0f)]
    public float speed;
    public Sprite art;


}
