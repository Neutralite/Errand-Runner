using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * speed, 0, 0);
    }
}
