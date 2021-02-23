using System;
using UnityEngine;

public abstract class MiniGame : MonoBehaviour
{
    public GameObject gameCanvas;
    public event Action GameCompleted;

    protected bool initialized;

    public AudioClip onStartAudioClip;
    public AudioClip onCompleteAudioClip;

    protected AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
    }

    private void AddAudioSource()
    {
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }


    public virtual void Init() 
    {
        initialized = true;
        AddAudioSource();
        if (onStartAudioClip != null) audioSource.PlayOneShot(onStartAudioClip);
    }
    public virtual void OnAbandoned() { }

    public virtual void OnPause() 
    {
        enabled = false;
    }

    public virtual void OnResume() 
    {
        enabled = false;
    }

    // Call this when the player completes the task
    public virtual void OnCompleted() 
    {
        AddAudioSource();

        if (GameCompleted != null)
        {
            if (onCompleteAudioClip != null) audioSource.PlayOneShot(onCompleteAudioClip);
            GameCompleted.Invoke();
        }
    }
}