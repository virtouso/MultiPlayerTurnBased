using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.General.Types
{
    public class ReturnData<T>
    {

        public T Data;
        public ReturnDataTypes ReturnDataType;
        public int StatusCode;
        public string Message;

        public ReturnData(T data, ReturnDataTypes returnDataType= ReturnDataTypes.Ok, int statusCode=200, string message=null)
        {
            Data = data;
            ReturnDataType = returnDataType;
            StatusCode = statusCode;
            Message = message;
        }
    }
}
