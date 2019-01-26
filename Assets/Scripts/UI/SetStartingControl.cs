using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetStartingControl : MonoBehaviour
{
	[SerializeField] private UnityEngine.UI.Selectable _startingControl;
	[SerializeField] private bool _runAtStart = false;
	
	void Awake(){
		if(_runAtStart){
			_startingControl.Select();
			_startingControl.OnSelect(null);
		}
	}

	public void SelectStartingControl(){
		_startingControl.Select();
		_startingControl.OnSelect(null);
	}
}
