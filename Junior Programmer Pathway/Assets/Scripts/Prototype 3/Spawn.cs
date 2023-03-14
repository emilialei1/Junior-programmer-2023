using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private float startDelay = 2;
    private float repeatRate = 2;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private PlayerCon playerConScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerConScript = GameObject.Find("Player").GetComponent<PlayerCon>();
    }

    void SpawnObstacle()
    {
        if (playerConScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
