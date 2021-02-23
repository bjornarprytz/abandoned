using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class BreakGame : MiniGame
{
    public Image progress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            progress.fillAmount += Time.deltaTime / 2;
        }
        else
        {
            progress.fillAmount = 0;
        }

        if (progress.fillAmount == 1)
        {
            OnCompleted();
        }
    }

}
