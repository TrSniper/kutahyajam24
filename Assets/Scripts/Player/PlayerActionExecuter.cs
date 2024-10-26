using UnityEngine;

public class PlayerActionExecuter: MonoBehaviour
{
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

    private void Inspect()
    {
       
    }

    private void Puzzle()
    {

    }

    private void Reading()
    {

    }

    private void Labor()
    {

    }

    private void SearchDoors()
    {

    }

    private void Fixing()
    {

    }
}
