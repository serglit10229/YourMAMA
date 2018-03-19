using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public GameObject Rifle;
    public Animation anim;

    public bool Fire = false;

	// Update is called once per frame
	void Update () {
        
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
