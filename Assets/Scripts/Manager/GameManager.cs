using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float difficultyIncreaseSeconds = 10;

    public float currentDifficulty = 1;
    public float currentSpeedAlteredDifficulty = 0;

    private float taskCountDown = 2;
    public float baseTaskFrequency = 3;

    // Update is called once per frame
    void Update()
    {
        currentDifficulty += (Time.deltaTime / difficultyIncreaseSeconds);
        currentSpeedAlteredDifficulty = Mathf.Clamp(currentDifficulty * PlayerMovement.MovementSpeed, currentDifficulty, currentDifficulty * PlayerMovement.MovementSpeed);

        taskCountDown -= Time.deltaTime;

        if (taskCountDown < 0)
        {
            taskCountDown = baseTaskFrequency - currentDifficulty;

            TaskController.CreateTask();
            TaskController.RedoPooledTask();
        }
    }
}
