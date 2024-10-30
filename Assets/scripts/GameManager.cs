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

    public TextMeshProUGUI pHealth;
    public TextMeshProUGUI cScore;
    public TextMeshProUGUI speedmeter;
    public TextMeshProUGUI damagemeter;

    public GameObject myPlayer;
    public GameObject EnemyPrefab;
    public GameObject CompanionPrefab;
    public GameObject item1;
    public GameObject item2;

    public Transform spawner;
    public Transform spawner2;
    public Transform spawner3;

    public float myTimer = 0f;
    public float myfixedTimer = 1f;
    public float spawnInterval = 5f;
    public float spawnIntervalitem = 20f;
    public float spawnTimer = 0f;
    public float spawnTimeritem = 0f;
    // Start is called before the first frame update

    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        pHealth.text = "Health: " + myPlayer.GetComponent<PlayerControls>().Health.ToString();
        damagemeter.text = "dmg: " + myPlayer.GetComponent<PlayerControls>().damage.ToString();
        speedmeter.text = "speed: " + myPlayer.GetComponent<PlayerControls>().speed.ToString();
        cScore.text = "Score: " + myPlayer.GetComponent<PlayerControls>().Score.ToString();

        myTimer += Time.deltaTime;

        spawnTimer += Time.deltaTime;
        spawnTimeritem += Time.deltaTime;

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

        }
        if (spawnTimeritem >= spawnIntervalitem)
        {
            spawnTimeritem = 0f;
            Vector3 SpawnPos = new Vector3(UnityEngine.Random.Range(-5, 5), 2, UnityEngine.Random.Range(-5, 5));
            spawner.transform.position = SpawnPos;

            System.Random rand = new System.Random();
            int decision = rand.Next(0, 2); 
            if(decision == 0)
            {
                Instantiate(item1, spawner.transform.position, spawner.transform.rotation);
            }
            else if (decision == 1)
            {
                Instantiate(item2, spawner.transform.position, spawner.transform.rotation);
            }

        }


        if (myPlayer.GetComponent<PlayerControls>().Health <= 0.0f)
        {
            // end game
            universevar.totalScore = myPlayer.GetComponent<PlayerControls>().Score;
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }



        if(myPlayer.GetComponent<PlayerControls>().Score >= 5f)
        {
            spawnInterval = 0.5f;
            spawnIntervalitem = 5f;
        }
    }
}
