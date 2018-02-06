using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour {

    private Camera cam;
    public Collider anObjCollider;
    private Plane[] planes;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
        anObjCollider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (!GeometryUtility.TestPlanesAABB(planes, anObjCollider.bounds))
        {
            Destroy(this.gameObject);
        }
    }
}
