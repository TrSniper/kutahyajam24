using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoSingleton<DayManager>
{
    // 3 states: morning, afternoon, night
    // each state has different lighting, different interactions dammn
    public List<Day> Days;

    public Day CurrentDay;

    private Day YesterDay;

    private void Start()
    {
        CurrentDay = Days[1];
        CurrentDay.InitializeDay(2, 5, 3); // first day

        SubscribeDayEvents();
    }
    void SubscribeDayEvents()
    {

        CurrentDay.MorningState.OnMorningStateEnter += OnMorningStateEnter;
        CurrentDay.MorningState.OnMorningStateExit += OnMorningStateExit;
        CurrentDay.MorningState.OnMorningStateUpdate += OnMorningStateUpdate;


        CurrentDay.AfternoonState.OnAfternoonStateEnter += OnAfternoonStateEnter;
        CurrentDay.AfternoonState.OnAfternoonStateExit += OnAfternoonStateExit;
        CurrentDay.AfternoonState.OnAfternoonStateUpdate += OnAfternoonStateUpdate;

        CurrentDay.NightState.OnNightStateEnter += OnNightStateEnter;
        CurrentDay.NightState.OnNightStateExit += OnNightStateExit;
        CurrentDay.NightState.OnNightStateUpdate += OnNightStateUpdate;
    }
    
    void UnSubscribeDayEvents()
    {

        CurrentDay.MorningState.OnMorningStateEnter -= OnMorningStateEnter;
        CurrentDay.MorningState.OnMorningStateExit -= OnMorningStateExit;
        CurrentDay.MorningState.OnMorningStateUpdate -= OnMorningStateUpdate;


        CurrentDay.AfternoonState.OnAfternoonStateEnter -= OnAfternoonStateEnter;
        CurrentDay.AfternoonState.OnAfternoonStateExit -= OnAfternoonStateExit;
        CurrentDay.AfternoonState.OnAfternoonStateUpdate -= OnAfternoonStateUpdate;

        CurrentDay.NightState.OnNightStateEnter -= OnNightStateEnter;
        CurrentDay.NightState.OnNightStateExit -= OnNightStateExit;
        CurrentDay.NightState.OnNightStateUpdate -= OnNightStateUpdate;
    }

    #region StateEvents
    //Morning
    private void OnMorningStateEnter()
    {

    }

    private void OnMorningStateUpdate()
    {

    }

    private void OnMorningStateExit()
    {

    }

    //Afternoon

    private void OnAfternoonStateEnter()
    {

    }
    private void OnAfternoonStateUpdate()
    {
    }

    private void OnAfternoonStateExit()
    {
    }

    //Night
    private void OnNightStateEnter()
    {

    }
    private void OnNightStateUpdate()
    {

    }

    private void OnNightStateExit()
    {

    }

    #endregion

    public void EndTheDay()
    {
        // two possible scenarios to end the day:
        // 1. player goes to bed => interact with bed => fade to black => next day
        // 2. player faints from scare => log scare so player's sanity goes down => fade to black => next day
        UnSubscribeDayEvents();
    }
    private void StartNewDay()
    {
        // change the day
        YesterDay = CurrentDay;
        CurrentDay = Days[1];
        CurrentDay.InitializeDay(2, 5, 3); // will change according to player's actions
        SubscribeDayEvents();
    }
    private void UpdateLigths(DayState state)
    {
        switch (state.StateName)
        {
            case "Morning":
                // change lights to morning
                break;
            case "Afternoon":
                // change lights to afternoon
                break;
            case "Night":
                // change lights to night
                break;
            default:
                //default lights are afternoon lights.
                break;
        }
    }
}
