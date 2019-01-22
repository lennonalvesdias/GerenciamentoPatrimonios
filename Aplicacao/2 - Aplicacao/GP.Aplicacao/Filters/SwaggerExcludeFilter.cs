using GP.Aplicacao.Atributos;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace GP.Aplicacao.Filters
{
    public class SwaggerExcludeFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            var excludedProperties = context.SystemType.GetProperties().Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);
            foreach (PropertyInfo excludedProperty in excludedProperties)
            {
                if (schema.Properties.ContainsKey(excludedProperty.Name))
                {
                    schema.Properties.Remove(excludedProperty.Name);
                }
            }
        }
    }
}