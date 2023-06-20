using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public CharacterController controller;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
