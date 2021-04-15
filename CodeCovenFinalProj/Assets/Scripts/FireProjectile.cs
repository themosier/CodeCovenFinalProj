using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public Object bulletPrefab;

    private Vector3 posOffset;

    // Start is called before the first frame update
    void Start()
    {
        float height = GetComponent<Renderer>().bounds.size.y;
        Debug.Log(GetComponent<Renderer>().bounds.size);
        posOffset = new Vector3(height, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        Vector3 pos = transform.position;
        Instantiate(bulletPrefab, pos + posOffset, Quaternion.identity);
    }
}
