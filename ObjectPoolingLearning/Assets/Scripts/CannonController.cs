using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    public GameObject cannonBallPrefab;
    public float delay = 0.3f;
    public float speed = 5f;

	// Use this for initialization
	void Start () {
        StartCoroutine(ShootCannon());
	}
	
    IEnumerator ShootCannon()
    {
        while (true)
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab);
            cannonBall.transform.position = gameObject.transform.position;
            cannonBallPrefab.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
            yield return new WaitForSeconds(delay); 
        }  
    }
}
