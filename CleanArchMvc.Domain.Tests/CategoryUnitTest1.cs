using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
	public class CategoryUnitTest1
	{
		[Fact]
		public void CreateCategory_WithValidParameters_ResultObjectValidState()
		{
			Action action = () => new Category(1, "Category Name");
			action.Should()
				  .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
		}

		[Fact]
		public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
		{
			Action action = () => new Category(-1, "Category Name");
			action.Should()
				  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
		}

		[Fact]
		public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
		{
			Action action = () => new Category(1, "");
			action.Should()
				  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
				  .WithMessage("Invalid name. Name is required");
		}

		[Fact]
		public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
		{
			Action action = () => new Category(1, null);
			action.Should()
				  .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
		}



	}
}