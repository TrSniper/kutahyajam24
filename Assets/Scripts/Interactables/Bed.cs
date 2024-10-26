using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public InteractionType InteractType => InteractionType.Default;

    public string InteractMessage => "Uyu?";

    public void Interact()
    {
        GameObject.Find("DayManager").GetComponent<DayManager>().EndTheDay();
    }
}
