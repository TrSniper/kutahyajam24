using UnityEngine;

public class Inspectable : MonoBehaviour, IActionInteractable
{
    //this will work button based amk tabiikide ya
    [SerializeField] PlayerAction inspectActionSO;
    [SerializeField] ItemSO diarySO;
    public PlayerAction PlayerAction => inspectActionSO;

    public InteractionType InteractType => InteractionType.Action;

    public string InteractMessage => "Incele?";

    public void Interact()
    {
        inspectActionSO.ExecuteAction();
    }
}
