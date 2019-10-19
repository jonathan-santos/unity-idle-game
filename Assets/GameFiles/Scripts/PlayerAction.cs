using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    [Header("Idle")]
    public Text scoreText;
    public int score = 0;
    public int passiveScoreGain = 0;

    [Header("Shooter")]
    public GameObject bullet;
    public int bulletVelocity = 50;

    new Camera camera;
    float time = 0f;

    void Start()
    {
        camera = this.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        UpdateIdle();
        UpdateShooter();
    }

    void UpdateIdle()
    {
        time += Time.deltaTime;
        if (time >= 1f)
        {
            score += passiveScoreGain;
            time = 0;
        }

        scoreText.text = "Score: " + score;
        if (passiveScoreGain > 0)
        {
            scoreText.text += "\nPassive gain: " + passiveScoreGain + "/s";
        }
    }

    void UpdateShooter()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var newBullet = Instantiate(bullet);
            var newBulletRB = newBullet.GetComponent<Rigidbody>();
            var newBulletAction = newBullet.GetComponent<BulletAction>();
            newBulletAction.player = this;
            newBullet.transform.position = this.transform.position;
            newBulletRB.velocity = camera.transform.rotation * Vector3.forward * bulletVelocity;
            Destroy(newBullet, 2);
        }
    }
} 