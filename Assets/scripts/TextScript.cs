using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public string textcontent;
    public TMP_Text texto;

    float elapsedTime;
    public int puntuacion = 0;
    int tiempo = 100;
    float crono;
    bool pausa = false;

    void Start()
    {
        texto.text = textcontent;
    }
    void Update()
    {

        elapsedTime += Time.deltaTime;
        crono = tiempo - elapsedTime;
        if (crono > 0 && puntuacion<500)
        {
            textcontent = "Tiempo restante: " + Mathf.Round(crono) +
            "\nPuntuaci�n: " + puntuacion;
        }
        else
        {
            if (pausa == false)
            {
                if (puntuacion == 500)
                {
                    textcontent = "Termin� la partida!\nPuntuaci�n final: " + puntuacion +
                "\nLlegado a la puntuaci�n m�xima en: " + crono;
                }
                else
                {
                    textcontent = "Termin� la partida!\nPuntuaci�n final: " + puntuacion;
                }
                pausa = true;
            }
        }
        texto.text = textcontent;
    }
    public void aumentarPuntuacion()
    {
        if (crono > 0)
        {
            puntuacion = puntuacion + 25;
        }
    }

    public void aumentarCrono()
    {
        if (crono > 0)
        {
            tiempo = tiempo + 30;
        }
    }
}
