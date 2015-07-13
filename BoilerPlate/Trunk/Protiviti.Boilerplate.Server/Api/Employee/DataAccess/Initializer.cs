using System.Collections.Generic;
using Repository.Pattern.DataContext;
using Repository.Pattern.UnitOfWork;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;

namespace Protiviti.Boilerplate.Server.Api.Employee
{
    public class EmployeeDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeContext>
    {
        readonly IRepositoryProvider _repositoryProvider = new RepositoryProvider(new RepositoryFactories());
        protected override void Seed(EmployeeContext context)
        {


            var divisions = new List<Division>
            {
                new Division {Name="PSS"},
                new Division {Name="RTS"},
            };


            var designations = new List<Designation>
            {
                new Designation{DesignationName="Director", IsActive=true},
                new Designation{DesignationName="Manager", IsActive=true},
                new Designation{DesignationName="Consultant", IsActive=true},
            };

            var employees = new List<Employee>
            {
                new Employee{FirstName="Ajay",LastName="Singh", Location="India" ,DivisionID=1,DesignationID=2,IsActive=true},
                new Employee{FirstName="Alok",LastName="Gupta", Location="Chicago",DivisionID=1,DesignationID=2,IsActive=true},
                new Employee{FirstName="Stewart",LastName="Armbrecht", Location="Chicago",DivisionID=1,DesignationID=1,IsActive=true},
                new Employee{FirstName="Douglas",LastName="Sellers", Location="Chicago",DivisionID=1,DesignationID=1,IsActive=true},
                new Employee{FirstName="Tejaswi",LastName="Aneja", Location="India",DivisionID=1,DesignationID=1,IsActive=true},

            };

            using (IDataContextAsync ctx = new EmployeeContext())
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(ctx, _repositoryProvider))
                {
                    unitOfWork.Repository<Division>().InsertRange(divisions);
                    unitOfWork.SaveChanges();
                }
            }
            using (IDataContextAsync ctx = new EmployeeContext())
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(ctx, _repositoryProvider))
                {
                    unitOfWork.Repository<Designation>().InsertRange(designations);
                    unitOfWork.SaveChanges();
                }
            }
            using (IDataContextAsync ctx = new EmployeeContext())
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(ctx, _repositoryProvider))
                {
                    unitOfWork.Repository<Employee>().InsertRange(employees);
                    unitOfWork.SaveChanges();
                }
            }
        }
    }

    
}