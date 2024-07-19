using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TEST_DEV.Models.Models
{
    public partial class TbUsuario
    {
        [Key]
        public int IdUser { get; set; }
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
    }
}
