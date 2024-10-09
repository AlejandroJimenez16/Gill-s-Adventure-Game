using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour{
    public float velocidad;
    public float fuerzaSalto;
    private bool mirandoDerecha = true;
    private bool corriendo = false;
    //
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    public LayerMask capaSuelo;
    private int saltosRestantes;
    public int saltosMaximos;
    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;

    }

    void Update(){
        ProcesarMovimiento();
    }

    void ProcesarMovimiento(){
        //Andar
        float inputMovimiento = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
        //Girar
        CambiarOrientacion(inputMovimiento);
        //Correr
        Correr(velocidad, inputMovimiento);
        //Saltar
        Saltar();
    }

    void CambiarOrientacion(float inputMovimiento){
        if((mirandoDerecha == true && inputMovimiento<0) || (mirandoDerecha == false && inputMovimiento>0)){
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    void Correr(float velocidad, float inputMovimiento){
        if(Input.GetKeyDown(KeyCode.R)){
            corriendo = !corriendo;
        }
        if(corriendo){
            velocidad = velocidad + 3;
            inputMovimiento = Input.GetAxis("Horizontal");
            rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
        }
    }

    void Saltar(){
        bool suelo = EstaEnSuelo();
        if (suelo){
            saltosRestantes = saltosMaximos;
        }
    
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 1){   
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltosRestantes--;
        }
    }

    bool EstaEnSuelo(){
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        bool suelo = (hit.collider != null);
        Debug.DrawRay(transform.position, Vector2.down, Color.blue);
        return suelo;

    }
}
