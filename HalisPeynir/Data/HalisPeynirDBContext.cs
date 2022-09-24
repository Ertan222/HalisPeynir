using HalisPeynir.Models;
using Microsoft.EntityFrameworkCore;

namespace HalisPeynir.Data
{
    public class HalisPeynirDBContext : DbContext
    {
        public HalisPeynirDBContext(DbContextOptions<HalisPeynirDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Servicee> Servicees{ get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }

        public DbSet<Shift> Shifts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                                                    new Product { ProductID = 1, Name = "Ezine Sert 600 gr", Price = 60 },
                                                    new Product { ProductID = 2, Name = "Ezine Sert 350 gr", Price = 20 },
                                                    new Product { ProductID = 3, Name = "Ezine Sert 150 gr", Price = 15 },
                                                    new Product { ProductID = 4, Name = "Ezine Sert 400 gr", Price = 50 }
                                                    );

            modelBuilder.Entity<Servicee>().HasData(
                                                    new Servicee { ServiceeID = 1, Name = "Service 1", Price = 70 },
                                                    new Servicee { ServiceeID = 2, Name = "Service 2", Price = 40 },
                                                    new Servicee { ServiceeID = 3, Name = "Service 3", Price = 55 },
                                                    new Servicee { ServiceeID = 4, Name = "Service 4", Price = 90 }
                                                    );
            modelBuilder.Entity<Gender>().HasData(

                                                      new Gender { GenderID = 1, GenderName = "Female" },
                                                      new Gender { GenderID = 2, GenderName = "Male" },
                                                      new Gender { GenderID = 3, GenderName = "I don't wanna choose" }
                                                      );

            modelBuilder.Entity<Employee>().HasData(

                                          new Employee { EmployeeID = 1, DOB = Convert.ToDateTime("01.05.2001"), GenderID = 1, NameAndSecName = "Bob", Surname = "Taylor", JobTitleID = 1, ShiftID = 1 , WorkStatus = true},
                                          new Employee { EmployeeID = 2, DOB = Convert.ToDateTime("03.02.2002"), GenderID = 2, NameAndSecName = "Michael", Surname = "Blanch", JobTitleID = 2, ShiftID = 2 , WorkStatus = false },
                                          new Employee { EmployeeID = 3, DOB = Convert.ToDateTime("12.10.2006"), GenderID = 3, NameAndSecName = "Leyla", Surname = "Green" , JobTitleID = 3 , ShiftID = 3 , WorkStatus = true }
                                          );

            modelBuilder.Entity<JobTitle>().HasData(

                                          new JobTitle { JobTitleID= 1,JobTitleName = "Techinician" },
                                          new JobTitle { JobTitleID= 2, JobTitleName = "Master" },
                                          new JobTitle { JobTitleID= 3, JobTitleName = "Director" }


                                          );

            modelBuilder.Entity<Shift>().HasData(

                                          new Shift { ShiftID = 1, ShiftName = "Morning" },
                                          new Shift { ShiftID = 2, ShiftName = "Evening" },
                                          new Shift { ShiftID = 3, ShiftName = "Night" }



                                          );

        }


    }
}
