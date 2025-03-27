 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Función para que cargue mediante el nombre de la escena
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("cargando escena" + sceneName);
        }
        else
        {
            Debug.LogWarning("copia escena miguel");
        }
    }



    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego");
    }
}
