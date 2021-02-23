using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public AudioClip crashAudioClip;

    public static float MovementSpeed { get; private set; }  = 0;

    public float speedPitchIncrease = 0.5f;

    public float sidewaysJumpSize = 1;
    public float lanes = 5;

    private float currentPosition = 0;
    private float startYPos = 0;
    private float corretXPosition = 0;
    private AudioSource audioSource;

    private float audioPitch = 0;


    private void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioPitch = audioSource.pitch;
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
        instance.audioSource.pitch = Mathf.Lerp(instance.audioSource.pitch, instance.audioPitch, 0.05f);
    }

    public static void AlterMoveSpeed(float amount)
    {
        if (amount > 0)
            instance.audioPitch += instance.speedPitchIncrease;
        else
            instance.audioPitch -= instance.speedPitchIncrease;
       
        MovementSpeed = Mathf.Clamp(MovementSpeed + amount, 0, MovementSpeed + amount);
    }

    public static void Crash()
    {
        instance.audioSource.Stop();
        instance.audioSource.PlayOneShot(instance.crashAudioClip);
    }
}
