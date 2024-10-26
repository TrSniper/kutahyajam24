public interface IInteractable
{
    public InteractionType InteractType { get; }
    public string InteractMessage { get; }
    public abstract void Interact();
}
