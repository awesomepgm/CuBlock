using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    private void Update() {
        if (Input.GetKey(KeyCode.LeftAlt)) {
            if (Input.GetKey(KeyCode.Equals)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            if (Input.GetKey(KeyCode.Minus)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            }
        }
    }
    public void CompleteLevel() 
    {
        completeLevelUI.SetActive(true);
    }

    public void GameOver ()
    {
        if (gameHasEnded== false)
        {
            gameHasEnded = true;
            //restart game
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Physics.gravity = new Vector3(0f, -9.8f, 0f);
    }
}
