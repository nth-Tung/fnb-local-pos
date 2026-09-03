using System;
using System.Collections.Generic;
using System.Data;
using POS.BLL.DTOs;
using POS.DAL.Repositories;

namespace POS.BLL.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        public List<CategoryDto> GetAllCategories(bool includeInactive = true)
        {
            var list = new List<CategoryDto>();
            DataTable dt = _categoryRepo.GetAllCategories(includeInactive);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CategoryDto
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    IsActive = Convert.ToInt32(row["IsActive"]) == 1,
                    ProductCount = row["ProductCount"] != DBNull.Value ? Convert.ToInt32(row["ProductCount"]) : 0
                });
            }
            return list;
        }

        public CategoryDto GetCategoryById(int id)
        {
            DataRow row = _categoryRepo.GetCategoryById(id);
            if (row == null) return null;

            return new CategoryDto
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"].ToString(),
                IsActive = Convert.ToInt32(row["IsActive"]) == 1
            };
        }

        public bool SaveCategory(CategoryDto dto, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (dto == null)
            {
                errorMessage = "Dữ liệu danh mục không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                errorMessage = "Tên danh mục không được để trống!";
                return false;
            }

            dto.Name = dto.Name.Trim();

            // Kiểm tra trùng tên danh mục
            var all = GetAllCategories(true);
            foreach (var c in all)
            {
                if (c.Id != dto.Id && c.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = $"Tên danh mục '{dto.Name}' đã tồn tại! Vui lòng chọn tên khác.";
                    return false;
                }
            }

            if (dto.Id == 0)
            {
                int newId = _categoryRepo.InsertCategory(dto.Name, dto.IsActive ? 1 : 0);
                dto.Id = newId;
                return newId > 0;
            }
            else
            {
                return _categoryRepo.UpdateCategory(dto.Id, dto.Name, dto.IsActive ? 1 : 0);
            }
        }

        public bool DeleteCategory(int id, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (_categoryRepo.HasProducts(id))
            {
                errorMessage = "Không thể xóa danh mục này vì đang chứa các món ăn! Vui lòng chuyển các món ăn sang nhóm khác trước hoặc tắt trạng thái hoạt động.";
                return false;
            }

            bool success = _categoryRepo.DeleteCategory(id);
            if (!success)
            {
                errorMessage = "Không tìm thấy danh mục để xóa hoặc có lỗi xảy ra!";
            }
            return success;
        }
    }
}
