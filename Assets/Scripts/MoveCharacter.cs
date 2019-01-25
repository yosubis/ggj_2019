using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private bool _isMoving = false;
    private static LayerMask _floorLayer;
    private RaycastHit _hit;

	private Vector3 _toPosition;
	private Vector3 _fromPosition;
	[SerializeField] private float _speed;

	private float _moveTotalDistance;
	private float _moveCurrentDistance;
	private float _moveTimeStart;

	private Tile _targetTile;

	private Battery battery;

	void Awake(){
		battery = GetComponent<Battery>();
	}

    private bool Move(Vector3 direction){
		if(Physics.Raycast(transform.position, direction, out _hit, 1.0f, LayerMask.GetMask("Floor"))){
			if(_targetTile != null && _targetTile.GetType() == typeof(Station)){
				((Station)_targetTile).Undock(battery);
			}
			_targetTile = _hit.collider.gameObject.GetComponent<Tile>();
			_toPosition = _targetTile.playerMarker;
			_fromPosition = transform.position;
			//TODO Import dotween from store and use it to move the character. once the move is complete, call a method to set _isMoving to false
			_isMoving = true;
			_moveTotalDistance = Vector3.Distance(_fromPosition, _toPosition);
			_moveTimeStart = Time.time;
		}
        return false;
    }

    private void Update(){
		if(battery.hasEnergy){
			if(!_isMoving){
				if(Input.GetKey(KeyCode.LeftArrow)){
					Move(Vector3.left);
				}else if(Input.GetKey(KeyCode.RightArrow)){
					Move(Vector3.right);
				}else if(Input.GetKey(KeyCode.UpArrow)){
					Move(Vector3.up);
				}else if(Input.GetKey(KeyCode.DownArrow)){
					Move(Vector3.down);
				}
			}else{
				AnimateMove();
			}
		}
    }

	private void AnimateMove(){
		_moveCurrentDistance = (Time.time - _moveTimeStart) * _speed;
		transform.position = Vector3.Lerp(_fromPosition, _toPosition, _moveCurrentDistance/_moveTotalDistance);
		//transform.position = Vector3.MoveTowards(_fromPosition, _toPosition, Time.deltaTime * _speed);
		if(transform.position == _toPosition){
			transform.position = _toPosition;
			_isMoving = false;
			if(_targetTile.GetType() == typeof(FloorTile)){
				((FloorTile)_targetTile).Clean();
			}
			if(_targetTile.GetType() == typeof(Station)){
				((Station)_targetTile).Dock(battery);
			}
		}
	}
}
