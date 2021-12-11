using System;

namespace PastryShopApi.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string IdEntity { get; set; }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string idEntity, string message) : base(message)
        {
            IdEntity = idEntity;
        }

        public EntityNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
