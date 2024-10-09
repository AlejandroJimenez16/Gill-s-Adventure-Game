using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour{

    public float jumpForce;

    private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.CompareTag("Personaje")) {
        Rigidbody2D jugadorRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        if (jugadorRigidbody != null) {
            jugadorRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}

    
}
