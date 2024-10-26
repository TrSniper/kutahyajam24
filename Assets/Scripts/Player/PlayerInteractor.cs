using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{

    float _time = 0;
    IInteractable _interactableFound;
    public static event System.Action<string> OnFoundInteractable;
    private void Update()
    {
        if(_interactableFound != null)
        TryInteracting(_interactableFound);
        _time += Time.deltaTime;
        if (_time >= 0.1f)
        {
            _interactableFound = DetectInteractables();
            _time = 0;
        }
    }
    private void TryInteracting(IInteractable interactable)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (interactable)
            {
                case IActionInteractable actionInteractable:
                    ActionInteraction(actionInteractable);
                    break;
                default:
                    DefaultInteraction(interactable);
                    break;
            }
        }
    }

    private void DefaultInteraction(IInteractable interactable) => interactable.Interact();
    private void LevelInteraction(IInteractableWithDirection interactable, Vector3 direction) => interactable.Interact(direction);
    private void ActionInteraction(IInteractable interactable) => interactable.Interact();

    private IInteractable DetectInteractables()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 3))
        {
            if (hit.transform.TryGetComponent<IInteractable>(out var interactable))
            {
                OnFoundInteractable?.Invoke(interactable.InteractMessage);
                if (interactable is IInteractableWithDirection levelInteractable && Input.GetKeyDown(KeyCode.E))
                {
                    LevelInteraction(levelInteractable, hit.normal);
                    return null;
                }
                return interactable;
            }
            OnFoundInteractable?.Invoke("");
        }
        OnFoundInteractable?.Invoke("");
        return null;
    }
    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(ray.origin, ray.direction * 100);
    }
}
