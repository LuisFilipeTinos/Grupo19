using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TrocaTela : MonoBehaviour
{
    public void trocarParaInicial()
    {
         SceneManager.LoadScene("CenaInicial");  
    }

    public void trocarParaCredito()
    {
        SceneManager.LoadScene("CenaCredito");
    }
}