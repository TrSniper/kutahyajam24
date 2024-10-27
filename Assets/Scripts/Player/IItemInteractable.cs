public interface IItemInteractable : IInteractable
{
    event System.Action<ItemSO> OnItemPickUp;
}