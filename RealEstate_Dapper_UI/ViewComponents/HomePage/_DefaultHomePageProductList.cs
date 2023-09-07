using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        // IHttpClientFactory türünden bir bağımlılık enjeksiyonu ile bir _httpClientFactory örneği alınır.
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // HTTP istemcisi oluşturulur.
            var client = _httpClientFactory.CreateClient();

            // Belirtilen URL'ye bir GET isteği gönderilir ve cevap beklenir.
            var responseMessage = await client.GetAsync("https://localhost:44328/api/Products/ProductListWithCategory");

            // Cevap başarıyla alındıysa işleme devam edilir.
            if (responseMessage.IsSuccessStatusCode)
            {
                // Cevap içeriği JSON formatında okunur.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON verisi bir metin formatına dönüştürülür (deserialization).
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);

                // Bu nesne bir View'a veri olarak gönderilir ve görünüm döndürülür.
                return View(values);
            }

            // Eğer istek başarısızsa veya hata alınırsa boş bir görünüm döndürülür.
            return View();
        }
    }
}
