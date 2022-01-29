
using SharedModels;
using SharedModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedRepository
{
    public interface IMongoRepository
    {
        

    
            public  ReturnData<string> FindPlayerId(PlayerAuthenticationInput input);
        



    }
}
