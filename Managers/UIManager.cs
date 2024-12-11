using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    public bool isDebug;
    public UI currentUI;

    public bool enableCursor = true;

    #region UIPrefabs
    
    #endregion

    #region UIReferences

    #endregion

    private void Update() {
        Cursor.visible = enableCursor;
        if(currentUI == UI.GAMEPLAY){
            Cursor.lockState = CursorLockMode.Locked;
        }
        else{
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ShowUI(UI ui){
        #if ENABLE_DEBUG
            Debug.Log("Showing UI: " + ui);
        #endif
        if(currentUI == ui){
            return;
        }
        HideUI(currentUI);

        switch(ui){
            // case UI.PAUSE:
            //     uiPause.Show();
            //     break;
            // case UI.BOOK:
            //     uiBook.Show();
            //     break;
            // case UI.SETTINGS:
            //     uiSettings.Show();
            //     break;
        }
        currentUI = ui;
    }

    public void HideUI(UI ui){
        #if ENABLE_DEBUG
            Debug.Log("Hiding UI: " + ui);
        #endif

        if(currentUI != ui){
            return;
        }
        switch(ui){
            // case UI.PAUSE:
            //     uiPause.Hide();
            //     break;
            // case UI.BOOK:
            //     uiBook.Hide();
            //     break;
            // case UI.SETTINGS:
            //     uiSettings.Hide();
            //     break;
        }
        currentUI = UI.GAMEPLAY;
    }
    public enum UI{
        PAUSE,
        GAMEPLAY,
        SETTINGS
    }
     public void OnEnable(){
        // inputActions = new PlayerInputActions();
        // pauseAction = inputActions.UI.Pause;
        // pauseAction.Enable();
        // pauseAction.performed += ctx => {
            
        // };
    }
}