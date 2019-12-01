using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour

    // configuration parameters
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15;
    [SerializeField] float screenWidthInUnits = 16f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // get mouse position according to pixels and length in our case being 16 bcuz 4:3
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        // compact way of storing x and y positions
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        // Mathf.Clamp you pass in the float number and give it a min number and max number this being the end of the screens so the paddle wont fly off
        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minX, maxX);
        transform.position = paddlePosition;
        
    }
}
