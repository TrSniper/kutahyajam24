using UnityEngine;

[CreateAssetMenu(fileName = "New Player Action", menuName = "Player Actions/Laboring Action")]
public class LaborAction : PlayerAction
{
    public override void ExecuteAction()
    {
        base.ExecuteAction();
        Debug.Log("Laboring...");
    }
}
