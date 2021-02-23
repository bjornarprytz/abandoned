using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestorMovement : MonoBehaviour
{
    public float yStart;
    public float yEnd;


    bool goingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        yStart = transform.position.y;
        yEnd = transform.position.y + 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(goingUp)
        {
            if (transform.position.y >= yEnd - 0.1f)
                goingUp = false;

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, yEnd, transform.position.z), 0.005f);
        }
        else
        {
            if (transform.position.y <= yStart + 0.1f)
                goingUp = true;

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, yStart, transform.position.z), 0.005f);
        }
    }
}
