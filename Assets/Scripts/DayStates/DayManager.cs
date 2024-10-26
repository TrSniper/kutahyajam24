using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public List<Day> Days;
    public int DayIndex = 0;
    public Day CurrentDay;

    private void Start()
    {
        CurrentDay = Days[DayIndex];
        CurrentDay.InitializeDay(2, 5, 3); // Action points for each state
        SubscribeDayEvents();
    }

    private void SubscribeDayEvents()
    {
        CurrentDay.MorningState.OnMorningStateEnter += OnMorningStateEnter;
        CurrentDay.AfternoonState.OnAfternoonStateEnter += OnAfternoonStateEnter;
        CurrentDay.NightState.OnNightStateEnter += OnNightStateEnter;
    }

    private void UnSubscribeDayEvents()
    {
        CurrentDay.MorningState.OnMorningStateEnter -= OnMorningStateEnter;
        CurrentDay.AfternoonState.OnAfternoonStateEnter -= OnAfternoonStateEnter;
        CurrentDay.NightState.OnNightStateEnter -= OnNightStateEnter;
    }

    // Event methods to handle each day phase
    private void OnMorningStateEnter() => UpdateLights("Morning");
    private void OnAfternoonStateEnter() => UpdateLights("Afternoon");
    private void OnNightStateEnter() => UpdateLights("Night");

    public void EndTheDay()
    {
        UnSubscribeDayEvents();
        DayIndex++;
        if (DayIndex < Days.Count)
        {
            StartNewDay();
        }
        else
        {
            Debug.Log("End of game - Mystery conclusion!");
        }
    }

    private void StartNewDay()
    {
        CurrentDay = Days[DayIndex];
        CurrentDay.InitializeDay(3, 5, 4);
        SubscribeDayEvents();
    }

    private void UpdateLights(string timeOfDay)
    {
        // Implement lighting changes here based on timeOfDay
        Debug.Log($"Lights set for {timeOfDay}");
    }
}
