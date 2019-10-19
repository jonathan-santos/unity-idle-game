using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objects;
    public int min;
    public int max;
    public float minDistanceFromSpawn = 10;
    public float maxDistanceFromSpawn = 30;
    public float spawnInterval;

    GameObject randomObject;
    int maxcount;
    int count = 0;

    void Start()
    {
        maxcount = Random.Range(min, max);
        if(spawnInterval == 0)
        {
            for(int i = 0; i < maxcount; i++)
            {
                Spawn();
            }
        }
        else
        {
            InvokeRepeating("Spawn", 0, spawnInterval);
        }
    }

    void Update()
    {
        if(count > maxcount)
        {
            CancelInvoke();
        }    
    }

    void Spawn()
    {
        int index = Random.Range(0, objects.Length);
        randomObject = Instantiate(objects[index]);

        randomObject.transform.parent = transform;

        randomObject.transform.localPosition = new Vector3(
            Random.Range((transform.position.x + minDistanceFromSpawn) - maxDistanceFromSpawn, transform.position.x + maxDistanceFromSpawn),
            0,
            Random.Range((transform.position.z + minDistanceFromSpawn) - maxDistanceFromSpawn, transform.position.z + maxDistanceFromSpawn)
        );
        count++;
    }
}
