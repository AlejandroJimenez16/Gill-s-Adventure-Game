using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioNivel : MonoBehaviour
{
    Inventario inventario;

    public bool tieneLLave = false;
    public GameObject puerta;

    void Start()
    {
        // Busca el objeto con la etiqueta "Personaje" y obtén el componente Inventario
        GameObject personaje = GameObject.FindGameObjectWithTag("Personaje");
        if (personaje != null)
        {
            inventario = personaje.GetComponent<Inventario>();

            // Verifica si el componente Inventario es nulo
            if (inventario == null)
            {
                Debug.LogError("No se encontró el componente Inventario en el objeto con la etiqueta 'Personaje'.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el objeto con la etiqueta 'Personaje' en la escena.");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje") && inventario != null && inventario.cantidad == 1){
            Debug.Log("Colisión exitosa y tiene la llave");

            if (SceneManager.GetActiveScene().name == "LVL 1")
            {
                CambiarNivel("LVL 2");
            }
            else if (SceneManager.GetActiveScene().name == "LVL 2")
            {
                CambiarNivel("Menu");
            }
            
        }else{
            Debug.Log("Colisión, pero no tiene la llave o el inventario es nulo");
        }
    }

    public void CambiarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}
