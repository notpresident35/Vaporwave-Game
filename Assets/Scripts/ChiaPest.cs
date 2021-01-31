using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiaPest : MonoBehaviour
{
    public GameObject body;
    Player playerScript;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
        }
        body.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            body.GetComponent<SpriteRenderer>().enabled = true;
            body.GetComponent<SpriteRenderer>().sortingOrder = 4;
            GetComponent<SpriteRenderer>().sortingOrder = 4;
            body.GetComponent<Transform>().position = collision.GetComponent<Transform>().position;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            StartCoroutine(stopHim());
        }
    }

    IEnumerator stopHim() {
        playerScript.trapped = true;
        yield return new WaitForSeconds(5);
        playerScript.trapped = false;
        Destroy(body);
        Destroy(gameObject);
    }
}
