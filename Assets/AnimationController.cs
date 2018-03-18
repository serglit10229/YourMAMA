using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public GameObject Rifle;

    public bool Fire = false;

	// Update is called once per frame
	void Update () {
        if (!Rifle.GetComponent<Animation>().isPlaying)
        {
            Rifle.GetComponent<Animation>().CrossFade("Idle");
        }
        if (Fire == true)
        {
            Rifle.GetComponent<Animation>().Stop("Idle");
            Rifle.GetComponent<Animation>().Play("Fire");
            if (!Rifle.GetComponent<Animation>().IsPlaying("Fire"))
            {
                Rifle.GetComponent<Animation>().Stop("Fire");
            }
        }
        //InvokeRepeating("FireAnimation", 3, 300);
    }

    public void FireAnimation()
    {
        while (Rifle.GetComponent<Animation>().IsPlaying("Fire"))
            //Rifle.GetComponent<Animation>().Stop();
            Rifle.GetComponent<Animation>().CrossFade("Fire");
        if (!Rifle.GetComponent<Animation>().IsPlaying("Fire"))
        {
            Rifle.GetComponent<Animation>().Stop();
        }
    }


}
