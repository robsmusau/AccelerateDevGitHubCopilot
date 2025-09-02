using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Library.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System.IO;
using System.Threading.Tasks;

namespace Library.UnitTests.Infrastructure.JsonLoanRepositoryTests;

public class GetLoanTest
{
    private readonly IConfiguration _configuration;
    private readonly JsonData _jsonData;
    private readonly JsonLoanRepository _jsonLoanRepository;
    private readonly ILoanRepository _mockLoanRepository;

    public GetLoanTest()
    {
        // Create configuration
        _configuration = new ConfigurationBuilder().Build();

        // Initialize JsonData with configuration
        _jsonData = new JsonData(_configuration);

        // Create the actual repository
        _jsonLoanRepository = new JsonLoanRepository(_jsonData);

        // Create a mock repository for comparison or alternative scenarios
        _mockLoanRepository = Substitute.For<ILoanRepository>();
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when valid ID is provided")]
    public async Task GetLoan_WithValidId_ReturnsLoan()
    {
        // Arrange
        int loanId = 34; // ID that exists in Loans.json

        // Create expected loan using the same ID
        var expectedLoan = new Loan
        {
            Id = loanId,
            BookItemId = 19,
            PatronId = 29,
            LoanDate = DateTime.Parse("2023-12-28T00:40:43.1809458"),
            DueDate = DateTime.Parse("2024-01-11T00:40:43.1809458"),
            ReturnDate = DateTime.Parse("2023-12-29T00:40:54.582495")
        };

        _mockLoanRepository.GetLoan(loanId).Returns(expectedLoan);

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.NotNull(actualLoan);
        Assert.Equal(loanId, actualLoan.Id);
        Assert.Equal(expectedLoan.BookItemId, actualLoan.BookItemId);
        Assert.Equal(expectedLoan.PatronId, actualLoan.PatronId);
    }
    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when invalid ID is provided")]
    public async Task GetLoan_WithInvalidId_ReturnsNull()
    {
        // Arrange
        int invalidLoanId = 9999; // ID that does not exist in Loans.json

        _mockLoanRepository.GetLoan(invalidLoanId).Returns((Loan?)null);
        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(invalidLoanId);

        // Assert
        Assert.Null(actualLoan);
    }
}