using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] InteractionType interactionType;
    public InteractionType InteractType { get => interactionType; }

    [SerializeField] Transform doorTransform;

    private void Start()
    {
        if (doorTransform == null)
            doorTransform = transform;
    }

    private bool isOpen = false;
    public void Interact()
    {
        OpenDoor();
    }

    void OpenDoor() //implement direction
    {
        if (isOpen)
        {
            doorTransform.DOLocalRotate(new Vector3(0, 0, 0), 1f);
            isOpen = false;
        }
        else
        {
            doorTransform.DOLocalRotate(new Vector3(0, 90, 0), 1f);
            isOpen = true;
        }
    }

}