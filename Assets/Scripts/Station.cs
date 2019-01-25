using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private static List<Station> _allStations = new List<Station>();
    [SerializeField] private Transform _spawnPoint;

    void Awake(){
        _allStations.Add(this);
    }
}
