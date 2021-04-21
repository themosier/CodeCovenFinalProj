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
    private static List<Object> EnemyList;
    private float spawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");

        curEnemies = 0;
        EnemyList = new List<Object>();

        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }


    public void SpawnEnemy()
    {
        if (EnemyList.Count < maxEnemies)
        {
            Vector3 pos = GetComponent<Transform>().position;
            EnemyList.Add(Instantiate(enemyPrefab, pos, Quaternion.identity));
            curEnemies++;
        }

    }
}
