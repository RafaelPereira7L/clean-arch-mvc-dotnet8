using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact(DisplayName = "Create Product With Valid State")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Product With Negative Id Value")]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid Id value!");
    }
    
    [Fact(DisplayName = "Create Product With Invalid Name (Too Short)")]
    public void CreateProduct_ShortNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, "P", "Product Description", 9.99m, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters!");
    }
    
    [Fact(DisplayName = "Create Product With Nullable Name Value")]
    public void CreateProduct_NullableNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required!");
    }
    
    [Fact(DisplayName = "Create Product With Nullable Description Value")]
    public void CreateProduct_NullableDescriptionValue_DomainExceptionInvalidDescription()
    {
        Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required!");
    }
    
    [Fact(DisplayName = "Create Product With Invalid Name (Too Short)")]
    public void CreateProduct_ShortDescriptionValue_DomainExceptionInvalidDescription()
    {
        Action action = () => new Product(1, "Product Name", "A", 9.99m, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters!");
    }
    
    [Fact(DisplayName = "Create Product With Invalid Price Value")]
    public void CreateProduct_InvalidPriceValue_DomainExceptionInvalidPrice()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", -1, 99, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid price value!");
    }
    
    [Fact(DisplayName = "Create Product With Invalid Stock Value")]
    public void CreateProduct_InvalidStockValue_DomainExceptionInvalidStock()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -1, "product image");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid stock value!");
    }
    
    [Fact(DisplayName = "Create Product With Nullable Image Value")]
    public void CreateProduct_NullableImageValue_DomainExceptionImage()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);

        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Create Product With Nullable Image Value (Null Reference)")]
    public void CreateProduct_NullableImageValue_NullReferenceException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);

        action.Should()
            .NotThrow<NullReferenceException>();
    }
    
    [Fact(DisplayName = "Create Product Long Image Value")]
    public void CreateProduct_LongImageValue_DomainExceptionInvalidImage()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "lorem ipsum dolor sit amet, consectetur adipiscing elit. donec aliquam, nunc eget aliquam rhoncus, nunc augue ultricies justo, quis aliquam nunc nunc ut arcu. donec aliquam, nunc eget aliquam rhoncus, nunc augue ultricies justo, quis aliquam nunc nunc ut arcu. donec aliquam, nunc eget aliquam rhoncus, nunc augue ultricies justo, quis aliquam nunc nunc ut arcu.");

        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid image. Image name too long, maximum 250 characters!");
    }
}