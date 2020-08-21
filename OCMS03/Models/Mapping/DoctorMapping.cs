﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCMS03.Models.Content;

namespace OCMS03.Models.Mapping
{
    public class DoctorMapping
    {
        public DoctorMapping(EntityTypeBuilder<Doctor> entityBuilder)
        {
            entityBuilder.HasKey(t => t.StaffNumber);
            entityBuilder.Property(t => t.ClinicId).IsRequired();
            entityBuilder.Property(t => t.Specialization).IsRequired();
            entityBuilder.Property(t => t.DepartmentId).IsRequired();
            entityBuilder.Property(t => t.HospitalId).IsRequired();
            entityBuilder.Property(t => t.ProvinceId).IsRequired();
            entityBuilder.Property(t => t.DistrictId).IsRequired();
        }
    }
}
