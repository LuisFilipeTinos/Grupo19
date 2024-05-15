using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] LevelLoaderController levelLoader;
    public async void TutorialScreen()
    {
        await levelLoader.LoadLevel(Enums.Scenes.SceneTest2);
    }
    public async void DialogueTestScreen()
    {
        await levelLoader.LoadLevel(Enums.Scenes.SceneTest3);
    }
}
