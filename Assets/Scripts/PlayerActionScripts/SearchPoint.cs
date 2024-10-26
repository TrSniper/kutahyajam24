using UnityEngine;

public class SearchPoint : MonoBehaviour, IActionInteractable
{
    //this will work button based amk tabiikide ya
    [SerializeField] PlayerAction searchForDoorsSO;
    [SerializeField] ItemSO diarySO;
    public PlayerAction PlayerAction => searchForDoorsSO;

    public InteractionType InteractType => InteractionType.Action;

    public string InteractMessage => "Kapı Kolunu Ara?";

    public void Interact()
    {
        searchForDoorsSO.ExecuteAction();
    }
}
