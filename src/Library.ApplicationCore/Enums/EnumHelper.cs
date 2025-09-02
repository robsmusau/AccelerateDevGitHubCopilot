using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Library.ApplicationCore.Enums;

public static class EnumHelper
{
    private static readonly Dictionary<LoanExtensionStatus, string> _loanExtensionDescriptions = new()
    {
        { LoanExtensionStatus.Success, "Book loan extension was successful." },
        { LoanExtensionStatus.LoanNotFound, "Loan not found." },
        { LoanExtensionStatus.LoanExpired, "Cannot extend book loan as it already has expired. Return the book instead." },
        { LoanExtensionStatus.MembershipExpired, "Cannot extend book loan due to expired patron's membership." },
        { LoanExtensionStatus.LoanReturned, "Cannot extend book loan as the book is already returned." },
        { LoanExtensionStatus.Error, "Cannot extend book loan due to an error." }
    };

    private static readonly Dictionary<LoanReturnStatus, string> _loanReturnDescriptions = new()
    {
        { LoanReturnStatus.Success, "Book was successfully returned." },
        { LoanReturnStatus.LoanNotFound, "Loan not found." },
        { LoanReturnStatus.AlreadyReturned, "Cannot return book as the book is already returned." },
        { LoanReturnStatus.Error, "Cannot return book due to an error." }
    };

    private static readonly Dictionary<MembershipRenewalStatus, string> _membershipRenewalDescriptions = new()
    {
        { MembershipRenewalStatus.Success, "Membership renewal was successful." },
        { MembershipRenewalStatus.PatronNotFound, "Patron not found." },
        { MembershipRenewalStatus.TooEarlyToRenew, "It is too early to renew the membership." },
        { MembershipRenewalStatus.LoanNotReturned, "Cannot renew membership due to an outstanding loan." },
        { MembershipRenewalStatus.Error, "Cannot renew membership due to an error." }
    };

    public static string GetDescription(Enum value)
    {
        if (value == null)
            return string.Empty;

        switch (value)
        {
            case LoanExtensionStatus loanExtensionStatus:
                return _loanExtensionDescriptions.TryGetValue(loanExtensionStatus, out var extDescription)
                    ? extDescription
                    : loanExtensionStatus.ToString();

            case LoanReturnStatus loanReturnStatus:
                return _loanReturnDescriptions.TryGetValue(loanReturnStatus, out var retDescription)
                    ? retDescription
                    : loanReturnStatus.ToString();

            case MembershipRenewalStatus membershipRenewalStatus:
                return _membershipRenewalDescriptions.TryGetValue(membershipRenewalStatus, out var memDescription)
                    ? memDescription
                    : membershipRenewalStatus.ToString();

            default:
                return value.ToString();
        }
    }
}