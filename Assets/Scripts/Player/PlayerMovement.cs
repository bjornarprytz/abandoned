using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sidewaysJumpSize = 1;
    public float lanes = 5;

    private float currentPosition = 0;
    private float startYPos = 0;
    public float speed = 0;
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
        transform.position = Vector3.Lerp(transform.position, new Vector3(xPosition, startYPos + speed, transform.position.z), 0.005f);
    }
}
