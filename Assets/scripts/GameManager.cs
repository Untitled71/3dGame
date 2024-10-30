using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public float myTimer = 0f;
    public float myfixedTimer = 1f;
    public float spawnInterval = 5f;
    public float spawnTimer = 0f;
    // Start is called before the first frame update

    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //add time passed between frames
        myTimer += Time.deltaTime;

        //track enemy spawn time here
        spawnTimer += Time.deltaTime;
        //once the interval is hit, trigger an enemy spawn and reset timer
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Vector3 SpawnPos = new Vector3(UnityEngine.Random.Range(-48, 48), 2, UnityEngine.Random.Range(-48, 48));
            if (myPlayer.transform.position == SpawnPos)
            {
                SpawnPos = new Vector3(UnityEngine.Random.Range(-48, 48), 2, UnityEngine.Random.Range(-48, 48));
            }
            spawner.transform.position = SpawnPos;
            Instantiate(EnemyPrefab, spawner.transform.position, spawner.transform.rotation);

            //Debug.Log("enemy spawn");
        }
        //because gameManager has an explicit connection to the player, we
        //can reference the player components, including WASD.cs, and find our score

        if(myPlayer.GetComponent<PlayerControls>().Health <= 0.0f)
        {
            // end game
            universevar.totalScore = myPlayer.GetComponent<PlayerControls>().Score;
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }



        if(myPlayer.GetComponent<PlayerControls>().Score == 5)
        {
            spawnInterval = 2f;
        }
    }
}
