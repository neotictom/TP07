using TP07.Models;
public class Juego{
    private static string _username{get;set;}
    private static int _puntajeActual{get;set;}
    private static int _cantidadPreguntasCorrectas{get;set;}
    private static List<Pregunta> _preguntas{get;set;}
    private static List<Respuesta> _respuestas{get;set;}
    public static void InicializarJuego(){
        _username = null;
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }
    public static string ObtenerNombre()
    {
        return _username;
    }
    public static int ObtenerPuntaje()
    {
        return _puntajeActual;
    }
    public static List<Categoria> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }
    public static List<Dificultad> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }
    public static void CargarPartida(string username, int dificultad, int categoria){
        _username = username;
        _preguntas = BD.ObtenerPreguntas(dificultad,categoria);
        _respuestas = BD.ObtenerRespuestas();
    }
    public static List<Pregunta> ObtenerPreguntas(){
        return _preguntas;
    }
    public static Pregunta ObtenerProximaPregunta(){
        Pregunta preguntarnd;
        if (_preguntas.Count() != 0)
        {
            return preguntarnd = _preguntas[0];
        }
        else
        {
            return null;
        }
    }
    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta){
        List<Respuesta> respuestas = new List<Respuesta>{};
        foreach (var item in _respuestas)
        {
            if (item.IdPregunta == idPregunta)
            {
                respuestas.Add(item);
            }
        }
        return respuestas;
    }
    public static bool VerificarRespuesta(bool respuesta){
        bool v;
        if(respuesta){
            _puntajeActual+=5;
            _preguntas.RemoveAt(0);
            v = true;
        }
        else
        {
            _preguntas.RemoveAt(0);
            v = false;
        }
        return v;
    }
}

