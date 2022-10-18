using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    private float velocidade = 6.0f;
    public float rotacao = 500.0f;

    public CharacterController controller;
    public float gravidade = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Screen.lockCursor = true;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        rotacaoCameraX();
    }

    void FixedUpdate() {
        movimento();
    }

    private void movimento(){
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direcao = transform.forward * z + transform.right * x + Vector3.down * gravidade;
 
        controller.Move(direcao * velocidade * Time.deltaTime);
 
        if (controller.isGrounded){
            gravidade = 0;
        }else{
            gravidade = 1;
        }
    }

    private void rotacaoCameraX(){
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX * rotacao * Time.deltaTime, 0));
    }

    public float Velocidade{
        get{
            return velocidade;
        }
        set{
            velocidade = value;
        }
    }
}
