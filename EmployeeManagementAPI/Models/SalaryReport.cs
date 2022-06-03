using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models
{
    public class SalaryReport
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string EmployeeName { get; set; }


        
        public string Email { get; set; }
        public User User { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string Designation { get; set; }


        [Required]
        [Key]
        [Column(TypeName = "nvarchar(15)")]
        public string PAN { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string BankAccount { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DOJ { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string PFAccount { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string UAN { get; set; }


        [Required]
        public int AvailableDays { get; set; }


        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaidDays { get; set; }


        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal Salary { get; set; }
    }
}
