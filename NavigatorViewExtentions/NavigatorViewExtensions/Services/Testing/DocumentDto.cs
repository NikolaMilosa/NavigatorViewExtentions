using System;

namespace NavigatorViewExtensions.Services.Testing
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public int DocumentDefinitionId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastUpdate { get; set; }
        public char Status { get; set; }
    }
}