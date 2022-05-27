using System.ComponentModel.DataAnnotations;

namespace MyDocApp.Models
{
    public class MyDocModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        [System.ComponentModel.DisplayName("Patient's Name:")]
         public string PatientsName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Street { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [System.ComponentModel.DisplayName("Doctor's Name:")]
        public string DoctorsName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [System.ComponentModel.DisplayName("Appointment Data:")]
        public string AppointmentData { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        [System.ComponentModel.DisplayName("Phone Number:")]
        public int PhoneNumber { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.PostalCode)]
        [System.ComponentModel.DisplayName("ZIP Code:")]
        public int ZipCode { get; set; }



        [System.ComponentModel.DisplayName("Pain Level:")]
        public int PainLevel { get; set; }

        [System.ComponentModel.DisplayName("JPMG:")]
        public int JPMGnumber { get; set; }


        [Required]
        [StringLength(500, MinimumLength = 4)]
        [System.ComponentModel.DisplayName("About Patient:")]
        public string AboutPatient { get; set; }

        
        public decimal PatientNetWorth { get; set; }

        [DataType(DataType.Duration)]
        [System.ComponentModel.DisplayName("Treatment Duration")]
        public int TreatmentDuration { get; set; }

    }
}
