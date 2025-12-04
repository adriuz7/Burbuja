using UnityEngine.SceneManagement;
using UnityEngine;

public class CargarScene : MonoBehaviour
{
    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}