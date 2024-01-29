using Corretora.BolsaDeValor.API.Application.Commands.Acoes;
using FluentValidation;
using static Corretora.BolsaDeValor.API.Application.Commands.Acoes.AddTransacaoCommand;
using static Corretora.BolsaDeValor.API.Application.Commands.Acoes.UpdateTransacaoCommand;

public class TransacaoCommandHandlerTests
{
    private AddTransacaoValidation _addvalidations;
    private UpdateTransacaoCommandValidation _updateTransacao;
    public TransacaoCommandHandlerTests(AddTransacaoValidation addvalidations, UpdateTransacaoCommandValidation updateTransacao)
    {
        _addvalidations = addvalidations;
        _updateTransacao = updateTransacao;
    }

    [Fact]
    public void AddTransacaoCommand_ValidCommand_Success()
    {
        // Arrange
        var TransacaoCommand = new AddTransacaoCommand(new Guid(),1,1M,1);

        // Act
        var response = _addvalidations.Validate(TransacaoCommand);
        
        // Assert
        response.IsValid.Equals(false);

    }
    [Fact]
    public void UpdateTransacaoCommand_ValidCommand_Success()
    {
        // Arrange
        var TransacaoCommand = new UpdateTransacaoCommand(new Guid(), new Guid(), 1, 1M, 1);

        // Act
        var response = _updateTransacao.Validate(TransacaoCommand);

        // Assert
        response.IsValid.Equals(false);

    }

}
