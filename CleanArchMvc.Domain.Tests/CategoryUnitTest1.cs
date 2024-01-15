using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Category With Negative Id Value")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid Id value!");
    }
    
    [Fact(DisplayName = "Create Category With Invalid Name (Too Short)")]
    public void CreateCategory_ShortNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, "A");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters!");
    }
    
    [Fact(DisplayName = "Create Category With Nullable Name Value")]
    public void CreateCategory_NullableNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null);

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required!");
    }
}