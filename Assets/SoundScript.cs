using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip shot;
    static AudioSource aso;
    void Start()
    {
        shot = Resources.Load<AudioClip>("Laser Shot");
        aso = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void ShootSound()
    {
        aso.PlayOneShot(shot);
    }
}
