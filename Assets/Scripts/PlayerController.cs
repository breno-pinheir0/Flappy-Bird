using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;

    public float jumpPower = 10;

    public float jumpInterval = 0.5f;

    private float jumpCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime; // é feito o decremento da variável "jumpCooldown" pelo valor de tempo atual
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCooldown <= 0 && isGameActive; // só quando o tmepo é resetado que pode pular novamente

        if(canJump){
           
            bool jumpInput = Input.GetKey(KeyCode.Space); // criando uma variável booleana p/ receber se o botão espaço foi apertado ou não
            if(jumpInput){ // se o botão espaço for apertado, a função Jump será executada
                Jump();
            }
        }

        thisRigidbody.useGravity = isGameActive; 

        
        
    }

    void OnTriggerEnter(Collider other){

        OnCustomCollisionEnter(other.gameObject);
        
    }
    
       void OnCollisionEnter(Collision other){

        OnCustomCollisionEnter(other.gameObject);
        
    }


    private void OnCustomCollisionEnter(GameObject other){
        bool isSensor = other.gameObject.CompareTag("Sensor");
        if(isSensor){
            GameManager.Instance.score++;
            Debug.Log("Score: " +GameManager.Instance.score);
        } else {
            GameManager.Instance.EndGame();
        }
    }
    private void Jump(){
        jumpCooldown = jumpInterval; // setando o valor da variável "jumpCooldown" para o intervalo entre os pulos (0.5)
        thisRigidbody.velocity = Vector3.zero; // Vector3.zero é igual a escrever new Vector3 (0, 0, 0)
        thisRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        
    }
}
