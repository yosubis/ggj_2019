using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : Tile
{
    private static List<Station> _allStations = new List<Station>();

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
