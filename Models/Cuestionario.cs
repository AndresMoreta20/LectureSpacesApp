namespace LectureSpacesApp.models
{
    public class Cuestionario
    {
        public int ID { get; set; }
        public string titulo { get; set; }
        public string descripicion { get; set; }
        public virtual ICollection<Pregunta> Preguntas { get; set; }

    }
}
