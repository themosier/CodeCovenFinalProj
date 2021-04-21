using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Put this on the Player object
    // This script identifies the GameObject tagged "Player" and sets it to the static variable Playermanager.player for reference from any script in the project

    // We can also add other general functionality to this for managing the Player within the game

    public static GameObject player;

    //Player Health System
    public int maxHealth = 50;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        Cursor.lockState = CursorLockMode.Locked;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("-5 Damage");
            TakeDamage(5);
        }

        void TakeDamage (int damage)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
    }
}
