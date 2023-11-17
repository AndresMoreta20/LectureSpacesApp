namespace LectureSpacesApp.models
{
    public class Usuario
    {
        public int ID{ get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }

        public virtual ICollection<Pregunta>? Preguntas { get; set; }
        public virtual ICollection<LectureSpaceComponent>? LectureSpaceComponents { get; set; }
    }
}
