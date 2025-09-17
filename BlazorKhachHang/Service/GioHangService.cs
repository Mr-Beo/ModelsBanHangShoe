using API.Models.DTO;
using BlazorKhachHang.Service.IService;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorKhachHang.Service
{
    public class GioHangService : IGioHangService
    {
        private readonly HttpClient _http;

        public GioHangService(HttpClient http)
        {
            _http = http;
        }
        public async Task AddToCartAsync(Guid khachHangId, Guid giayId, Guid chiTietGiayId, int soLuong)
        {
            var data = new
            {
                KhachHangId = khachHangId,
                GiayId = giayId,
                ChiTietGiayId = chiTietGiayId,
                SoLuong = soLuong
            };

            var response = await _http.PostAsJsonAsync("api/cart/add", data);
            response.EnsureSuccessStatusCode();
        }
        public async Task<GioHangDTO> LayTheoTaiKhoanAsync(Guid taiKhoanId)
            => await _http.GetFromJsonAsync<GioHangDTO>($"/api/giohang/tai-khoan/{taiKhoanId}");

        public async Task CapNhatSoLuong(Guid chiTietId, int soLuong)
            => await _http.PutAsJsonAsync($"/api/giohang/cap-nhat-so-luong/{chiTietId}", soLuong);

        public async Task XoaSanPham(Guid chiTietId)
            => await _http.DeleteAsync($"/api/giohang/xoa/{chiTietId}");
    }
}
