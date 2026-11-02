using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Client.Services;

public class HttpService<T> : IDisposable, IHttpService<T> where T : class
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
        // var config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

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

    public async Task Delete(string resource, string id)
    {
        try
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{resource}/{id}");
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
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

    public async Task<T> Get(string resource, string predicate)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{resource}?q={predicate}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(result))
                {
                    throw new Exception("Det fanns inte det du ville ha");
                }

                var data = JsonSerializer.Deserialize<List<T>>(result, _options)!;
                return data[0];
            }

            throw new Exception("Något gick fel:" + response.StatusCode);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task Post(string resource, T data)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await _httpClient.PostAsJsonAsync<T>($"{_baseUrl}/{resource}", data);
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

    public async Task Put(string resource, T data, string objectId)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("spplication/json"));
            await _httpClient.PutAsJsonAsync($"{_baseUrl}/{resource}/{objectId}", data);
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

    public void Dispose()
    {
        _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}
