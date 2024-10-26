using System;
using UnityEngine;
[Serializable]
public class NightState : DayState
{
    public event Action OnNightStateEnter;
    public event Action OnNightStateExit;
    public event Action OnNightStateUpdate;

    public override void OnStateEnter()
    {
        Debug.Log("Night state entered");
        OnNightStateEnter?.Invoke();
    }

    public override void OnStateExit()
    {
        Debug.Log("Night state exited");
        OnNightStateExit?.Invoke();
    }

    public override void OnStateUpdate()
    {
        Debug.Log("Night state updated");
        OnNightStateUpdate?.Invoke();
    }
}