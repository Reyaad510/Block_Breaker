using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    // This is to say when we have the ball collider go through the box trigger collider then to end game
    // Normally wouldnt use hard coded string "Game Over"(referring to scene in build settings) but since we know we will never change it is okay. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");
    }
}
