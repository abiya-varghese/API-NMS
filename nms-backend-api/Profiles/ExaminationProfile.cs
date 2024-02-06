using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using nms_backend_api.DTO;
using nms_backend_api.Entity;

namespace nms_backend_api.Profiles
{
    public class ExaminationProfile:Profile
    {
        public ExaminationProfile() 
        {
            CreateMap<ExaminationDTO, Examination>();
            CreateMap<Examination, ExaminationDTO>();
        }
    }
}
