using UnityEngine;

public class TimeController : MonoBehaviour
{
    bool isRunning = true;
    float time;
    public float startTime = 15.0f;
    bool isActive = true;
    float displayTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning && isActive)
        {
            time += Time.deltaTime;
            displayTime = time - startTime + 1;
            if (displayTime <= 0)
            {
                displayTime = 0;
                IsActive();
            }

        }
        else
        {
            return;
        }
    }

    public void IsActive()
    {
        isActive = false;
    }

    public float GetDisplayTime()
    {
        return displayTime;
    }
}
