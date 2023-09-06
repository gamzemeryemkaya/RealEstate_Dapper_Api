using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        // (INSERT, UPDATE, DELETE) için ExecuteAsync
        //QueryAsync, veritabanından veri çekmek için kullanılır.Result
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            // Veritabanından tüm kategorileri çekmek için SQL sorgusu hazırlanır.
            string query = "Select * From Category";

            // Veritabanı bağlantısı oluşturulur ve bu bağlantı sorguyu çalıştırır.
            using (var connection = _context.CreateConnection())
            {
                // Sorgu sonuçları, ResultCategoryDto türüne dönüştürülüp listeye çevrilir ve geri döndürülür.
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        /// <summary>
        /// Yeni bir kategori oluşturur.
        /// </summary>

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            //Yeni bir kategori eklerken veritabanına kategori adı ve durumu ekler.
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            //Sorgu için parametreler oluşturulur ve kategori bilgileri eklenir.
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            // Veritabanı bağlantısı oluşturulur ve sorgu çalıştırılır.
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        /// <summary>
        /// Belirtilen kategori bilgileri ile mevcut bir kategoriyi günceller.
        /// </summary>

         public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            //Belirtilen kategori ID'sine sahip kategoriyi günceller.

            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            //Sorgu için parametreler oluşturulur ve güncelleme için gerekli bilgiler eklenir.
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);
            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }
        }
    }
}
