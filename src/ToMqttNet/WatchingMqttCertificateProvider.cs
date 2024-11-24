using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet.Client;

namespace ToMqttNet;

public class WatchingMqttCertificateProvider : IMqttClientCertificatesProvider
{
    private readonly List<FileSystemWatcher> _watchers = [];
    private readonly MqttConnectionOptions _options;
    private readonly ILogger<WatchingMqttCertificateProvider> _logger;

    public X509Certificate2? CaCertificate { get; private set; }
    public X509Certificate2Collection ClientCertificates { get; private set; } = new();

    public WatchingMqttCertificateProvider(ILogger<WatchingMqttCertificateProvider> logger, IOptions<MqttConnectionOptions> options)
    {
        _options = options.Value;
        _logger = logger;
        var certDirectories = new string?[] { _options.CaCrt, _options.ClientCrt, _options.ClientKey }
            .Where(x => x != null)
            .Select(x => Path.GetDirectoryName(x)!)
            .Distinct()
            .ToList();

        foreach (var directory in certDirectories)
        {
            var watcher = new FileSystemWatcher(directory);
            _watchers.Add(watcher);

            watcher.Changed += OnCertificateChanged;
            watcher.EnableRaisingEvents = true;
        }

        LoadCertificates();
    }

    private void LoadCertificates()
    {
        _logger.LogInformation("Loading certificates");
        try
        {
            ClientCertificates.Clear();
            if (_options.ClientCrt != null && _options.ClientKey != null)
            {
                var clientCert = X509Certificate2.CreateFromPemFile(_options.ClientCrt, _options.ClientKey);
                ClientCertificates.Add(clientCert);
                _logger.LogInformation("Loaded Client Certificate {name} from {certPath}, {keyPath}", clientCert.Thumbprint, _options.ClientCrt, _options.ClientKey);
            }

            if (_options.CaCrt != null)
            {
                CaCertificate = new X509Certificate2(_options.CaCrt);
                ClientCertificates.Add(CaCertificate);
                _logger.LogInformation("Loaded CA Certificate {name} from {path}", CaCertificate.Thumbprint, _options.CaCrt);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load certificates");
            throw;
        }
        _logger.LogInformation("Certificates loaded");
    }

    private void OnCertificateChanged(object sender, FileSystemEventArgs e)
    {
        LoadCertificates();
    }

    public X509CertificateCollection GetCertificates()
    {
        return ClientCertificates;
    }
}