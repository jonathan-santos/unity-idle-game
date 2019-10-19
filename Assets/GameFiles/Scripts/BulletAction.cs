using UnityEngine;

public class BulletAction : MonoBehaviour
{
    public PlayerAction player;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            player.score += 5;
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
