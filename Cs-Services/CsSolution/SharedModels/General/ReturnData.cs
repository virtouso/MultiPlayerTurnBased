using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.General
{
    public class ReturnData<T>
    {

        public T Data;
        public ReturnDataTypes ReturnDataType;

        public ReturnData(T data, ReturnDataTypes returnDataType)
        {
            Data = data;
            ReturnDataType = returnDataType;
        }
    }
}
