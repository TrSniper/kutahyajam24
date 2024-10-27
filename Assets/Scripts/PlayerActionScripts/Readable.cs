using UnityEngine;

public class Readable : MonoBehaviour, IActionInteractable
{
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
