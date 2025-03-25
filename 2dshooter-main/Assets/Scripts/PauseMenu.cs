using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuname;
    public GameObject pauseScreen;
    public bool isPaused;

    public static PauseMenu instance;

    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            PauseUnpause();
        }

    }

    // Función para que cargue mediante la escena del Menú Principal
    public void MainMenu()
    {
        if (!string.IsNullOrEmpty(mainMenuname))
        {
            SceneManager.LoadScene(mainMenuname);
            Debug.Log("cargando escena" + mainMenuname);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no está asignado.");
        }
    }

    public void PauseUnpause()
    {
        if (isPaused){
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
