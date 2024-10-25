using UnityEngine;

public class GhostManager: MonoBehaviour
{
    public static GhostManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
