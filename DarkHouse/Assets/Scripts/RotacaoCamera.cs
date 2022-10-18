using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoCamera : MonoBehaviour
{
    public float rotacao = 500.0f;
    // Start is called before the first frame update
    void Start()
    {  

    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3((-mouseY * rotacao) * Time.deltaTime, 0, 0));

        limitarRotacaoEmY();
    }

    private void limitarRotacaoEmY(){
        Vector3 angulosEulerJogador = transform.rotation.eulerAngles;

        angulosEulerJogador.x = (angulosEulerJogador.x > 180) ? angulosEulerJogador.x - 360 : angulosEulerJogador.x;
        angulosEulerJogador.x = Mathf.Clamp(angulosEulerJogador.x, -50f, 50f);

        transform.rotation = Quaternion.Euler(angulosEulerJogador);
    } 
}
