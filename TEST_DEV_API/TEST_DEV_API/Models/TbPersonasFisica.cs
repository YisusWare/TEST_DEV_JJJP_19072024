using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TEST_DEV_API.ValidationAttributes;

#nullable disable

namespace TEST_DEV_API.Models
{
    [Table("Tb_PersonasFisicas")]
    public partial class TbPersonasFisica
    {
        [Key]
        public int IdPersonaFisica { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaRegistro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaActualizacion { get; set; }
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required]
        public string ApellidoPaterno { get; set; }
        [StringLength(50)]
        [Required]
        public string ApellidoMaterno { get; set; }
        [Column("RFC")]
        [RfcAttribute]
        [StringLength(13)]
        public string Rfc { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime? FechaNacimiento { get; set; }
        public int? UsuarioAgrega { get; set; }
        public bool? Activo { get; set; }
    }
}
