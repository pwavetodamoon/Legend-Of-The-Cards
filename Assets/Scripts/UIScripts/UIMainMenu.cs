using deVoid.UIFramework;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class UIMainMenu : APanelController
{
    public Button FindMatchapbutton;
    protected override void AddListeners()
    {
        FindMatchapbutton.onClick.AddListener(OpenGamePlayScene);
    }
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        FindMatchapbutton.onClick.RemoveListener(OpenGamePlayScene);
    }
    public void OpenGamePlayScene()
    {
        SceneManager.LoadScene(ScreenIds.GamePlay);

    }
}
