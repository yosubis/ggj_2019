using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	[SerializeField] protected Transform _playerPositionTransform;
	
	public Vector3 playerMarker{
        get{
            return _playerPositionTransform.position;
        }
    }
}
