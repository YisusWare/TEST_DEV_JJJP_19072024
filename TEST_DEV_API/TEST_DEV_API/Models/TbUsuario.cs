using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TEST_DEV_API.Models
{
    [Table("Tb_Usuarios")]
    public partial class TbUsuario
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}
