using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector3 PosObstacles = new Vector3(25,6,0);
    public float startDelay = 2;
    public float frequency = 1.5f;
    public PlayerController PlayerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles",startDelay, frequency);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacles()
    {
        if(PlayerControllerScript.gameOver == false){
        Instantiate(obstacles[0],PosObstacles,transform.rotation);   
        } 
    }
}
