using System;

namespace GP.Aplicacao.Atributos
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : Attribute
    {
    }
}
