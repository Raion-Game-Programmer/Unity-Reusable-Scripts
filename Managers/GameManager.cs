using UnityEngine;
public class GameManager : SingletonMonoBehaviour<GameManager>{

    public void PlayGame(){

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame(){
        Time.timeScale = 0;

    }
    public void ResumeGame(){
        Time.timeScale = 1;
    }

    private void OnApplicationQuit() {
        
    }

}