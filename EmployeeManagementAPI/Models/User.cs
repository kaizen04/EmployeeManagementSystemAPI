using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models
{
    public class User
    {
        public User()
        {

        }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }


        [Required]
        [Key]
        [Column(TypeName = "nvarchar(500)")]
        public string Email { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public string DOB { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public string PAN { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public string Contact { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(1500)")]
        public string Address { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public string DOJ { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string DepartmentName { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Designation { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Role { get; set; }
    }
}
