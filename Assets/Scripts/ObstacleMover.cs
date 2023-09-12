using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() //usado para que a atualização role a cada evento físico
    {
         var gameManager = GameManager.Instance;

        if(gameManager.IsGameOver()){
            return;
        }
        float x = gameManager.obstacleSpeed * Time.deltaTime;
        transform.position -= new Vector3(x, 0, 0);
        
        if(transform.position.x <= -gameManager.obstacleOffsetX){
            Destroy(gameObject);
        }
    }
}
