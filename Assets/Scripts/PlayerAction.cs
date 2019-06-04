using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public Text scoreText;
    public int score;

    void Update()
    {
        scoreText.text = "Score: " + score;
    }
}