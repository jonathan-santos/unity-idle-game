﻿using UnityEngine;

public class ClickObjectAction : MonoBehaviour
{
    public PlayerAction player;
    public int scorePointsOnClick = 1;

    void OnMouseDown()
    {
        player.score += scorePointsOnClick;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            player.score -= 10;
            if (player.score < 0)
            {
                player.score = 0;
            }
            Destroy(collision.gameObject);
        }
    }
}
