using UnityEngine;

[CreateAssetMenu(fileName = "New Player Action", menuName = "Player Actions/Reading Action")]
public class ReadingAction : PlayerAction
{
    public override void ExecuteAction()
    {
        base.ExecuteAction();
        Debug.Log("Readinging...");
    }
}
