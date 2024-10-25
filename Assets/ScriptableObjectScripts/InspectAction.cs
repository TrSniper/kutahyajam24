using UnityEngine;

[CreateAssetMenu(fileName = "New Player Action", menuName = "Player Actions/Inspect Action")]
public class InspectAction : PlayerAction
{
    public override void ExecuteAction()
    {
        base.ExecuteAction();
        Debug.Log("Inspecting..."); // bro inspects... those who know, know
    }
}
