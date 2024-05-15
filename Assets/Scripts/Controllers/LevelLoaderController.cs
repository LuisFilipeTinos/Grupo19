using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderController : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;
    [SerializeField] float transitionTime = 0.5f;

    public async Task LoadLevel(Enums.Scenes sceneIndex)
    {
        transitionAnim.SetTrigger("Start");
        await Awaitable.WaitForSecondsAsync(transitionTime);
        SceneManager.LoadScene((int)sceneIndex);
    }
}
