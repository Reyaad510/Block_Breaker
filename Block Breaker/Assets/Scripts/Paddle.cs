using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{   
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
        Vector2 paddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
        transform.position = paddlePosition;
        
    }
}
