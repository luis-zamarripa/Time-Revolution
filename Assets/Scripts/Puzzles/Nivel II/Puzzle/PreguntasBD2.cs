using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
/*
 Clase pregunta BD PARA puzzle
 Autor: Roberto Valdez Jasso
 */
public class PreguntasBD2 : MonoBehaviour
{
    [SerializeField] private List<pregunta2> listapregunta = null;

    private List<pregunta2> M_Backup = null;

    private void Awake()
    {
        M_Backup = listapregunta.ToList();
    }

    // Removiendo la preguntas de la BD
    public pregunta2 GETRandom(bool remove = true)
    {
        if (listapregunta.Count == 0)
        {
            RestoreBackup();
        }

        int index = Random.Range(0, listapregunta.Count);
        //print(index);
        //print(listapregunta.Count);
        if (!remove)
        {
            return listapregunta[index];
        }

        pregunta2 q = listapregunta[index];
        //print(q.texto);
        listapregunta.RemoveAt(index);
        return q;
    }

    private void RestoreBackup()
    {
        listapregunta = M_Backup.ToList();
    }
}
