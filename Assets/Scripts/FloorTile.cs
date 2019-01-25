using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    private static int _totalCells = 0;
    private static int _cleanCells = 0;
    [SerializeField] private Transform _playerPositionTransform;
    [SerializeField] private SpriteRenderer _spriteComponent;

    private bool _isClean = false;

    public static int totalCells{
        get{
            return _totalCells;
        }
    }

    public static int cleanCells{
        get{
            return _cleanCells;
        }
    }

    public Vector3 playerMarker{
        get{
            return _playerPositionTransform.position;
        }
    }

    public void Clean(){
        if(!_isClean){
            _isClean = true;
            _cleanCells++;
        }
    }

    void Awake(){
        _totalCells++;
    }
}
