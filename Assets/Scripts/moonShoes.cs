using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonShoes : MonoBehaviour
{
    Player playerScript;
    float playerSpd;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
            playerSpd = playerScript.Speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(waitUp());
        }
    }

    IEnumerator waitUp()
    {
        playerScript.Speed = 1;
        yield return new WaitForSeconds(5);
        playerScript.Speed = playerSpd;
        
    }
}
