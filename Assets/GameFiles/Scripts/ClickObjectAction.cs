using UnityEngine;

public class ClickObjectAction : MonoBehaviour
{
    public PlayerAction player;
    public int scorePointsOnClick = 1;

    void OnMouseDown()
    {
        player.score += scorePointsOnClick;
    }
}
