using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    // cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    // This adds amount of blocks because each block instance of the prefab has the Block script which calls the CountBreakableBlocks() method in the start. They instance says "Add" which is how we get the breakable blocks number
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        
        if(breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }

    }


}
