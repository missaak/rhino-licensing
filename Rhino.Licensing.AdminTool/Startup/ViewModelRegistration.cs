using System;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Rhino.Licensing.AdminTool.Extensions;
using Rhino.Licensing.AdminTool.ViewModels;

namespace Rhino.Licensing.AdminTool.Startup
{
    public class ViewModelRegistration : IRegistration
    {
        public void Register(IKernel kernel)
        {
            kernel.Register(AllTypes.FromAssemblyContaining<ViewModelRegistration>()
                                    .Where(t => t.Namespace.EndsWith("Rhino.Licensing.AdminTool.ViewModels"))
                                    .WithService.FirstInterfaceOnClass()
                                    .Configure(c => c.LifeStyle.Transient)
                                    .ConfigureFor<ShellViewModel>(c => c.LifeStyle.Singleton));
        }
    }
}