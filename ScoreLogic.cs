using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    // Der Punktestand, der im Spiel angezeigt wird.
    public int score = 0;

    // Update wird einmal pro Frame aufgerufen.
    void Update()
    {
        // Findet das Text-Objekt, das ein Kind von diesem Objekt ist,
        // und aktualisiert den angezeigten Text mit dem aktuellen Punktestand.
        GetComponentInChildren<Text>().text = "Score: " + score;
    }
}
