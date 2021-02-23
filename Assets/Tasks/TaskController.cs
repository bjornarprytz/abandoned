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
            CreateTask();
        }
    }


    public static TaskBehaviour CreateTask()
    {
        var task = Instantiate(Instance.taskPrefab, Camera.main.transform);

        var taskWidth = Screen.width / 8;
        var taskHeight = Screen.height / 8;

        var x = Random.Range(0, Screen.width - taskWidth);
        var y = Random.Range(0, Screen.height - taskHeight );

        var rt = task.gameCanvas.GetComponent<RectTransform>();

        rt.position = new Vector3(x, y);
        rt.sizeDelta = new Vector2(taskWidth, taskHeight);

        task.StartGame(ChooseGame());

        return task;
    }

    private static MiniGame ChooseGame()
    {
        return Instance.miniGamePool[Random.Range(0, Instance.miniGamePool.Length)];
    }
}
