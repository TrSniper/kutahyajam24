using UnityEngine;

[CreateAssetMenu(fileName = "New Player Action", menuName = "Player Actions/Puzzle Action")]
public class PuzzleAction : PlayerAction
{
    public override void ExecuteAction()
    {
        base.ExecuteAction();
        Debug.Log("Puzzling...");
    }
}
