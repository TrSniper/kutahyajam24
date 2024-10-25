public interface IInteractable
{
    public InteractionType InteractType { get; }
    public abstract void Interact();
}
