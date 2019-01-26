using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveScreen : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasRect;
    private RectTransform _screenRect;
    [SerializeField] private Button[] _interactables;

    void Awake(){
        _screenRect = GetComponent<RectTransform>();
    }

    public void Move(int dirVal = 1){
        DisableInteractables();
        dirVal = dirVal / System.Math.Abs(dirVal);
        //print(_screenRect.anchoredPosition.x);
        _screenRect.DOAnchorPosX(_screenRect.anchoredPosition.x + _canvasRect.rect.width * dirVal,1,true).OnComplete(EnableInteractables);
    }

    public void DisableInteractables(){
        for(int i=0;i<_interactables.Length;i++){
            _interactables[i].interactable = false;
        }
    }

    private void EnableInteractables(){
        for(int i=0;i<_interactables.Length;i++){
            _interactables[i].interactable = true;
        }
    }
}
