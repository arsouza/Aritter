using Ritter.Domain;
using Ritter.Samples.Domain.Aggregates.Employees;

namespace Ritter.Samples.Domain.Aggregates.People
{
    public class Document : Entity
    {
        public int EmployeeId { get; private set; }
        public DocumentType Type { get; private set; }
        public string Number { get; private set; }

        public Employee Employee { get; set; }

        protected Document()
            : base()
        {
        }

        public Document(DocumentType type, string number)
        {
            Type = type;
            Number = number;
        }

        public static Document NewCpf(string number)
        {
            return new Document(DocumentType.Cpf, number);
        }
    }
}
