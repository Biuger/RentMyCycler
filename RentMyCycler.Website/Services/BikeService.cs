using Newtonsoft.Json;
using RentMyCycler.Api.DTO;
using RentMyCycler.Core.http;
using RentMyCycler.Website.Services.Interfaces;

namespace RentMyCycler.Website.Services;

public class BikeService: IBikeService
{
    private readonly string _baseURL = "http://localhost:5252/";
    private readonly string _endpoint = "api/bikes";

    public BikeService()
    {
        
    }

    public async Task<Response<List<BikeDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<List<BikeDto>>>(json);

        return response;
    }

    public async Task<Response<BikeDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<BikeDto>>(json);

        return response;
    }

    public async Task<Response<BikeDto>> SaveAsync(BikeDto BikeDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(BikeDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<BikeDto>>(json);

        return response;
    }

    public async Task<Response<BikeDto>> UpdateAsync(BikeDto BikeDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(BikeDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<BikeDto>>(json);
        Console.WriteLine(response);
        return response;
        
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<bool>>(json);

        return response;
    }
}