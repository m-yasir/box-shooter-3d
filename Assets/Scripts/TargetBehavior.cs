using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{

    // target impact on game
    public int scoreAmount = 0;
    public float timeAmount = 0.0f;

    // explosion when hit?
    public GameObject explosionPrefab;

    // when collided with another gameObject
    void OnCollisionEnter(Collision newCollision)
    {
        // exit if there is a game manager and the game is over
        if (newCollision.gameObject.tag != "Projectile" || (GameManager.gm && GameManager.gm.gameIsOver))
        {
            return;
        }

        // only do stuff if hit by a projectile
        // Instantiate an explosion effect at the gameObjects position and rotation
        if (explosionPrefab)
            Instantiate(explosionPrefab, transform.position, transform.rotation);

        // if game manager exists, make adjustments based on target properties
        GameManager.gm.targetHit(scoreAmount, timeAmount);

        // destroy the projectile
        Destroy(newCollision.gameObject);

        // destroy self
        Destroy(gameObject);
    }
}
