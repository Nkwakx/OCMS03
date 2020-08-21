using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OCMS03.Models.Content;
using OCMS03.Models.Mapping;
using OCMS03.Models.ViewModels;

namespace OCMS03.Data
{
    public partial class OCMS03_TheCollectiveContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public OCMS03_TheCollectiveContext()
        {
        }

        public OCMS03_TheCollectiveContext(DbContextOptions<OCMS03_TheCollectiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> tblAppointment { get; set; }
        public virtual DbSet<AppointmentNotes> tblAppointmentNotes { get; set; }
        public virtual DbSet<City> tblCity { get; set; }
        public virtual DbSet<Clinic> tblClinic { get; set; }
        public virtual DbSet<Department> tblDepartment { get; set; }
        public virtual DbSet<Diagnosis> tblDiagnosis { get; set; }
        public virtual DbSet<District> tblDistrict { get; set; }
        public virtual DbSet<Doctor> tblDoctor { get; set; }
        public virtual DbSet<Hospital> tblHospital { get; set; }
        public virtual DbSet<Laboratorist> tblLaboratorist { get; set; }
        public virtual DbSet<Nurse> tblNurse { get; set; }
        public virtual DbSet<Patient> tblPatient { get; set; }
        public virtual DbSet<Pharmacist> tblPharmacist { get; set; }
        public virtual DbSet<Prescription> tblPrescription { get; set; }
        public virtual DbSet<Province> tblProvince { get; set; }
        public virtual DbSet<Receptionist> tblReceptionist { get; set; }
        public virtual DbSet<Suburb> tblSuburb { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DoctorMapping(modelBuilder.Entity<Doctor>());
            new NurseMapping(modelBuilder.Entity<Nurse>());
            new ReceptionistMapping(modelBuilder.Entity<Receptionist>());
            new PharmasistMapping(modelBuilder.Entity<Pharmacist>());
            new LaboratoristMapping(modelBuilder.Entity<Laboratorist>());
            new AppointmentMapping(modelBuilder.Entity<Appointment>());
            new PatientMapping(modelBuilder.Entity<Patient>());


            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("tblAppointment");

                entity.Property(e => e.AddedDate).HasColumnType("date");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.AppointmentDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.TblAppointment)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAppointment_tblClinic");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.TblAppointment)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_tblAppointment_tblHospital");

                entity.HasOne(d => d.StaffNumberNavigation)
                    .WithMany(p => p.TblAppointment)
                    .HasForeignKey(d => d.StaffNumber)
                    .HasConstraintName("FK_tblAppointment_tblDoctor");

                entity.HasOne(d => d.StaffNumber1)
                    .WithMany(p => p.TblAppointment)
                    .HasForeignKey(d => d.StaffNumber)
                    .HasConstraintName("FK_tblAppointment_tblNurse");

