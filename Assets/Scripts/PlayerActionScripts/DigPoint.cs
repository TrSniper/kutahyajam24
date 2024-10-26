using UnityEngine;

public class DigPoint : MonoBehaviour, IAction
{
    [SerializeField] PlayerAction diggingActionSO;
    [SerializeField] bool isCluePoint;
    public PlayerAction PlayerAction => diggingActionSO;

    public InteractionType InteractType => InteractionType.Action;

    public void Interact()
    {
         /*if(PlayerInventory.HasFixedShovel)
         {
             PlayDiggingAnimation();
             diggingActionSO.ExecuteAction();
            if(isCluePoint)
            {
                //play clue related dialogue or animation
            }
        }
         else
         {
             //play some sound or animation to show that player needs a shovel to dig.
         }*/
    }

    void PlayDiggingAnimation()
    {
        //play digging animation
        //will reveal the chest. if there is any
    }

}