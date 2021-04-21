using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    private const int AMMO_MAX = 100;
    private float currAmmo;
    private float ammoRegenAmt = 10f;

    public Object bulletPrefab;
    public GameObject spawnPoint;

    public Slider ammoBar;


    // Start is called before the first frame update
    void Awake()
    {
        currAmmo = AMMO_MAX;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CheckAmmo());
        }
        currAmmo += ammoRegenAmt * Time.deltaTime;

        ammoBar.value = currAmmo;
    }
    private void SpawnBullet()
    {
        Vector3 pos = spawnPoint.transform.position;
        Instantiate(bulletPrefab, pos, Quaternion.identity);
        //currAmmo -= ammoRegenAmt;
    }

    private IEnumerator CheckAmmo()
    {
        if (currAmmo > 0)
        {
            SpawnBullet();
            currAmmo -= ammoRegenAmt;
        }

        yield return new WaitForSeconds(0.2f);
    }
}

