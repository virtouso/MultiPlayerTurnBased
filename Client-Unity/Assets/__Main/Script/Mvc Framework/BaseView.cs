using UnityEngine;

namespace Mvc
{
    
    public class BaseView<T, M> : MonoBehaviour 
        where T : BaseModel 
        where M : BaseController<T>, new()
    {
        public T Model;
        protected M Controller;

        public virtual void Awake()
        {
            Controller = new  M();
            Controller.Setup(Model);
        }
    }
}