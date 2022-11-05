using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PublicScripts.Entity;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private MoveObject _moveObject;
    [SerializeField] private RotateObject _rotateObject;
    public void Bind(ECard entity)
    {
        img.sprite = ShareResources.Instance.GetCardSprite("1", entity.id);
        _moveObject = GetComponent<MoveObject>();
    }

    public void StartMove(Transform firstPos,Transform targetTrs, float speed,(int,int) amountOfBreadth, Action OnStart, Action OnEnd)
    {
        _moveObject.StartMove(firstPos,targetTrs,speed,amountOfBreadth,OnStart,OnEnd);
    }
    public void StartRotate(Transform firstPos,Transform targetTrs, float speed,(int,int) amountOfBreadth, Action OnStart, Action OnEnd)
    {
        _rotateObject.StartRotate(firstPos,targetTrs,speed,amountOfBreadth,OnStart,OnEnd);
    }
    public void StartRotate(Quaternion firstPos,Quaternion targetTrs, float speed,(int,int) amountOfBreadth, Action OnStart, Action OnEnd)
    {
        _rotateObject.StartRotate(firstPos,targetTrs,speed,amountOfBreadth,OnStart,OnEnd);
    }
}

[System.Serializable]
public class ECard
{
    public string fullName;
    public int id;
    public int number;
    public int order;
    public Symbol symbol;
}

public enum Symbol
{
    Heart,Spade,Diamond,Clubs
}
