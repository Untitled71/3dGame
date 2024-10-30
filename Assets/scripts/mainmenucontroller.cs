using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenucontroller : MonoBehaviour
{
    public string Scene1;
    public TextMeshProUGUI FinalScore;
    public float fscore = 0f;
    //public GameObject gm1;
    public void Loadscene()
    {
        SceneManager.LoadScene("lvlOneScene", LoadSceneMode.Single);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Awake()
    {
        fscore = universevar.totalScore;
        FinalScore.text = "Last Score: " + fscore.ToString();
    }
}