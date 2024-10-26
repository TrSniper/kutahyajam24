using System;
using UnityEngine;

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

    [SerializeField]
    private AudioClip[] actionDubs;
    public AudioClip[] ActionDubs
    {
        get { return actionDubs; }
    }
    public event Action<PlayerAction> OnExecutePlayerAction;

    public virtual void ExecuteAction()
    {
        Debug.Log("Action Executed : " + actionName);
        OnExecutePlayerAction?.Invoke(this);
    }
}
