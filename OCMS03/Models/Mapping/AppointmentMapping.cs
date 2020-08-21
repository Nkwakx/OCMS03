using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCMS03.Models.Content;

namespace OCMS03.Models.Mapping
{
    public class AppointmentMapping
    {
        public AppointmentMapping(EntityTypeBuilder<Appointment> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.PatientId).IsRequired();
            entityBuilder.Property(t => t.StartTime).IsRequired();
            entityBuilder.Property(t => t.EndTime).IsRequired();
            entityBuilder.Property(t => t.Available).IsRequired();
            entityBuilder.Property(t => t.Arrived).IsRequired();
            entityBuilder.Property(t => t.AppointmentDescription).IsRequired();
            entityBuilder.Property(t => t.PatientId).IsRequired();
            entityBuilder.Property(t => t.HospitalId).IsRequired();
            entityBuilder.Property(t => t.ClinicId).IsRequired();
            entityBuilder.Property(t => t.StaffNumber).IsRequired();
        }
    }
}
