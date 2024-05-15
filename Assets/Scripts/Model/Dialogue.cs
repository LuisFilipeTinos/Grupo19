using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    [TextArea(1, 5)]
    private string[] dialogue;

    public string[] GetDialogue => dialogue;
}
