using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        //use invoke to trigger the start of making (aka instantiating) the first object. This invoke starts off the incursion that is to happen within SpawnRandomBall() method
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {    // Generate random ball index and random spawn position
         int randomBallIndex = Random.Range(0, ballPrefabs.Length);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBallIndex], spawnPos, ballPrefabs[randomBallIndex].transform.rotation);

        // Generate a random time spawn interval between 1-5 seconds - you can use variables if you want eg minInterval, maxInterval. I'm just using numbers here. Also using 1 and 5 here so I can see the difference. 3 & 5 seconds wasnt easy for me to see the diff.
        int spawnBallInterval = Random.Range(3, 5);

        //Invoke instantiation of ball at random spawn location with generated timelapse
        Invoke("SpawnRandomBall", spawnBallInterval);
    }

}
