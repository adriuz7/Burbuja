using UnityEngine;
using UnityEngine.UI;

public class UIControlDepositarMobile : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private InventarioJugador inventario;
    [SerializeField] private clasificacionBasura clasificador;
    [SerializeField] private Button depositButton;

    [Header("Imágenes (sprites)")]
    [SerializeField] private Sprite imagenVacia; 
    [SerializeField] private Sprite imagenPlaceholder;      
    [SerializeField] private Image mainImage;               
    [SerializeField] private Image glowImage;               

    [Header("Opciones")]
    [SerializeField] private bool ocultarBotonCuandoVacio = true;

    private void Reset()
    {
        if (mainImage == null && depositButton != null)
            mainImage = depositButton.GetComponent<Image>();
    }

    private void Start()
    {
        if (depositButton == null) Debug.LogWarning("depositButton no asignado en UIControlDepositarMobile.");
        if (mainImage == null) Debug.LogWarning("mainImage no asignado en UIControlDepositarMobile.");
        if (glowImage != null) glowImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        ActualizarEstadoUI();
    }

    private void ActualizarEstadoUI()
    {
        var basuraSeleccionada = inventario.ObtenerBasuraSeleccionada();
        bool cerca = false;
        if (clasificador != null) cerca = clasificador.EstaCercaContenedor();
        if (basuraSeleccionada == null)
        {
            if (mainImage != null && imagenVacia != null)
            {
                mainImage.sprite = imagenVacia;
                mainImage.enabled = true;
            }
            if (glowImage != null) glowImage.gameObject.SetActive(false);

            if (depositButton != null)
            {
                depositButton.interactable = false;
                if (ocultarBotonCuandoVacio)
                    depositButton.gameObject.SetActive(false);
            }

            return;
        }
        if (depositButton != null && !depositButton.gameObject.activeSelf) depositButton.gameObject.SetActive(true);

        Sprite spriteItem = ObtenerSpriteDeItem(basuraSeleccionada);
        if (mainImage != null)
        {
            mainImage.sprite = spriteItem != null ? spriteItem : imagenPlaceholder != null ? imagenPlaceholder : imagenVacia;
            mainImage.enabled = true;
        }

        if (depositButton != null)
        {
            depositButton.interactable = cerca; 
        }

        if (glowImage != null)
        {
            glowImage.gameObject.SetActive(cerca);
        }
    }

    private Sprite ObtenerSpriteDeItem(itemBasura item)
    {
        if (item == null) return null;
        var sr = item.GetComponent<SpriteRenderer>();
        if (sr != null && sr.sprite != null) return sr.sprite;

        return null;
    }
}
