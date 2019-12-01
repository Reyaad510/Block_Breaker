using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // config paramaters
    [Range(0.5f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // state variables
    [SerializeField] int currentScore = 0;


    // Awake occurs before Start
    // With below put Game Canvas in Game Status to carry over the score and delete the GameCanvas from other levels
    private void Awake()
    {   // FindObjects(plural)
        // Looking for all GameStatus we have. If there is one then destroy yourself, if not then dont destroy when the level loads
        int gameStatusCont = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCont > 1)
        {
            // Fixes a bug with Singleton 
            gameObject.SetActive(false);
            // Destroy yourself
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();


    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
