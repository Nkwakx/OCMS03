using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCMS03.Models.Content;

namespace OCMS03.Models.Mapping
{
    public class PatientMapping
    {
        public PatientMapping(EntityTypeBuilder<Patient> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.Dob).IsRequired();
            entityBuilder.Property(t => t.Idnumber).IsRequired();
            entityBuilder.Property(t => t.Gender).IsRequired();
            entityBuilder.Property(t => t.PhoneNumber).IsRequired();
            entityBuilder.Property(t => t.EmailAddress).IsRequired();
            entityBuilder.Property(t => t.Username).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
            entityBuilder.Property(t => t.ConfirmPassword).IsRequired();
            entityBuilder.Property(t => t.AddressLine2).IsRequired();
            entityBuilder.Property(t => t.SuburbId).IsRequired();
            entityBuilder.Property(t => t.NextOfKinName).IsRequired();
            entityBuilder.Property(t => t.NextOfKinSurname).IsRequired();
            entityBuilder.Property(t => t.NextOfKinNumber).IsRequired();
        }
    }
}
