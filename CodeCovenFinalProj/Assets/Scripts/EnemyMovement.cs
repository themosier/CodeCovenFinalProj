using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Put this on enemy prefab
    
    // This spawns enemies that move toward the player in a linear fashion
    // Am going to try and update this to an algorithm to deal with obstacles but for now it's just linear

    private Rigidbody rb;
    private Vector3 forward;

    //public GameObject player;

    public float velocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = rb.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 vec = rb.position - player.transform.position;
        //Vector3 vec = player.transform.position + rb.position;
        //rb.velocity = -vec * velocity;

        Vector3 vec = new Vector3(PlayerManager.player.transform.position.x, transform.position.y, PlayerManager.player.transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, vec, velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            //EnemyManager.curEnemies--;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            EnemyManager.curEnemies--;
            FireProjectile.ammoCt++;
            Debug.Log("Hit Enemy");
        }

    }
}
