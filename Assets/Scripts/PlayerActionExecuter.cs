using UnityEngine;

public class PlayerActionExecuter: MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InspectAction inspectAction = Resources.Load<InspectAction>("PlayerActions/Inspect1");
            ExecuteAction(inspectAction);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PuzzleAction puzzleAction = Resources.Load<PuzzleAction>("PlayerActions/Puzzle1");
            ExecuteAction(puzzleAction);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadingAction readingAction = Resources.Load<ReadingAction>("PlayerActions/Reading1");
            ExecuteAction(readingAction);
        }
    }
    public void ExecuteAction(PlayerAction action)
    {
        Debug.Log("Action Name: " + action.ActionName);
        Debug.Log("Action Cost: " + action.ActionCost);
        foreach (string comment in action.ActionCommentary)
        {
            Debug.Log("Action Commentary: " + comment);
        }
        action.ExecuteAction();
    }
}
