using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    public GameObject cannonBallPrefab;
    public float delay = 0.3f;
    public float speed = 5f;

    public int poolSize = 20;
    public bool expandablePoolSize = true;

    public List<Rigidbody2D> cannonBallPool;

    // Use this for initialization
    void Start () {
        cannonBallPool = new List<Rigidbody2D>();
     
        for(int i= 0; i < poolSize; i++)
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab);
            cannonBall.SetActive(false);
            cannonBallPool.Add(cannonBall.GetComponent<Rigidbody2D>());
        }
        StartCoroutine(ShootCannon());
	}
	
    IEnumerator ShootCannon()
    {
        while (true)
        {
            Rigidbody2D cannonBall = GetCannonBall();//Instantiate(cannonBallPrefab);
            if(cannonBall != null)
            {
                cannonBall.gameObject.SetActive(true);
                cannonBall.gameObject.transform.position = gameObject.transform.position;
                cannonBall.AddForce(Vector2.right * speed);
            }
            yield return new WaitForSeconds(delay); 
        }  
    }

    Rigidbody2D GetCannonBall()
    {
        for(int i = 0; i < cannonBallPool.Count; i++)
        {
            if (cannonBallPool[i] == null)
            {
                GameObject cannonBall = Instantiate(cannonBallPrefab);
                cannonBallPool[i] = cannonBall.GetComponent<Rigidbody2D>();
                cannonBall.SetActive(false);
                return cannonBall.GetComponent<Rigidbody2D>();
            }

            //if the ball is not visible retrieve it
            if (!cannonBallPool[i].gameObject.activeInHierarchy)
            {
                return cannonBallPool[i];
            }
        }

        if (expandablePoolSize)
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab);
            cannonBallPool.Add(cannonBall.GetComponent<Rigidbody2D>());
            cannonBall.SetActive(false);
            return cannonBall.GetComponent<Rigidbody2D>();
        }
        return null;
    }
}
