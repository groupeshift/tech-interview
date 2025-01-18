using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using tech_interview_api.Application.Common;
using tech_interview_api.Application.Members.Models;
using tech_interview_api.Infrastructure.Persistence;

namespace tech_interview_api.Application.Members.Commands;

public class GetMembersRequest : IRequest<List<MemberDto>> { }

public class GetMembersRequestHandler : IRequestHandler<GetMembersRequest, List<MemberDto>>
{
    private readonly ApplicationDbContext context;
    public GetMembersRequestHandler(ApplicationDbContext context) => this.context = context;

    public async Task<List<MemberDto>> Handle(GetMembersRequest request)
    {
        return (await context.Members
                .AsNoTracking()
                .Select(member => new MemberDto
                {
                    Id = member.Id,
                    Name = member.Name,
                    EmailAddress = member.EmailAddress,
                    PhoneNumber = member.PhoneNumber
                })
                .ToListAsync())
            .ToList();
    }
}
