using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManger gameManager;
   
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        
        targetRb.AddForce (RandomForce (), ForceMode.Impulse);
        
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
       
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
        gameManager = GameObject.Find("GameManger").GetComponent<GameManger>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(5);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject) ;
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    } 
}

