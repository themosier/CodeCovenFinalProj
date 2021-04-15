using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    // Put this on the projectile prefab

    // This script checks for collision with a gameObject tagged "Enemy"
    // On collision with enemy this script destroys the enemy and the projectile
    // If we wanted to give the enemy a certain amount of health we can also change this to decrement the enemy health a certain amount and destroy the projectile on collision

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
