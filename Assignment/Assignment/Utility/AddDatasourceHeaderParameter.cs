using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Assignment.Utility
{
    public class AddDatasourceHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Datasource",
                In = ParameterLocation.Header,
                Required = false, // Ensure this is false
                Description = "Specifies the datasource to use",
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }
    }
}
