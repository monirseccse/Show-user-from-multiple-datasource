using Assignment.Model.ResponseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using static Assignment.Constants.AppConstants;

namespace Assignment.ActionFIlters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new Dictionary<string, string>();

                //context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                IEnumerable<ModelError> allErrors = context.ModelState.Values.SelectMany(v => v.Errors);

                foreach (var modelStateKey in context.ModelState.Keys)
                {
                    var modelStateVal = context.ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        errors.Add(char.ToLowerInvariant(modelStateKey[0]) + modelStateKey.Substring(1), error.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Status = ResultStatus.Success.ToString(),
                    Data = errors,
                    Message = "One or more model validation error found."
                });
            }
        }
    }
}
