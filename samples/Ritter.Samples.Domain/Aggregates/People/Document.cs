using Ritter.Domain;
using System.Diagnostics;

namespace Ritter.Samples.Domain.Aggregates.People
{
    [DebuggerDisplay("Type = {Type}; Number = {Number}")]
    public class Document : Entity
    {
        public DocumentType Type { get; private set; }
        public string Number { get; private set; }

        public Person Person { get; set; }

        protected Document()
            : base()
        {
        }

        public Document(DocumentType type, string number)
        {
            Type = type;
            Number = number;
        }

        public static Document CreateCpf(string number)
        {
            return new Document(DocumentType.Cpf, number);
        }
    }
}
