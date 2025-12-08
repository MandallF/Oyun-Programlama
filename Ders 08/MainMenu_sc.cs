using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_sc : MonoBehaviour
{

public void LoadGame()
    {
        SceneManager.LoadScene(1);//sahbe indeks numarası ile yüklendi.
        //SceneManager.LoadScene("Game") //sahne ismi ile yapılması.
    }

}
