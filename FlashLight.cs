using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {
    public LayerMask CollisionMask;
    private float viewRange = 5f;
    public Transform flashlight;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var collisionData = new CollisionData();

        
        var hit = Physics2D.Raycast(transform.position, new Vector2(flashlight.position.x - transform.position.x, flashlight.transform.position.y - transform.position.y), viewRange, CollisionMask);
        if (hit)
        {
            GameObject gObject = hit.transform.gameObject;
            collisionData = new CollisionData(true, hit.distance, hit.normal, gObject);

            if (collisionData.GameObject.CompareTag("Wall") || (collisionData.GameObject.CompareTag("Door") && !collisionData.GameObject.GetComponentInParent<MLDoor>().isOpen()))
            {
                changeFlashlightSize((collisionData.Distance / 3f) - 0.1f, collisionData.Distance / 5);
            }
            else
            {
                changeFlashlightSize(1 + (viewRange / 10), (viewRange / 10) + 0.4f);
            }
        }
        else
        {
            changeFlashlightSize(1 + (viewRange / 10), (viewRange / 10) + 0.4f);
        }
    }
    private void changeFlashlightSize(float wallDistanceX, float wallDistanceY)
    {
        flashlight.transform.localScale = new Vector3(wallDistanceX, wallDistanceY, 1);
    }
}
