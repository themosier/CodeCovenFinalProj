using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Put this on empty object marking enemy spawn points

    // this spawns enemies from a designated spawn point

    public Object enemyPrefab;
    
    // obsolete: use PlayerManager.player
    //public static GameObject player;

    public static int maxEnemies = 5;
    public static int curEnemies;
    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");

        curEnemies = 0;
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning && curEnemies < maxEnemies)
        {
            Invoke("SpawnEnemy", 1.0f); // Change float value to desired spawn interval
            isSpawning = true;
        }
    }

    public void SpawnEnemy()
    {
        Vector3 pos = GetComponent<Transform>().position;
        Instantiate(enemyPrefab, pos, Quaternion.identity);
        curEnemies++;
        isSpawning = false;
    }
}
