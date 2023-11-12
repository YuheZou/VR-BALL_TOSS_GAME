using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnRangeX;
    [SerializeField] private float spawnRangeZ;
    private float enemySpawnInterval = 5;
    private float powerupSpawnInterval = 5;
    private float startWait;
    private int waveCount = 1;

    public List<GameObject> enemies;
    public List<GameObject> powerupRune;
    public GameManager GameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("enemySpawn", startWait, enemySpawnInterval);
        InvokeRepeating("powerupSpawn", startWait, powerupSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 generateRandomPos()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnRangeZ, spawnRangeZ);
        return new Vector3(xPos, -1, zPos);
    }

    void enemySpawn()
    {
        if (!GameManagerScript.gameOver())
        {
            int randomIndex;
            for (int i = 0; i < waveCount; i++)
            {
                randomIndex = Random.Range(0, 5);
                Instantiate(enemies[randomIndex], generateRandomPos(), enemies[randomIndex].transform.rotation);
            }
        }
    }

    void powerupSpawn()
    {
        if (!GameManagerScript.gameOver())
        {
            if (GameObject.FindGameObjectsWithTag("Health").Length == 0 && GameObject.FindGameObjectsWithTag("Strength").Length == 0)
            {
                int randomIndex = Random.Range(0, 2);
                Instantiate(powerupRune[randomIndex], generateRandomPos(), powerupRune[randomIndex].transform.rotation);
            }
        }
    }
}
