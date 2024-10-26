using System;
using UnityEngine;
[Serializable]
public class AfternoonState: DayState
{
    public event Action OnAfternoonStateEnter;
    public event Action OnAfternoonStateExit;
    public event Action OnAfternoonStateUpdate;

    public override void OnStateEnter()
    {
        Debug.Log("Afternoon state entered");
        OnAfternoonStateEnter?.Invoke();
    }

    public override void OnStateExit()
    {
        Debug.Log("Afternoon state exited");
        OnAfternoonStateExit?.Invoke();
    }

    public override void OnStateUpdate()
    {
        Debug.Log("Afternoon state updated");
        OnAfternoonStateUpdate?.Invoke();
    }
}
