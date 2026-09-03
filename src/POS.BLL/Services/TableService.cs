using System;
using System.Collections.Generic;
using System.Data;
using POS.BLL.DTOs;
using POS.BLL.Helpers;
using POS.DAL.Helpers;
using POS.DAL.Repositories;

namespace POS.BLL.Services
{
    public class TableService
    {
        private readonly AreaRepository _areaRepo = new AreaRepository();
        private readonly TableRepository _tableRepo = new TableRepository();
        private readonly OrderRepository _orderRepo = new OrderRepository();

        #region Quản lý Khu Vực (Areas)

        public List<AreaDto> GetAllAreas(bool includeInactive = false)
        {
            var list = new List<AreaDto>();
            var dt = _areaRepo.GetAllAreas(includeInactive);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new AreaDto
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    SortOrder = row["SortOrder"] != DBNull.Value ? Convert.ToInt32(row["SortOrder"]) : 0,
                    IsActive = Convert.ToInt32(row["IsActive"]) == 1,
                    TableCount = row["TableCount"] != DBNull.Value ? Convert.ToInt32(row["TableCount"]) : 0,
                    OccupiedCount = row["OccupiedCount"] != DBNull.Value ? Convert.ToInt32(row["OccupiedCount"]) : 0
                });
            }
            return list;
        }

        public bool SaveArea(AreaDto dto, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (dto == null)
            {
                errorMessage = "Dữ liệu khu vực không hợp lệ!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                errorMessage = "Tên khu vực không được để trống!";
                return false;
            }

            if (dto.Id > 0)
            {
                return _areaRepo.UpdateArea(dto.Id, dto.Name, dto.SortOrder, dto.IsActive);
            }
            else
            {
                bool res = _areaRepo.InsertArea(dto.Name, dto.SortOrder, dto.IsActive, out int newId);
                if (res) dto.Id = newId;
                return res;
            }
        }

        public bool DeleteArea(int areaId, out string errorMessage)
        {
            return _areaRepo.DeleteArea(areaId, out errorMessage);
        }

        #endregion

        #region Quản lý Bàn (Tables)

        public List<TableDto> GetAllTables(int? areaId = null, bool includeInactive = false)
        {
            var list = new List<TableDto>();
            var dt = _tableRepo.GetAllTables(areaId, includeInactive);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToTableDto(row));
            }
            return list;
        }

        public TableDto GetTableById(int tableId)
        {
            var row = _tableRepo.GetTableById(tableId);
            return row != null ? MapRowToTableDto(row) : null;
        }

        public bool SaveTable(TableDto dto, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (dto == null)
            {
                errorMessage = "Dữ liệu bàn không hợp lệ!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                errorMessage = "Tên bàn không được để trống!";
                return false;
            }

            if (dto.AreaId <= 0)
            {
                errorMessage = "Vui lòng chọn Khu vực cho bàn!";
                return false;
            }

            if (dto.Capacity <= 0)
            {
                dto.Capacity = 4;
            }

            if (dto.Id > 0)
            {
                return _tableRepo.UpdateTable(dto.Id, dto.AreaId, dto.Name, dto.Capacity, dto.SortOrder, dto.IsActive);
            }
            else
            {
                bool res = _tableRepo.InsertTable(dto.AreaId, dto.Name, dto.Capacity, dto.SortOrder, dto.IsActive, out int newId);
                if (res) dto.Id = newId;
                return res;
            }
        }

        public bool DeleteTable(int tableId, out string errorMessage)
        {
            return _tableRepo.DeleteTable(tableId, out errorMessage);
        }

        #endregion

        #region Nghiệp vụ Bán Hàng Tại Bàn (Dine-In Operations)

        /// <summary>
        /// Mở bàn mới và lưu giỏ hàng khởi tạo thành Đơn hàng mở (Open Tab)
        /// </summary>
        public bool OpenTableWithOrder(int tableId, string cashier, List<CartItemDto> items, decimal discount, out long newOrderId, out string errorMessage)
        {
            newOrderId = 0;
            errorMessage = string.Empty;

            if (items == null || items.Count == 0)
            {
                errorMessage = "Vui lòng chọn ít nhất một món trước khi lưu vào bàn!";
                return false;
            }

            try
            {
                string orderNumber = _orderRepo.GenerateOrderNumber();
                decimal rawTotal = 0;
                var dictItems = MapCartItemsToDict(items, out rawTotal);
                decimal finalTotal = Math.Max(0, rawTotal - discount);

                bool success = _orderRepo.SaveOpenTableOrder(tableId, orderNumber, cashier, finalTotal, discount, dictItems, out newOrderId);
                if (!success)
                {
                    errorMessage = "Không thể lưu đơn hàng vào bàn. Vui lòng thử lại!";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi mở bàn: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật giỏ hàng mới nhất vào Đơn hàng đang mở của bàn
        /// </summary>
        public bool UpdateTableOrder(int tableId, long orderId, List<CartItemDto> items, decimal discount, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (items == null || items.Count == 0)
            {
                errorMessage = "Giỏ hàng không được rỗng! Nếu muốn trả bàn trống, vui lòng chọn Hủy/Thanh toán.";
                return false;
            }

            try
            {
                decimal rawTotal = 0;
                var dictItems = MapCartItemsToDict(items, out rawTotal);
                decimal finalTotal = Math.Max(0, rawTotal - discount);

                bool success = _orderRepo.UpdateOpenTableOrder(orderId, finalTotal, discount, dictItems);
                if (!success)
                {
                    errorMessage = "Không thể cập nhật đơn hàng của bàn!";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật đơn bàn: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Lấy toàn bộ món trong đơn mở của một bàn để nạp lại vào giỏ hàng POS
        /// </summary>
        public List<CartItemDto> GetTableCartItems(long orderId)
        {
            var list = new List<CartItemDto>();
            var dt = _orderRepo.GetOpenOrderDetails(orderId);
            if (dt == null || dt.Rows.Count == 0) return list;

            var keyMap = new Dictionary<long, string>();

            // Vòng 1: Tạo key cho tất cả chi tiết
            foreach (DataRow row in dt.Rows)
            {
                long id = Convert.ToInt64(row["Id"]);
                keyMap[id] = Guid.NewGuid().ToString("N");
            }

            // Vòng 2: Tạo CartItemDto
            foreach (DataRow row in dt.Rows)
            {
                long id = Convert.ToInt64(row["Id"]);
                string parentKey = null;

                if (row["ParentDetailId"] != DBNull.Value)
                {
                    long parentId = Convert.ToInt64(row["ParentDetailId"]);
                    if (keyMap.ContainsKey(parentId))
                    {
                        parentKey = keyMap[parentId];
                    }
                }

                list.Add(new CartItemDto
                {
                    ItemKey = keyMap[id],
                    ParentKey = parentKey,
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    ProductName = row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : "Món",
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    Note = row["Note"] != DBNull.Value ? row["Note"].ToString() : string.Empty
                });
            }

            return list;
        }

        /// <summary>
        /// Chuyển bàn từ Bàn A sang Bàn B
        /// </summary>
        public bool MoveTable(int fromTableId, int toTableId, out string errorMessage)
        {
            return _tableRepo.MoveTable(fromTableId, toTableId, out errorMessage);
        }

        /// <summary>
        /// Gộp đơn từ Bàn A vào Bàn B
        /// </summary>
        public bool MergeTables(int fromTableId, int toTableId, out string errorMessage)
        {
            return _tableRepo.MergeTables(fromTableId, toTableId, out errorMessage);
        }

        /// <summary>
        /// In phiếu tạm tính (Pre-receipt / Check-out) và đổi trạng thái bàn sang 'PRINTED'
        /// </summary>
        public bool PrintPreReceipt(int tableId, string printerName, out string errorMessage)
        {
            errorMessage = string.Empty;
            var table = GetTableById(tableId);
            if (table == null || !table.CurrentOrderId.HasValue)
            {
                errorMessage = "Bàn không có đơn hàng để in tạm tính!";
                return false;
            }

            var items = GetTableCartItems(table.CurrentOrderId.Value);
            if (items.Count == 0)
            {
                errorMessage = "Đơn hàng của bàn không có món!";
                return false;
            }

            try
            {
                using (var builder = new TicketBuilder())
                {
                    builder.Initialize()
                           .AlignCenter()
                           .SetBold(true)
                           .PrintLine("PHIẾU TẠM TÍNH")
                           .SetBold(false)
                           .PrintLine("(Vui lòng kiểm tra trước khi thanh toán)")
                           .PrintLine()
                           .AlignLeft()
                           .PrintLine($"Bàn: {table.Name} ({table.AreaName})")
                           .PrintLine($"Số HĐ: {table.OrderNumber}")
                           .PrintLine($"Giờ vào: {table.OccupiedSince:dd/MM/yyyy HH:mm}")
                           .PrintLine($"Thu ngân: {table.CreatedBy}")
                           .PrintSeparator('-');

                    decimal total = 0;
                    foreach (var item in items)
                    {
                        total += item.LineTotal;
                        if (string.IsNullOrEmpty(item.ParentKey))
                        {
                            builder.PrintRow($"{item.ProductName} x{item.Quantity}", item.LineTotal.ToString("N0") + "d");
                        }
                        else
                        {
                            builder.PrintRow($"  + {item.ProductName}", item.LineTotal.ToString("N0") + "d");
                        }
                    }

                    builder.PrintSeparator('=')
                           .SetBold(true)
                           .PrintRow("TỔNG CỘNG:", total.ToString("N0") + " đ")
                           .SetBold(false)
                           .PrintLine()
                           .AlignCenter()
                           .PrintLine("Xin cảm ơn quý khách!")
                           .CutPaper(3);

                    byte[] bytes = builder.Build();
                    RawPrinterHelper.SendBytesToPrinter(printerName, bytes);
                }

                // Đổi trạng thái bàn sang PRINTED
                _tableRepo.UpdateTableStatus(tableId, "PRINTED", table.CurrentOrderId.Value);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi in tạm tính: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Hoàn tất thanh toán bàn: chuyển Order sang PAID và trả Bàn về EMPTY
        /// </summary>
        public bool SettleTable(int tableId, long orderId, string paymentMethod, decimal finalTotal, decimal discountAmount, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                bool success = _orderRepo.SettleTableOrder(tableId, orderId, paymentMethod, finalTotal, discountAmount);
                if (!success)
                {
                    errorMessage = "Không thể thanh toán đơn của bàn!";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi thanh toán bàn: " + ex.Message;
                return false;
            }
        }

        #endregion

        #region Helper Functions

        private TableDto MapRowToTableDto(DataRow row)
        {
            return new TableDto
            {
                Id = Convert.ToInt32(row["Id"]),
                AreaId = Convert.ToInt32(row["AreaId"]),
                AreaName = row["AreaName"].ToString(),
                Name = row["Name"].ToString(),
                Capacity = row["Capacity"] != DBNull.Value ? Convert.ToInt32(row["Capacity"]) : 4,
                Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "EMPTY",
                CurrentOrderId = row["CurrentOrderId"] != DBNull.Value ? (long?)Convert.ToInt64(row["CurrentOrderId"]) : null,
                OrderNumber = row["OrderNumber"] != DBNull.Value ? row["OrderNumber"].ToString() : string.Empty,
                OrderTotal = row["OrderTotal"] != DBNull.Value ? Convert.ToDecimal(row["OrderTotal"]) : 0,
                OccupiedSince = row["OccupiedSince"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["OccupiedSince"]) : null,
                CreatedBy = row["CreatedBy"] != DBNull.Value ? row["CreatedBy"].ToString() : string.Empty,
                ItemCount = row.Table.Columns.Contains("ItemCount") && row["ItemCount"] != DBNull.Value ? Convert.ToInt32(row["ItemCount"]) : 0,
                SortOrder = row["SortOrder"] != DBNull.Value ? Convert.ToInt32(row["SortOrder"]) : 0,
                IsActive = Convert.ToInt32(row["IsActive"]) == 1
            };
        }

        private List<Dictionary<string, object>> MapCartItemsToDict(List<CartItemDto> items, out decimal rawTotal)
        {
            rawTotal = 0;
            var dictList = new List<Dictionary<string, object>>();

            foreach (var item in items)
            {
                rawTotal += item.LineTotal;

                dictList.Add(new Dictionary<string, object>
                {
                    { "ItemKey", item.ItemKey },
                    { "ProductId", item.ProductId },
                    { "Quantity", item.Quantity },
                    { "UnitPrice", item.UnitPrice },
                    { "ParentKey", item.ParentKey },
                    { "Note", item.Note }
                });
            }
            return dictList;
        }

        #endregion
    }
}
