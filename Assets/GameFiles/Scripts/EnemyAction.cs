using UnityEngine;
using UnityEngine.AI;

public class EnemyAction : MonoBehaviour
{
    public GameObject explosion;

    void Start()
    {
        var clickObject = GameObject.FindGameObjectWithTag("clickObject");
        var agent = GetComponent<NavMeshAgent>();
        agent.destination = clickObject.transform.position;
        transform.LookAt(clickObject.transform.position, Vector3.up);
    }

    private void OnDestroy()
    {
        var newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
    }
}