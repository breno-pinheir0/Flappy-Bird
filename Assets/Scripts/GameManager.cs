using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance{get; private set;}

    [FormerlySerializedAs("prefabs")] //marcador para deixar o Unity Sabendo que o nome obstaclePrefabs está atrelado à prefabs
    public List<GameObject> obstaclePrefabs;

    public float obstacleInterval = 1;

    public float obstacleSpeed = 10;

    public float obstacleOffsetX = 0;

[HideInInspector]
public int score;

[HideInInspector]
public bool isGameOver = false;

    public Vector2 obstacleOffsetY = new Vector2(0, 0);

    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this);
        } else{
            Instance = this;
        }
    
    }

    public bool IsGameActive(){
        return !isGameOver;
    }

    public bool IsGameOver(){
        return isGameOver;
    }

    public void EndGame  (){
        isGameOver = true;
        Debug.Log("Game Over... Final score is: " + score);
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay){ // restaura o jogo para a cena principal (começo)
        Debug.Log("Reloading the scene.");
        yield return new WaitForSeconds(1);
        Debug.Log("Reloading the scene..");
        yield return new WaitForSeconds(1);
        Debug.Log("Reloading the scene...");
        yield return new WaitForSeconds(delay);

        
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

}
