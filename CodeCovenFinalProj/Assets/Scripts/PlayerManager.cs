using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    // Put this on the Player object
    // This script identifies the GameObject tagged "Player" and sets it to the static variable Playermanager.player for reference from any script in the project

    // We can also add other general functionality to this for managing the Player within the game

    public static GameObject player;

    //Player Health System
    public int maxHealth = 50;
    public int currentHealth;
    private bool isInvincible = false;
    public GameObject model;
    private Vector3 modelScale;
    
    [SerializeField]
    private float invincibilityDurationSec;
    private float invincibilityDeltaTime = 0.15f;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        Cursor.lockState = CursorLockMode.Locked;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        modelScale = model.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("-5 Damage");
            TakeDamage(5);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        }

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        Debug.Log("Took damage");
        StartCoroutine(TempInvincibility());
    }

    IEnumerator TempInvincibility()
    {
        Debug.Log("Invincible");
        isInvincible = true;


        for (float i = 0; i < invincibilityDurationSec; i += invincibilityDeltaTime)
        {
            // Flash character
            if (model.transform.localScale == modelScale)
            {
                model.transform.localScale = Vector3.zero;
            }
            else if (model.transform.localScale == Vector3.zero)
            {
                model.transform.localScale = modelScale;
            }

            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        

        isInvincible = false;
        model.transform.localScale = modelScale;
        Debug.Log("Not invincible anymore");
    }
}
