using System;
using UnityEngine;

[Serializable]
public class MorningState : DayState
{
    public event Action OnMorningStateEnter;
    public event Action OnMorningStateExit;
    public event Action OnMorningStateUpdate;
    public override void OnStateEnter()
    {
        Debug.Log("Morning state entered");
        OnMorningStateEnter?.Invoke();
    }

    public override void OnStateExit()
    {
        Debug.Log("Morning state exited");
        OnMorningStateExit?.Invoke();
    }

    public override void OnStateUpdate()
    {
        Debug.Log("Morning state updated");
        OnMorningStateUpdate?.Invoke();
    }
}
