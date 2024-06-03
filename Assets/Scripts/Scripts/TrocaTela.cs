using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TrocaTela : MonoBehaviour
{
    public void trocarParaCredito()
    {
        var start = SceneManager.GetActiveScene();
        var sceneLoad = SceneManager.LoadSceneAsync("CenaCredito");
        sceneLoad.allowSceneActivation = true;
    }

    public void trocarParaInicial()
    {
        var start = SceneManager.GetActiveScene();
        var sceneLoad = SceneManager.LoadSceneAsync("CenaInicial");
        sceneLoad.allowSceneActivation = true;
    }

}