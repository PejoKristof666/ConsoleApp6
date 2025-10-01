using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class ServerConnection
    {
        HttpClient client = new HttpClient();
        string baseUrl = "";
        public ServerConnection(string url)
        {
            if (!url.StartsWith("http://")) throw new ArgumentException("Hibás url (http://)");
            baseUrl = url;
        }
  
        /////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<Car>> GetCars()
        {
            List<Car> result = new List<Car>();
            string url = baseUrl + "/cars";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                result = JsonSerializer.Deserialize<List<Car>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public async Task<Message> CreateCar(int brandId, string model, int performance, int productionYear, int wheelSize)
        {
            Message message = new Message();
            string url = baseUrl + "/cars";

            try
            {
                var jsonData = new
                {
                    brandID = brandId,
                    model = model,
                    performance = performance,
                    productionYear = productionYear,
                    wheelSize = wheelSize
                };
                string jsonString = JsonSerializer.Serialize(jsonData);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return message;
        }
        public async Task<Message> DeleteCar(int id)
        {
            Message message = new Message();
            string url = $"{baseUrl}/cars/{id}";

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return message;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<Owner>> GetOwners()
        {
            List<Owner> result = new List<Owner>();
            string url = baseUrl + "/owner";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                result = JsonSerializer.Deserialize<List<Owner>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public async Task<Message> CreateOwner(int carId, string name, string address, int birthYear)
        {
            Message message = new Message();
            string url = baseUrl + "/owner";

            try
            {
                var jsonData = new
                {
                    carID = carId,
                    name = name,
                    address = address,
                    birthYear = birthYear
                };
                string jsonString = JsonSerializer.Serialize(jsonData);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return message;
        }

        public async Task<Message> DeleteOwner(int id)
        {
            Message message = new Message();
            string url = $"{baseUrl}/owner/{id}";

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return message;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<List<Brand>> GetManufacturers()
        {
            List<Brand> result = new List<Brand>();
            string url = baseUrl + "/manufacturers";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                result = JsonSerializer.Deserialize<List<Brand>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }

        public async Task<Message> CreateManufacturer(string name, int foundedYear, string country, int? productionYear)
        {
            Message message = new Message();
            string url = baseUrl + "/manufacturers";

            try
            {
                var jsonData = new
                {
                    name = name,
                    foundedYear = foundedYear,
                    country = country,
                    productionYear = productionYear
                };
                string jsonString = JsonSerializer.Serialize(jsonData);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return message;
        }

        public async Task<Message> DeleteManufacturer(int id)
        {
            Message message = new Message();
            string url = $"{baseUrl}/manufacturers/{id}";

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                message = JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return message;
        }
    }
}
