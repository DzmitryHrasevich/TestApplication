using Autofac;
using WebApp.Data.Contracts;
using WebApp.Data.Repositories;

namespace WebApp.Data;

public class DataModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<OrganisationRepository>().As<IOrganisationRepository>();
        builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
    }
}