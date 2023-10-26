using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Feedback
{
    public int Id { get; set; }

    public string? TicketId { get; set; }

    public string? CustName { get; set; }

    public string? CustEmail { get; set; }

    public string? PhoneNo { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public int? FeedbackType { get; set; }

    public int? ResolveStatus { get; set; }

    public string? ResolveBy { get; set; }

    public string? MsgFeedback { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DateModified { get; set; }

    public sbyte? ActiveFlag { get; set; }

    public DateTime? Dstamp { get; set; }

    public string? MemberNo { get; set; }

    public string? NonMemberNo { get; set; }

    public int? MemberId { get; set; }
}
