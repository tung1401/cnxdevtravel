using CNXDevTravel.Model.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MFEC.SQ.API.Filter
{

    //To be implement to trace log
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            WrapResult(context);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        private void WrapResult(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                var result = context.Result as OkObjectResult;
                result.Value = new ResponseModel<object>()
                {
                    Data = result.Value,
                    Status = "Success"
                };
                context.Result = result;
            }
        }
    }
}
