using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float difficultyIncreaseSeconds = 10;

    public float currentDifficulty = 1;
    public float currentSpeedAlteredDifficulty = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentDifficulty += (Time.deltaTime / difficultyIncreaseSeconds);
        currentSpeedAlteredDifficulty = Mathf.Clamp(currentDifficulty * PlayerMovement.MovementSpeed, currentDifficulty, currentDifficulty * PlayerMovement.MovementSpeed);

        if (Input.GetKeyDown(KeyCode.W))
            PlayerMovement.MovementSpeed++;
        if (Input.GetKeyDown(KeyCode.S))
            PlayerMovement.MovementSpeed--;
    }
}
