using deVoid.UIFramework;
using UnityEngine;
public class UIMainMenuManager : MonoBehaviour
{
    [SerializeField] private UISettings _defaultUISetting = null;
    private UIFrame _uIFrameGamePlay;

    private void Awake()
    {
        _uIFrameGamePlay = _defaultUISetting.CreateUIInstance();
    }
    private void Start()
    {
        AddListeners();
    }
    private void OnDestroy()
    {
        RemoveAddListeners();
    }
    private void AddListeners()
    {
        _uIFrameGamePlay.ShowPanel(ScreenIds.UIMainMenu);
    }
    private void RemoveAddListeners()
    {
    }
}
