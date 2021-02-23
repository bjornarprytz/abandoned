using UnityEngine;

public class TaskController : MonoBehaviour
{
    public static TaskController Instance { get; private set; }
    public TaskBehaviour taskPrefab;
    public MiniGame[] miniGamePool;

    public void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CreateTask(RandomPosition());
        }
    }


    public static TaskBehaviour CreateTask(Vector3 screenPosition)
    {
        var task = Instantiate(Instance.taskPrefab);

        task.StartGame(ChooseGame());

        return task;
    }

    private static MiniGame ChooseGame()
    {
        return Instance.miniGamePool[Random.Range(0, Instance.miniGamePool.Length)];
    }

    private static Vector3 RandomPosition()
    {
        var width = Random.Range(0, Screen.width);
        var height = Random.Range(0, Screen.height);

        width = Screen.width / 2;
        height = Screen.height / 2;

        return new Vector3(width, height, 0);
    }

}
