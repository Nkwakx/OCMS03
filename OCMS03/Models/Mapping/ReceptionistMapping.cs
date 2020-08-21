using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OCMS03.Models.Content;

namespace OCMS03.Models.Mapping
{
    public class ReceptionistMapping
    {
        public ReceptionistMapping(EntityTypeBuilder<Receptionist> entityBuilder)
        {
            entityBuilder.HasKey(t => t.StaffNumber);
            entityBuilder.Property(t => t.ReceptionistType).IsRequired();
            entityBuilder.Property(t => t.DepartmentId).IsRequired();
        }
    }
}
