using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public PlayerData _playerData;
    public UIGamePlay UIGamePlay;

    void Start()
    {
        if (UIGamePlay == null)
        {
            UIGamePlay = FindFirstObjectByType<UIGamePlay>();
        }
    }
}
