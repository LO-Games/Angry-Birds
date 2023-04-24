using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructibles : MonoBehaviour
{
    [SerializeField] private float resistance; 
    [SerializeField] private GameObject explosionPrefab;
    public static int numOfPigs = 3; 

    void OnCollisionEnter2D(Collision2D other){
        if(other.relativeVelocity.magnitude > resistance){
            if(explosionPrefab != null){
                var go = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(go, 4);
            }
            Destroy(gameObject, 0.1f);
            if(gameObject.tag == "Pig1" || gameObject.tag == "Pig2" || gameObject.tag == "Pig3"){
                numOfPigs--; 
                Debug.Log("The num of pigs now is : " + numOfPigs);
            }
        }else{
            resistance -= other.relativeVelocity.magnitude;
        }
    }
    
    void Start()
    {
     
    }

    void Update()
    {
        
    }
}
