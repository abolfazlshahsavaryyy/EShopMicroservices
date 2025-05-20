namespace Ordering.Application.Dtos;


public record PaymentDto
    (
    string CartName,
    string CartNumber,
    string Expiration,
    string Cvv,
    int PaymentMethod
    );
