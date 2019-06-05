using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public int passiveScoreGain = 0;
    float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 1f)
        {
            score += passiveScoreGain;
            time = 0;
        }

        scoreText.text = "Score: " + score;
        if(passiveScoreGain > 0)
        {
            scoreText.text += "\nPassive gain: " + passiveScoreGain + "/s";
        }
    }
}