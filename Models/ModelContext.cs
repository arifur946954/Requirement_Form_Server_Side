using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RequirementForm.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accademicqulification> Accademicqulifications { get; set; } = null!;
        public virtual DbSet<Cvtable> Cvtables { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Division> Divisions { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Experience> Experiences { get; set; } = null!;
        public virtual DbSet<Imagetbl> Imagetbls { get; set; } = null!;
        public virtual DbSet<Parmanentaddress> Parmanentaddresses { get; set; } = null!;
        public virtual DbSet<Presentaddress> Presentaddresses { get; set; } = null!;
        public virtual DbSet<Register> Registers { get; set; } = null!;
        public virtual DbSet<Thana> Thanas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User ID=system;Password=oracleDB123;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Accademicqulification>(entity =>
            {
                entity.HasKey(e => e.AccQlfId);

                entity.ToTable("ACCADEMICQULIFICATION");

                entity.Property(e => e.AccQlfId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ACC_QLF_ID");

                entity.Property(e => e.Board)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BOARD");

                entity.Property(e => e.Degree)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Instution)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INSTUTION");

                entity.Property(e => e.Major)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAJOR");

                entity.Property(e => e.Passingyear)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PASSINGYEAR");

                entity.Property(e => e.Result)
                    .HasColumnType("NUMBER(4,2)")
                    .HasColumnName("RESULT");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Accademicqulifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_ACCADEMICQULIFICATION_EMPLOYEE_ID");
            });

            modelBuilder.Entity<Cvtable>(entity =>
            {
                entity.HasKey(e => e.CvId);

                entity.ToTable("CVTABLE");

                entity.Property(e => e.CvId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CV_ID");

                entity.Property(e => e.Cv)
                    .HasColumnType("BLOB")
                    .HasColumnName("CV");

                entity.Property(e => e.EmpId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMP_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.DisId)
                    .HasName("SYS_C008381");

                entity.ToTable("DISTRICT");

                entity.Property(e => e.DisId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DIS_ID");

                entity.Property(e => e.BnName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BN_NAME");

                entity.Property(e => e.DivId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DIV_ID");

                entity.Property(e => e.Ion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ION")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Lat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAT")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Div)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DivId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRICT_DIV_ID");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(e => e.DivId)
                    .HasName("SYS_C008371");

                entity.ToTable("DIVISION");

                entity.Property(e => e.DivId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DIV_ID");

                entity.Property(e => e.BnName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BN_NAME");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Appliedby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLIEDBY");

                entity.Property(e => e.Appliedpost)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPLIEDPOST");

                entity.Property(e => e.Birthplace)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BIRTHPLACE");

                entity.Property(e => e.Bloodgroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BLOODGROUP");

                entity.Property(e => e.Dateofbirthd)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTHD");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Expectedselery)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXPECTEDSELERY");

                entity.Property(e => e.Fathername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FATHERNAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Interviewdate)
                    .HasColumnType("DATE")
                    .HasColumnName("INTERVIEWDATE");

                entity.Property(e => e.Maritalstatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MARITALSTATUS");

                entity.Property(e => e.Mobilenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILENUMBER");

                entity.Property(e => e.Mothername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOTHERNAME");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Nid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NID");

                entity.Property(e => e.Probablyjoiningdate)
                    .HasColumnType("DATE")
                    .HasColumnName("PROBABLYJOININGDATE");

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.Spousename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SPOUSENAME");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(e => e.ExpId);

                entity.ToTable("EXPERIENCE");

                entity.Property(e => e.ExpId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXP_ID");

                entity.Property(e => e.Defaultproduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULTPRODUCT");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Joblocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOBLOCATION");

                entity.Property(e => e.Organization)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZATION");

                entity.Property(e => e.Post)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("POST");

                entity.Property(e => e.Reportingto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORTINGTO");

                entity.Property(e => e.Selery)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("SELERY");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EXPERIENCE_EMPLOYEE_ID");
            });

            modelBuilder.Entity<Imagetbl>(entity =>
            {
                entity.HasKey(e => e.ImgId);

                entity.ToTable("IMAGETBL");

                entity.Property(e => e.ImgId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMG_ID");

                entity.Property(e => e.EmpId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMP_ID");

                entity.Property(e => e.Image)
                    .HasColumnType("BLOB")
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Parmanentaddress>(entity =>
            {
                entity.HasKey(e => e.ParmanentAddId);

                entity.ToTable("PARMANENTADDRESS");

                entity.Property(e => e.ParmanentAddId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PARMANENT_ADD_ID");

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.Division)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Postoffice)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("POSTOFFICE");

                entity.Property(e => e.Thana)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("THANA");

                entity.Property(e => e.Village)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VILLAGE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Parmanentaddresses)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_PARMANENTADDRESS_EMPLOYEE_ID");
            });

            modelBuilder.Entity<Presentaddress>(entity =>
            {
                entity.HasKey(e => e.PresentAddId);

                entity.ToTable("PRESENTADDRESS");

                entity.Property(e => e.PresentAddId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRESENT_ADD_ID");

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.Division)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Postoffice)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("POSTOFFICE");

                entity.Property(e => e.Thana)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("THANA");

                entity.Property(e => e.Village)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VILLAGE");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Presentaddresses)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_PRESENTADDRESS_EMPLOYEE_ID");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.ToTable("REGISTER");

                entity.Property(e => e.RegisterId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REGISTER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Mobilenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOBILENUMBER");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Refreshtoken)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFRESHTOKEN");

                entity.Property(e => e.Refreshtokenexpirytime)
                    .HasColumnType("DATE")
                    .HasColumnName("REFRESHTOKENEXPIRYTIME");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Token)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TOKEN");
            });

            modelBuilder.Entity<Thana>(entity =>
            {
                entity.ToTable("THANA");

                entity.Property(e => e.ThanaId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("THANA_ID");

                entity.Property(e => e.BnName)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("BN_NAME");

                entity.Property(e => e.DisId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("DIS_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Url)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Dis)
                    .WithMany(p => p.Thanas)
                    .HasForeignKey(d => d.DisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DISTRICT_THANA_ID");
            });

            modelBuilder.HasSequence("ADDRESS_ID");

            modelBuilder.HasSequence("LOGMNR_DIDS$");

            modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");

            modelBuilder.HasSequence("LOGMNR_SEQ$");

            modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");

            modelBuilder.HasSequence("PRESENT_ADDRESS_ID");

            modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

            modelBuilder.HasSequence("TEACHER_ID_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
