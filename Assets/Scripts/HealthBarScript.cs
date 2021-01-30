using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    int heartNum;
    int totalHearts;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        totalHearts =  gameObject.transform.childCount;
        heartNum = totalHearts;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && heartNum > 0) {//Hearts disappear here. Replace with a link to player later?
            hurtMe();
        }
        else if (Input.GetKeyDown(KeyCode.S) && heartNum < totalHearts) {//Hearts reappear here. Replace with a link to player later?
            healMe();
        }
    }

    public void hurtMe() {
        heartNum--;
        gameObject.transform.GetChild(heartNum).gameObject.SetActive(false);
        if (heartNum == 0) {
            die();
        }
    }

    public void healMe() {
        gameObject.transform.GetChild(heartNum).gameObject.SetActive(true);
        heartNum++;
    }

    public void die() {
        print("EH DEAD");
    }
}
