using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : Tile
{
    private static int _totalCells = 0;
    private static int _cleanCells = 0;
    [SerializeField] private SpriteRenderer _spriteComponent;
    [SerializeField] private Sprite _cleanSprite;

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

    public void Clean(){
        if(!_isClean){
            _isClean = true;
            _cleanCells++;
            _spriteComponent.sprite = _cleanSprite;
            print("Clean tiles: "+_cleanCells+"/"+_totalCells);
        }
    }

    void Awake(){
        _totalCells++;
    }
}
