using UnityEngine;

public class GardenDoor : MonoBehaviour, IInteractable
{
    public InteractionType InteractType => InteractionType.Default;

    public string InteractMessage =>"İşe git?";

    public void Interact()
    {
        //DayManager.Instance.GoToWork();
    }
}