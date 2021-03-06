using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerups;
    public int difficulty;

    public float delay;
    float timeFromSpawn;
    public float[] spawnPoints;

    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        timeFromSpawn = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.GameSpeed == 4) 
        {
            delay = 12;
        }
        if (GameHandler.GameSpeed == 2)
        {
            delay = 24;
        }     
        if (timeFromSpawn >= delay)
		{
            if (rand.Next(0, 1000) <= difficulty)
            {
                Instantiate(powerups[rand.Next(0, powerups.Length)], new Vector2(transform.position.x, spawnPoints[rand.Next(0, spawnPoints.Length)]), transform.rotation);
                timeFromSpawn = 0;
            }

		}
        timeFromSpawn += Time.deltaTime;
    }
}
