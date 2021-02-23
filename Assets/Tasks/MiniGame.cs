using System;
using UnityEngine;

public abstract class MiniGame : MonoBehaviour
{
    public GameObject gameCanvas;
    public event Action GameCompleted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Init() { }
    public virtual void OnAbandoned() { }

    // Call this when the player completes the task
    public virtual void OnCompleted() 
    {
        if (GameCompleted != null)
        {
            GameCompleted.Invoke();
        }
    }
}
