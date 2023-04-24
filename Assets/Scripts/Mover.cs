using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private float maxDistance;
    [SerializeField] private float maxVelocity;
    private Rigidbody2D rb;
    private bool canDrag = true; 
    private Vector3 vec;
    private Vector3 initialPos; 
    private float delay = 2f;
    private Quaternion initialRot;

    void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; 
    }

    void OnMouseDrag(){
        if(!canDrag){
            return;
        }

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec = pos - pivot.position;
        vec.z = 0;

        if(vec.magnitude > maxDistance){
            vec = vec.normalized * maxDistance;
        }
        transform.position = vec + pivot.position;
    }

    void OnMouseUp(){
        if(!canDrag)
            return;
        canDrag = false;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -vec.normalized * maxVelocity * vec.magnitude / maxDistance;
        if(Destructibles.numOfPigs > 0){
            StartCoroutine(GetToInitialPosAfterTwoSeconds());
        }
    }

    IEnumerator GetToInitialPosAfterTwoSeconds(){
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        transform.position = initialPos;
        transform.rotation = initialRot;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.bodyType = RigidbodyType2D.Kinematic;
        canDrag = true;
    }

    void Update()
    {
        
    }
}
