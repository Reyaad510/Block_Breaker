using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour

    // configuration parameters
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15;
    [SerializeField] float screenWidthInUnits = 16f;

    // cached references
    GameStatus theGameStatus;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // compact way of storing x and y positions
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        // Mathf.Clamp you pass in the float number and give it a min number and max number this being the end of the screens so the paddle wont fly off
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
        
    }

    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            // Used to enable autoplay for testing for developers
            return theBall.transform.position.x;
        }
        else
        { // get mouse position according to pixels and length in our case being 16 bcuz 4:3
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
