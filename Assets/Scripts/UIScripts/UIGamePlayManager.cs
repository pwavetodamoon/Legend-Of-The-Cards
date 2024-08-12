using System.Collections;
using deVoid.UIFramework;
using UnityEngine;

public class UIGamePlayManager : MonoBehaviour
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
          _uIFrameGamePlay.ShowPanel(ScreenIds.UIGamePlay);
      }
      private void RemoveAddListeners()
      {
      }
}
