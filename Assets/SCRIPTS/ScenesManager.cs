using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [Header("CONFIGURACION DE ESCENAS (ARRASTRA AQUI LOS ARCHIVOS DE ESCENA)")]
    [SerializeField] private Object escenaInicio;
    [SerializeField] private Object escenaGame;
    [SerializeField] private Object escenaCreditos;

    // METODO PARA IR A LA ESCENA DE JUEGO
    public void LoadGameScene()
    {
        Time.timeScale = 1f; // Restaurar el tiempo por si venimos de Game Over
        LoadSceneByAsset(escenaGame);
    }

    // METODO PARA IR A LA ESCENA DE CREDITOS
    public void LoadCreditsScene()
    {
        LoadSceneByAsset(escenaCreditos);
    }

    // METODO PARA REGRESAR A LA ESCENA INICIO
    public void LoadInicioScene()
    {
        LoadSceneByAsset(escenaInicio);
    }

    // METODO AUXILIAR PRIVADO PARA CARGAR LA ESCENA USANDO EL OBJETO ARRASTRADO
    private void LoadSceneByAsset(Object sceneAsset)
    {
        if (sceneAsset != null)
        {
            string sceneName = sceneAsset.name;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("¡ERROR! No se ha asignado ninguna escena en el Inspector para este botón.");
        }
    }

    // METODO PARA SALIR DEL JUEGO
    public void QuitGame()
    {
        Debug.Log("SALIENDO DEL JUEGO...");
        Application.Quit();
    }
}