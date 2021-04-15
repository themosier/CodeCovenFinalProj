using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Put this on the Player object
    // This script identifies the GameObject tagged "Player" and sets it to the static variable Playermanager.player for reference from any script in the project

    // We can also add other general functionality to this for managing the Player within the game

    public static GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
