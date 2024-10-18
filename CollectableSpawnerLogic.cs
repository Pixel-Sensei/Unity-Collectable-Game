using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnerLogic : MonoBehaviour
{
    // Referenz auf das "Collectable"-Objekt, das im Spiel gespawnt wird.
    public GameObject collectable;
    // Referenz auf das "BadCollectable"-Objekt, das im Spiel gespawnt wird.
    public GameObject badCollectable;

    // Zeitintervall (in Sekunden) zwischen dem Spawnen von Collectables.
    public float collectableSpawnTime = 1f;
    // Zeitintervall (in Sekunden) zwischen dem Spawnen von BadCollectables.
    public float badCollectableSpawnTime = 2f;

//Neu!!!-----------------------------
    // Zufällige X- und Y-Koordinaten für das Collectable.
    float randomXCollectable = 0;
    float randomYCollectable = 0;

    // Zufällige X- und Y-Koordinaten für das BadCollectable.
    float randomXBadCollectable = 0;
    float randomYBadCollectable = 0;
//------------------------------------

    // Maximale X- und Y-Werte, die die Positionen der Collectables begrenzen.
    float maxX = 17.5f;
    float maxY = 9f;

    // Start wird vor dem ersten Frame einmal aufgerufen.
    void Start()
    {
        // Startet die Coroutine, die regelmässig Collectables spawnt.
        StartCoroutine(spawnCollectables());
        // Startet die Coroutine, die regelmässig BadCollectables spawnt.
        StartCoroutine(spawnBadCollectables());
    }

    // Coroutine, die Collectables in regelmässigen Abständen spawnt.
    IEnumerator spawnCollectables()
    {
        while (true)
        {
            // Spawnt ein einzelnes Collectable.
             spawnCollectable();
             // Wartet eine bestimmte Zeit, bevor das nächste Collectable gespawnt wird.
             yield return new WaitForSeconds(collectableSpawnTime);
        }
    }

    // Coroutine, die BadCollectables in regelmässigen Abständen spawnt.
    IEnumerator spawnBadCollectables()
    {
        while (true)
        {
            // Spawnt ein einzelnes BadCollectable.
             spawnBadCollectable();
             // Wartet eine bestimmte Zeit, bevor das nächste BadCollectable gespawnt wird.
             yield return new WaitForSeconds(badCollectableSpawnTime);
        }
    }

    // Spawnt ein Collectable an einer zufälligen Position.
    void spawnCollectable()
    {
        // Zufällige X- und Y-Position innerhalb der festgelegten Grenzen.
        randomXCollectable = Random.Range(-maxX, maxX);
        randomYCollectable = Random.Range(-maxY, maxY);

        // Erstellt ein neues Collectable-Objekt an der zufälligen Position.
        Instantiate(collectable, new Vector3(randomXCollectable, randomYCollectable, 0), Quaternion.identity);
    }

    // Spawnt ein BadCollectable an einer zufälligen Position.
    void spawnBadCollectable()
    {
        // Zufällige X- und Y-Position innerhalb der festgelegten Grenzen.
        randomXBadCollectable = Random.Range(-maxX, maxX);
        randomYBadCollectable = Random.Range(-maxY, maxY);

        // Erstellt ein neues BadCollectable-Objekt an der zufälligen Position.
        Instantiate(badCollectable, new Vector3(randomXBadCollectable, randomYBadCollectable, 0), Quaternion.identity);
    }
}
