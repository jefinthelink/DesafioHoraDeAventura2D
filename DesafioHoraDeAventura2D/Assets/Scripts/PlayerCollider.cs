using UnityEngine.Audio;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
     private Player player;
    private AudioSource source;
    

    private void Start()
    {
        GetValues();
    }
    private void GetValues()
    {
        player = transform.GetComponent<Player>();
        source = transform.GetComponent<AudioSource>();
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.number >= player.level)
            {
                player.GameOverPanel.SetActive(true);
                player.GameOverPanel.GetComponent<GameOver>().ShowPanel();
                Destroy(transform.gameObject);
            }
            else
            {
                player.points += enemy.pointsValue;
                player.GetXp(enemy.xpValue);
                Destroy(collision.gameObject);
               
            }
        }
        if (collision.gameObject.CompareTag("Xp"))
        {
            Xp xp = collision.gameObject.GetComponent<Xp>();
            player.GetXp(xp.xpValue);
            player.points += xp.pointValue; 
            source.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("StartEvent"))
        {
            player.events.StartEvent();
            Destroy(collision.gameObject);

        }

        
       
    }

}
