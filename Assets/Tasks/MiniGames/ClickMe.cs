using UnityEngine;

public class ClickMe : MiniGame
{
    public void Awake()
    {

    }

    public void OnClickDestroy()
    {
        Debug.Log("It clicked Yay!");
        Destroy(gameObject);
    }
}
