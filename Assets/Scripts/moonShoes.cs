using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonShoes : MonoBehaviour
{
    Player playerScript;
    float playerSpd;
    bool hasBeenSteppedIn;
    SpriteRenderer sprite;
    Collider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
            playerSpd = playerScript.Speed;
        }
        sprite = GetComponent<SpriteRenderer> ();
        col = GetComponent<Collider2D> ();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasBeenSteppedIn)
        {
            StartCoroutine(waitUp());
        }
    }

    IEnumerator waitUp()
    {
        hasBeenSteppedIn = true;
        playerScript.Speed = playerSpd * 3;
        playerScript.spedUp = true;
        sprite.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(5);
        playerScript.Speed = playerSpd;
        playerScript.spedUp = false;
        Destroy (gameObject);
    }
}
