using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBehaviour : MonoBehaviour
{
    public Canvas gameCanvas;
    private MiniGame miniGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAbandon()
    {
        miniGame.OnAbandoned();
    }

    public void StartGame(MiniGame gamePrefab)
    {
        var go = Instantiate(gamePrefab, gameCanvas.transform);

        miniGame = go;
    }
}
