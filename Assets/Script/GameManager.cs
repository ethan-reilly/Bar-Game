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


    int currentCustomer = 0;


    void Start()
    {
        _waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        _npcs = GameObject.FindGameObjectsWithTag("NPC");

        for (int i = 0; i < _npcs.Length; i++)
        {
            _npcs[i].SetActive(false);
        }

        Invoke("NextCustomer", 3f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void NextCustomer()
    {
        Debug.Log("Next Customer");
        if (currentCustomer < _npcs.Length)
        {
            _npcs[currentCustomer].SetActive(true);
        }
        currentCustomer++;
    }

    public GameObject[] GetNPCs()
    {
        return _npcs;
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
