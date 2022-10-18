using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acoes : MonoBehaviour
{
    public Light lanterna;
    public MovimentoJogador movimento;
    // Start is called before the first frame update
    void Start()
    {
        movimento = GetComponent<MovimentoJogador>();
    }

    // Update is called once per frame
    void Update()
    {
        LigarDesligarLanterna();
        aumentarDiminuirVelocidade();
    }

    private void LigarDesligarLanterna(){
        if(Input.GetKeyUp(KeyCode.E)){
            lanterna.enabled = !lanterna.enabled;
        }
    }

    public void aumentarDiminuirVelocidade(){
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            movimento.Velocidade = 10.0f;
        }else if(Input.GetKeyUp(KeyCode.LeftShift)){
            movimento.Velocidade = 6.0f;
        }
    }
}
