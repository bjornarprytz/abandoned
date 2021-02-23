using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCall : MiniGame
{
    public AudioClip[] customerVoicesAudio;

    public TextMeshProUGUI customerText;
    public TextMeshProUGUI buttonText;
    public Button responseButton;

    public string[] customerProblems = { "My cat broke my VR headset!", "Model cloud keeps freezing.", "Aliens are inside small scale" };
    public string[] customerProblemResponses = { "Restart your pc.", "Are you serious.", "It's my day off." };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AnswerPhone()
    {
        audioSource.PlayOneShot(customerVoicesAudio[Random.Range(0, customerVoicesAudio.Length - 1)]);
        customerText.text = customerProblems[Random.Range(0, customerProblems.Length - 1)];
        buttonText.text = customerProblemResponses[Random.Range(0, customerProblemResponses.Length - 1)];

        responseButton.onClick.RemoveAllListeners();
        responseButton.onClick.AddListener(OnFinalResponse);
    }

    public void OnFinalResponse()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        OnCompleted();
    }
}
