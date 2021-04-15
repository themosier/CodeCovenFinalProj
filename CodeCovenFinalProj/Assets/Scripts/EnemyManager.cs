using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Object enemyPrefab;
    public static GameObject player;

    public static int maxEnemies = 5;
    public static int curEnemies;
    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        curEnemies = 0;
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning && curEnemies < maxEnemies)
        {
            //Invoke("SpawnEnemy", 1.0f);
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
