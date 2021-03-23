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
    public class DangNhapController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<DangNhap> item = DangNhapDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] DangNhap x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            DangNhapDAO.Instance.Create(x.ID, x.Password, x.MaNV, x.PhanQuyen);//(string ID, string Password, string MaNV, string PhanQuyen)
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  DangNhap x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            DangNhapDAO.Instance.Update(x.ID, x.Password, x.MaNV, x.PhanQuyen);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string ID)
        {
            DangNhapDAO.Instance.Delete(ID);
            return Ok();
        }

    }
}
