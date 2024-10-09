using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Respawn : MonoBehaviour{

    Inventario inventario;

    public GameObject llave;

    public float initialTimerValue = 0;
    private float timer;

    public Text textoTimer;

    // Posición inicial del personaje
    private Vector3 initialPosition;

    void Start(){

        inventario = GameObject.FindGameObjectWithTag("Personaje").GetComponent<Inventario>();

        // Almacena la posición inicial del personaje al comenzar el juego
        initialPosition = transform.position;

        // Inicializa el temporizador con el valor inicial
        timer = initialTimerValue;
    }

    void Update(){
        if(timer > 0){
            timer -= Time.deltaTime;
        }else {
            // Cuando el temporizador llega a cero, reinicia la posición del personaje y restablece el temporizador
            RespawnCharacter();
        }



        // Actualiza el texto del temporizador
         textoTimer.text = "" + timer.ToString("f1");
    }

    private void RespawnCharacter(){
        transform.position = initialPosition;
        timer = initialTimerValue;
        inventario.cantidad = 0;
        llave.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("PolygonColliderTag")){
            RespawnCharacter();
            Debug.Log("Collider detectado");
        }else{
            Debug.Log("No detectado");
        }
    }


}
