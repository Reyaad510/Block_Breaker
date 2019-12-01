using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    // cached reference
    Level level;


    private void Start()
    {
        // Looking for something of the Type Level and assigning it to variable level
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

  


    // when something collides that collision moment will tell us  what was the colision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(obj, float t = 0.0f meaning how long you want it to get destroyed)
        // gameObject not captial referring to "this" gameObecjt(being the block)
        // creating new AudioSource so dont use GetComponent. PlayClipAtPoint creates a new audiosource
        // Camera.main.transform.position saying to play break sound at the position of the camera. If play sound on block wont sound loud bcuz of 3d space. Click 2d tab to understand
        DestroyBlock();


        // tells us what collided with us. In this case would be "Ball"
        Debug.Log(collision.gameObject.name);
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().addToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}









/*Prefab notes
 
- To make a prefab take an object and drag it below in the "Project" Tab
- From there make a new game object called "Blocks" to store all blocks
- Drag n drop the prefabs into the "Blocks" object or onto the canvas
- In "Edit" you can go to "Snap Settings" and change the way the blocks can move
- Click an object and hold "CTRL" and move them and they will move incrementally depending on the "Snap Settings"
- You can snap other block together by clicking on it and then holding "V". Boxes will appear on the corners. You then left click and drag next to another block and it will snap to it.
- To create neat blocks and alot hold "Shift" and click on blocks that are together(worked for me by highlighting in the Blocks ob) and then duplicate(CTRL D). 
- After "CTRL-D" then use the snap to move them incrementally(CTRL- Direction To Move)
- Make sure to click Apply on prefab override settings when changing anything to apply to rest so they affect all scenes

*/


    // Audio dont use .wav because they are massive. Used Ogg Vorbis and not mp3
    // on Ball Audio Source play on awake means something that will play when game starts!