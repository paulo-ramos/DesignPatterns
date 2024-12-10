public interface IConfiguracao : ICloneable
{
    void AplicarConfiguracao();
}

public class ConfiguracaoSistema : IConfiguracao
{
    public string Nome { get; set; }
    public string Valor { get; set; }
    public string Identificador { get; private set; }

    private Dictionary<string, string> configuracoes;

    public ConfiguracaoSistema(string identificador)
    {
        configuracoes = new Dictionary<string, string>();
        Identificador = identificador;
    }

    public object Clone()
    {
        ConfiguracaoSistema clone = (ConfiguracaoSistema)this.MemberwiseClone();
        clone.configuracoes = new Dictionary<string, string>(this.configuracoes); // Deep copy do dicionário
        clone.Identificador = this.Identificador + "_Clone";
        return clone;
    }

    public void AplicarConfiguracao()
    {
        Console.WriteLine($"Aplicando configurações do identificador {Identificador}");;
        foreach (var config in configuracoes)
        {
            Console.WriteLine($"Aplicando configuração: - {config.Key} = {config.Value}");
        }
    }

    public void SetConfiguracao(string chave, string valor)
    {
        if (configuracoes.ContainsKey(chave))
        {
            configuracoes[chave] = valor;
        }
        else
        {
            configuracoes.Add(chave, valor);
        }
    }

    public string GetConfiguracao(string chave)
    {
        return configuracoes.TryGetValue(chave, out string valor) ? valor : null;
    }
}

public class Program
{
    public static void Main()
    {
        // Criação do protótipo de configuração
        ConfiguracaoSistema configuracaoOriginal = new ConfiguracaoSistema("Original");
        configuracaoOriginal.SetConfiguracao("Tema", "Escuro");
        configuracaoOriginal.SetConfiguracao("Idioma", "Português");

        // Clonando e modificando o protótipo
        ConfiguracaoSistema configuracaoClone = (ConfiguracaoSistema)configuracaoOriginal.Clone();
        configuracaoClone.SetConfiguracao("Tema", "Claro");

        // Recuperando e aplicando as configurações
        string temaOriginal = configuracaoOriginal.GetConfiguracao("Tema");
        string idiomaOriginal = configuracaoOriginal.GetConfiguracao("Idioma");
        string temaClone = configuracaoClone.GetConfiguracao("Tema");

        Console.WriteLine($"Configuração Original - Tema: {temaOriginal}, Idioma: {idiomaOriginal}");
        Console.WriteLine($"Configuração Clone - Tema: {temaClone}");

        configuracaoOriginal.AplicarConfiguracao();
        configuracaoClone.AplicarConfiguracao();
    }
}



