using UnityEngine;

public class ExplosionAction : MonoBehaviour
{
    void Start()
    {
        var explosion = GetComponent<ParticleSystem>();
        var main = explosion.main;
        main.loop = false;
        explosion.Play();
        Destroy(gameObject, main.duration);
    }
}
