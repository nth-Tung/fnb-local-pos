using System;
using System.Collections.Generic;
using System.Linq;
using POS.BLL.DTOs;
using POS.DAL.Repositories;

namespace POS.BLL.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepo = new OrderRepository();

        // Hàm lấy số hóa đơn tự động tiếp theo hiển thị trên màn hình UI
        public string GetNextOrderNumber()
        {
            try
            {
                return _orderRepo.GenerateOrderNumber();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sinh mã hóa đơn: " + ex.Message);
            }
        }

        // Hàm tính toán tiền hàng, chiết khấu và tổng thanh toán (Business Logic độc lập với UI)
        public OrderSummaryDto CalculateOrderSummary(List<CartItemDto> cartItems, decimal discountValue, bool isPercentDiscount)
        {
            decimal rawTotal = 0;
            if (cartItems != null)
            {
                foreach (var item in cartItems)
                {
                    if (item.Quantity > 0 && item.UnitPrice >= 0)
                    {
                        rawTotal += item.LineTotal;
                    }
                }
            }

            decimal discountAmount = 0;
            if (discountValue > 0)
            {
                if (isPercentDiscount)
                {
                    decimal pct = Math.Min(100m, Math.Max(0m, discountValue));
                    discountAmount = rawTotal * (pct / 100m);
                }
                else
                {
                    discountAmount = discountValue;
                }
            }

            // Đảm bảo số tiền giảm giá không vượt quá tổng tiền hàng
            if (discountAmount > rawTotal)
            {
                discountAmount = rawTotal;
            }

            decimal finalTotal = Math.Max(0, rawTotal - discountAmount);

            return new OrderSummaryDto
            {
                RawTotal = rawTotal,
                DiscountAmount = discountAmount,
                FinalTotal = finalTotal
            };
        }

        // Hàm xử lý nghiệp vụ thanh toán chuẩn 3 lớp với CartItemDto
        public bool ProcessPayment(
            string employeeName,
            string paymentMethod,
            decimal discountValue,
            bool isPercentDiscount,
            List<CartItemDto> cartItems,
            out decimal finalTotal,
            out string generatedOrderNumber)
        {
            generatedOrderNumber = string.Empty;
            finalTotal = 0;

            // 1. Kiểm tra tính hợp lệ của giỏ hàng (Business Validation)
            if (cartItems == null || cartItems.Count == 0)
            {
                throw new ArgumentException("Giỏ hàng đang trống. Không thể tiến hành thanh toán!");
            }

            if (string.IsNullOrEmpty(employeeName))
            {
                throw new ArgumentException("Hệ thống yêu cầu thông tin nhân viên trực ca để thanh toán!");
            }

            foreach (var item in cartItems)
            {
                if (item.Quantity <= 0 || item.UnitPrice < 0)
                {
                    throw new ArgumentException($"Sản phẩm '{item.ProductName}' có số lượng hoặc giá không hợp lệ!");
                }
            }

            // 2. Tính toán tổng số tiền qua hàm Business Logic
            var summary = CalculateOrderSummary(cartItems, discountValue, isPercentDiscount);
            finalTotal = summary.FinalTotal;

            // 3. Sinh mã hóa đơn mới nhất tại thời điểm bấm nút
            generatedOrderNumber = _orderRepo.GenerateOrderNumber();

            // 4. Đóng gói thông tin hóa đơn chung (Master Order)
            var orderInfo = new Dictionary<string, object>
            {
                { "OrderNumber", generatedOrderNumber },
                { "TotalAmount", summary.FinalTotal },
                { "DiscountAmount", summary.DiscountAmount },
                { "PaymentMethod", paymentMethod.ToUpper() },
                { "CreatedBy", employeeName }
            };

            // 5. Chuyển đổi CartItemDto sang cấu trúc dữ liệu lưu trữ DAL
            var dalItems = cartItems.Select(x => new Dictionary<string, object>
            {
                { "ProductId", x.ProductId },
                { "Quantity", x.Quantity },
                { "UnitPrice", x.UnitPrice },
                { "ItemKey", x.ItemKey ?? Guid.NewGuid().ToString("N") },
                { "ParentKey", x.ParentKey },
                { "Note", x.Note }
            }).ToList();

            // 6. Đẩy dữ liệu xuống tầng DAL để thực hiện Transaction lưu vào SQLite
            try
            {
                return _orderRepo.SaveOrder(orderInfo, dalItems);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi hệ thống khi ghi nhận hóa đơn vào cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
