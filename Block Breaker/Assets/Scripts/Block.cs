using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // when something collides that collision moment will tell us  what was the colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(obj, float t = 0.0f meaning how long you want it to get destroyed)
        // gameObject not captial referring to "this" gameObecjt(being the block)
        Destroy(gameObject);

        // tells us what collided with us. In this case would be "Ball"
        Debug.Log(collision.gameObject.name);
    }
}
