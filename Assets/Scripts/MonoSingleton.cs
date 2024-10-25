using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    /// <summary>
    /// This nigga is a smooth way to handle singletons in unity (I stole it)
    /// </summary>
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject newGo = new GameObject();
                    _instance = newGo.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}
