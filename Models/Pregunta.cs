namespace LectureSpacesApp.models
{
    public class Pregunta
    {
        public int ID { get; set; }
        public string enunciado { get; set; }
        public virtual ICollection<Respuesta>? Respuestas { get; set; }
        public Respuesta? correcta { get; set; }
        public int votos { get; set; }

    }
}
