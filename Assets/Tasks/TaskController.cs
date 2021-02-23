using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public static TaskController Instance { get; private set; }
    public TaskBehaviour taskPrefab;
    public MiniGame[] miniGamePool;

    public AudioClip notificationAudioClip;

    private AudioSource audioSource;

    private static Queue<TaskBehaviour> AbandonedTasks { get; set; } = new Queue<TaskBehaviour>();

    public void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
    }

    public static TaskBehaviour RedoPooledTask()
    {
        if (AbandonedTasks.Count == 0)
            return null;
        
        var task = AbandonedTasks.Dequeue();

        Debug.Log("Redoing task");

        if (task != null)
        {
            Instance.audioSource.PlayOneShot(Instance.notificationAudioClip);
            task.ResumeGame();
        }

        return task;
    }

    public static TaskBehaviour CreateTask()
    {
        var task = Instantiate(Instance.taskPrefab, Camera.main.transform);

        var taskWidth = Screen.width / 8;
        var taskHeight = Screen.height / 8;

        var x = Random.Range(taskWidth, Screen.width - taskWidth);
        var y = Random.Range(taskHeight, Screen.height - taskHeight);

        var rt = task.gameContainer.GetComponent<RectTransform>();

        rt.position = new Vector3(x, y);
        rt.sizeDelta = new Vector2(taskWidth, taskHeight);

        task.StartGame(ChooseGame());
        Instance.audioSource.PlayOneShot(Instance.notificationAudioClip);
        return task;
    }

    public static void AddToPool(TaskBehaviour abandonedTask)
    {
        Debug.Log("Adding task to pool");

        AbandonedTasks.Enqueue(abandonedTask);
    }

    private static MiniGame ChooseGame()
    {
        return Instance.miniGamePool[Random.Range(0, Instance.miniGamePool.Length)];
    }
}
