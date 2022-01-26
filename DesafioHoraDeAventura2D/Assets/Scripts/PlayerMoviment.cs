using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private KeyCode keyMoveUp = KeyCode.W;
    [SerializeField] private KeyCode keyMoveDown = KeyCode.S;
    [SerializeField] private KeyCode keyMoveRight = KeyCode.D;
    [SerializeField] private KeyCode keyMoveLeft = KeyCode.A;
    [SerializeField] private float speed = 2.0f;


    private void FixedUpdate()
    {
        Inputs();
    }
    private void Inputs()
    {
        if (Input.GetKey(keyMoveLeft))
        {
            Move(new Vector2(-speed, 0));
        }
        if (Input.GetKey(keyMoveRight))
        {
            Move(new Vector2(speed, 0));
        }
        if (Input.GetKey(keyMoveUp))
        {
            Move(new Vector2(0, speed));
        }
        if (Input.GetKey(keyMoveDown))
        {
            Move(new Vector2(0, -speed));
        }
    }
    private void Move(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime);
    }
}
