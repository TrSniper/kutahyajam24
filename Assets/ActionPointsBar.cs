using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPointsBar : MonoBehaviour
{
    [SerializeField] Image actionPointsBar;
    [SerializeField] int actionPoints = 10;

    private void Start()
    {
        GameManager.Instance.OnGameStart += () => actionPoints = 10;
        GameManager.Instance.OnActionPointsChange += UpdateActionPointsBar;
    }

    void UpdateActionPointsBar(int i)
    {
        actionPoints -= i;
        actionPointsBar.fillAmount = actionPoints / 10f;
    }
}
