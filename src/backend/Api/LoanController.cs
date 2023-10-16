using Microsoft.AspNetCore.Mvc;
using tech_interview_api.Domain;
using tech_interview_api.Infrastructure.Persistence;

namespace tech_interview_api.Api;

[ApiController]
[Route("[controller]")]
public class LoanController
{
    private readonly ApplicationDbContext applicationDbContext;
    public LoanController(ApplicationDbContext applicationDbContext) => this.applicationDbContext = applicationDbContext;

    [HttpGet]
    public IEnumerable<Loan> Get() => applicationDbContext.Loans;

    [HttpPost]
    public Loan Post(Loan loan)
    {
        applicationDbContext.Loans.Add(loan);
        applicationDbContext.SaveChanges();
        return loan;
    }

    [HttpPut("{id:int}")]
    public Loan Put(int id, Loan loan)
    {
        applicationDbContext.Loans.Update(loan);
        applicationDbContext.SaveChanges();
        return loan;
    }
}