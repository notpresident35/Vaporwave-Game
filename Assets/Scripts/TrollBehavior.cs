using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollBehavior : MonoBehaviour, GenericKillableEntity
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die () {
        Destroy (gameObject);
    }
}
