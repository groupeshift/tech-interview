using Microsoft.AspNetCore.Mvc;
using tech_interview_api.Application.Members.Commands;
using tech_interview_api.Application.Members.Models;

namespace tech_interview_api.Api;

[ApiController]
[Route("[controller]")]
public class MemberController
{
    private readonly GetMembersRequestHandler getMembersRequestHandler;
    private readonly CreateMemberRequestHandler createMemberRequestHandler;
    private readonly UpdateMemberRequestHandler updateMemberRequestHandler;

    public MemberController(
        GetMembersRequestHandler getMembersRequestHandler,
        CreateMemberRequestHandler createMemberRequestHandler,
        UpdateMemberRequestHandler updateMemberRequestHandler
    )
    {
        this.getMembersRequestHandler = getMembersRequestHandler;
        this.createMemberRequestHandler = createMemberRequestHandler;
        this.updateMemberRequestHandler = updateMemberRequestHandler;
    }

    [HttpGet]
    public List<MemberDto> Get() => getMembersRequestHandler.Handle(new GetMembersRequest()).Result;

    [HttpPost]
    public bool Post(CreateMemberRequest createMemberRequest) => createMemberRequestHandler.Handle(createMemberRequest).Result;

    [HttpPut("{id:int}")]
    public bool Put(int id, [FromBody] UpdateMemberRequest updateMemberRequest)
    {
        updateMemberRequest.Id = id;

        return updateMemberRequestHandler.Handle(updateMemberRequest).Result;
    }
}
