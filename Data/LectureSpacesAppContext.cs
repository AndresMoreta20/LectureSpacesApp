using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LectureSpacesApp.models;

namespace LectureSpacesApp.Data
{
    public class LectureSpacesAppContext : DbContext
    {
        public LectureSpacesAppContext(DbContextOptions<LectureSpacesAppContext> options)
            : base(options)
        {
        }

        public DbSet<LectureSpacesApp.models.Admin>  Admin { get; set; }
        public DbSet<LectureSpacesApp.models.Respuesta> Respuesta { get; set; } = default!;

        public DbSet<LectureSpacesApp.models.Pregunta>? Pregunta { get; set; }

        public DbSet<LectureSpacesApp.models.Cuestionario>? Cuestionario { get; set; }

        public DbSet<LectureSpacesApp.models.Recurso>? Recurso { get; set; }

        public DbSet<LectureSpacesApp.models.Video>? Video { get; set; }

        public DbSet<LectureSpacesApp.models.Usuario>? Usuario { get; set; }

        public DbSet<LectureSpacesApp.models.LectureSpaceComponent>? LectureSpaceComponent { get; set; }
    }
}
