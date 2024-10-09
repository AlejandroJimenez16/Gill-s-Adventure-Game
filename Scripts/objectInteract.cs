using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInteract : MonoBehaviour
{
    Inventario inventario;

    void Start(){
        // Busca el objeto con la etiqueta "Personaje" y obtén el componente Inventario
        inventario = GameObject.FindGameObjectWithTag("Personaje").GetComponent<Inventario>();

        gameObject.SetActive(true);
        
        // Verifica si el componente Inventario es nulo
        if (inventario == null){
            Debug.LogError("No se encontró el componente Inventario en el objeto con la etiqueta 'Personaje'.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Personaje"))
        {
            // Accede a la variable 'cantidad' a través del objeto 'inventario'
            inventario.cantidad = inventario.cantidad + 1;
            gameObject.SetActive(false);
        }
    }
}
