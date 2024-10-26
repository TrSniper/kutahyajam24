using TMPro;
using UnityEngine;

public class InteractableInfoCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactableMessage;

    private void Awake()
    {
        PlayerInteractor.OnFoundInteractable += OnFoundInteractable;
    }

    private void OnFoundInteractable(string obj)
    {
        interactableMessage.text = obj;
    }
}