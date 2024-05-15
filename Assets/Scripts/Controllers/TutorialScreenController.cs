using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScreenController : MonoBehaviour
{
    [SerializeField] LevelLoaderController levelLoader;

    public async void BackToMainMenu()
    {
        await levelLoader.LoadLevel(Enums.Scenes.SceneTest1);
    }
}
