using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Action", menuName = "Player Actions")]
public abstract class PlayerAction : ScriptableObject
{
    [SerializeField]
    private string actionName;
    public string ActionName
    {
        get { return actionName; }
    }
    [SerializeField]
    private int actionCost;
    public int ActionCost
    {
        get { return actionCost; }
    }
    [SerializeField]
    private string[] actionCommentary;
    public string[] ActionCommentary
    {
        get { return actionCommentary; }
    }

    public event Action<PlayerAction> OnExecutePlayerAction;

    public virtual void ExecuteAction()
    {
        Debug.Log("Action Executed : " + actionName);
        OnExecutePlayerAction?.Invoke(this);
    }
}