                entity.HasOne(d => d.StaffNumber2)
                    .WithMany(p => p.TblAppointment)
                    .HasForeignKey(d => d.StaffNumber)
                    .HasConstraintName("FK_tblAppointment_tblReceptionist");
            });

            modelBuilder.Entity<AppointmentNotes>(entity =>
            {
                entity.HasKey(e => e.AppointmentNotesId);

                entity.ToTable("tblAppointmentNotes");

                entity.Property(e => e.NotesComment).IsRequired();

                entity.HasOne(d => d.DiagnosisCodeNavigation)
                    .WithMany(p => p.TblAppointmentNotes)
                    .HasForeignKey(d => d.DiagnosisCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAppointmentNotes_tblDiagnosis");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblAppointmentNotes)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAppointmentNotes_tblPatient");

                entity.HasOne(d => d.StaffNumberNavigation)
                    .WithMany(p => p.TblAppointmentNotes)
                    .HasForeignKey(d => d.StaffNumber)
                    .HasConstraintName("FK_tblAppointmentNotes_tblDoctor1");

                entity.HasOne(d => d.StaffNumber1)
                    .WithMany(p => p.TblAppointmentNotes)
                    .HasForeignKey(d => d.StaffNumber)
                    .HasConstraintName("FK_tblAppointmentNotes_tblNurse");
            });

            modelBuilder.Entity<City>(entity =>
                        {
                            entity.HasKey(e => e.CityId);

                            entity.ToTable("tblCity");

                            entity.Property(e => e.CityId).ValueGeneratedOnAdd();

                            entity.Property(e => e.CityName)
                                                .IsRequired()
                                                .HasMaxLength(50);

                            entity.HasOne(d => d.District)
                                               .WithMany(p => p.City)
                                               .HasForeignKey(d => d.DistrictId)
                                               .OnDelete(DeleteBehavior.ClientSetNull)
                                               .HasConstraintName("FK_tblCity_tblDistrict");
                        });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.ClinicId);

                entity.ToTable("tblClinic");

                entity.Property(e => e.ClinicName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblClinic)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblClinic_tblCity");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("tblDepartment");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.HasKey(e => e.DiagnosisCode);

                entity.ToTable("tblDiagnosis");

                entity.Property(e => e.DiagnosisComment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DiagnosisDescription)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PK_tblRegion");

                entity.ToTable("tblDistrict");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblDistrict)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDistrict_tblProvince");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.StaffNumber)
                    .HasName("PK_tblDoctor_1");

                entity.ToTable("tblDoctor");

                entity.Property(e => e.AddedDate).HasColumnType("date");

                entity.Property(e => e.IPAddress)
                   .IsRequired()
                   .HasColumnName("IPAddress")
                   .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfKinNumber)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.NextOfKinSurname)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.NextOfName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.TblDoctor)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("FK_tblDoctor_tblClinic");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblDoctor)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tblDoctor_tblDepartment");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.TblDoctor)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_tblDoctor_tblHospital");

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.TblDoctor)
                    .HasForeignKey(d => d.SuburbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDoctor_tblSuburb");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblDoctor)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDoctor_tblProvince");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.TblDoctor)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDoctor_tblDistrict");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblDoctor)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tblDoctor_tblCity");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.HospitalId);

                entity.ToTable("tblHospital");

                entity.Property(e => e.HospitalName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblHospital)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblHospital_tblCity");
            });

            modelBuilder.Entity<Laboratorist>(entity =>
            {
                entity.HasKey(e => e.StaffNumber)
                    .HasName("PK_tblLaboratorist_1");

                entity.ToTable("tblLaboratorist");
                entity.Property(e => e.AddedDate).HasColumnType("date");

                entity.Property(e => e.IPAddress)
                   .IsRequired()
                   .HasColumnName("IPAddress")
                   .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfKinNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.NextOfKinSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.PostalCode)
                   .IsRequired()
                   .HasMaxLength(10)
                   .IsFixedLength();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblLaboratorist)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tblLaboratorist_tblDepartment");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.TblLaboratorist)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLaboratorist_tblHospital");

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.TblLaboratorist)
                    .HasForeignKey(d => d.SuburbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLaboratorist_tblSuburb");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblLaboratorist)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLaboratorist_tblProvince");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.TblLaboratorist)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLaboratorist_tblDistrict");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblLaboratorist)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblLaboratorist_tblCity");


            });

            modelBuilder.Entity<Nurse>(entity =>
            {
                entity.HasKey(e => e.StaffNumber)
                    .HasName("PK_tblNurse_1");

                entity.ToTable("tblNurse");
                entity.Property(e => e.AddedDate).HasColumnType("date");

                entity.Property(e => e.IPAddress)
                   .IsRequired()
                   .HasColumnName("IPAddress")
                   .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfKinNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.NextOfKinSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NurseType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.PostalCode)
                   .IsRequired()
                   .HasMaxLength(10)
                   .IsFixedLength();

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.TblNurse)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("FK_tblNurse_tblClinic");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblNurse)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tblNurse_tblDepartment");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.TblNurse)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_tblNurse_tblHospital");

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.TblNurse)
                    .HasForeignKey(d => d.SuburbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNurse_tblSuburb");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblNurse)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNurse_tblProvince");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.TblNurse)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNurse_tblDistrict");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblNurse)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblNurse_tblCity");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("tblPatient");

                entity.Property(e => e.AddedDate).HasColumnType("date");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.AddressLine2).HasMaxLength(250);

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.NextOfKinName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfKinNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.NextOfKinSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.PostalCode)
                   .IsRequired()
                   .HasMaxLength(10)
                   .IsFixedLength();

                entity.HasOne(d => d.StaffNumberNavigation)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(d => d.StaffNumber)
                    .HasConstraintName("FK_tblPatient_tblDoctor");

                entity.HasOne(d => d.StaffNumber1)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(d => d.StaffNumber)
                    .HasConstraintName("FK_tblPatient_tblReceptionist");

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(d => d.SuburbId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPatient_tblSuburb");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPatient_tblProvince");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPatient_tblDistrict");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPatient_tblCity");
            });

            modelBuilder.Entity<Pharmacist>(entity =>
            {
                entity.HasKey(e => e.StaffNumber)
                    .HasName("PK_tblPharmasist_1");

                entity.ToTable("tblPharmacist");
                entity.Property(e => e.AddedDate).HasColumnType("date");

                entity.Property(e => e.IPAddress)
                   .IsRequired()
                   .HasColumnName("IPAddress")
                   .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(500);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfKinNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.NextOfKinSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.PostalCode)
                   .IsRequired()
                   .HasMaxLength(10)
                   .IsFixedLength();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblPharmacist)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tblPharmasist_tblDepartment");

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.TblPharmacist)
                    .HasForeignKey(d => d.SuburbId)
                    .HasConstraintName("FK_tblPharmasist_tblSuburb");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblPharmacist)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_tblPharmasist_tblProvince");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.TblPharmacist)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_tblPharmasist_tblDistrict");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblPharmacist)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tblPharmasist_tblCity");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId);

                entity.ToTable("tblPrescription");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblPrescription)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPrescription_tblPatient");

                entity.HasOne(d => d.StaffNumberNavigation)
                    .WithMany(p => p.TblPrescription)
                    .HasForeignKey(d => d.StaffNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPrescription_tblDoctor");

                entity.HasOne(d => d.StaffNumber1)
                    .WithMany(p => p.TblPrescription)
                    .HasForeignKey(d => d.StaffNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPrescription_tblNurse");

                entity.HasOne(d => d.StaffNumber2)
                    .WithMany(p => p.TblPrescription)
                    .HasForeignKey(d => d.StaffNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPrescription_tblPharmasist");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ProvinceId);

                entity.ToTable("tblProvince");

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Receptionist>(entity =>
            {
                entity.HasKey(e => e.StaffNumber)
                    .HasName("PK_tblReceptionist_1");

                entity.ToTable("tblReceptionist");
                entity.Property(e => e.AddedDate).HasColumnType("date");

                entity.Property(e => e.IPAddress)
                   .IsRequired()
                   .HasColumnName("IPAddress")
                   .HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.StaffNumber).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AddressLine2)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Idnumber)
                    .IsRequired()
                    .HasColumnName("IDNumber")
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfKinNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.NextOfKinSurname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NextOfName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsFixedLength();

                entity.Property(e => e.ReceptionistType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                   .IsRequired()
                   .HasMaxLength(10)
                   .IsFixedLength();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblReceptionist)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tblReceptionist_tblDepartment");

                entity.HasOne(d => d.Suburb)
                    .WithMany(p => p.TblReceptionist)
                    .HasForeignKey(d => d.SuburbId)
                    .HasConstraintName("FK_tblReceptionist_tblSuburb");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.TblReceptionist)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_tblReceptionist_tblProvince");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.TblReceptionist)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_tblReceptionist_tblDistrict");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblReceptionist)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tblReceptionist_tblCity");
            });

            modelBuilder.Entity<Suburb>(entity =>
            {
                entity.HasKey(e => e.SuburbId);

                entity.ToTable("tblSuburb");

                entity.Property(e => e.SuburbName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblSuburb)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSuburb_tblCity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    new DoctorMapping(modelBuilder.Entity<Doctor>());
        //    new NurseMapping(modelBuilder.Entity<Nurse>());
        //    new ReceptionistMapping(modelBuilder.Entity<Receptionist>());
        //    new PharmasistMapping(modelBuilder.Entity<Pharmasist>());
        //    new LaboratoristMapping(modelBuilder.Entity<Laboratorist>());
        //    new AppointmentMapping(modelBuilder.Entity<Appointment>());
        //    new PatientMapping(modelBuilder.Entity<Patient>());
        //}
