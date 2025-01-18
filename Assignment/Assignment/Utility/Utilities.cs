using Assignment.Model.ResponseDto;
using static Assignment.Constants.AppConstants;
using System.Net;

namespace Assignment.Utility
{
    public static class Utilities
    {
        public static ResponseModel GetSuccessMsg(string message, object? data = null)
        {
            return new ResponseModel
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
                Status = ResultStatus.Success.ToString(),
                Message = message,
                Data = data
            };
        }
        public static ResponseModel GetAlreadyExistMsg(string message)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.Conflict,
                Status = ResultStatus.Canceled.ToString(),
                Message = message,
                Data = null
            };
        }
        public static ResponseModel GetErrorMsg(string message)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                Status = String.IsNullOrEmpty(message) ? ResultStatus.Canceled.ToString() : message,
                Message = message
            };
        }

        public static ResponseModel GetInternalServerErrorMsg(string message)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Status = ResultStatus.Error.ToString(),
                Message = message,
                Data = null
            };
        }
        public static ResponseModel GetNoDataFoundMsg(string message)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                Status = ResultStatus.Error.ToString(),
                Message = message,
                Data = null
            };
        }

        public static ResponseModel GetValidationFailedMsg(string message)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                Status = ResultStatus.Canceled.ToString(),
                Message = String.IsNullOrEmpty(message) ? CommonMessage.ValidationFailed.ToString() : message,
                Data = null
            };
        }
        public static ResponseModel GetValidationFailedMsg(List<string> messageList)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                Status = ResultStatus.Canceled.ToString(),
                Message = CommonMessage.ValidationFailed.ToString(),
                Data = messageList
            };
        }
    }
}
