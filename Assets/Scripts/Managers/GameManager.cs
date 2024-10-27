using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public event Action OnGameStart;
    public event Action OnGameEnd;

    public event Action<int> OnActionPointsChange;

    public void StartGame()
    {
        OnGameStart?.Invoke();
    }
}
