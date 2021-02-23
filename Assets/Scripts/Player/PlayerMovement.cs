using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float MovementSpeed { get; private set; }  = 0;

    public float sidewaysJumpSize = 1;
    public float lanes = 5;

    private float currentPosition = 0;
    private float startYPos = 0;
    private float corretXPosition = 0;

    private void Start()
    {
        startYPos = transform.position.y;
        corretXPosition = transform.position.x;
    }

    private void Update()
    {
        float xPosition = corretXPosition;
        if (Input.GetKeyDown(KeyCode.A) && -(lanes / 2) < currentPosition - 1)
        {
            currentPosition--;
            xPosition -= sidewaysJumpSize;
        }

        if (Input.GetKeyDown(KeyCode.D) && (lanes / 2) > currentPosition + 1)
        {
            currentPosition++;
            xPosition += sidewaysJumpSize;
        }
        corretXPosition = xPosition;
        transform.position = Vector3.Lerp(transform.position, new Vector3(xPosition, startYPos + MovementSpeed, transform.position.z), 0.005f);
    }

    public static void AlterMoveSpeed(float amount)
    {
        if(amount > 0)
        {
            //play speed up sound
        }
        else
        {
            //play slow down sounds
        }

        MovementSpeed = Mathf.Clamp(MovementSpeed + amount, 0, MovementSpeed + amount);
    }
}
