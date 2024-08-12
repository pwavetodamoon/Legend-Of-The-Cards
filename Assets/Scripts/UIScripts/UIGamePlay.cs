using System;
using deVoid.UIFramework;
using TMPro;
using UnityEngine;

public class UIGamePlay : APanelController
{
    public TextMeshProUGUI PlayerName;
    public GameManager GameManager;

    public GameObject DropZone1;
    public GameObject DropZone2;
    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        if (GameManager != null)
        {
            PlayerName.text = GameManager._playerData.PlayerName;
        }
    }

    protected override void AddListeners()
    {
        base.AddListeners();
    }
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
    }
}
