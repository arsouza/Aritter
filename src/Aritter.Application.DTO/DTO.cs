using System;

namespace Aritter.Application.DTO
{
    public abstract class DTO
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }
    }
}
