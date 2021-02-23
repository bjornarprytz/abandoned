using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearShift : MiniGame
{
    public Slider gearUp;
    public Slider gearRight;

    public AudioClip gearSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckProgress();
    }

    public override void Init()
    {
        base.Init();

        gearRight.gameObject.SetActive(false);
    }

    private void CheckProgress()
    {
        if (gearUp.IsActive() && gearUp.value == 1)
        {
            gearRight.gameObject.SetActive(true);
            gearUp.gameObject.SetActive(false);
            audioSource.PlayOneShot(gearSound);
        }

        if (gearRight.value == 1)
        {
            OnCompleted();
        }
    }
}
