using Corretora.BolsaDeValor.API.Application.Commands.Acoes;
using Corretora.BolsaDeValor.API.Application.Commands.Brand;
using Corretora.BolsaDeValor.API.Controllers;
using Corretora.BolsaDeValor.Core.Domain;
using Corretora.BolsaDeValor.Infra.Intaface;
using Delivery.Core.DomainObjects;
using Delivery.Core.Mediator;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class FavoritoControllerTests
{
    private readonly Mock<IMediatorHandler> _mediatorMock;
    private readonly Mock<IFavoritosRepository> _favoritosRepositoryMock;
    private readonly FavoritoController _favoritoController;

    public FavoritoControllerTests()
    {
        _mediatorMock = new Mock<IMediatorHandler>();
        _favoritosRepositoryMock = new Mock<IFavoritosRepository>();
        _favoritoController = new FavoritoController(_mediatorMock.Object, _favoritosRepositoryMock.Object);
    }


    [Fact]
    public async Task ListaFavorito_Paginada_DeveExecutarComSucesso()
    {
        // Arrange
        var usuarioId = Guid.NewGuid();
        var pagedResult = new PagedResult<Favorito>();
        _favoritosRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Guid>()))
                                .ReturnsAsync(pagedResult);

        // Act
        var result = await _favoritoController.get(usuarioId);

        // Assert
        Assert.IsType<PagedResult<Favorito>>(result);
    }

    [Fact]
    public async Task Adicionada_AcaoListaFavorito_DeveExecutarComSucesso()
    {
        // Arrange
        var addFavoritosCommand = new AddFavoritosCommand(Guid.NewGuid(), Guid.NewGuid()); // Preencha conforme necessário
        _mediatorMock.Setup(x => x.SendCommand(It.IsAny<AddFavoritosCommand>())).ReturnsAsync(new ValidationResult());

        // Act
        var result = await _favoritoController.add(addFavoritosCommand);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task atualiza_AcaoListaFavorito_DeveExecutarComSucesso()
    {
        // Arrange
        var updateFavoritosCommand = new UpdateFavoritosCommand(Guid.NewGuid(), Guid.NewGuid()); // Preencha conforme necessário
        _mediatorMock.Setup(mediator => mediator.SendCommand(It.IsAny<UpdateFavoritosCommand>()))
                     .ReturnsAsync(new ValidationResult());

        // Act
        var result = await _favoritoController.Update(updateFavoritosCommand);

        // Assert
        Assert.IsType<NoContentResult>(result);

    }

    [Fact]
    public async Task Deleta_AcaoListaFavorito_DeveExecutarComSucesso()
    {
        // Arrange
        var favoritoId = Guid.NewGuid();
        _mediatorMock.Setup(mediator => mediator.SendCommand(It.IsAny<DeleteFavoritosCommand>()))
                     .ReturnsAsync(new ValidationResult());

        // Act
        var result = await _favoritoController.Delete(favoritoId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

}