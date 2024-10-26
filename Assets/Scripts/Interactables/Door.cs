using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour, IInteractableWithDirection
{
    [SerializeField] InteractionType interactionType;
    public InteractionType InteractType { get => interactionType; }

    [SerializeField] Transform doorTransform;
    [SerializeField] bool isLocked = false;

    private void Start()
    {
        if (doorTransform == null)
            doorTransform = transform;
    }

    private bool isOpen = false;
    public void Interact()
    {
        OpenDoor();
        Debug.Log("No-Directional Interacting with door");
    }
    public void Interact(Vector3 v1)
    {
        OpenDoor(v1);
        Debug.Log("Directional Interacting with door");
    }
    void OpenDoor() //implement direction
    {
        if (isOpen)
        {
            doorTransform.DOLocalRotate(new Vector3(0, 0, 0), 1f).OnComplete(() => isOpen = false);
        }
        else
        {
            doorTransform.DOLocalRotate(new Vector3(0, 90, 0), 1f).OnComplete(() => isOpen = true);
        }
    }
    void OpenDoor(Vector3 lookDir) // fix direction so it only works when door is closed
    {
       
        if (!isOpen && (Vector3.Dot(transform.localPosition.normalized, lookDir.normalized) > 0))
        {
            doorTransform.DOLocalRotate(new Vector3(0, 90, 0), 1f).OnComplete(() => isOpen = true);
            Debug.Log("!isOpen && alpha > 0");
        }
        else if (!isOpen && (Vector3.Dot(transform.localPosition.normalized, lookDir.normalized) < 0))
        {
            doorTransform.DOLocalRotate(new Vector3(0, -90, 0), 1f).OnComplete(() => isOpen = true);
            Debug.Log("!isOpen && alpha > 0");
        }
        else if (isOpen) // looking to the same general direction as door's zed axis
        {
            doorTransform.DOLocalRotate(new Vector3(0, 0, 0), 1f).OnComplete(() => isOpen = false);
            Debug.Log("isOpen just closing");
        }
    }  
}
