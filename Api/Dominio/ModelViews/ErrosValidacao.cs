namespace MinimalApi.Dominio.ModelViews;

public struct ErrosValidacao
{
    public List<string> Mensagem { get; set; }
    public List<string> Mensagens { get; internal set; }
}