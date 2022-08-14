using AutoMapper;
using BlogSite.BLL.Models.DTOs;
using BlogSite.BLL.Models.VMs;
using BlogSite.Core.Entities;
using BlogSite.Core.Enums;
using BlogSite.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BLL.Services.TopicService
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository topicRepository;
        private readonly IMapper mapper;

        public TopicService(ITopicRepository topicRepository, IMapper mapper)
        {
            this.topicRepository = topicRepository;
            this.mapper = mapper;
        }

        public async Task Create(CreateTopicDTO model)
        {
            var topic = mapper.Map<Topic>(model);
            await topicRepository.Create(topic);
        }

        public async Task Delete(int id)
        {
            var topic = await topicRepository.GetWhere(x => x.Id == id);
            topicRepository.Delete(topic);
        }

        public async Task<UpdateTopicDTO> GetById(int id)
        {
            var topic = await topicRepository.GetFilteredFirstOrDefault(
               selector: x => new UpdateTopicDTO
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description
               },
               expression: x => x.Id == id && x.Status! != Status.Passive);
            return topic;
        }

        public async Task<List<GetTopicVM>> GetTopics()
        {
            var topics = await topicRepository.GetFilteredList(
            selector: x => new GetTopicVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            },
            expression: x => x.Status! != Status.Passive,
            orderBy: x => x.OrderBy(x => x.Name));

            return topics;
        }

        public void Update(UpdateTopicDTO model)
        {
            var topic = mapper.Map<Topic>(model);
            topicRepository.Update(topic);
        }
    }
}
