using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> trees = new List<GameObject>();
    public List<GameObject> instantiatedTrees = new List<GameObject>();

    public List<Transform> walls = new List<Transform>();
    public List<Transform> ground = new List<Transform>();

    public GameController gc;
    public Caravan caravan;

    private void Start()
    {
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
        caravan = GameObject.Find("Caravan").GetComponent<Caravan>();
    }

    public void SpawnTree()
    {
        if(Random.Range(0.0f, 1.0f) > 0.66f)
        {
            var newTree = Instantiate(trees[Random.Range(0, trees.Count)], new Vector3(transform.position.x + (Random.Range(-5, 5)), transform.position.y, transform.position.z), Quaternion.identity);
            instantiatedTrees.Add(newTree);
        }
    }

    private void Update()
    {
    }
}
