using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_antigo : MonoBehaviour
{
    public float velocidade = 30.0f;
    public float multiplicadorMovimento = 10.0f;
    public float multiplicadorAr = 0.3f;
    public float rotacao = 500.0f;
    private Rigidbody rb;
    private bool noChao = true;
    private float altura = 2;
    private LayerMask chao;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Screen.lockCursor = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        noChao = Physics.Raycast(transform.position, Vector3.down, altura * 0.5f + 0.2f);

        if(noChao){
            rb.drag = 6f;
        }else{
            rb.drag = 0f;
        }

        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");

        

        //Vector3 direcao = new Vector3(x, 0, y) * velocidade;

        //transform.Translate(direcao * Time.deltaTime);

        //float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidade * 3;
        //float z = Input.GetAxis("Vertical") * Time.deltaTime * velocidade * 3;

        //rb.velocity = new Vector3(x,rb.velocity.y,z);

        rotacaoCameraX();
    }

    void FixedUpdate() {
        movimento();
    }

    private void movimento(){
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direcao = transform.forward * z + transform.right * x;

        if(noChao){
            rb.AddForce(direcao.normalized * velocidade * multiplicadorMovimento, ForceMode.Force);
        }else{
            rb.AddForce(direcao.normalized * velocidade * multiplicadorAr, ForceMode.Force);
        }
    }

    private void rotacaoCameraX(){
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX * rotacao * Time.deltaTime, 0));
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Chao")
        {
            noChao = true;
            rb.drag = 8f;
        }
    }
    void OnCollisionExit(Collision Collider)
    {
        if (Collider.gameObject.tag == "Chao")
        {
            noChao = false;
            rb.drag = 4f;
        }
    }
    */
}
