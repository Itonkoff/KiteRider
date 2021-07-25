using Database.Models.Payroll;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts {
    public class PayRollDatabaseContext : DbContext {
        public DbSet<BankDetail> BankDetails;
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePayroll> EmployeePayrolls { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<PayrollValue> PayrollValues { get; set; }
        public DbSet<PaySpecification> PaySpecifications { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Spouse> Spouses { get; set; }

        // public PayRollDatabaseContext()
        // {
        //     
        // }

        public PayRollDatabaseContext(DbContextOptions<PayRollDatabaseContext> options) : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=localhost;Database=traburu;Trusted_Connection=True;Enlist=False;");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankDetail>(entity =>
            {
                entity.ToTable("bank_details");

                entity.Property(e => e.BankDetailId).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Branch).HasColumnName("branch_code");

                entity.Property(e => e.AccountNumber).HasColumnName("account_number");

                entity.Property(e => e.SplitPercentage).HasColumnName("split").HasDefaultValue(100);

                entity.Property(e => e.EmployeeId).HasColumnName("account_holder");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.BankDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Deduction>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("d_employee");

                entity.Property(e => e.PayrollId).HasColumnName("d_payroll");

                entity.Property(e => e.PaySpecificationId).HasColumnName("d_pay_spec");

                entity.HasOne(d => d.AssociatedPayroll)
                    .WithMany(p => p.Deductions)
                    .HasForeignKey(d => new {d.EmployeeId, d.PayrollId, d.PaySpecificationId})
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Earning>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("e_employee");

                entity.Property(e => e.PayrollId).HasColumnName("e_payroll");

                entity.Property(e => e.PaySpecificationId).HasColumnName("e_pay_spec");

                entity.HasOne(d => d.AssociatedPayroll)
                    .WithMany(p => p.Earnings)
                    .HasForeignKey(d => new {d.EmployeeId, d.PayrollId, d.PaySpecificationId})
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.DateHired).HasColumnName("date_hired");

                entity.Property(e => e.EmploymentStatus).HasColumnName("status");
            });

            modelBuilder.Entity<EmployeePayroll>(entity =>
            {
                entity.ToTable("employee_payroll");

                entity.HasKey(e => new {e.EmployeeId, e.PayrollId, e.PaySpecificationId});

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.PayrollId).HasColumnName("payroll_id");

                entity.Property(e => e.PaySpecificationId).HasColumnName("pay_spec_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PayRolls)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Payroll)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PayrollId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.PaySpecification)
                    .WithOne(p => p.Payroll)
                    .HasForeignKey<EmployeePayroll>(d => d.PaySpecificationId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.ToTable("organisations");

                entity.Property(e => e.OrganisationId).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.ToTable("payrolls");

                entity.Property(e => e.PayrollId).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.PayRunDate).HasColumnName("pay_date");

                entity.Property(e => e.LastRunDate).HasColumnName("last_run");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.OrganisationId).HasColumnName("organisation");

                entity.Property(e => e.SoftDeleted).HasColumnName("deleted").HasDefaultValue(false);

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.PayRolls)
                    .HasForeignKey(d => d.OrganisationId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasQueryFilter(e => !e.SoftDeleted);
            });

            modelBuilder.Entity<PayrollValue>(entity =>
            {
                entity.ToTable("pay_values");

                entity.Property(e => e.PayrollValueId).HasColumnName("id");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EmployeeContribution).HasColumnName("e_contribution");

                entity.Property(e => e.OrganisationContribution).HasColumnName("o_contribution");

                entity.Property(e => e.Reference).HasColumnName("reference");

                entity.HasDiscriminator<string>("type")
                    .HasValue<Deduction>("d")
                    .HasValue<Earning>("e");
            });

            modelBuilder.Entity<PaySpecification>(entity =>
            {
                entity.ToTable("pay_specs");

                entity.Property(e => e.PaySpecificationId).HasColumnName("id");

                entity.Property(e => e.Period).HasColumnName("period");

                entity.Property(e => e.BaseAmount).HasColumnName("base_amt");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.PersonId).HasColumnName("id");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Names).HasColumnName("names");

                entity.Property(e => e.DateOfBirth).HasColumnName("dob");

                entity.Property(e => e.NationalId).HasColumnName("national_id");

                entity.Property(e => e.PassportNumber).HasColumnName("passport_id");

                entity.Property(e => e.MaritalStatus).HasColumnName("marital_status");

                entity.Property(e => e.HomeTelephone).HasColumnName("home_tel");

                entity.Property(e => e.CellNumber).HasColumnName("cell");

                entity.Property(e => e.EmailAddress).HasColumnName("email_address");

                entity.Property(e => e.HomeAddress).HasColumnName("home_address");

                entity.Property(e => e.PostalAddress).HasColumnName("postal_address");

                entity.HasDiscriminator<string>("type")
                    .HasValue<Employee>("e");
            });

            modelBuilder.Entity<Spouse>(entity =>
            {
                entity.ToTable("spouses");

                entity.Property(e => e.SpouseId).HasColumnName("id");

                entity.Property(e => e.Names).HasColumnName("names");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.NationalId).HasColumnName("national_id");

                entity.Property(e => e.EmployeeSpouseId).HasColumnName("employee");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Spouses)
                    .HasForeignKey(d => d.EmployeeSpouseId)
                    .OnDelete(DeleteBehavior.NoAction);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}