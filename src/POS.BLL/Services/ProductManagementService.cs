using System;
using System.Collections.Generic;
using System.Data;
using POS.BLL.DTOs;
using POS.DAL.Repositories;

namespace POS.BLL.Services
{
    public class ProductManagementService
    {
        private readonly ProductRepository _productRepo = new ProductRepository();
        private readonly ModifierRepository _modifierRepo = new ModifierRepository();

        // 1. Lọc sản phẩm
        public List<ProductDto> GetFilteredProducts(int? categoryId = null, string keyword = null, bool? isActive = null)
        {
            var list = new List<ProductDto>();
            DataTable dt = _productRepo.GetFilteredProducts(categoryId, keyword, isActive);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ProductDto
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Name = row["Name"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    ProductType = row["ProductType"].ToString(),
                    IsActive = Convert.ToInt32(row["IsActive"]) == 1,
                    ModifierCount = row["ModifierCount"] != DBNull.Value ? Convert.ToInt32(row["ModifierCount"]) : 0
                });
            }
            return list;
        }

        // 2. Lấy chi tiết món kèm danh sách Topping được gán
        public ProductDto GetProductById(int id)
        {
            DataRow row = _productRepo.GetProductById(id);
            if (row == null) return null;

            var dto = new ProductDto
            {
                Id = Convert.ToInt32(row["Id"]),
                CategoryId = Convert.ToInt32(row["CategoryId"]),
                CategoryName = row["CategoryName"]?.ToString() ?? string.Empty,
                Name = row["Name"].ToString(),
                Price = Convert.ToDecimal(row["Price"]),
                ProductType = row["ProductType"].ToString(),
                IsActive = Convert.ToInt32(row["IsActive"]) == 1,
                ModifierIds = _productRepo.GetModifierIdsByProductId(id)
            };
            dto.ModifierCount = dto.ModifierIds.Count;
            return dto;
        }

        // 3. Lưu sản phẩm (Thêm mới hoặc Cập nhật)
        public bool SaveProduct(ProductDto dto, List<int> modifierIds, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (dto == null)
            {
                errorMessage = "Dữ liệu món ăn không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                errorMessage = "Tên món ăn / đồ uống không được để trống!";
                return false;
            }

            if (dto.CategoryId <= 0)
            {
                errorMessage = "Vui lòng chọn danh mục cho món ăn!";
                return false;
            }

            if (dto.Price < 0)
            {
                errorMessage = "Đơn giá bán không được là số âm!";
                return false;
            }

            dto.Name = dto.Name.Trim();

            // Kiểm tra trùng tên món trong cùng danh mục
            var existing = GetFilteredProducts(dto.CategoryId, dto.Name, null);
            foreach (var p in existing)
            {
                if (p.Id != dto.Id && p.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = $"Món '{dto.Name}' đã tồn tại trong danh mục này! Vui lòng chọn tên khác.";
                    return false;
                }
            }

            if (dto.Id == 0)
            {
                int newId = _productRepo.InsertProduct(dto.Name, dto.CategoryId, dto.Price, dto.ProductType, dto.IsActive ? 1 : 0, modifierIds);
                dto.Id = newId;
                return newId > 0;
            }
            else
            {
                return _productRepo.UpdateProduct(dto.Id, dto.Name, dto.CategoryId, dto.Price, dto.ProductType, dto.IsActive ? 1 : 0, modifierIds);
            }
        }

        // 4. Bật / Tắt nhanh trạng thái kinh doanh
        public bool ToggleProductStatus(int id, bool isActive)
        {
            return _productRepo.ToggleProductStatus(id, isActive);
        }

        // 5. Xóa món ăn
        public bool DeleteProduct(int id, out bool wasSoftDeleted, out string message)
        {
            try
            {
                bool success = _productRepo.DeleteProduct(id, out wasSoftDeleted);
                if (success)
                {
                    message = wasSoftDeleted
                        ? "Món này đã có trong lịch sử hóa đơn cũ, hệ thống đã tự động chuyển sang trạng thái 'Tạm ngưng kinh doanh' để đảm bảo toàn vẹn dữ liệu kế toán."
                        : "Đã xóa món ăn thành công!";
                    return true;
                }
                else
                {
                    message = "Không thể xóa món ăn!";
                    return false;
                }
            }
            catch (Exception ex)
            {
                wasSoftDeleted = false;
                message = "Lỗi khi xóa món: " + ex.Message;
                return false;
            }
        }

        // 6. Topping / Modifier CRUD
        public List<ModifierDto> GetAllModifiers(bool includeInactive = true)
        {
            var list = new List<ModifierDto>();
            DataTable dt = _modifierRepo.GetAllModifiers(includeInactive);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ModifierDto
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    IsActive = Convert.ToInt32(row["IsActive"]) == 1
                });
            }
            return list;
        }

        public bool SaveModifier(ModifierDto dto, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (dto == null)
            {
                errorMessage = "Dữ liệu Topping không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                errorMessage = "Tên Topping không được để trống!";
                return false;
            }

            if (dto.Price < 0)
            {
                errorMessage = "Đơn giá Topping không được là số âm!";
                return false;
            }

            dto.Name = dto.Name.Trim();

            // Kiểm tra trùng tên
            var all = GetAllModifiers(true);
            foreach (var m in all)
            {
                if (m.Id != dto.Id && m.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = $"Topping '{dto.Name}' đã tồn tại! Vui lòng chọn tên khác.";
                    return false;
                }
            }

            if (dto.Id == 0)
            {
                int newId = _modifierRepo.InsertModifier(dto.Name, dto.Price, dto.IsActive ? 1 : 0);
                dto.Id = newId;
                return newId > 0;
            }
            else
            {
                return _modifierRepo.UpdateModifier(dto.Id, dto.Name, dto.Price, dto.IsActive ? 1 : 0);
            }
        }

        public bool DeleteModifier(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                return _modifierRepo.DeleteModifier(id);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa Topping: " + ex.Message;
                return false;
            }
        }
    }
}
