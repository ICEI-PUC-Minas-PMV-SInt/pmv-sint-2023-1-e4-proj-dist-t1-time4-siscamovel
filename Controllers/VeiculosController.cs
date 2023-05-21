using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using siscm_data_management.Database;
using siscm_data_management.Models.Especificacoes;

namespace siscm_data_management.Controllers;

[ApiController]
[Route("siscm/v1/[controller]")]
public class VeiculosController : Controller
{
    private readonly DatabaseSettings _gerenciar;

    public VeiculosController(DatabaseSettings databaseSettings)
    {
        _gerenciar = databaseSettings;
    }
    
    /// <summary>
    /// Obter lista de cadastro de todos os veiculos
    /// </summary>
    /// <param name="model">Dados do veiculo</param>
    [HttpGet]
    public async Task<IActionResult> ObterTodosOsVeiculos()
    {
        var veiculos = await _gerenciar.veiculos.ToListAsync();
        
        if (veiculos == null)
        {
            return NoContent();
        }
        
        return Ok(veiculos);
    }
    
    /// <summary>
    /// Obter lista de cadastro de veiculo por ID
    /// </summary>
    /// <param name="model">Dados do veiculo</param>
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> ObterTodosOsVeiculosPorId(Guid id)
    {
        var veiculosPorId = await _gerenciar.veiculos.FirstOrDefaultAsync(car => car.Id == id);
        
        if (veiculosPorId == null)
        {
            return NoContent();
        }
        
        return Ok(veiculosPorId);
    }    

    /// <summary>
    /// Cadastrar um veiculo
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AdicionarVeiculo([FromBody] Veiculos veiculosRequest)
    {
        veiculosRequest.Id = Guid.NewGuid();

        await _gerenciar.veiculos.AddAsync(veiculosRequest);
        await _gerenciar.SaveChangesAsync();

        if (veiculosRequest == null)
        {
            return NoContent();
        }        
        
        return Ok(veiculosRequest);
    }

    /// <summary>
    /// Editar dados de um veiculo pelo identificador
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> AlterarDadosVeiculo([FromRoute] Guid id, Veiculos atualizarVeiculo)
    {
        var veiculo = await _gerenciar.veiculos.FindAsync(id);

        if (veiculo == null)
        {
            return NotFound();
        }

        veiculo.Id = atualizarVeiculo.Id;
        veiculo.Fabricante = atualizarVeiculo.Fabricante;
        veiculo.Modelo = atualizarVeiculo.Modelo;
        veiculo.Ano = atualizarVeiculo.Ano;
        veiculo.Capacidade = atualizarVeiculo.Capacidade;
        veiculo.Potencia = atualizarVeiculo.Potencia;
        veiculo.Torque = atualizarVeiculo.Torque;
        veiculo.VelocidadeMaxima = atualizarVeiculo.VelocidadeMaxima;
        veiculo.Tempo = atualizarVeiculo.Tempo;
        veiculo.VolumePortaMalas = atualizarVeiculo.VolumePortaMalas;
        veiculo.PneusRodas = atualizarVeiculo.PneusRodas;
        veiculo.Garantia = atualizarVeiculo.Garantia;
        veiculo.Preco = atualizarVeiculo.Preco;

        await _gerenciar.SaveChangesAsync();

        return Ok(veiculo);
    }

    /// <summary>
    /// Excluir um veiculo (obrigatoriamente pelo ID)
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> RemoverVeiculo([FromRoute] Guid id)
    {
        var removerVeiculo = await _gerenciar.veiculos.FindAsync(id);

        if (removerVeiculo == null)
        {
            return NotFound();
        }

        _gerenciar.veiculos.Remove(removerVeiculo);
        await _gerenciar.SaveChangesAsync();

        return Ok();
    }
}