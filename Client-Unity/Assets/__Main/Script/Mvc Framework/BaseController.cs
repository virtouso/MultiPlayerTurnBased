

namespace Mvc
{
    
    public class BaseController<T> where T : BaseModel
    {

        protected T Model;

        public virtual void Setup(T model)
        {
            Model = model;
        }

    }
}