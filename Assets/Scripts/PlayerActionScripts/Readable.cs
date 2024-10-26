using UnityEngine;

public class Readable : MonoBehaviour, IActionInteractable
{
    //this will work button based amk tabiikide ya
    [SerializeField] PlayerAction readingActionSO;
    [SerializeField] ItemSO diarySO;
    public PlayerAction PlayerAction => readingActionSO;

    public InteractionType InteractType => InteractionType.Action;

    public string InteractMessage => "Oku?";

    public void Interact()
    {
        readingActionSO.ExecuteAction();
    }
}
