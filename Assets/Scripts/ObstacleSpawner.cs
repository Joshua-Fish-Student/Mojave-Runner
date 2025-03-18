using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject[] obstacleIntances;
    public int numberOfIntances = 10;
    public int instanceIndex;
    public float timeToSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(1.2f,2f);

        obstacleIntances = new GameObject[numberOfIntances];

        for(int i= 0; i < numberOfIntances; i++){
            obstacleIntances[i] = Instantiate(obstaclePrefab);
            obstacleIntances[i].transform.position = transform.position;
            obstacleIntances[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;

        if(timeToSpawn <= 0.0f){
            SpawnObstacle();
            timeToSpawn = Random.Range(1.2f,2f);
        }
    }

    void SpawnObstacle(){
        obstacleIntances[instanceIndex].SetActive(true);
        obstacleIntances[instanceIndex].transform.position = transform.position;
        instanceIndex++;
        if(instanceIndex == numberOfIntances) instanceIndex = 0;
    }
}
