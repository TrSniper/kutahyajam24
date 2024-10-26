using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // use a cursor to detect the object that the player is looking at
    // and then call the interact method of the object Iinteractable
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteracting();
        }
    }
    public void TryInteracting()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            if (hit.transform.TryGetComponent<IInteractable>(out var interactable))
            {
                switch (interactable.InteractType)
                {
                    case InteractionType.Default:
                        interactable.Interact();
                        break;
                    case InteractionType.LevelInteraction:
                        hit.transform.GetComponent<IInteractableWithDirection>().Interact(ray.direction);
                        break;
                    case InteractionType.Action:
                        interactable.Interact(); /// TODO: implement action type interaction
                        break;
                    default: Debug.LogError("No Interaction Type");
                        break;
                }
            }
        }
    }
}
