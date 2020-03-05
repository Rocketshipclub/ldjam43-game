using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour {

    Caravan caravan;
    GameController gc;
    public Spawner spawner;
    bool canMove = true;
    public TextMeshProUGUI pausetext;

    private void Start()
    {
        caravan = GetComponent<Caravan>();
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
    }

    void Update()
    {
        if (!gc.IsPaused() && canMove)
        {
            canMove = false;
            foreach (var tree in spawner.instantiatedTrees)
            {
                tree.GetComponent<Tree>().Move();
            }

            foreach(var wall in spawner.walls)
            {
                wall.GetComponent<Tree>().Move();
            }

            foreach (var ground in spawner.ground)
            {
                ground.GetComponent<Tree>().Move();
            }
            spawner.SpawnTree();
            Move();
            StartCoroutine(MovementCooldown());
        }
    }

    private void Move()
    {
        caravan.ModifyCaravanRestStatus(false);
        caravan.ProcessTurn(false);
    }

    IEnumerator MovementCooldown()
    {
        yield return new WaitForSeconds(3);
        canMove = true;
    }

    public void PauseMovement(bool isPaused)
    {
        Debug.Log("paused");
        if (isPaused)
        {
            pausetext.text = "PAUSED";
        }

        else
        {
            pausetext.text = "";
        }
    }
}
