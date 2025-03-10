﻿namespace TodoList.Di.Modules
{
    using Autofac;

    using TodoList.Di.Extensions;

    public class ApiDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Data.AssemblyRunner.Run();
            Services.AssemblyRunner.Run();

            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .OrderByDescending(a => a.FullName)
                .ToArray();

            builder.RegisterServices(assemblies);
            builder.RegisterRepositories(assemblies);
        }
    }
}
