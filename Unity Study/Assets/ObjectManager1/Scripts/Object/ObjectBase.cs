using UnityEngine;

namespace ObjectManager1
{
    public class ObjectBase : MonoBehaviour
    {
        protected int id = (int)ObjectId.None;

        public virtual void Init()
        {

        }
        public virtual void DoAction()
        {

        }

        public int GetId()
        {
            return id;
        }
    }

}