using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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

        Vector3 vec = new Vector3(EnemyManager.player.transform.position.x, transform.position.y, EnemyManager.player.transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, vec, velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
            EnemyManager.curEnemies--;
        }
    }
}
