using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    // Eine Referenz auf das Script, das den Punktestand (Score) verwaltet.
    public ScoreLogic scoreGUIScript;

    // Start wird vor dem ersten Frame einmal aufgerufen.
    void Start()
    {
        // Der Mauszeiger wird unsichtbar gemacht, wenn das Spiel startet.
        Cursor.visible = false;
    }

    // Update wird einmal pro Frame aufgerufen.
    void Update()
    {
        // Speichert die aktuelle Position der Maus.
        var tempMousePosition = Input.mousePosition;

        // Konvertiert die Mausposition von Bildschirmkoordinaten in Weltkoordinaten.
        tempMousePosition = Camera.main.ScreenToWorldPoint(tempMousePosition);

        // Setzt die z-Koordinate auf 0, damit das Objekt sich nur in 2D (x und y) bewegt.
        tempMousePosition.z = 0;

        // Bewegt das Spielerobjekt mit einer konstanten Geschwindigkeit in Richtung der Mausposition.
        // 2000 * Time.deltaTime sorgt dafür, dass die Bewegung framerate-unabhängig ist.
        transform.position = Vector3.MoveTowards(transform.position, tempMousePosition, 2000 * Time.deltaTime);
    }

    // Diese Methode wird aufgerufen, wenn der Spieler mit einem anderen Objekt kollidiert.
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Wenn der Spieler mit einem Objekt kollidiert, das den Tag "Collectable" hat.
        if (other.gameObject.tag.Equals("Collectable"))
        {
            // Zerstört das Objekt (Collectable), das eingesammelt wurde.
            Destroy(other.gameObject);

            // Erhöht den Punktestand um 1, wenn ein Collectable eingesammelt wird.
            scoreGUIScript.score += 1;
        }
        // Wenn der Spieler mit einem Objekt kollidiert, das den Tag "BadCollectable" hat.
        else if (other.gameObject.tag.Equals("BadCollectable"))
        {
            // Lädt die Szene "SampleScene" neu (vermutlich um das Spiel von vorne zu starten).
            SceneManager.LoadScene("SampleScene");
        }
    }
}
