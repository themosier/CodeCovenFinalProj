using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    // Put this on the Player object

    // set bulletPrefab to the projectile prefab
    // set spawnPoint to the gameObject from which we want to fire the projectiles (i.e.: gun)

    // This should spawn a projectile at the spawnPoint regardless of how it has moved through worldspace

    public Object bulletPrefab;
    public GameObject spawnPoint;

    private Vector3 posOffset;

    // Start is called before the first frame update
    void Start()
    {
        float length = spawnPoint.GetComponent<Renderer>().bounds.size.z;
        float width = spawnPoint.GetComponent<Renderer>().bounds.size.x;
        Debug.Log(spawnPoint.GetComponent<Renderer>().bounds.size);
        posOffset = new Vector3(width / 2.0f, 0.0f, length / 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        Vector3 pos = spawnPoint.transform.position;
        Instantiate(bulletPrefab, pos + posOffset, Quaternion.identity);
    }
}
