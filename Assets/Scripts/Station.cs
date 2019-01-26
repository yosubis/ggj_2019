using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : Tile
{
    private static List<Station> _allStations = new List<Station>();

	public static Station GetRandomStation(){
		print(_allStations.Count);
		return _allStations[Random.Range(0, _allStations.Count)];
	}

    void Awake(){
        _allStations.Add(this);
    }

    public void Dock(Battery battery){
		battery.StartCharge();
	}

	public void Undock(Battery battery){
		battery.EndCharge();
	}
}
