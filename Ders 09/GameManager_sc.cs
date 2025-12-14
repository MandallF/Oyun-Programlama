using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



public class GameManager_sc : MonoBehaviour
{

    bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
