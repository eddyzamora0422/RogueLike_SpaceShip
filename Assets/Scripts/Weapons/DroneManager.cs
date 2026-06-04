using UnityEngine;
using System.Collections.Generic;

public class DroneManager : MonoBehaviour
{
    public GameObject dronePrefab;
    public Transform player;

    public float distance = 1.5f;

    List<GameObject> drones = new List<GameObject>();

    Vector2[] offsets =
    {
        new Vector2(1,1),
        new Vector2(-1,1),
        new Vector2(1,-1),
        new Vector2(-1,-1)
    };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddDrone();
        }
    }

    public void AddDrone()
    {
        if (drones.Count >= 4) return;

        GameObject drone = Instantiate(dronePrefab, player.position, Quaternion.identity);

        DroneFollower follower = drone.GetComponent<DroneFollower>();

        follower.player = player;
        follower.offset = offsets[drones.Count] * distance;

        drones.Add(drone);
    }
}