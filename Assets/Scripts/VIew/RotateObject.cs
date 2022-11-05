using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotateObject : MonoBehaviour
{
    [SerializeField]private Transform myTrs;
    [SerializeField]private Quaternion targetRoattion;
    [SerializeField]private Quaternion firstPos;
    [SerializeField] private AnimationCurve moveCurve;
    [SerializeField]private float speed;
    [SerializeField]private float time;
    [SerializeField]private Action StartMoveAct;
    [SerializeField]private Action EndMoveAct;
    [SerializeField] private bool isStart;

    private void Update()
    {
        if (isStart)
        {
            if (time <= 1.0f)
            {
                if (myTrs == null)
                    myTrs = transform;
                myTrs.rotation = Quaternion.LerpUnclamped(firstPos, targetRoattion,
                    (moveCurve.Evaluate(time)));
                time += speed * Time.deltaTime;
                if (time >= 1)
                {
                    EndMoveAct?.Invoke();
                    isStart = false;
                }
                    
            }
        }
        
    }

    public void StartRotate(Transform firstPos,Transform targetTrs, float speed,(int,int) amountOfBreadth, Action OnStart, Action OnEnd)
    {
        myTrs = transform;
        this.targetRoattion = targetTrs.rotation*Quaternion.AngleAxis(Random.Range(amountOfBreadth.Item1,amountOfBreadth.Item2),Vector3.forward);
        this.speed = speed;
        this.firstPos = firstPos.rotation;

        if (OnEnd != null)
            EndMoveAct = OnEnd;

        if (OnStart != null)
            EndMoveAct = OnEnd;


        time = 0;
        StartMoveAct?.Invoke();
        isStart = true;
    }
    public void StartRotate(Quaternion firstPos,Transform targetTrs, float speed,(int,int) amountOfBreadth, Action OnStart, Action OnEnd)
    {
        myTrs = transform;
        this.targetRoattion = targetTrs.rotation*Quaternion.AngleAxis(Random.Range(amountOfBreadth.Item1,amountOfBreadth.Item2),Vector3.forward);
        this.speed = speed;
        this.firstPos = firstPos;
        
        if (OnEnd != null)
            EndMoveAct = OnEnd;

        if (OnStart != null)
            EndMoveAct = OnEnd;


        time = 0;
        StartMoveAct?.Invoke();
        isStart = true;
    }
    public void StartRotate(Quaternion firstPos,Quaternion targetTrs, float speed,(int,int) amountOfBreadth, Action OnStart, Action OnEnd)
    {
        myTrs = transform;
        this.targetRoattion = targetTrs*Quaternion.AngleAxis(Random.Range(amountOfBreadth.Item1,amountOfBreadth.Item2),Vector3.forward);
        this.speed = speed;
        this.firstPos = firstPos;
        
        if (OnEnd != null)
            EndMoveAct = OnEnd;

        if (OnStart != null)
            EndMoveAct = OnEnd;


        time = 0;
        StartMoveAct?.Invoke();
        isStart = true;
    }
}
