using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    // Put this on the projectile prefab

    // This script sets a fixed velocity on the projectile at time of spawn

    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(PlayerManager.player.transform.forward * velocity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
