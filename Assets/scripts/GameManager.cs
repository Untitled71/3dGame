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
        if(universaltime % 10 == 0)
        {
            Instantiate(EnemyPrefab, spawner2);
        }
        if(universaltime % 30  == 0)
        {
            Instantiate(item1, spawner);
        }

    }
}
