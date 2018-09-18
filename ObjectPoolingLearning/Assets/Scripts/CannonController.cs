using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    public GameObject cannonBallPrefab;
    public float delay = 0.3f;
    public float speed = 5f;

    public List<GameObject> cannonBallPool;
    public int poolSize = 20;

    // Use this for initialization
    void Start () {
        cannonBallPool = new List<GameObject>();
        for(int i= 0; i < poolSize; i++)
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab);
            cannonBall.SetActive(false);
            cannonBallPool.Add(cannonBall);
        }
        StartCoroutine(ShootCannon());
	}
	
    IEnumerator ShootCannon()
    {
        while (true)
        {
            GameObject cannonBall = GetCannonBall();//Instantiate(cannonBallPrefab);
            if(cannonBall != null)
            {
                cannonBall.SetActive(true);
                cannonBall.transform.position = gameObject.transform.position;
                cannonBall.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
            }
            yield return new WaitForSeconds(delay); 
        }  
    }

    GameObject GetCannonBall()
    {
        for(int i = 0; i < cannonBallPool.Count; i++)
        { 
            //if the ball is not visible retrieve it
            if (!cannonBallPool[i].activeInHierarchy){
                return cannonBallPool[i];
            }
        }
        return null;
    }
}
