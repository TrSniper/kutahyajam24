using UnityEngine;

[CreateAssetMenu(fileName = "New Player Action", menuName = "Player Actions/Fixing Action")]
public class FixingAction : PlayerAction
{
    public override void ExecuteAction()
    {
        base.ExecuteAction();
        Debug.Log("Fixing...");
    }
}
