using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

    Spawner spawner;
    GameController gc;
    public float movement;
    public float pos;
    public float deletePos;

    private void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
    }

    public void Move()
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - movement, transform.position.y, transform.position.z), 0.1f * Time.deltaTime);
        //transform.position = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (!gc.IsPaused())
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - movement, transform.position.y, transform.position.z), 0.1f * Time.deltaTime);
        }
        if (transform.position.x < deletePos && !spawner.instantiatedTrees.Contains(gameObject))
        {
            transform.position = new Vector3(pos, transform.position.y, transform.position.z);
        }
        
        else if(transform.position.x < deletePos)
        {
            spawner.instantiatedTrees.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
