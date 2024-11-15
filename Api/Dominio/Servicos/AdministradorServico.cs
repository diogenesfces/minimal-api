using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interface;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador BuscaPorId(int id)
    {
        return _contexto?.Administradores?.FirstOrDefault(v => v.Id == id) ?? new Administrador();
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto?.Administradores?.Add(administrador);
        _contexto?.SaveChanges();

        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Administradores?.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;
    }

    public List<Administrador> Todos(int? pagina)
    {
        var query = _contexto.Administradores?.AsQueryable();

        int intensPorPagina = 10;

        if( pagina != null)
        {
            query = query?.Skip(((int)pagina - 1) * intensPorPagina).Take(intensPorPagina);
        }
        return query.ToList();
    }
}