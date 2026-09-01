using System;
using System.Data;
using POS.DAL.Repositories;

namespace POS.BLL.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo = new ProductRepository();

        // Lấy danh sách toàn bộ món ăn đang kinh doanh
        public DataTable GetActiveMenu()
        {
            try
            {
                return _productRepo.GetActiveProducts();
            }
            catch (Exception ex)
            {
                // Ở môi trường doanh nghiệp, bạn có thể ghi log lỗi ở đây (Log4Net/NLog)
                throw new Exception("Lỗi nghiệp vụ khi tải thực đơn: " + ex.Message);
            }
        }

        // Lấy danh sách Topping được phép đi kèm của một món cụ thể
        public DataTable GetModifiersForProduct(int productId)
        {
            if (productId <= 0) return new DataTable();

            try
            {
                return _productRepo.GetModifiersByProductId(productId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải danh sách Topping: " + ex.Message);
            }
        }
        // Lấy danh sách nhóm danh mục đang kinh doanh
        public DataTable GetCategories()
        {
            try
            {
                return _productRepo.GetCategories();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải danh mục: " + ex.Message);
            }
        }
    }
}
