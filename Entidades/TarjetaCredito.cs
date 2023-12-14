using System.ComponentModel.DataAnnotations;

namespace ProyectoEspecializacionISBC.Entidades;

    public class TarjetaCredito
    {
        public int id { get; set; }

        [Required]
        public string titulo { get; set; }
        [Required]
        public string Tarjeta { get; set; }
        [Required]
        public string fechaexpiracion { get; set; }
        [Required]
        public int cvv { get; set; }
    }

