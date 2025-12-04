using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstruccionesJuego : MonoBehaviour
{
    [Header("Configuración de texto")]
    [SerializeField] private Text textoInstrucciones;
    [SerializeField] private string[] lineasDeTexto;
    [SerializeField] private float velocidadEscritura = 0.05f;

    [Header("Configuración de botón")]
    [SerializeField] private Button botonContinuar;
    [SerializeField] private string nombreEscenaJuego;

    private void Start()
    {
        botonContinuar.gameObject.SetActive(false);
        StartCoroutine(EscribirTexto());
    }

    private IEnumerator EscribirTexto()
    {
        textoInstrucciones.text = "";

        foreach (string linea in lineasDeTexto)
        {
            foreach (char letra in linea)
            {
                textoInstrucciones.text += letra;
                yield return new WaitForSeconds(velocidadEscritura);
            }

            textoInstrucciones.text += "\n";
            yield return new WaitForSeconds(0.5f);
        }

        botonContinuar.gameObject.SetActive(true);
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(nombreEscenaJuego);
    }
}
