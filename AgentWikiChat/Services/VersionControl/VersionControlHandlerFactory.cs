using Microsoft.Extensions.Configuration;

namespace AgentWikiChat.Services.VersionControl;

/// <summary>
/// Factory para crear instancias de handlers de sistemas de control de versiones.
/// Similar a DatabaseHandlerFactory, permite agregar nuevos proveedores fácilmente.
/// </summary>
public static class VersionControlHandlerFactory
{
    /// <summary>
    /// Crea un handler de sistema de control de versiones según el proveedor configurado.
    /// </summary>
    /// <param name="configuration">Configuración de la aplicación</param>
    /// <param name="configSection">Sección de configuración (ej: "SVN", "Git")</param>
    /// <returns>Instancia del handler apropiado</returns>
    public static IVersionControlHandler CreateHandler(IConfiguration configuration, string configSection = "SVN")
    {
        var config = configuration.GetSection(configSection);
        var provider = config.GetValue<string>("Provider") ?? "SVN";

        return provider.ToUpperInvariant() switch
        {
            "SVN" or "SUBVERSION" => new SvnVersionControlHandler(configuration),
            "GIT" => new GitVersionControlHandler(configuration), // ? Ya implementado (referencia)
            // Futuro: "MERCURIAL" or "HG" => new MercurialVersionControlHandler(configuration),
            // Futuro: "TFS" or "TFVC" => new TfsVersionControlHandler(configuration),
            // Futuro: "PERFORCE" or "P4" => new PerforceVersionControlHandler(configuration),
            _ => throw new NotSupportedException($"Proveedor de control de versiones '{provider}' no soportado. Proveedores válidos: {string.Join(", ", GetSupportedProviders())}")
        };
    }

    /// <summary>
    /// Obtiene la lista de proveedores soportados
    /// </summary>
    public static IEnumerable<string> GetSupportedProviders()
    {
        return new[] { "SVN", "Git" }; // Git ya tiene implementación de referencia
        // Futuro: return new[] { "SVN", "Git", "Mercurial", "TFS", "Perforce" };
    }
}
