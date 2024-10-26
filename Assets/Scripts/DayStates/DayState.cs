using System;
using UnityEngine;

public abstract class DayState
{
    public string StateName { get; private set; }
    public int GrantedActionPoints { get; private set; }
    public int SpentActionPoints { get; private set; }

    public DayState(string name, int actionPoints)
    {
        StateName = name;
        GrantedActionPoints = actionPoints;
    }

    public bool CanSpendPoints(int cost) => SpentActionPoints + cost <= GrantedActionPoints;

    public void SpendPoints(int cost)
    {
        if (CanSpendPoints(cost)) SpentActionPoints += cost;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateExit();
}

public class MorningState : DayState
{
    public event Action OnMorningStateEnter;
    public MorningState(int actionPoints) : base("Morning", actionPoints) { }
    public override void OnStateEnter() => OnMorningStateEnter?.Invoke();
    public override void OnStateExit() => Debug.Log("Morning state exited");
}

public class AfternoonState : DayState
{
    public event Action OnAfternoonStateEnter;
    public AfternoonState(int actionPoints) : base("Afternoon", actionPoints) { }
    public override void OnStateEnter() => OnAfternoonStateEnter?.Invoke();
    public override void OnStateExit() => Debug.Log("Afternoon state exited");
}

public class NightState : DayState
{
    public event Action OnNightStateEnter;
    public NightState(int actionPoints) : base("Night", actionPoints) { }
    public override void OnStateEnter() => OnNightStateEnter?.Invoke();
    public override void OnStateExit() => Debug.Log("Night state exited");
}

