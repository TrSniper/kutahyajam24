using System;
using UnityEngine;

public class Pickupable : MonoBehaviour, IItemInteractable
{
    [SerializeField] ItemSO itemSO;
    public InteractionType InteractType => InteractionType.Default;

    public event Action<ItemSO> OnItemPickUp;

    public string InteractMessage => "Al";

    public void Interact()
    {
        Debug.Log("selecting pickupable: " + itemSO.name);
        OnItemPickUp?.Invoke(itemSO);
        Destroy(gameObject);
    }
}
