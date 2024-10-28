using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float universaltime = 0f;

    public GameObject myPlayer;
    public GameObject EnemyPrefab;
    public GameObject CompanionPrefab;
    public GameObject item1;
    public GameObject item2;

    public Transform spawner;
    public Transform spawner2;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        universaltime += Time.deltaTime;

        // SPAWNING
        if(universaltime % 10 <= 0.1f)
        {
            Debug.Log("spawn enemy");
            Instantiate(EnemyPrefab, spawner2.position, spawner2.rotation);
        }
        if(universaltime % 30  <= 0.1f)
        {
            Instantiate(item1, spawner.position, spawner.rotation);
        }

        // CHECK PLAYER ALIVE
        if(myPlayer.GetComponent<PlayerControls>().Health <= 0.0f)
        {
            // change to menu screen
            Debug.Log("End game");
        }
    }
}
