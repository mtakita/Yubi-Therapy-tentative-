using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour {

    float t;
    float deltaT = 0.01f;
    float min = 0.5f;
    float max = 20.0f;
    float tMax = 0.5f;

	// Use this for initialization
	void Start () {

        t = 0;

    }
	
	// Update is called once per frame
	void Update () {
		if( !Input.GetMouseButton( 0 ))
        {
            GameObject gameObject = GetComponent<GameObject>();
            DestroyObject(this.gameObject);
        }

        if (t < tMax)
        {
            t = t + deltaT;
        }

        float y = 3 * Mathf.Pow(t,2) - 2 * Mathf.Pow( t , 2);

        float s = (max - min) * y + min;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.transform.localScale = new Vector3(s,s,s);

        Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseLoc.z = 0.0f;
        sr.transform.position = mouseLoc;

    }
}
