using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoles : MonoBehaviour {

    public GameObject[] bulletTex;
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, fwd * 10, Color.green);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            Vector3 point = new Vector3(0.01f, 0.01f, 0.01f);
            Instantiate(bulletTex[0], hit.point + hit.normal*0.01f, Quaternion.FromToRotation(Vector3.up, hit.normal));

            Debug.Log(hit.normal);
        }
	}
}
