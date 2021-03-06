using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Objetivo: Pasar a la transicion de pasillo al museo del Nivel III del Prota
 * Autor: Roberto Valdez Jasso
 * Autor: Diego Alejandro Juarez Ruiz
 * Autor: Luis Enrique Zamarripa
 * Referencia a: Drosgame
 * Youtube: https://youtu.be/FjoL4ufZmXc
 */

public class Transicion1Pasillo : MonoBehaviour
{
    // Variables ---//
    // llamanndo al mensaje
    public TextMeshProUGUI textD;


    //Velocidad del Parrafo
    public float velParrafo;

    // GameObjects----//
    // Botones
    // Boton Si 
    public GameObject botonSi;


    // Boton Boton No
    public GameObject botonNo;

    // Panel Dialogo
    public GameObject PanelDialogo;
    // Boton Lectura
    public GameObject BotonLeer;


    // Referencia al auido Source
    public AudioSource EfectoSonido;

    //Imagen que dara la transicion en negro a la siguiente escena
    public Image imagenFondo;

    // Start is called before the first frame update
    void Start()
    {
        // Declarando el inicio
        //No estara prendido hasta que el objeto sea utilizado
        BotonLeer.SetActive(false);
        PanelDialogo.SetActive(false);
        //imagenFondo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Si utilizamos el objecto pasamos al if

    }




    //Interaccion  con el jugador
    public void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.CompareTag("Player"))
        {
            BotonLeer.SetActive(true);

        }
        else
        {
            BotonLeer.SetActive(false);

        }
    }
    //Activaar la pregunta
    public void activarBotonLeer()
    {

        PanelDialogo.SetActive(true);
        textD.text = "¿Listo para seguir adelante?";

        botonSi.SetActive(true);
        botonNo.SetActive(true);



    }

    //Cambiar de mapa
    public void botoncambiar()
    {
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);
        //Reproducimos el sonido
        EfectoSonido.Play();

        // Esperamos Tres segundos y esperamos que efecto Fade in aparezca
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(true);
        imagenFondo.CrossFadeAlpha(1, 0.8f, true);
        new WaitForSeconds(3);
        botonSi.SetActive(false);
        botonNo.SetActive(false);

        // Cargamos Escena
        StartCoroutine(CambiarEscena());

        
    }

    //Corrutina -> Cambio de escena
    private IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(2);
        // Cambiar de escena
        //Ya regreso /Ya termino
        SceneManager.LoadScene("Scenes/Nivel_III/nivel3Museo");
    }


    public void botonQuedarse()
    {
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);
    }

    public void OnTriggerExit2D(Collider2D collsion)
    {
        BotonLeer.SetActive(false);
        PisoPrueba.estaenpiso = true;
    }
}
