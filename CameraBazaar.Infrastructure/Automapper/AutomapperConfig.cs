namespace CameraBazaar.Infrastructure.Automapper
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AutomapperConfig
    {
		private const string MappingProfileSuffix = "MappingProfile";

		public static void Init(IMapperConfigurationExpression cfg)
		{
			var mappingProfiles = new List<Type>();

			var assemblies = AppDomain.CurrentDomain.GetAssemblies();

			foreach (var a in assemblies)
			{
				mappingProfiles.AddRange(a.GetTypes()
					.Where(t => t.IsClass 
									&& t.IsSubclassOf(typeof(Profile))
									&& t.Name.EndsWith(MappingProfileSuffix)));
			}

			foreach (var profile in mappingProfiles)
			{
				cfg.AddProfile(profile);
			}
		}
    }
}
