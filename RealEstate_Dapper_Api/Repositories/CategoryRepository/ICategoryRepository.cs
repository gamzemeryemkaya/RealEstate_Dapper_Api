using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        // 'result' ve 'update' DTO'ları aynıdır.
        // İki farklı DTO tanımlaması, temiz kod prensipleri açısından daha iyidir.
        // Yönetim ve revizyon süreçlerinde hata kontrolünü daha kolay ve hızlı bir şekilde sağlamamıza yardımcı olur.
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void DeleteCategory(int id);

        void UpdateCategory(UpdateCategoryDto categoryDto);
    }
}
