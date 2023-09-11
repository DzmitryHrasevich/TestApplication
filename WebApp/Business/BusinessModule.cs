using Autofac;
using WebApp.Business.Contracts;
using WebApp.Business.Services;

namespace WebApp.Business;

public class BusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<OrganisationService>().As<IOrganisationService>();
        builder.RegisterType<EmployeeService>().As<IEmployeeService>();
    }
}