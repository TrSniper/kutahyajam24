using UnityEngine;

public class GardenDoor : MonoBehaviour, IInteractable
{
    public InteractionType InteractType => InteractionType.Default;

    public void Interact()
    {
        //DayManager.Instance.GoToWork();
    }
}