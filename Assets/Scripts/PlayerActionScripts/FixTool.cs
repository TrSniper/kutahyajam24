using UnityEngine;

public class FixTool : MonoBehaviour, IActionInteractable
{
    //this will work button based amk tabiikide ya
    [SerializeField] PlayerAction fixTool;
    [SerializeField] ItemSO diarySO;
    public PlayerAction PlayerAction => fixTool;

    public InteractionType InteractType => InteractionType.Action;

    public string InteractMessage => "Tamir Et?";

    public void Interact()
    {
        fixTool.ExecuteAction();
    }
}
