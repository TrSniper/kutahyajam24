using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public InteractionType InteractType => InteractionType.Default;

    public void Interact()
    {
        DayManager.Instance.EndTheDay();
    }
}
