using Corretora.BolsaDeValor.API.Controllers;
using Corretora.BolsaDeValor.Core.Domain;
using Corretora.BolsaDeValor.Infra.Intaface;
using Delivery.Core.DomainObjects;
using Moq;

public class AcoesControllerTests
{
    private readonly Mock<IAcoesRepository> _acoesRepositoryMock;
    private readonly AcoesController _acoesController;

    public AcoesControllerTests()
    {
        _acoesRepositoryMock = new Mock<IAcoesRepository>();
        _acoesController = new AcoesController(_acoesRepositoryMock.Object);
    }


    [Fact]
    public async Task Lista_Paginada_DeveExecutarComSucesso()
    {
        // Arrange
        var pagedResult = new PagedResult<Acoes>();

        _acoesRepositoryMock.Setup(
            repo => repo.GetAll(
                It.IsAny<int>(), 
                It.IsAny<int>(), 
                It.IsAny<string>())
            ).ReturnsAsync(pagedResult);

        // Act
        var result = await _acoesController.Get();

        // Assert
        Assert.IsType<PagedResult<Acoes>>(result);
    }

    [Fact]
    public async Task Lista_PeloNome_DeveExecutarComSucesso()
    {
        // Arrange
        _acoesRepositoryMock.Setup(repo => repo.GetAcoes(It.IsAny<string>()))
                            .ReturnsAsync(new List<string> { "acao1", "acao1" });

        // Act
        var result = await _acoesController.List("acao1");

        // Assert
        Assert.IsType<List<string>>(result);
    }

    [Fact]
    public async Task Detalha_Acoes_DeveExecutarComSucesso()
    {
        // Arrange
        _acoesRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>()))
                            .ReturnsAsync(new Acoes("tet03", "Teste", 10M, 10M));

        // Act
        var result = await _acoesController.Details(Guid.NewGuid());

        // Assert
        Assert.IsType<Acoes>(result);
    }
}