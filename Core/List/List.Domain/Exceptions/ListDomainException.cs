using RecALLDemo.Infrastructure.Ddd.Domain.Exceptions;

namespace RecALLDemo.Core.List.Domain.Exceptions;



public class ListDomainException : DomainException {
    public ListDomainException() { }

    public ListDomainException(string message) : base(message) { }

    public ListDomainException(string message, Exception innerException) : base(message, innerException) { }
}
