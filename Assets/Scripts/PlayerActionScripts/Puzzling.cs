using UnityEngine;

public class Puzzling : MonoBehaviour, IActionInteractable
{
    //this will work button based amk tabiikide ya
    [SerializeField] PlayerAction puzzleSO;
    [SerializeField] ItemSO diarySO;
    public PlayerAction PlayerAction => puzzleSO;

    public InteractionType InteractType => InteractionType.Action;

    public string InteractMessage => "?";

    public void Interact()
    {
        puzzleSO.ExecuteAction();
    }
}
