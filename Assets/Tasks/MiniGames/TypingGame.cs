using TMPro;
using UnityEngine;

public class TypingGame : MiniGame
{
    public TextMeshProUGUI textTarget;
    public TextMeshProUGUI textProgress;

    private int nextCharIdx;

    private static string[] easyStrings =
    {
        "no",
        "help",
        "i++;",
        "thanks",
        "yes",
    };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            CheckProgress(Input.inputString);
        }
    }

    public override void Init()
    {
        base.Init();

        textTarget.text = easyStrings[Random.Range(0, easyStrings.Length)];

        nextCharIdx = 0;

        textProgress.text = "";
    }

    void CheckProgress(string inputString) 
    {
        var nextChar = textTarget.text[nextCharIdx];

        while (nextChar == inputString[0])
        {
            textProgress.text += nextChar;

            inputString = inputString.Substring(1);

            if (nextCharIdx == textTarget.text.Length)
                break;
            
            nextCharIdx++;
            
            nextChar = textTarget.text[nextCharIdx];

        }

        if (textProgress.text == textTarget.text)
        {
            OnCompleted();
        }
    }
}
