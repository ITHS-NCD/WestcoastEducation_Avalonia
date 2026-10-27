using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls.Platform;
using Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Client.Services;

public class HttpService<T> : IHttpService<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = string.Empty;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public HttpService()
    {
        var config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

        var apikey = config.GetSection("Settings:ApiKey").Value!;
        _baseUrl = config.GetSection("Settings:BaseUrl").Value!;

        _httpClient = new()
        {
            BaseAddress = new Uri(_baseUrl)
        };
        _httpClient.DefaultRequestHeaders.Add("Cache-Control", "none");
        _httpClient.DefaultRequestHeaders.Add("x-apikey", apikey);
    }

    public Task Delete(string resource, string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> Get(string resource)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{resource}");

            if (!response.IsSuccessStatusCode) return [];

            var result = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
            return list;

        }
        catch (HttpRequestException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public Task<T> Get(string resource, string predicate)
    {
        throw new NotImplementedException();
    }

    public Task Post(string resource, T data)
    {
        throw new NotImplementedException();
    }

    public Task Put(string resource, T data, string objectId)
    {
        throw new NotImplementedException();
    }
}
