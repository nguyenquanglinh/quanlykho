using DataSource.DAO;
using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_QuanLyKho.Controllers
{
    public class NhanVienController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<NhanVien> item = NhanVienDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] NhanVien x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaNV, string TenNhanVien, string NgaySinh, string GioiTinh, string DiaChi, string SDT, string Email)
            NhanVienDAO.Instance.Create(x.MaNV, x.TenNhanVien, x.NgaySinh, x.GioiTinh,x.DiaChi,x.SDT, x.Email);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  NhanVien x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            NhanVienDAO.Instance.Update(x.MaNV, x.TenNhanVien, x.NgaySinh, x.GioiTinh, x.DiaChi, x.SDT, x.Email);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaNV)
        {
            NhanVienDAO.Instance.Delete(MaNV);
            return Ok();
        }


    }
}
