using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public static DayNightCycle Instance { get; private set; }

    [SerializeField]
    Light sun;
    [SerializeField]
    float speed;
    public TimeofDay timeofDay;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * speed, 0, 0);
        sun.intensity = Mathf.Sin(transform.eulerAngles.x / 60);
        if (transform.eulerAngles.x > 0 && transform.eulerAngles.x < 180 && timeofDay!=TimeofDay.Day)
        {
            timeofDay = TimeofDay.Day;

        }
        if (!(transform.eulerAngles.x > 0 && transform.eulerAngles.x < 180) && timeofDay!=TimeofDay.Night)
        {
            timeofDay = TimeofDay.Night;
        }

    }
}
[Serializable]
public enum TimeofDay
{
    Day,Night
}