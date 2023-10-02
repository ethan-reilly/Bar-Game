using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Setting up waypoints

    [SerializeField]
    private GameObject[] _waypoints;

    [SerializeField]
    private GameObject[] _npcs;


    void Start()
    {
        _waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Transform GenerateWaypoint()
    {

        return _waypoints[Random.Range(0, _waypoints.Length)].transform;
    }

    public GameObject[] GetWaypoints()
    {
        return _waypoints;
    }
}
