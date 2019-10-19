using UnityEngine;
using UnityEngine.AI;

public class EnemyAction : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject clickObject;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        clickObject = GameObject.FindGameObjectsWithTag("clickObject")[0];
        agent.destination = clickObject.transform.position;
    }
}