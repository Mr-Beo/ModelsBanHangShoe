﻿using API.Models.DTO;

namespace BlazorKhachHang.Service.IService
{
    public interface IGioHangService
    { 
        Task AddToCartAsync(Guid khachHangId, Guid giayId, Guid chiTietGiayId, int soLuong);
        Task<GioHangDTO> LayTheoTaiKhoanAsync(Guid taiKhoanId);
       
        Task CapNhatSoLuong(Guid chiTietId, int soLuong);
        Task XoaSanPham(Guid chiTietId);
    }
}
