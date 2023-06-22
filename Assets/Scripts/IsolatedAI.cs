using UnityEngine;
using UnityEngine.AI;

public class IsolatedAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 destination;
    bool passive;
    // Update is called once per frame
    void Update()
    {
        if (DayNightCycle.Instance.timeofDay == TimeofDay.Day && !passive)
        {
            GetComponentInChildren<Renderer>().material.color = Color.blue;
            passive = true;
        }
        if (DayNightCycle.Instance.timeofDay == TimeofDay.Night && passive)
        {
            GetComponentInChildren<Renderer>().material.color = Color.red;
            passive = false;
        }
        if (transform.position == destination)
        {
            destination = TileGrid.Instance.roadTiles[Random.Range(0, TileGrid.Instance.roadTiles.Count)].transform.position;
        }
        if (destination.y!= transform.position.y)
        {
            destination.y = transform.position.y;
        }

        agent.SetDestination(destination);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !passive)
        {
            destination = other.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")&& !passive)
        {
            HealthManager.Instance.Health-=5;
        }
    }
}
