using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class MoveObject : MonoBehaviour
{
    [SerializeField]private Transform myTrs;
    [SerializeField]private Vector3 targetTrs;
    [SerializeField]private Vector3 firstPos;
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
                myTrs.position = Vector3.Lerp(firstPos, targetTrs,
                    (moveCurve.Evaluate(time)));
                time += speed * Time.deltaTime;
                if (time >= 1)
                {
                    EndMoveAct?.Invoke();
                    isStart = true;
                }
                   
            }
        }
       
    }

    public void StartMove(Transform firstPos,Transform targetTrs, float speed,(int,int) amountOfBreadth, Action OnStart, Action OnEnd)
    {
        myTrs = GetComponent<Transform>();
        this.targetTrs = targetTrs.position+new Vector3(Random.Range(amountOfBreadth.Item1,amountOfBreadth.Item2),Random.Range(amountOfBreadth.Item1,amountOfBreadth.Item2),0);
        this.speed = speed;
        this.firstPos = firstPos.position;

        if (OnEnd != null)
            EndMoveAct = OnEnd;

        if (OnStart != null)
            EndMoveAct = OnEnd;


        time = 0;
        StartMoveAct?.Invoke();
        isStart = true;
    }
    public void StartMove(Vector3 firstPos,Transform targetTrs, float speed,(int,int) amountOfBreadth, Action OnStart, Action OnEnd)
    {
        this.targetTrs = targetTrs.position+new Vector3(Random.Range(amountOfBreadth.Item1,amountOfBreadth.Item2),Random.Range(amountOfBreadth.Item1,amountOfBreadth.Item2),0);
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
