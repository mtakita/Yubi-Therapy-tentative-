using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour, IgeneratorRef
{

    float t;
    float scale;

    const float deltaT = 0.01f;
    const float min = 0.5f;
    const float max = 20.0f;
    const float tMax = 0.5f;

    const float r_min = 5.0f / 11.0f;
    const float r_max = 50.0f / 11.0f;

    Generator generator;

    float GetRadius()
    {
        float r = (r_max - r_min) / (max - min) * (scale + r_min);
        return r;

    }

    public bool IsInRadius( Vector3 position )
    {
        float distance = (transform.position - position).magnitude;
        float r = GetRadius();

        if( distance <= r)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetGenerator(Generator inGenerator)
    {
        generator = inGenerator;
    }

    public float GetInfrationLevel()
    {
        return scale / max;
    }

	// Use this for initialization
	void Start () {

        t = 0;
        scale = min;

    }
	
	// Update is called once per frame
	void Update () {
		if( !Input.GetMouseButton( 0 ))
        {
            generator.touchDestroy();

            GameObject gameObject = GetComponent<GameObject>();
            DestroyObject(this.gameObject);
        }

        if (t < tMax)
        {
            t = t + deltaT;
        }

        float y = 3 * Mathf.Pow(t,2) - 2 * Mathf.Pow( t , 2);

        scale = (max - min) * y + min;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.transform.localScale = new Vector3(scale, scale, scale);

        Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseLoc.z = 0.0f;
        sr.transform.position = mouseLoc;

    }
}
