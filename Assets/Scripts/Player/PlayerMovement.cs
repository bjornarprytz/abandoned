using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public AudioClip crashAudioClip;
    public AudioClip cryAudioClip;
    public AudioClip investorLaugh;

    public static float MovementSpeed { get; private set; }  = 0;

    public float speedPitchIncrease = 0.5f;

    public float sidewaysJumpSize = 1;
    public float lanes = 5;

    private float currentPosition = 0;
    private float startYPos = 0;
    private float corretXPosition = 0;
    private AudioSource audioSource;

    private float audioPitch = 0;

    private bool isDead = false;

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
        instance.audioSource.pitch = Mathf.Lerp(instance.audioSource.pitch, instance.audioPitch, 0.05f);

        if (isDead)
        {
            MovementSpeed = Mathf.Lerp(MovementSpeed, 0, 0.005f);
            return;
        }

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
        if (amount > 0)
        {
            instance.audioPitch += instance.speedPitchIncrease;
        }
        else
        {
            instance.audioPitch -= instance.speedPitchIncrease;

            var randomRange = Random.Range(0, 100);
            if (randomRange < 25)
                instance.audioSource.PlayOneShot(instance.investorLaugh);

            if (randomRange > 75)
                instance.audioSource.PlayOneShot(instance.cryAudioClip);
        }

        if (instance.isDead) return;

        MovementSpeed = Mathf.Clamp(MovementSpeed + amount, 0, MovementSpeed + amount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Car"))
            Crash();
    }

    public static void Crash()
    {
        if (instance.isDead) return;

        instance.isDead = true;
        instance.audioSource.Stop();
        instance.audioSource.PlayOneShot(instance.crashAudioClip);
        instance.audioSource.PlayOneShot(instance.cryAudioClip);
        instance.audioSource.PlayOneShot(instance.investorLaugh);
    }
}
