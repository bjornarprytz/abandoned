using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLoop : MonoBehaviour
{
    [SerializeField]
    private Transform[] worldChunks;
    private float distanceMidway = 25f;
    private float distanceCounter = 0f;
    private int currentChunk = 2;

    [SerializeField]
    // Adjust this modifier until the gamefeel is good.
    private float spdMod = 1f;

    // Change out currentSpeed for whatever the player's speed is set to.
    public float currentSpeed = 1f;

    private void FixedUpdate()
    {
        MoveWorld();
    }

    private void MoveWorld()
    {
        float movement = (spdMod * currentSpeed) * Time.deltaTime;
        foreach (Transform chunk in worldChunks)
        {
            chunk.position = new Vector3(chunk.position.x - movement, 0, 0);
        }
        distanceCounter += movement;
        if (distanceCounter >= distanceMidway)
        {
            distanceCounter -= distanceMidway;
            ShiftChunk();
        }
    }
    private void ShiftChunk()
    {
        int firstChunk = 0;
        int finalChunk = 0;
        switch (currentChunk)
        {
            case (0):
                firstChunk = 3;
                finalChunk = 2;
                break;
            case (1):
                firstChunk = 4;
                finalChunk = 3;
                break;
            case (2):
                firstChunk = 0;
                finalChunk = 4;
                break;
            case (3):
                firstChunk = 1;
                finalChunk = 0;
                break;
            case (4):
                firstChunk = 2;
                finalChunk = 1;
                break;
            default:
                Debug.Log("INCORRECT WORLD CHUNK NUMBER!");
                break;
        }
        worldChunks[firstChunk].position = new Vector3(worldChunks[finalChunk].position.x + 50, 0, 0);
        if (currentChunk >= 4)
        {
            currentChunk = 0;
        }
        else
        {
            currentChunk++;
        }
    }
}
