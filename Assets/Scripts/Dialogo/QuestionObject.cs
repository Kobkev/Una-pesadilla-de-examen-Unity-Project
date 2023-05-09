using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pregunta/PreguntaObject")]
public class QuestionObject : ScriptableObject
{
    [SerializeField][TextArea] private string mensajePregunta;
    [SerializeField][TextArea] private string contrasena;

    public string Pregunta => mensajePregunta;
    public string Respuesta => contrasena;
}
