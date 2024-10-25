using UnityEngine;

[CreateAssetMenu(fileName = "New Player Action", menuName = "Player Actions/Searching Doors Action")]
public class SearchDoorsAction : PlayerAction
{
    public override void ExecuteAction()
    {
        base.ExecuteAction();
        Debug.Log("Searching Doors...");
    }
}
