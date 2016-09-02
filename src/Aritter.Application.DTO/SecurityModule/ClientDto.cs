using System;

namespace Aritter.Application.DTO.SecurityModule
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid UID { get; set; }
        public object AllowedOrigin { get; set; }
    }
}