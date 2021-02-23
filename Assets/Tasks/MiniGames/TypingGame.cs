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

        textProgress.fontSize = textTarget.fontSize;
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
        if (nextCharIdx >= textTarget.text.Length) return;

        var nextChar = textTarget.text[nextCharIdx];

        while (inputString.Length > 0 && nextChar == inputString[0])
        {
            textProgress.text += nextChar;

            inputString = inputString.Substring(1);

            nextCharIdx++;
            
            if (nextCharIdx == textTarget.text.Length)
                break;
            
            nextChar = textTarget.text[nextCharIdx];

        }

        if (textProgress.text == textTarget.text)
        {
            OnCompleted();
            Debug.Log("Typing Finished");
        }
    }
}
