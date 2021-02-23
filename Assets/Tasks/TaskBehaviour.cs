using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBehaviour : MonoBehaviour
{
    public GameObject gameContainer;
    private MiniGame miniGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAbandon()
    {
        miniGame.OnAbandoned();
        Destroy(gameObject);
    }


    public void StartGame(MiniGame gamePrefab)
    {
        var go = Instantiate(gamePrefab);
        go.transform.SetParent(gameContainer.transform, false);
        go.Init();
        go.GameCompleted += Go_GameCompleted;

        miniGame = go;
    }

    private void Go_GameCompleted()
    {
        Destroy(gameObject);
    }
}
