using BlogSite.BLL.Models.DTOs;
using BlogSite.BLL.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.TopicService
{
    public interface ITopicService
    {
        Task Create(CreateTopicDTO model);
        void Update(UpdateTopicDTO model);
        Task Delete(int id);
        Task<UpdateTopicDTO> GetById(int id);
        Task<List<GetTopicVM>> GetTopics();
    }
}
